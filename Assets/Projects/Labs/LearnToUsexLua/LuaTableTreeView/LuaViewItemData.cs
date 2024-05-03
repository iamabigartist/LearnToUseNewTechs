using System.Collections.Generic;
using XLua;
namespace Labs.LearnToUseXLua.LuaTblTreeView
{
[CSharpCallLua]
public interface LuaViewItemData
{
	string key { get; }
	string type { get; }
	string value { get; }
	Dictionary<string, LuaViewItemData> children { get; }
}
}