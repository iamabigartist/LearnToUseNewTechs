using UnityEngine;
using UnityEngine.UIElements;
namespace Labs.LearnUIToolkitResizable
{
public class ResizablePanel : VisualElement
{
	VisualTreeAsset uxml = Resources.Load<VisualTreeAsset>("ResizablePanel");
	StyleSheet uss = Resources.Load<StyleSheet>("ResizablePanelUSS");
	public ResizablePanel()
	{
		var ve = uxml.Instantiate();
		Add(ve);
		ve.styleSheets.Add(uss);
	}
}
}