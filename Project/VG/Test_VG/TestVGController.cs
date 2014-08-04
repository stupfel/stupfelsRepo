using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VierGewinnt;

namespace Test_VG
{
    [TestClass]
    public class TestVGController
    {
        [TestMethod]
        public void TestSetSpielstein1()
        {
            VGController vgc = new VGController();
            vgc.SetSpielstein(0, 0);
           
        }
    }
}
