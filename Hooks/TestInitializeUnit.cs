using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SpecFlowProjectAppium.Utilities;

namespace SpecFlowProjectAppium.Hooks
{
    [TestFixture]
    public class TestInitializeUnit : BaseClass
    {
        [SetUp]
        public void TestInitialiseTest()
        {
            AndroidContext = StartAppiumServerForHybrid();
        }
        public void CleanUp()
        {
            AppiumUtilities.CloseAppiumServer();
        }
    }
}
