using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace Labs.ExamUI.ExamUGUI
{
public abstract class BasePanelController : MonoBehaviour
{
	void Awake()
	{
		
	}

	public abstract void BindUI();
	public abstract void InitUI();
	public abstract void MyUpdate();
	public abstract void CloseUI();
}

public class UIManager:MonoBehaviour
{
	public List<BasePanelController> Controllers;
	BasePanelController controller1;
	BasePanelController controller2;
	void Update()
	{
		foreach (var controller in Controllers)
		{
			controller.MyUpdate();
		}
		controller1.MyUpdate();
		controller2.MyUpdate();
	}
}
public class ButtonController : MonoBehaviour
{
	Button m_button;
	Text m_button_text;
	EventTrigger m_trigger;
	Animation m_anime_player;
	int click_count;
	Slider m_slider;
	void Start()
	{
		m_button = GetComponent<Button>();
		m_trigger = GetComponent<EventTrigger>();
		m_anime_player = GetComponent<Animation>();
		m_button_text = GetComponentInChildren<Text>();
		m_button.onClick.AddListener(OnButtonClick);
		click_count = 0;
		m_slider = GetComponentInChildren<Slider>();
		m_slider.onValueChanged.AddListener(Arg0 => Debug.Log($"Slider Value {Arg0}"));


		var callback_enter = new EventTrigger.TriggerEvent();
		callback_enter.AddListener(Arg0 =>
		{
			m_button_text.text = "鼠标进入按钮范围。";
		});
		var pointer_enter_entry = new EventTrigger.Entry()
		{
			eventID = EventTriggerType.PointerEnter,
			callback = callback_enter
		};

		var callback_exit = new EventTrigger.TriggerEvent();
		callback_exit.AddListener(Arg0 =>
		{
			m_button_text.text = $"点击次数：{click_count}";
		});
		var pointer_exit_entry = new EventTrigger.Entry()
		{
			eventID = EventTriggerType.PointerExit,
			callback = callback_exit
		};
		m_trigger.triggers.Add(pointer_enter_entry);
		m_trigger.triggers.Add(pointer_exit_entry);
	}
	void OnButtonClick()
	{
		Debug.Log("这个按钮被点击了。");
		click_count++;
		m_button_text.text = $"点击次数：{click_count}";
		m_anime_player.Play("ButtonWave");
	}

	void Update() {}
}
}