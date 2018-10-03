using System.Collections.Generic;
using Microsoft.ML.Runtime.Api;

namespace BostonHousingDataSet.Core.Models
{
    /// <summary>
    /// Boston Housing DataSet
    /// </summary>
    public class BostonHousingData
    {
        /// <summary>
        /// 人口一人当たりの犯罪発生率
        /// </summary>
        [Column("0")]
        public float CRIM;

        /// <summary>
        /// 25,00平方フィート以上の住居区画の占める割合（％）
        /// </summary>
        [Column("1")]
        public float ZIN;

        /// <summary>
        /// 小売業以外の商業が占める面積の割合（％）
        /// </summary>
        [Column("2")]
        public float INDUS;

        /// <summary>
        /// チャールズ川（ボストンに存在する川）によるダミー変数
        /// 1:川の周辺　0:それ以外
        /// </summary>
        [Column("3")]
        public float CHAS;

        /// <summary>
        /// NOxの濃度（％）
        /// </summary>
        [Column("4")]
        public float NOX;

        /// <summary>
        /// 住居の平均部屋数
        /// </summary>
        [Column("5")]
        public float RM;

        /// <summary>
        /// 1940年より前に建てられた物件の割合
        /// </summary>
        [Column("6")]
        public float AGE;
        /// <summary>
        /// ５つのボストン市の雇用施設からの距離（重みづけ済み/単位不明）
        /// </summary>
        [Column("7")]
        public float DIS;

        /// <summary>
        /// 環状高速道路へのアクセスしやすさ（1-24の間隔尺度）
        /// </summary>
        [Column("8")]
        public float RAD;

        /// <summary>
        /// $10,000あたりの不動産税率の総計($)
        /// </summary>
        [Column("9")]
        public float TAX;

        /// <summary>
        /// 教師1人が持つ生徒の数（人）
        /// </summary>
        [Column("10")]
        public float PTRATIO;

        /// <summary>
        /// 1000*(黒人比率[%]-0.63)^2の式で計算される指標
        /// </summary>
        [Column("11")]
        public float B;
        /// <summary>
        /// 給与の低い職業に従事する人口の割合(%)
        /// </summary>
        [Column("12")]
        public float LSTAT;

        /// <summary>
        /// 住宅価格の中央値(1,000ドル）
        /// </summary>
        [Column("13")]
        public float MEDV;

        /// <summary>
        /// カラム名を列挙します。
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<string> EnumerableColumnNames()
        {
            yield return $"{nameof(CRIM)}";
            yield return $"{nameof(ZIN)}";
            yield return $"{nameof(INDUS)}";
            yield return $"{nameof(CHAS)}";
            yield return $"{nameof(NOX)}";
            yield return $"{nameof(RM)}";
            yield return $"{nameof(AGE)}";
            yield return $"{nameof(DIS)}";
            yield return $"{nameof(RAD)}";
            yield return $"{nameof(TAX)}";
            yield return $"{nameof(PTRATIO)}";
            yield return $"{nameof(B)}";
            yield return $"{nameof(LSTAT)}";
            yield return $"{nameof(MEDV)}";
        }
    }
}
