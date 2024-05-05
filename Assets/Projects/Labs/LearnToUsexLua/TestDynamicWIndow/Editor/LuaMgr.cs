using UnityEditor;
using UnityEngine;
using XLua;
namespace Labs.LearnToUseXLua.TestDynamicWindow.Editor
{
[FilePath(
	"Assets/GlobalSettings/LuaEnvConfig.txt",
	FilePathAttribute.Location.ProjectFolder)]
public class LuaMgr : ScriptableSingleton<LuaMgr>
{
	public LuaEnv lua_env;

	public void DoScriptString(string script)
	{
		lua_env.DoString(script);
	}

	public void DoScriptBytes(byte[] bytes)
	{
		lua_env.DoString(bytes);
	}
	
	public void Tick()
	{
		lua_env.Tick();
	}
	
	public void LoadAllPreloadFiles()
	{
		var lua_loader = new BytesArrayInProjectFolderLoader("Assets/Projects/Labs/LearnToUseXLua/PreloadLuaScripts");
		var preload_files = new[]
		{
			"LuaMgr.lua",
			"LuaMgrTest.lua",
		};
		foreach (var file in preload_files)
		{
			var bytes = lua_loader.LoadByPath(file);
			lua_env.DoString(System.Text.Encoding.UTF8.GetString(bytes), file);
		}
	}
}
}