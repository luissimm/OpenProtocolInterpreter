﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenProtocolInterpreter.Tightening;

namespace MIDTesters.Tightening
{
    [TestClass]
    [TestCategory("Tightening")]
    public class TestMid0064 : MidTester
    {
        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ASCII")]
        public void Mid0064Revision1()
        {
            string package = "00300064001         0123456789";
            var mid = _midInterpreter.Parse<Mid0064>(package);

            Assert.AreEqual(typeof(Mid0064), mid.GetType());
            Assert.IsNotNull(mid.TighteningId);
            AssertEqualPackages(package, mid);
        }

        [TestMethod]
        [TestCategory("Revision 1"), TestCategory("ByteArray")]
        public void Mid0064ByteRevision1()
        {
            string package = "00300064001         0123456789";
            byte[] bytes = GetAsciiBytes(package);
            var mid = _midInterpreter.Parse<Mid0064>(bytes);

            Assert.AreEqual(typeof(Mid0064), mid.GetType());
            Assert.IsNotNull(mid.TighteningId);
            AssertEqualPackages(bytes, mid);
        }
    }
}
