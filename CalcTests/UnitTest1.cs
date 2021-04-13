using NUnit.Framework;

namespace CalcTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Add()
        {
            StringAssert.Equals(MathCalc.Add("10", "15"), 25);
            StringAssert.Equals(MathCalc.Add("-10", "15"), 5);
            StringAssert.Equals(MathCalc.Add("0", "0"), 0);
            StringAssert.Equals(MathCalc.Add("3.6", "15"), 18.6);
            StringAssert.Equals(MathCalc.Add("4", "-100"), -96);
            StringAssert.Equals(MathCalc.Add("1000000000000000000", "15"),1000000000000000015);
        }
        [Test]
        public void Sub()
        {
            StringAssert.Equals(MathCalc.Sub("10", "15"), -5);
            StringAssert.Equals(MathCalc.Sub("-10", "15"), -25);
            StringAssert.Equals(MathCalc.Sub("0", "0"), 0);
            StringAssert.Equals(MathCalc.Sub("4", "-100"), 104);
            StringAssert.Equals(MathCalc.Sub("-1000000000000000000", "-100"), -1000000000000000100);
        }
        [Test]
        public void Mul()
        {
            StringAssert.Equals(MathCalc.Mul("-10", "15"), -150);
            StringAssert.Equals(MathCalc.Mul("10", "15"), 150);
            StringAssert.Equals(MathCalc.Mul("0", "10"), 0);
            StringAssert.Equals(MathCalc.Mul("4000", "-100"), -400000);
            StringAssert.Equals(MathCalc.Mul("1000000000000000000", "15"),15000000000000000000);
        }
        [Test]
        public void Div()
        {
            StringAssert.Equals(MathCalc.Div("-10", "10"), -1);
            Assert.Fail("Eror",MathCalc.Div("10","0"));
            StringAssert.Equals(MathCalc.Div("0", "10"), 0);
            StringAssert.Equals(MathCalc.Div("4000", "-100"), -40);
            StringAssert.Equals(MathCalc.Div("100", "10"),10);
            
        }
        [Test]
        public void Pow()
        {
            StringAssert.Equals(MathCalc.Pow("-10", "3"), -1000);
            Assert.Fail("Eror",MathCalc.Pow("10","-5"));
            Assert.Fail("Eror",MathCalc.Pow("10","1.5"));
            StringAssert.Equals(MathCalc.Pow("0", "10"), 0);
            StringAssert.Equals(MathCalc.Pow("-10", "2"), 100);
            StringAssert.Equals(MathCalc.Pow("-10", "3"), -1000);
            StringAssert.Equals(MathCalc.Pow("2", "9"),512);
        
        }
        [Test]
        public void Sqrt()
        {
            StringAssert.Equals(MathCalc.Sqrt("-27", "3"), -3);
            Assert.Fail("Eror",MathCalc.Sqrt("10","0"));
            Assert.Fail("Eror",MathCalc.Sqrt("-1","2"));
            Assert.Fail("Eror",MathCalc.Sqrt("0","0"));
            StringAssert.Equals(MathCalc.Sqrt("0", "2"), 0);
            StringAssert.Equals(MathCalc.Sqrt("12", "1"), 12);
            StringAssert.Equals(MathCalc.Sqrt("-10", "3"), -1000);
            StringAssert.Equals(MathCalc.Sqrt("2", "9"),512);
            StringAssert.Equals(MathCalc.Sqrt("16", "4"),2);
        
        }
        [Test]
        public void Abs()
        {
            StringAssert.Equals(MathCalc.Abs("2"), 2);
            StringAssert.Equals(MathCalc.Abs("0"), 0);
            StringAssert.Equals(MathCalc.Abs("-3"), 3);
            StringAssert.Equals(MathCalc.Abs("-7"), 7);
            StringAssert.Equals(MathCalc.Abs("5"),5);
            StringAssert.Equals(MathCalc.Abs("-3628800"),3628800);
        
        }
    }
}