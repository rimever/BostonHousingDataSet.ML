using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using BostonHousingDataSet.Core;
using BostonHousingDataSet.Core.Services;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace BostonHousingDataSet.Tests.Services
{
    /// <summary>
    /// <see cref="DataCleaningService"/>をテストします。
    /// </summary>
    [TestFixture]
    public class DataCleaningServiceTest
    {
        /// <summary>
        /// <see cref="DataCleaningService.RawFilePath"/>を検証します。
        /// </summary>
        [Test]
        public void RawFilePath()
        {
            var service = new DataCleaningService();
            Assert.IsTrue(File.Exists(service.RawFilePath), service.RawFilePath);
        }


        /// <summary>
        /// <see cref="DataCleaningService.CleanedFilePath"/>を検証します。
        /// </summary>
        [Test]
        public void CleanedFilePath()
        {
            var service = new DataCleaningService();
            service.Clean();
            Assert.IsTrue(File.Exists(service.CleanedFilePath), service.CleanedFilePath);
        }

        /// <summary>
        /// <see cref="DataCleaningService.Clean"/>をテストします。
        /// </summary>
        [Test]
        public void Clean()
        {
            var service = new DataCleaningService();
            service.Clean();
        }
    }
}
