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
    public class LabsTryImplementFSMRM_2022_11_2TestBonePlatingBonePlatingRMMyEntryDataWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM.MyEntryData);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 1, 1);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Type", _g_get_Type);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "Type", _s_set_Type);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM.MyEntryData();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM.MyEntryData constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Type(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM.MyEntryData gen_to_be_invoked = (Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM.MyEntryData)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Type);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Type(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM.MyEntryData gen_to_be_invoked = (Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM.MyEntryData)translator.FastGetCSObj(L, 1);
                Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM.MyEntryData.EntryType gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.Type = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
