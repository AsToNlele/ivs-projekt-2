using NUnit.Framework;

namespace CalcTests
{
    /// <summary>
    /// Testovaci skript pro matematickou knihovnu
    /// </summary>
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Add()
        {
            Assert.AreEqual(25, MathCalc.Add(10, 15));
            Assert.AreEqual(5, MathCalc.Add(-10, 15));
            Assert.AreEqual(0, MathCalc.Add(0, 0));
            Assert.AreEqual(18.6, MathCalc.Add(3.6, 15));
            Assert.AreEqual(-96, MathCalc.Add(4, -100));
            Assert.AreEqual(1000000000000000015, MathCalc.Add(1000000000000000000, 15));
        }
        [Test]
        public void Sub()
        {
            Assert.AreEqual(-5, MathCalc.Sub(10, 15));
            Assert.AreEqual(-25, MathCalc.Sub(-10, 15));
            Assert.AreEqual(0, MathCalc.Sub(0, 0));
            Assert.AreEqual(104, MathCalc.Sub(4, -100));
            Assert.AreEqual(-999999999999999900, MathCalc.Sub(-1000000000000000000, -100));
        }
        [Test]
        public void Mul()
        {
            Assert.AreEqual(-150, MathCalc.Mul(-10, 15));
            Assert.AreEqual(150, MathCalc.Mul(10, 15));
            Assert.AreEqual(0, MathCalc.Mul(0, 10));
            Assert.AreEqual(-400000, MathCalc.Mul(4000, -100));
            Assert.AreEqual(15000000000000000000, MathCalc.Mul(1000000000000000000, 15));
        }
        [Test]
        public void Div()
        {
            Assert.AreEqual(-1, MathCalc.Div(-10, 10));
            Assert.AreEqual(0, MathCalc.Div(0, 10));
            Assert.AreEqual(-40, MathCalc.Div(4000, -100));
            Assert.AreEqual(10, MathCalc.Div(100, 10));
            
        }
        [Test]
        public void Pow()
        {
            Assert.AreEqual(-1000, MathCalc.Pow(-10, 3));
            Assert.AreEqual(0, MathCalc.Pow(0, 10));
            Assert.AreEqual(100, MathCalc.Pow(-10, 2));
            Assert.AreEqual(-1000, MathCalc.Pow(-10, 3));
            Assert.AreEqual(512, MathCalc.Pow(2, 9));
        
        }
        [Test]
        public void Root()
        {
            Assert.AreEqual(0, MathCalc.Root(0, 2));
            Assert.AreEqual(-3, MathCalc.Root(-27, 3));
            Assert.AreEqual(12, MathCalc.Root(12, 1));
            Assert.AreEqual(2, MathCalc.Root(16, 4));
        
        }
        [Test]
        public void Abs()
        {
            Assert.AreEqual(2, MathCalc.Abs(2));
            Assert.AreEqual(0, MathCalc.Abs(0));
            Assert.AreEqual(3, MathCalc.Abs(-3));
            Assert.AreEqual(7, MathCalc.Abs(-7));
            Assert.AreEqual(5, MathCalc.Abs(5));
            Assert.AreEqual(3628800, MathCalc.Abs(-3628800));
        }
    }
}