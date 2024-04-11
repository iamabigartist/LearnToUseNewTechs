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
    public class LabsTryImplementFSMRM_2022_11_2TestBonePlatingBonePlatingRMWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 6, 6);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "PlateCount", _g_get_PlateCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ActivatedStamp", _g_get_ActivatedStamp);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CooldownStamp", _g_get_CooldownStamp);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ActivatedDuration", _g_get_ActivatedDuration);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CooldownDuration", _g_get_CooldownDuration);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "UsageState", _g_get_UsageState);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "PlateCount", _s_set_PlateCount);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ActivatedStamp", _s_set_ActivatedStamp);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "CooldownStamp", _s_set_CooldownStamp);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ActivatedDuration", _s_set_ActivatedDuration);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "CooldownDuration", _s_set_CooldownDuration);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "UsageState", _s_set_UsageState);
            
			
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
					
					var gen_ret = new Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PlateCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM gen_to_be_invoked = (Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.PlateCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ActivatedStamp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM gen_to_be_invoked = (Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.ActivatedStamp);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CooldownStamp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM gen_to_be_invoked = (Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.CooldownStamp);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ActivatedDuration(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM gen_to_be_invoked = (Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.ActivatedDuration);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CooldownDuration(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM gen_to_be_invoked = (Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.CooldownDuration);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_UsageState(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM gen_to_be_invoked = (Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.UsageState);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_PlateCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM gen_to_be_invoked = (Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM)translator.FastGetCSObj(L, 1);
                Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.Resource gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.PlateCount = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ActivatedStamp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM gen_to_be_invoked = (Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM)translator.FastGetCSObj(L, 1);
                Labs.TryImplementFSM.RM_2022_11_2.TimeStamp gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.ActivatedStamp = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CooldownStamp(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM gen_to_be_invoked = (Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM)translator.FastGetCSObj(L, 1);
                Labs.TryImplementFSM.RM_2022_11_2.TimeStamp gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.CooldownStamp = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ActivatedDuration(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM gen_to_be_invoked = (Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.ActivatedDuration = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CooldownDuration(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM gen_to_be_invoked = (Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.CooldownDuration = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_UsageState(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM gen_to_be_invoked = (Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.UsageState = (Labs.TryImplementFSM.RM_2022_11_2.State<Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM.UsageStateType>)translator.GetObject(L, 2, typeof(Labs.TryImplementFSM.RM_2022_11_2.State<Labs.TryImplementFSM.RM_2022_11_2.TestBonePlating.BonePlatingRM.UsageStateType>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
