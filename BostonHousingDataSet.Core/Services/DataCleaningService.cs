using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using BostonHousingDataSet.Core.Models;

namespace BostonHousingDataSet.Core.Services
{
    public class DataCleaningService
    {
        /// <summary>
        /// 生データのファイルパス
        /// </summary>
        public string RawFilePath => Path.GetFullPath(Path.Combine(RootDirectoryPath, "Data", "boston.txt"));

        /// <summary>
        /// ルートディレクトリのパス
        /// </summary>
        public string RootDirectoryPath { get; } = @"..\..\..\..\BostonHousingDataSet.Core";

        /// <summary>
        /// クリーニングした後のデータパス
        /// </summary>
        public string CleanedFilePath => Path.GetFullPath(Path.Combine(RootDirectoryPath, "Data", "cleanedBoston.csv"));

        /// <summary>
        /// データのクリーニングを実施します。
        /// </summary>
        public void Clean()
        {
            using (var writer = new StreamWriter(CleanedFilePath))
            {
                writer.Write(string.Join(",", BostonHousingData.EnumerableColumnNames().ToArray()));
                foreach (var data in EnumerableRawLine(RawFilePath))
                {
                    writer.WriteLine();
                    writer.Write(ConvertToCommaLine(data));
                }

                writer.Flush();
            }
        }

        private static string ConvertToCommaLine(string data)
        {
            return data.Trim().Replace("  ", ",");
        }

        /// <summary>
        /// 名前データを1行のデータとして列挙します。
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static IEnumerable<string> EnumerableRawLine(string fileName)
        {
            const int startIndex = 23 - 1;
            string cacheText = string.Empty;
            foreach (var item in EnumerableLine(fileName).Select((value, index) => new {value, index}))
            {
                if (item.index < startIndex)
                {
                    continue;
                }

                if ((item.index - startIndex) % 2 == 1)
                {
                    string line = cacheText + item.value;
                    yield return line;
                }
                else
                {
                    cacheText = item.value;
                }
            }
        }

        /// <summary>
        /// 1行ずつデータを読み込みます。
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private static IEnumerable<string> EnumerableLine(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                while (reader.Peek() >= 0)
                {
                    yield return reader.ReadLine();
                }
            }
        }
    }
}
