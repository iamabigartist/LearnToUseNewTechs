using Labs.LearnToUseXLua.TestDynamicWindow.Editor;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;
using XLua;
public class LuaScriptRunWindow : EditorWindow
{
	[MenuItem("Labs/LuaScriptRunWindow")]
	public static void ShowExample()
	{
		LuaScriptRunWindow wnd = GetWindow<LuaScriptRunWindow>();
		wnd.titleContent = new("LuaScriptRunWindow");
	}

	SerializedObject this_so;
	LuaEnv lua_env;
	[SerializeField] string cur_script;

	public void CreateGUI()
	{
		var builder = new UXMLBuilder(rootVisualElement);
		builder.Add(new VisualElement(), out var root_panel);
		root_panel.style.marginLeft = root_panel.style.marginRight = root_panel.style.marginTop = root_panel.style.marginBottom = 10;
		using (var s_r = builder.Scope(root_panel))
		{
			builder.Add(new Label("Script"), out _);
			builder.Add(new TextField(), out var script_field);
			script_field.multiline = true;
			script_field.style.height = 300;
			script_field.bindingPath = "cur_script";
			builder.Add(new Button(RunCurScript), out var run_button);
			run_button.text = "Run";
		}
		rootVisualElement.Bind(this_so);
	}

	void OnEnable()
	{
		this_so = new(this);
		lua_env = new();
	}

	void OnDisable()
	{
		lua_env.Dispose();
	}

	void RunCurScript()
	{
		lua_env.DoString(cur_script);
	}
}