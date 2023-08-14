using UnityEngine;
using UnityEngine.UIElements;
namespace Labs.ExamUI.ExamUGUI
{
public class TestUIDocument : MonoBehaviour
{
	UIDocument document;
	void Start()
	{
		document = GetComponent<UIDocument>();
		var root = document.rootVisualElement;
		VisualElement a = new HelpBox("BoxA", HelpBoxMessageType.Info);
		VisualElement b = new HelpBox("BoxB", HelpBoxMessageType.Info);
		a.Add(b);
		a.style.position = Position.Absolute;
		a.style.bottom = 100;
		a.style.top = 100;
		a.style.left = 100;
		a.style.right = 100;
		b.style.position = Position.Absolute;
		a.RegisterCallback<MouseMoveEvent>(Evt =>
		{
			Debug.Log(Evt.mousePosition);
			var position_in_a = a.WorldToLocal(Evt.mousePosition);
			b.style.left = position_in_a.x;
			b.style.top = position_in_a.y;
		});
		root.Add(a);
	}
}
}