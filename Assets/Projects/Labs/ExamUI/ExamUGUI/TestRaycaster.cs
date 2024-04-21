using System.Collections.Generic;
using System.Linq;
using PrototypePackages.MiscUtils;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
namespace Labs.ExamUI.ExamUGUI
{
	public class TestRaycaster : MonoBehaviour
	{
		public EventSystem m_EventSystem;
		public GraphicRaycaster m_GraphicRaycaster;
		void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{

				m_EventSystem = EventSystem.current;
				var results = new List<RaycastResult>();
				m_GraphicRaycaster.Raycast(new(m_EventSystem) { position = Input.mousePosition }, results);
				var result_string = results.Select(r => r.gameObject.name).JoinString(",");
				Debug.Log(result_string);
			}

		}
	}
}