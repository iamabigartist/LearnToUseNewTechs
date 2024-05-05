using System;
using UnityEditor;
using UnityEngine;
namespace Labs.LearnToUseXLua.TestDynamicWindow.Editor
{
public class EditorWindowHook:EditorWindow
{

	public Action OnGUI_Hook;
	public Action CreateGUI_Hook;
	public Action OnFocus_Hook;
	public Action OnLostFocus_Hook;
	public Action<Rect> ShowButton_Hook;
	
	void OnGUI() => OnGUI_Hook?.Invoke();
	void CreateGUI() => CreateGUI_Hook?.Invoke();
	void OnFocus()=> OnFocus_Hook?.Invoke();
	void OnLostFocus()=> OnLostFocus_Hook?.Invoke();
	void ShowButton(Rect rect)=> ShowButton_Hook?.Invoke(rect);
	
	
}
}