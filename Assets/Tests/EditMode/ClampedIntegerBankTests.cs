using NUnit.Framework;
using Plugins.Banks.Core;
using Plugins.Banks.Integer;

namespace Tests.EditMode
{
    public class ClampedIntegerBankTests
    {
        [Test]
        public void InitialValues()
        {
            IClampedBank<int> clampedBank = new ClampedIntegerBank();

            Assert.AreEqual(0, clampedBank.Amount.Value);
            Assert.AreEqual(0, clampedBank.MaxAmount.Value);
            Assert.AreEqual(0, clampedBank.FillAmount.Value);
            Assert.IsTrue(clampedBank.IsEmpty.Value);
            Assert.IsTrue(clampedBank.IsFull.Value);
        }

        [Test]
        public void InitialValuesWithConstructor()
        {
            IClampedBank<int> clampedBank = new ClampedIntegerBank(10, 20);

            Assert.AreEqual(10, clampedBank.Amount.Value);
            Assert.AreEqual(20, clampedBank.MaxAmount.Value);
            Assert.AreEqual(0.5f, clampedBank.FillAmount.Value);
            Assert.IsFalse(clampedBank.IsEmpty.Value);
            Assert.IsFalse(clampedBank.IsFull.Value);
        }

        [Test]
        public void NegativeInitialValuesWithConstructor()
        {
            IClampedBank<int> clampedBank = new ClampedIntegerBank(-10, -20);

            Assert.AreEqual(0, clampedBank.Amount.Value);
            Assert.AreEqual(0, clampedBank.MaxAmount.Value);
            Assert.AreEqual(0, clampedBank.FillAmount.Value);
            Assert.IsTrue(clampedBank.IsEmpty.Value);
            Assert.IsTrue(clampedBank.IsFull.Value);
        }

        [Test]
        public void Add()
        {
            IClampedBank<int> clampedBank = new ClampedIntegerBank(10, 20);

            clampedBank.Add(5);

            Assert.AreEqual(15, clampedBank.Amount.Value);
            Assert.AreEqual(20, clampedBank.MaxAmount.Value);
            Assert.AreEqual(0.75f, clampedBank.FillAmount.Value);
            Assert.IsFalse(clampedBank.IsEmpty.Value);
            Assert.IsFalse(clampedBank.IsFull.Value);
        }

        [Test]
        public void AddMoreThanMax()
        {
            IClampedBank<int> clampedBank = new ClampedIntegerBank(10, 20);

            clampedBank.Add(15);

            Assert.AreEqual(20, clampedBank.Amount.Value);
            Assert.AreEqual(20, clampedBank.MaxAmount.Value);
            Assert.AreEqual(1, clampedBank.FillAmount.Value);
            Assert.IsFalse(clampedBank.IsEmpty.Value);
            Assert.IsTrue(clampedBank.IsFull.Value);
        }

        [Test]
        public void AddNegative()
        {
            IClampedBank<int> clampedBank = new ClampedIntegerBank(10, 20);

            clampedBank.Add(-5);

            Assert.AreEqual(10, clampedBank.Amount.Value);
            Assert.AreEqual(20, clampedBank.MaxAmount.Value);
            Assert.AreEqual(0.5f, clampedBank.FillAmount.Value);
            Assert.IsFalse(clampedBank.IsEmpty.Value);
            Assert.IsFalse(clampedBank.IsFull.Value);
        }

        [Test]
        public void AddMoreNegativeThanMax()
        {
            IClampedBank<int> clampedBank = new ClampedIntegerBank(10, 20);

            clampedBank.Add(-15);

            Assert.AreEqual(10, clampedBank.Amount.Value);
            Assert.AreEqual(20, clampedBank.MaxAmount.Value);
            Assert.AreEqual(0.5f, clampedBank.FillAmount.Value);
            Assert.IsFalse(clampedBank.IsEmpty.Value);
            Assert.IsFalse(clampedBank.IsFull.Value);
        }

        [Test]
        public void Spend()
        {
            IClampedBank<int> clampedBank = new ClampedIntegerBank(10, 20);

            clampedBank.Spend(5);

            Assert.AreEqual(5, clampedBank.Amount.Value);
            Assert.AreEqual(20, clampedBank.MaxAmount.Value);
            Assert.AreEqual(0.25f, clampedBank.FillAmount.Value);
            Assert.IsFalse(clampedBank.IsEmpty.Value);
            Assert.IsFalse(clampedBank.IsFull.Value);
        }

        [Test]
        public void SpendMoreThanAmount()
        {
            IClampedBank<int> clampedBank = new ClampedIntegerBank(10, 20);

            clampedBank.Spend(15);

            Assert.AreEqual(10, clampedBank.Amount.Value);
            Assert.AreEqual(20, clampedBank.MaxAmount.Value);
            Assert.AreEqual(0.5f, clampedBank.FillAmount.Value);
            Assert.IsFalse(clampedBank.IsEmpty.Value);
            Assert.IsFalse(clampedBank.IsFull.Value);
        }

