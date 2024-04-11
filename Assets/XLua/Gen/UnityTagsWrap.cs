#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class UnityTagsWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityTags);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 8, 0, 0);
			
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Untagged", UnityTags.Untagged);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Respawn", UnityTags.Respawn);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Finish", UnityTags.Finish);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "EditorOnly", UnityTags.EditorOnly);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MainCamera", UnityTags.MainCamera);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Player", UnityTags.Player);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "GameController", UnityTags.GameController);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "UnityTags does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        
        
        
        
        
		
		
		
		
    }
}
