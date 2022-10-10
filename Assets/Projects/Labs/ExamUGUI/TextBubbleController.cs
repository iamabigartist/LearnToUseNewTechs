using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class TextBubbleController : MonoBehaviour, IDragHandler
{
	public RectTransform Content;
	public GameObject TextBubblePrefab;

	void Start()
	{
		StartCoroutine(AddBubble());
		StartCoroutine(RemoveBubble());
		var entry = new EventTrigger.Entry()
		{

			callback = new()
		};
	}

	IEnumerator AddBubble()
	{
		while (true)
		{
			var cur_text = Instantiate(TextBubblePrefab, Content).GetComponentInChildren<Text>();
			cur_text.text = $"{Time.time}";
			yield return new WaitForSeconds(1.0f);
		}

	}

	IEnumerator RemoveBubble()
	{
		while (true)
		{
			yield return new WaitForSeconds(4.0f);
			Destroy(Content.GetChild(0).gameObject);
		}
	}

	public void OnDrag(PointerEventData eventData) {}
}