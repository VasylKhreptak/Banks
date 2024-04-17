using NUnit.Framework;
using Plugins.Banks.Core;
using Plugins.Banks.Integer;

namespace Plugins.Banks.Tests.EditMode
{
    public class IntegerBankTests
    {
        [Test]
        public void InitialValues()
        {
            IBank<int> integerBank = new IntegerBank();

            Assert.AreEqual(0, integerBank.Amount.Value);
            Assert.IsTrue(integerBank.IsEmpty.Value);
        }

        [Test]
        public void NegativeInitialValue()
        {
            IBank<int> integerBank = new IntegerBank(-10);

            Assert.AreEqual(0, integerBank.Amount.Value);
            Assert.IsTrue(integerBank.IsEmpty.Value);
        }

        [Test]
        public void AddPositiveValue()
        {
            IBank<int> integerBank = new IntegerBank();

            integerBank.Add(10);

            Assert.AreEqual(10, integerBank.Amount.Value);
            Assert.IsFalse(integerBank.IsEmpty.Value);
        }

        [Test]
        public void AddNegativeValue()
        {
            IBank<int> integerBank = new IntegerBank();

            integerBank.Add(-10);

            Assert.AreEqual(0, integerBank.Amount.Value);
            Assert.IsTrue(integerBank.IsEmpty.Value);
        }

        [Test]
        public void SpendPositiveValue()
        {
            IBank<int> integerBank = new IntegerBank(10);

            integerBank.Spend(5);

            Assert.AreEqual(5, integerBank.Amount.Value);
            Assert.IsFalse(integerBank.IsEmpty.Value);
        }

        [Test]
        public void SpendNegativeValue()
        {
            IBank<int> integerBank = new IntegerBank(10);

            integerBank.Spend(-5);

            Assert.AreEqual(10, integerBank.Amount.Value);
            Assert.IsFalse(integerBank.IsEmpty.Value);
        }

        [Test]
        public void SpendMoreThanAmount()
        {
            IBank<int> integerBank = new IntegerBank(10);

            integerBank.Spend(15);

            Assert.AreEqual(10, integerBank.Amount.Value);
            Assert.IsFalse(integerBank.IsEmpty.Value);
        }

        [Test]
        public void SetValuePositiveValue()
        {
            IBank<int> integerBank = new IntegerBank();

            integerBank.SetValue(10);

            Assert.AreEqual(10, integerBank.Amount.Value);
            Assert.IsFalse(integerBank.IsEmpty.Value);
        }

        [Test]
        public void SetValueNegativeValue()
        {
            IBank<int> integerBank = new IntegerBank();

            integerBank.SetValue(-10);

            Assert.AreEqual(0, integerBank.Amount.Value);
            Assert.IsTrue(integerBank.IsEmpty.Value);
        }

        [Test]
        public void Clear()
        {
            IBank<int> integerBank = new IntegerBank(10);

            integerBank.Clear();

            Assert.AreEqual(0, integerBank.Amount.Value);
            Assert.IsTrue(integerBank.IsEmpty.Value);
        }

        [Test]
        public void HasEnough()
        {
            IBank<int> integerBank = new IntegerBank(10);

            bool hasEnough = integerBank.HasEnough(5);

            Assert.IsTrue(hasEnough);
        }

        [Test]
        public void HasNotEnough()
        {
            IBank<int> integerBank = new IntegerBank(10);

            bool hasEnough = integerBank.HasEnough(15);

            Assert.IsFalse(hasEnough);
        }

        [Test]
        public void HasEnoughNegativeValue()
        {
            IBank<int> integerBank = new IntegerBank(10);

            bool hasEnough = integerBank.HasEnough(-5);

            Assert.IsTrue(hasEnough);
        }

        [Test]
        public void HasEnoughZeroValue()
        {
            IBank<int> integerBank = new IntegerBank(10);

            bool hasEnough = integerBank.HasEnough(0);

            Assert.IsTrue(hasEnough);
        }

        [Test]
        public void HasEnoughZeroAmount()
        {
            IBank<int> integerBank = new IntegerBank();

            bool hasEnough = integerBank.HasEnough(5);

            Assert.IsFalse(hasEnough);
        }

        [Test]
        public void HasEnoughZeroAmountZeroValue()
        {
            IBank<int> integerBank = new IntegerBank();

            bool hasEnough = integerBank.HasEnough(0);

            Assert.IsTrue(hasEnough);
        }
    }
}