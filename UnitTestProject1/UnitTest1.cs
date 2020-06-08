using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PSamples.ViewModels;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var vm = new ViewAViewModel();
            vm.OKButton.Execute();
        }
    }
}
