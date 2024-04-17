using NUnit.Framework;
using Plugins.Banks.Core;
using Plugins.Banks.Float;

namespace Plugins.Banks.Tests.EditMode
{
    public class FloatBankTests
    {
        [Test]
        public void InitialValues()
        {
            IBank<float> floatBank = new FloatBank();

            Assert.AreEqual(0, floatBank.Amount.Value);
            Assert.IsTrue(floatBank.IsEmpty.Value);
        }

        [Test]
        public void NegativeInitialValue()
        {
            IBank<float> floatBank = new FloatBank(-10);

            Assert.AreEqual(0, floatBank.Amount.Value);
            Assert.IsTrue(floatBank.IsEmpty.Value);
        }

        [Test]
        public void Add()
        {
            IBank<float> floatBank = new FloatBank();

            floatBank.Add(10);

            Assert.AreEqual(10, floatBank.Amount.Value);
            Assert.IsFalse(floatBank.IsEmpty.Value);
        }

        [Test]
        public void Spend()
        {
            IBank<float> floatBank = new FloatBank(10);

            floatBank.Spend(5);

            Assert.AreEqual(5, floatBank.Amount.Value);
            Assert.IsFalse(floatBank.IsEmpty.Value);
        }

        [Test]
        public void SpendMoreThanAvailable()
        {
            IBank<float> floatBank = new FloatBank(10);

            floatBank.Spend(15);

            Assert.AreEqual(10, floatBank.Amount.Value);
            Assert.IsFalse(floatBank.IsEmpty.Value);
        }

        [Test]
        public void SetValue()
        {
            IBank<float> floatBank = new FloatBank(10);

            floatBank.SetValue(5);

            Assert.AreEqual(5, floatBank.Amount.Value);
            Assert.IsFalse(floatBank.IsEmpty.Value);
        }

        [Test]
        public void Clear()
        {
            IBank<float> floatBank = new FloatBank(10);

            floatBank.Clear();

            Assert.AreEqual(0, floatBank.Amount.Value);
            Assert.IsTrue(floatBank.IsEmpty.Value);
        }

        [Test]
        public void HasEnough()
        {
            IBank<float> floatBank = new FloatBank(10);

            Assert.IsTrue(floatBank.HasEnough(5));
            Assert.IsFalse(floatBank.HasEnough(15));
        }

        [Test]
        public void HasEnoughWithNegativeValue()
        {
            IBank<float> floatBank = new FloatBank(-10);

            Assert.IsFalse(floatBank.HasEnough(5));
        }

        [Test]
        public void HasEnoughWithNegativeAmount()
        {
            IBank<float> floatBank = new FloatBank(10);

            floatBank.Spend(15);

            Assert.IsTrue(floatBank.HasEnough(5));
        }

        [Test]
        public void HasEnoughWithNegativeAmountAndValue()
        {
            IBank<float> floatBank = new FloatBank(-10);

            Assert.IsFalse(floatBank.HasEnough(5));
        }

        [Test]
        public void HasEnoughWithNegativeAmountAndNegativeValue()
        {
            IBank<float> floatBank = new FloatBank(-10);

            Assert.IsTrue(floatBank.HasEnough(-5));
        }

        [Test]
        public void AddNegative()
        {
            IBank<float> floatBank = new FloatBank();

            floatBank.Add(-10);

            Assert.AreEqual(0, floatBank.Amount.Value);
            Assert.IsTrue(floatBank.IsEmpty.Value);
        }

        [Test]
        public void SpendNegative()
        {
            IBank<float> floatBank = new FloatBank(10);

            floatBank.Spend(-5);

            Assert.AreEqual(10, floatBank.Amount.Value);
            Assert.IsFalse(floatBank.IsEmpty.Value);
        }

        [Test]
        public void SetValueNegative()
        {
            IBank<float> floatBank = new FloatBank(10);

            floatBank.SetValue(-5);

            Assert.AreEqual(0, floatBank.Amount.Value);
            Assert.IsTrue(floatBank.IsEmpty.Value);
        }
    }
}