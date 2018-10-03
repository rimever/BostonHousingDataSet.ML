using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BostonHousingDataSet.Core;
using BostonHousingDataSet.Core.Services;
using NUnit.Framework;

namespace BostonHousingDataSet.Tests.Services
{
    /// <summary>
    /// <see cref="MachineLearningService"/>をテストするクラスです。
    /// </summary>
    [TestFixture]
    public class MachineLearningServiceTest
    {
        /// <summary>
        /// <see cref="MachineLearningService.Analyze"/>をテストします。
        /// </summary>
        [Test]
        public async Task Analyze()
        {
            MachineLearningService service = new MachineLearningService();
            await service.Analyze();
        }
    }
}
