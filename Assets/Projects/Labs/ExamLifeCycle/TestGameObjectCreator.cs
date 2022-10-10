using UnityEngine;
namespace Labs.ExamLifeCycle
{
    public class TestGameObjectCreator : MonoBehaviour
    {
        void Start()
        {
            
        }

        void Update()
        {
        
        }

        [ContextMenu("Add")]
        void Add()
        {
            var gameobject = new GameObject("Created1");
            gameobject.transform.parent = transform;
            Debug.Log("Before Add");
            gameobject.AddComponent<TestCreatedGameObject>();
            Debug.Log("After Add");
        }
    }
}
