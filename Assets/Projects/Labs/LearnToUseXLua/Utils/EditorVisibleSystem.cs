using UnityEditor;
namespace Labs.LearnToUseXLua.Utils
{
public abstract class EditorVisibleSystem<T> : ScriptableSingleton<T>
	where T : EditorVisibleSystem<T>
{
	public EditorWindowHook hook;

	[InitializeOnLoadMethod]
	public static void OnEditorLaunch_Entry() => instance.OnEditorLaunch();
	public virtual void OnEditorLaunch() {}

	[InitializeOnEnterPlayMode]
	public static void OnEnterPlayMode_Entry(EnterPlayModeOptions options) => instance.OnEnterPlayMode(options);
	public virtual void OnEnterPlayMode(EnterPlayModeOptions options) {}
}
}