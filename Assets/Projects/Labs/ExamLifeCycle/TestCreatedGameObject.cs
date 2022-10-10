using UnityEngine;
namespace Labs.ExamLifeCycle
{
	public class TestCreatedGameObject : MonoBehaviour
	{
		public bool Awaken = false;
		public bool Started = false;
		public bool Enabled = false;

		void Awake()
		{
			Debug.Log($"{gameObject.name} Awake");
			Awaken = true;
		}
		void Start()
		{
			Debug.Log($"{gameObject.name} Start");
			Started = true;
		}
		void OnEnable()
		{
			Debug.Log($"{gameObject.name} Enable");
			Enabled = true;
		}
	}
}