using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpecFlowProjectAppium.Utilities;

namespace SpecFlowProjectAppium.Hooks
{
    [Binding]
    public class TestInitialize: BaseClass
    {
        [BeforeScenario]
        public void TestInitializeTest()
        {
            AndroidContext = StartAppiumServerForHybrid();
            ScenarioContext.Current["androidContext"] = AndroidContext;
        }

        [AfterScenario]
        public void CleanUp()
        { 
            AppiumUtilities.CloseAppiumServer();
        }
    }
}
