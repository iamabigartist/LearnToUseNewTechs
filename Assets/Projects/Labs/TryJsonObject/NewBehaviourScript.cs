using UnityEngine;
namespace Labs.TryJsonObject
{
public class NewBehaviourScript : MonoBehaviour
{
    void Start()
    {
        dynamic a=2;
        a[0]["asd"] = 12;
    }

    void Update()
    {
        
    }
}
}
