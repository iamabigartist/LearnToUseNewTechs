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
    public class LabsTryImplementFSMFSM_2022_10MyRuleKeyWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Labs.TryImplementFSM.FSM_2022_10.MyRuleKey);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 2, 2);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "ExpectType", _g_get_ExpectType);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "EventType", _g_get_EventType);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "ExpectType", _s_set_ExpectType);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "EventType", _s_set_EventType);
            
			
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
					
					var gen_ret = new Labs.TryImplementFSM.FSM_2022_10.MyRuleKey();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Labs.TryImplementFSM.FSM_2022_10.MyRuleKey constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ExpectType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.TryImplementFSM.FSM_2022_10.MyRuleKey gen_to_be_invoked = (Labs.TryImplementFSM.FSM_2022_10.MyRuleKey)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.ExpectType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_EventType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.TryImplementFSM.FSM_2022_10.MyRuleKey gen_to_be_invoked = (Labs.TryImplementFSM.FSM_2022_10.MyRuleKey)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.EventType);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ExpectType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.TryImplementFSM.FSM_2022_10.MyRuleKey gen_to_be_invoked = (Labs.TryImplementFSM.FSM_2022_10.MyRuleKey)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ExpectType = (ProjectUtils.ValueFilter<Labs.TryImplementFSM.FSM_2022_10.TestFSM.ExpectType>)translator.GetObject(L, 2, typeof(ProjectUtils.ValueFilter<Labs.TryImplementFSM.FSM_2022_10.TestFSM.ExpectType>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_EventType(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.TryImplementFSM.FSM_2022_10.MyRuleKey gen_to_be_invoked = (Labs.TryImplementFSM.FSM_2022_10.MyRuleKey)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.EventType = (ProjectUtils.ValueFilter<Labs.TryImplementFSM.FSM_2022_10.MyEventData.EventType>)translator.GetObject(L, 2, typeof(ProjectUtils.ValueFilter<Labs.TryImplementFSM.FSM_2022_10.MyEventData.EventType>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
