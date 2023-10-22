using Newtonsoft.Json;
using Plugins.Banks;
using Sirenix.OdinInspector;
using UnityEngine;

public class SerializeTest : MonoBehaviour
{
    [Button]
    private void Test()
    {
        ClampedFloatBank bank = new ClampedFloatBank(10, 20);
        
        string json = JsonConvert.SerializeObject(bank);
        
        Debug.Log(json);
        
        bank = JsonConvert.DeserializeObject<ClampedFloatBank>(json);
        
        Debug.Log(bank.Value.Value);
        Debug.Log(bank.MaxValue.Value);
    }
}