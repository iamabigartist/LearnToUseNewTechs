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
    public class LabsTryImplementFSMFSM_2022_10TestFSMWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Labs.TryImplementFSM.FSM_2022_10.TestFSM);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 2, 2);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "CurrentStateTimer", _g_get_CurrentStateTimer);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CurrentExpectType", _g_get_CurrentExpectType);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "CurrentStateTimer", _s_set_CurrentStateTimer);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "CurrentExpectType", _s_set_CurrentExpectType);
            
			
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
					
					var gen_ret = new Labs.TryImplementFSM.FSM_2022_10.TestFSM();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Labs.TryImplementFSM.FSM_2022_10.TestFSM constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurrentStateTimer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.TryImplementFSM.FSM_2022_10.TestFSM gen_to_be_invoked = (Labs.TryImplementFSM.FSM_2022_10.TestFSM)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.CurrentStateTimer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurrentExpectType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.TryImplementFSM.FSM_2022_10.TestFSM gen_to_be_invoked = (Labs.TryImplementFSM.FSM_2022_10.TestFSM)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.CurrentExpectType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CurrentStateTimer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.TryImplementFSM.FSM_2022_10.TestFSM gen_to_be_invoked = (Labs.TryImplementFSM.FSM_2022_10.TestFSM)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.CurrentStateTimer = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CurrentExpectType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.TryImplementFSM.FSM_2022_10.TestFSM gen_to_be_invoked = (Labs.TryImplementFSM.FSM_2022_10.TestFSM)translator.FastGetCSObj(L, 1);
                Labs.TryImplementFSM.FSM_2022_10.TestFSM.ExpectType gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.CurrentExpectType = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
