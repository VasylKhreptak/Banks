using NUnit.Framework;
using Plugins.Banks.Core;
using Plugins.Banks.Float;

namespace Plugins.Banks.Tests.EditMode
{
    public class ClampedFloatBankTests
    {
        [Test]
        public void InitialValues()
        {
            IClampedBank<float> floatClampedBank = new ClampedFloatBank();

            Assert.AreEqual(0, floatClampedBank.Amount.Value);
            Assert.AreEqual(0, floatClampedBank.MaxAmount.Value);
            Assert.AreEqual(0, floatClampedBank.FillAmount.Value);
            Assert.IsTrue(floatClampedBank.IsEmpty.Value);
            Assert.IsTrue(floatClampedBank.IsFull.Value);
        }

        [Test]
        public void InitialValuesWithConstructor()
        {
            IClampedBank<float> floatClampedBank = new ClampedFloatBank(10, 20);

            Assert.AreEqual(10, floatClampedBank.Amount.Value);
            Assert.AreEqual(20, floatClampedBank.MaxAmount.Value);
            Assert.AreEqual(0.5f, floatClampedBank.FillAmount.Value);
            Assert.IsFalse(floatClampedBank.IsEmpty.Value);
            Assert.IsFalse(floatClampedBank.IsFull.Value);
        }

        [Test]
        public void NegativeInitialValuesWithConstructor()
        {
            IClampedBank<float> floatClampedBank = new ClampedFloatBank(-10, -20);

            Assert.AreEqual(0, floatClampedBank.Amount.Value);
            Assert.AreEqual(0, floatClampedBank.MaxAmount.Value);
            Assert.AreEqual(0, floatClampedBank.FillAmount.Value);
            Assert.IsTrue(floatClampedBank.IsEmpty.Value);
            Assert.IsTrue(floatClampedBank.IsFull.Value);
        }

        [Test]
        public void Add()
        {
            IClampedBank<float> floatClampedBank = new ClampedFloatBank(10, 20);

            floatClampedBank.Add(5);

            Assert.AreEqual(15, floatClampedBank.Amount.Value);
            Assert.AreEqual(20, floatClampedBank.MaxAmount.Value);
            Assert.AreEqual(0.75f, floatClampedBank.FillAmount.Value);
            Assert.IsFalse(floatClampedBank.IsEmpty.Value);
            Assert.IsFalse(floatClampedBank.IsFull.Value);
        }

        [Test]
        public void AddNegativeValue()
        {
            IClampedBank<float> floatClampedBank = new ClampedFloatBank(10, 20);

            floatClampedBank.Add(-5);

            Assert.AreEqual(10, floatClampedBank.Amount.Value);
            Assert.AreEqual(20, floatClampedBank.MaxAmount.Value);
            Assert.AreEqual(0.5f, floatClampedBank.FillAmount.Value);
            Assert.IsFalse(floatClampedBank.IsEmpty.Value);
            Assert.IsFalse(floatClampedBank.IsFull.Value);
        }

        [Test]
        public void Spend()
        {
            IClampedBank<float> floatClampedBank = new ClampedFloatBank(10, 20);

            floatClampedBank.Spend(5);

            Assert.AreEqual(5, floatClampedBank.Amount.Value);
            Assert.AreEqual(20, floatClampedBank.MaxAmount.Value);
            Assert.AreEqual(0.25f, floatClampedBank.FillAmount.Value);
            Assert.IsFalse(floatClampedBank.IsEmpty.Value);
            Assert.IsFalse(floatClampedBank.IsFull.Value);
        }

        [Test]
        public void SpendNegativeValue()
        {
            IClampedBank<float> floatClampedBank = new ClampedFloatBank(10, 20);

            floatClampedBank.Spend(-5);

            Assert.AreEqual(10, floatClampedBank.Amount.Value);
            Assert.AreEqual(20, floatClampedBank.MaxAmount.Value);
            Assert.AreEqual(0.5f, floatClampedBank.FillAmount.Value);
            Assert.IsFalse(floatClampedBank.IsEmpty.Value);
            Assert.IsFalse(floatClampedBank.IsFull.Value);
        }

        [Test]
        public void SpendMoreThanAmount()
        {
            IClampedBank<float> floatClampedBank = new ClampedFloatBank(10, 20);

            floatClampedBank.Spend(15);

            Assert.AreEqual(10, floatClampedBank.Amount.Value);
            Assert.AreEqual(20, floatClampedBank.MaxAmount.Value);
            Assert.AreEqual(0.5f, floatClampedBank.FillAmount.Value);
            Assert.IsFalse(floatClampedBank.IsEmpty.Value);
            Assert.IsFalse(floatClampedBank.IsFull.Value);
        }

        [Test]
        public void SetValue()
        {
            IClampedBank<float> floatClampedBank = new ClampedFloatBank(10, 20);

            floatClampedBank.SetValue(15);

            Assert.AreEqual(15, floatClampedBank.Amount.Value);
            Assert.AreEqual(20, floatClampedBank.MaxAmount.Value);
            Assert.AreEqual(0.75f, floatClampedBank.FillAmount.Value);
            Assert.IsFalse(floatClampedBank.IsEmpty.Value);
            Assert.IsFalse(floatClampedBank.IsFull.Value);
        }

