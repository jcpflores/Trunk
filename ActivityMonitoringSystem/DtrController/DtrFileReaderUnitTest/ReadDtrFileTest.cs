using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DtrController.Tools.DtrFileReader;
using DtrController;

namespace UnitTestProject1
{
    [TestClass]
    public class ReadDtrFileTest
    {
        
        [TestMethod]
        public void TestMethod1()
        {
            Controller cntrl = new Controller();
            cntrl._ReadDtrFile(@"C:\Users\KATION\Desktop\Dtr");
           // Assert.IsNotNull(dfr.Dtrlist);
        }
    }
}