        [Test]
        public void SpendNegative()
        {
            IClampedBank<int> clampedBank = new ClampedIntegerBank(10, 20);

            clampedBank.Spend(-5);

            Assert.AreEqual(10, clampedBank.Amount.Value);
            Assert.AreEqual(20, clampedBank.MaxAmount.Value);
            Assert.AreEqual(0.5f, clampedBank.FillAmount.Value);
            Assert.IsFalse(clampedBank.IsEmpty.Value);
            Assert.IsFalse(clampedBank.IsFull.Value);
        }

        [Test]
        public void SpendMoreNegativeThanAmount()
        {
            IClampedBank<int> clampedBank = new ClampedIntegerBank(10, 20);

            clampedBank.Spend(-15);

            Assert.AreEqual(10, clampedBank.Amount.Value);
            Assert.AreEqual(20, clampedBank.MaxAmount.Value);
            Assert.AreEqual(0.5f, clampedBank.FillAmount.Value);
            Assert.IsFalse(clampedBank.IsEmpty.Value);
            Assert.IsFalse(clampedBank.IsFull.Value);
        }

        [Test]
        public void SetValue()
        {
            IClampedBank<int> clampedBank = new ClampedIntegerBank(10, 20);

            clampedBank.SetValue(15);

            Assert.AreEqual(15, clampedBank.Amount.Value);
            Assert.AreEqual(20, clampedBank.MaxAmount.Value);
            Assert.AreEqual(0.75f, clampedBank.FillAmount.Value);
            Assert.IsFalse(clampedBank.IsEmpty.Value);
            Assert.IsFalse(clampedBank.IsFull.Value);
        }

        [Test]
        public void SetNegativeValue()
        {
            IClampedBank<int> clampedBank = new ClampedIntegerBank(10, 20);

            clampedBank.SetValue(-5);

            Assert.AreEqual(0, clampedBank.Amount.Value);
            Assert.AreEqual(20, clampedBank.MaxAmount.Value);
            Assert.AreEqual(0, clampedBank.FillAmount.Value);
            Assert.IsTrue(clampedBank.IsEmpty.Value);
            Assert.IsFalse(clampedBank.IsFull.Value);
        }

        [Test]
        public void SetMoreThanMaxValue()
        {
            IClampedBank<int> clampedBank = new ClampedIntegerBank(10, 20);

            clampedBank.SetValue(25);

            Assert.AreEqual(20, clampedBank.Amount.Value);
            Assert.AreEqual(20, clampedBank.MaxAmount.Value);
            Assert.AreEqual(1, clampedBank.FillAmount.Value);
            Assert.IsFalse(clampedBank.IsEmpty.Value);
            Assert.IsTrue(clampedBank.IsFull.Value);
        }

        [Test]
        public void Clear()
        {
            IClampedBank<int> clampedBank = new ClampedIntegerBank(10, 20);

            clampedBank.Clear();

            Assert.AreEqual(0, clampedBank.Amount.Value);
            Assert.AreEqual(20, clampedBank.MaxAmount.Value);
            Assert.AreEqual(0, clampedBank.FillAmount.Value);
            Assert.IsTrue(clampedBank.IsEmpty.Value);
            Assert.IsFalse(clampedBank.IsFull.Value);
        }

        [Test]
        public void Fill()
        {
            IClampedBank<int> clampedBank = new ClampedIntegerBank(10, 20);

            clampedBank.Fill();

            Assert.AreEqual(20, clampedBank.Amount.Value);
            Assert.AreEqual(20, clampedBank.MaxAmount.Value);
            Assert.AreEqual(1, clampedBank.FillAmount.Value);
            Assert.IsFalse(clampedBank.IsEmpty.Value);
            Assert.IsTrue(clampedBank.IsFull.Value);
        }

        [Test]
        public void HasEnough()
        {
            IClampedBank<int> clampedBank = new ClampedIntegerBank(10, 20);

            bool result = clampedBank.HasEnough(5);

            Assert.IsTrue(result);
        }

        [Test]
        public void HasNotEnough()
        {
            IClampedBank<int> clampedBank = new ClampedIntegerBank(10, 20);

            bool result = clampedBank.HasEnough(15);

            Assert.IsFalse(result);
        }

        [Test]
        public void HasEnoughNegative()
        {
            IClampedBank<int> clampedBank = new ClampedIntegerBank(10, 20);

            bool result = clampedBank.HasEnough(-5);

            Assert.IsTrue(result);
        }
    }
}