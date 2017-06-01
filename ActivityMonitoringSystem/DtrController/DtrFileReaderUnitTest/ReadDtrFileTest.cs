using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DtrController.Tools.DtrFileReader;


namespace UnitTestProject1
{
    [TestClass]
    public class ReadDtrFileTest
    {
        
        [TestMethod]
        public void TestMethod1()
        {
            DtrFileReader dfr = new DtrFileReader();
            dfr.ReadDtrFileFromFolder(@"C:\Users\KATION\Desktop\Dtr");
           // Assert.IsNotNull(dfr.Dtrlist);

        }
    }
}
