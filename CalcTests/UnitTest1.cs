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
            Assert.AreEqual(MathCalc.Add(10, 15), 25);
            Assert.AreEqual(MathCalc.Add(-10, 15), 5);
            Assert.AreEqual(MathCalc.Add(0, 0), 0);
            Assert.AreEqual(MathCalc.Add(3.6, 15), 18.6);
            Assert.AreEqual(MathCalc.Add(4, -100), -96);
            Assert.AreEqual(MathCalc.Add(1000000000000000000, 15),1000000000000000015);
        }
        [Test]
        public void Sub()
        {
            Assert.AreEqual(MathCalc.Sub(10, 15), -5);
            Assert.AreEqual(MathCalc.Sub(-10, 15), -25);
            Assert.AreEqual(MathCalc.Sub(0, 0), 0);
            Assert.AreEqual(MathCalc.Sub(4, -100), 104);
            Assert.AreEqual(MathCalc.Sub(-1000000000000000000, -100), -999999999999999900);
        }
        [Test]
        public void Mul()
        {
            Assert.AreEqual(MathCalc.Mul(-10, 15), -150);
            Assert.AreEqual(MathCalc.Mul(10, 15), 150);
            Assert.AreEqual(MathCalc.Mul(0, 10), 0);
            Assert.AreEqual(MathCalc.Mul(4000, -100), -400000);
            Assert.AreEqual(MathCalc.Mul(1000000000000000000, 15),15000000000000000000);
        }
        [Test]
        public void Div()
        {
            Assert.AreEqual(MathCalc.Div(-10, 10), -1);
            Assert.AreEqual(MathCalc.Div(0, 10), 0);
            Assert.AreEqual(MathCalc.Div(4000, -100), -40);
            Assert.AreEqual(MathCalc.Div(100, 10),10);
            
        }
        [Test]
        public void Pow()
        {
            Assert.AreEqual(MathCalc.Pow(-10, 3), -1000);
            Assert.AreEqual(MathCalc.Pow(0, 10), 0);
            Assert.AreEqual(MathCalc.Pow(-10, 2), 100);
            Assert.AreEqual(MathCalc.Pow(-10, 3), -1000);
            Assert.AreEqual(MathCalc.Pow(2, 9),512);
        
        }
        [Test]
        public void Sqrt()
        {
            Assert.AreEqual(MathCalc.Sqrt(-27, 3), -3);
            Assert.AreEqual(MathCalc.Sqrt(0, 2), 0);
            Assert.AreEqual(MathCalc.Sqrt(12, 1), 12);
            Assert.AreEqual(MathCalc.Sqrt(-10, 3), -1000);
            Assert.AreEqual(MathCalc.Sqrt(2, 9),512);
            Assert.AreEqual(MathCalc.Sqrt(16, 4),2);
        
        }
        [Test]
        public void Abs()
        {
            Assert.AreEqual(MathCalc.Abs(2), 2);
            Assert.AreEqual(MathCalc.Abs(0), 0);
            Assert.AreEqual(MathCalc.Abs(-3), 3);
            Assert.AreEqual(MathCalc.Abs(-7), 7);
            Assert.AreEqual(MathCalc.Abs(5),5);
            Assert.AreEqual(MathCalc.Abs(-3628800),3628800);
        }
    }
}