using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestPatternMatching
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(FunctionInTest(1) == 101);
            Assert.IsTrue(FunctionInTest("test") == 8);
            Assert.IsTrue(FunctionInTest(DateTime.UtcNow) == 2015);
            Assert.IsTrue(FunctionInTest(true) == 0);
        }

        private int FunctionInTest(MyUnion union)
        {
            return union
                .Match(
                    integer => integer + 100,
                    str => (str + "sadf").Length,
                    datTime => datTime.Year,
                    boolean => !boolean ? 1 : 0);
        }
    }
}
