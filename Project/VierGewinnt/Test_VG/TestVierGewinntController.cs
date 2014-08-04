using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VierGewinnt;

namespace Test_VG
{
    [TestClass]
    public class TestVierGewinntController
    {
        [TestMethod]
        public void TestSetSpielstein1()
        {
            VierGewinntController vgc = new VierGewinntController();
            vgc.SetSpielstein(0, 0);
           
        }
    }
}
