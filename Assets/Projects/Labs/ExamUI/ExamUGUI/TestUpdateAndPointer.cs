using UnityEngine;
using UnityEngine.EventSystems;
namespace Labs.ExamUI.ExamUGUI
{
public class TestUpdateAndPointer : MonoBehaviour, IPointerDownHandler
{

	int down_frame;
	public void OnPointerDown(PointerEventData eventData)
	{
		down_frame = Time.frameCount;
		Debug.Log(down_frame);
	}

	void Update()
	{
		if (Time.frameCount==down_frame)
		{
			Debug.Log("Success");
		}
	}
}
}