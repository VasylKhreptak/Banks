using Newtonsoft.Json;
using NUnit.Framework;
using Plugins.Banks.Float;
using Plugins.Banks.Integer;

namespace Tests.EditMode
{
    public class SerializationTests
    {
        [Test]
        public void IntegerBank()
        {
            IntegerBank bank = new IntegerBank(10);

            string jsonString = JsonConvert.SerializeObject(bank);

            IntegerBank deserializedBank = JsonConvert.DeserializeObject<IntegerBank>(jsonString);

            Assert.AreEqual(bank.Amount.Value, deserializedBank.Amount.Value);
            Assert.AreEqual(bank.IsEmpty.Value, deserializedBank.IsEmpty.Value);
        }

        [Test]
        public void FloatBank()
        {
            FloatBank bank = new FloatBank(10);

            string jsonString = JsonConvert.SerializeObject(bank);

            FloatBank deserializedBank = JsonConvert.DeserializeObject<FloatBank>(jsonString);

            Assert.AreEqual(bank.Amount.Value, deserializedBank.Amount.Value);
            Assert.AreEqual(bank.IsEmpty.Value, deserializedBank.IsEmpty.Value);
        }

        [Test]
        public void ClampedIntegerBank()
        {
            ClampedIntegerBank bank = new ClampedIntegerBank(10, 100);

            string jsonString = JsonConvert.SerializeObject(bank);

            ClampedIntegerBank deserializedBank = JsonConvert.DeserializeObject<ClampedIntegerBank>(jsonString);

            Assert.AreEqual(bank.Amount.Value, deserializedBank.Amount.Value);
            Assert.AreEqual(bank.MaxAmount.Value, deserializedBank.MaxAmount.Value);
            Assert.AreEqual(bank.IsEmpty.Value, deserializedBank.IsEmpty.Value);
            Assert.AreEqual(bank.IsFull.Value, deserializedBank.IsFull.Value);
            Assert.AreEqual(bank.FillAmount.Value, deserializedBank.FillAmount.Value);
        }

        [Test]
        public void ClampedFloatBank()
        {
            ClampedFloatBank bank = new ClampedFloatBank(10, 100);

            string jsonString = JsonConvert.SerializeObject(bank);

            ClampedFloatBank deserializedBank = JsonConvert.DeserializeObject<ClampedFloatBank>(jsonString);

            Assert.AreEqual(bank.Amount.Value, deserializedBank.Amount.Value);
            Assert.AreEqual(bank.MaxAmount.Value, deserializedBank.MaxAmount.Value);
            Assert.AreEqual(bank.IsEmpty.Value, deserializedBank.IsEmpty.Value);
            Assert.AreEqual(bank.IsFull.Value, deserializedBank.IsFull.Value);
            Assert.AreEqual(bank.FillAmount.Value, deserializedBank.FillAmount.Value);
        }
    }
}