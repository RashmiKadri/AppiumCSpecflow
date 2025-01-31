using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SpecFlowProjectAppium.Hooks;
using SpecFlowProjectAppium.Pages;

namespace SpecFlowProjectAppium.TestSuite
{
    [TestFixture]
    public class Testcase1: TestInitializeUnit
    {
        static ClickPage cp = new ClickPage(AndroidContext);
        [Test]
        public void TestClick()
        {
            cp.ClickViews();
        }
    }
}
