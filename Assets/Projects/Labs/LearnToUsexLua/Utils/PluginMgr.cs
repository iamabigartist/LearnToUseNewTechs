using System;
namespace Labs.LearnToUseXLua.Utils
{
public class PluginMgr
{
	
	
	
	
	void Execute<TCallbackDoc>(
		TCallbackDoc[] callback_list, 
		Action<TCallbackDoc> ExecuteMethod)
	{
		foreach (var doc in callback_list) { ExecuteMethod(doc); }
	}
}
}