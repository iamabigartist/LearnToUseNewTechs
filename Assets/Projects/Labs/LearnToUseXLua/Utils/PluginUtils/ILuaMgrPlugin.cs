using UnityEditor;
using UnityEngine;
namespace Labs.LearnToUseXLua.Utils
{
public interface ILuaMgrPlugin
{
	string name { get; }
	[MenuItem("Labs/ListAllPlugins")]
	static void ListAllPlugins()
	{
		foreach (var func in PluginMgr<ILuaMgrPlugin>.instance.PluginList)
		{
			Debug.Log($"PluginInitializer: {func}");
		}
	}
}
public class TestLuaMgrPlugin : ILuaMgrPlugin
{
	[InitializeOnLoadMethod]
	static void Register()
	{
		PluginMgr<ILuaMgrPlugin>.RegisterPlugin(() => new TestLuaMgrPlugin());
	}

	public string name => "TestLuaMgrPlugin";

}
}