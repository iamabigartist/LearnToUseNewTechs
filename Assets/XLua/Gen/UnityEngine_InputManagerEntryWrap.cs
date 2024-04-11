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
    public class UnityEngineInputManagerEntryWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.InputManagerEntry);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 14, 14);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "name", _g_get_name);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "desc", _g_get_desc);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "btnNegative", _g_get_btnNegative);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "btnPositive", _g_get_btnPositive);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "altBtnNegative", _g_get_altBtnNegative);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "altBtnPositive", _g_get_altBtnPositive);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "gravity", _g_get_gravity);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "deadZone", _g_get_deadZone);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "sensitivity", _g_get_sensitivity);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "snap", _g_get_snap);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "invert", _g_get_invert);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "kind", _g_get_kind);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "axis", _g_get_axis);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "joystick", _g_get_joystick);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "name", _s_set_name);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "desc", _s_set_desc);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "btnNegative", _s_set_btnNegative);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "btnPositive", _s_set_btnPositive);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "altBtnNegative", _s_set_altBtnNegative);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "altBtnPositive", _s_set_altBtnPositive);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "gravity", _s_set_gravity);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "deadZone", _s_set_deadZone);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "sensitivity", _s_set_sensitivity);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "snap", _s_set_snap);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "invert", _s_set_invert);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "kind", _s_set_kind);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "axis", _s_set_axis);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "joystick", _s_set_joystick);
            
			
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
					
					var gen_ret = new UnityEngine.InputManagerEntry();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.InputManagerEntry constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_name(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.name);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_desc(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.desc);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_btnNegative(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.btnNegative);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_btnPositive(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.btnPositive);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_altBtnNegative(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.altBtnNegative);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_altBtnPositive(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.altBtnPositive);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_gravity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.gravity);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_deadZone(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.deadZone);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sensitivity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.sensitivity);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_snap(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.snap);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_invert(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.invert);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_kind(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.kind);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_axis(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.axis);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_joystick(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.joystick);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_name(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_desc(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.desc = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_btnNegative(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.btnNegative = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_btnPositive(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.btnPositive = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_altBtnNegative(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.altBtnNegative = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_altBtnPositive(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.altBtnPositive = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_gravity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.gravity = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_deadZone(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.deadZone = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_sensitivity(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.sensitivity = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_snap(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.snap = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_invert(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.invert = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_kind(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                UnityEngine.InputManagerEntry.Kind gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.kind = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_axis(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                UnityEngine.InputManagerEntry.Axis gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.axis = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_joystick(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.InputManagerEntry gen_to_be_invoked = (UnityEngine.InputManagerEntry)translator.FastGetCSObj(L, 1);
                UnityEngine.InputManagerEntry.Joy gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.joystick = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
