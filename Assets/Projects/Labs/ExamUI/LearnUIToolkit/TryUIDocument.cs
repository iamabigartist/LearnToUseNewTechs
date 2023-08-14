using UnityEngine;
using UnityEngine.UIElements;
using Utils;
namespace Labs.ExamUI.LearnUIToolkit
{
	public class TryUIDocument : MonoBehaviour
	{
		UIDocument MyDocument;
		Label label0;
		Syncer<Vector3> PositionSyncer;
		public Vector3 LabelPosition;
		void Start()
		{
			MyDocument = GetComponent<UIDocument>();
			MyDocument.visualTreeAsset = Resources.Load<VisualTreeAsset>("UXML1");
			var root = MyDocument.rootVisualElement;
			label0 = root.Query<Label>().First();

			PositionSyncer = new(
				() => LabelPosition, () => label0.transform.position,
				(_, new_pos) => label0.transform.position = new_pos,
				(_, new_pos) => LabelPosition = new_pos);
			PositionSyncer.Update();
		}


		void Update()
		{
			PositionSyncer.Apply();
		}
	}
}