        [Test]
        public void SetValueNegativeValue()
        {
            IClampedBank<float> floatClampedBank = new ClampedFloatBank(10, 20);

            floatClampedBank.SetValue(-5);

            Assert.AreEqual(0, floatClampedBank.Amount.Value);
            Assert.AreEqual(20, floatClampedBank.MaxAmount.Value);
            Assert.AreEqual(0, floatClampedBank.FillAmount.Value);
            Assert.IsTrue(floatClampedBank.IsEmpty.Value);
            Assert.IsFalse(floatClampedBank.IsFull.Value);
        }

        [Test]
        public void SetValueMoreThanMaxAmount()
        {
            IClampedBank<float> floatClampedBank = new ClampedFloatBank(10, 20);

            floatClampedBank.SetValue(25);

            Assert.AreEqual(20, floatClampedBank.Amount.Value);
            Assert.AreEqual(20, floatClampedBank.MaxAmount.Value);
            Assert.AreEqual(1, floatClampedBank.FillAmount.Value);
            Assert.IsFalse(floatClampedBank.IsEmpty.Value);
            Assert.IsTrue(floatClampedBank.IsFull.Value);
        }

        [Test]
        public void SetMaxValue()
        {
            IClampedBank<float> floatClampedBank = new ClampedFloatBank(10, 20);

            floatClampedBank.SetMaxValue(15);

            Assert.AreEqual(10, floatClampedBank.Amount.Value);
            Assert.AreEqual(15, floatClampedBank.MaxAmount.Value);
            Assert.AreEqual(0.6666667f, floatClampedBank.FillAmount.Value);
            Assert.IsFalse(floatClampedBank.IsEmpty.Value);
            Assert.IsFalse(floatClampedBank.IsFull.Value);
        }

        [Test]
        public void SetMaxValueNegativeValue()
        {
            IClampedBank<float> floatClampedBank = new ClampedFloatBank(10, 20);

            floatClampedBank.SetMaxValue(-5);

            Assert.AreEqual(0, floatClampedBank.Amount.Value);
            Assert.AreEqual(0, floatClampedBank.MaxAmount.Value);
            Assert.AreEqual(0, floatClampedBank.FillAmount.Value);
            Assert.IsTrue(floatClampedBank.IsEmpty.Value);
            Assert.IsTrue(floatClampedBank.IsFull.Value);
        }

        [Test]
        public void SetMaxValueLessThanAmount()
        {
            IClampedBank<float> floatClampedBank = new ClampedFloatBank(10, 20);

            floatClampedBank.SetMaxValue(5);

            Assert.AreEqual(5, floatClampedBank.Amount.Value);
            Assert.AreEqual(5, floatClampedBank.MaxAmount.Value);
            Assert.AreEqual(1, floatClampedBank.FillAmount.Value);
            Assert.IsFalse(floatClampedBank.IsEmpty.Value);
            Assert.IsTrue(floatClampedBank.IsFull.Value);
        }

        [Test]
        public void SetMaxValueLessThanAmountAndNegative()
        {
            IClampedBank<float> floatClampedBank = new ClampedFloatBank(10, 20);

            floatClampedBank.SetMaxValue(-5);

            Assert.AreEqual(0, floatClampedBank.Amount.Value);
            Assert.AreEqual(0, floatClampedBank.MaxAmount.Value);
            Assert.AreEqual(0, floatClampedBank.FillAmount.Value);
            Assert.IsTrue(floatClampedBank.IsEmpty.Value);
            Assert.IsTrue(floatClampedBank.IsFull.Value);
        }

        [Test]
        public void Clear()
        {
            IClampedBank<float> floatClampedBank = new ClampedFloatBank(10, 20);

            floatClampedBank.Clear();

            Assert.AreEqual(0, floatClampedBank.Amount.Value);
            Assert.AreEqual(20, floatClampedBank.MaxAmount.Value);
            Assert.AreEqual(0, floatClampedBank.FillAmount.Value);
            Assert.IsTrue(floatClampedBank.IsEmpty.Value);
            Assert.IsFalse(floatClampedBank.IsFull.Value);
        }

        [Test]
        public void Fill()
        {
            IClampedBank<float> floatClampedBank = new ClampedFloatBank(10, 20);

            floatClampedBank.Fill();

            Assert.AreEqual(20, floatClampedBank.Amount.Value);
            Assert.AreEqual(20, floatClampedBank.MaxAmount.Value);
            Assert.AreEqual(1, floatClampedBank.FillAmount.Value);
            Assert.IsFalse(floatClampedBank.IsEmpty.Value);
            Assert.IsTrue(floatClampedBank.IsFull.Value);
        }

        [Test]
        public void HasEnough()
        {
            IClampedBank<float> floatClampedBank = new ClampedFloatBank(10, 20);

            Assert.IsTrue(floatClampedBank.HasEnough(5));
            Assert.IsFalse(floatClampedBank.HasEnough(15));
        }

        [Test]
        public void HasEnoughNegative()
        {
            IClampedBank<float> floatClampedBank = new ClampedFloatBank(10, 20);

            Assert.IsTrue(floatClampedBank.HasEnough(-5));
            Assert.IsTrue(floatClampedBank.HasEnough(-15));
        }

        [Test]
        public void HasEnoughMoreThanMaxAmount()
        {
            IClampedBank<float> floatClampedBank = new ClampedFloatBank(10, 20);

            Assert.IsFalse(floatClampedBank.HasEnough(25));
        }
    }
}