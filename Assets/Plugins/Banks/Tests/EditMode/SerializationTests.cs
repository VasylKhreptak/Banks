using Newtonsoft.Json;
using NUnit.Framework;
using Plugins.Banks.Core;
using Plugins.Banks.Float;
using Plugins.Banks.Integer;

namespace Plugins.Banks.Tests.EditMode
{
    public class SerializationTests
    {
        [Test]
        public void IntegerBank()
        {
            IBank<int> bank = new IntegerBank(10);

            string jsonString = JsonConvert.SerializeObject(bank);

            IBank<int> deserializedBank = JsonConvert.DeserializeObject<IntegerBank>(jsonString);

            Assert.AreEqual(bank.Amount.Value, deserializedBank.Amount.Value);
            Assert.AreEqual(bank.IsEmpty.Value, deserializedBank.IsEmpty.Value);
        }

        [Test]
        public void FloatBank()
        {
            IBank<float> bank = new FloatBank(10);

            string jsonString = JsonConvert.SerializeObject(bank);

            IBank<float> deserializedBank = JsonConvert.DeserializeObject<FloatBank>(jsonString);

            Assert.AreEqual(bank.Amount.Value, deserializedBank.Amount.Value);
            Assert.AreEqual(bank.IsEmpty.Value, deserializedBank.IsEmpty.Value);
        }

        [Test]
        public void ClampedIntegerBank()
        {
            IClampedBank<int> bank = new ClampedIntegerBank(10, 100);

            string jsonString = JsonConvert.SerializeObject(bank);

            IClampedBank<int> deserializedBank = JsonConvert.DeserializeObject<ClampedIntegerBank>(jsonString);

            Assert.AreEqual(bank.Amount.Value, deserializedBank.Amount.Value);
            Assert.AreEqual(bank.MaxAmount.Value, deserializedBank.MaxAmount.Value);
            Assert.AreEqual(bank.IsEmpty.Value, deserializedBank.IsEmpty.Value);
            Assert.AreEqual(bank.IsFull.Value, deserializedBank.IsFull.Value);
            Assert.AreEqual(bank.FillAmount.Value, deserializedBank.FillAmount.Value);
        }

        [Test]
        public void ClampedFloatBank()
        {
            IClampedBank<float> bank = new ClampedFloatBank(10, 100);

            string jsonString = JsonConvert.SerializeObject(bank);

            IClampedBank<float> deserializedBank = JsonConvert.DeserializeObject<ClampedFloatBank>(jsonString);

            Assert.AreEqual(bank.Amount.Value, deserializedBank.Amount.Value);
            Assert.AreEqual(bank.MaxAmount.Value, deserializedBank.MaxAmount.Value);
            Assert.AreEqual(bank.IsEmpty.Value, deserializedBank.IsEmpty.Value);
            Assert.AreEqual(bank.IsFull.Value, deserializedBank.IsFull.Value);
            Assert.AreEqual(bank.FillAmount.Value, deserializedBank.FillAmount.Value);
        }
    }
}