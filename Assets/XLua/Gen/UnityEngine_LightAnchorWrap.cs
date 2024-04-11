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
    public class UnityEngineLightAnchorWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.LightAnchor);
			Utils.BeginObjectRegister(type, L, translator, 0, 2, 8, 7);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SynchronizeOnTransform", _m_SynchronizeOnTransform);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateTransform", _m_UpdateTransform);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "yaw", _g_get_yaw);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pitch", _g_get_pitch);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "roll", _g_get_roll);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "distance", _g_get_distance);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "frameSpace", _g_get_frameSpace);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "anchorPosition", _g_get_anchorPosition);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "anchorPositionOverride", _g_get_anchorPositionOverride);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "anchorPositionOffset", _g_get_anchorPositionOffset);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "yaw", _s_set_yaw);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "pitch", _s_set_pitch);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "roll", _s_set_roll);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "distance", _s_set_distance);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "frameSpace", _s_set_frameSpace);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "anchorPositionOverride", _s_set_anchorPositionOverride);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "anchorPositionOffset", _s_set_anchorPositionOffset);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "NormalizeAngleDegree", _m_NormalizeAngleDegree_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new UnityEngine.LightAnchor();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.LightAnchor constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NormalizeAngleDegree_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    float _angle = (float)LuaAPI.lua_tonumber(L, 1);
                    
                        var gen_ret = UnityEngine.LightAnchor.NormalizeAngleDegree( _angle );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SynchronizeOnTransform(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.LightAnchor gen_to_be_invoked = (UnityEngine.LightAnchor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Camera _camera = (UnityEngine.Camera)translator.GetObject(L, 2, typeof(UnityEngine.Camera));
                    
                    gen_to_be_invoked.SynchronizeOnTransform( _camera );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateTransform(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.LightAnchor gen_to_be_invoked = (UnityEngine.LightAnchor)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Camera _camera = (UnityEngine.Camera)translator.GetObject(L, 2, typeof(UnityEngine.Camera));
                    UnityEngine.Vector3 _anchor;translator.Get(L, 3, out _anchor);
                    
                    gen_to_be_invoked.UpdateTransform( _camera, _anchor );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_yaw(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.LightAnchor gen_to_be_invoked = (UnityEngine.LightAnchor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.yaw);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pitch(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.LightAnchor gen_to_be_invoked = (UnityEngine.LightAnchor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.pitch);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_roll(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.LightAnchor gen_to_be_invoked = (UnityEngine.LightAnchor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.roll);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_distance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.LightAnchor gen_to_be_invoked = (UnityEngine.LightAnchor)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.distance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_frameSpace(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.LightAnchor gen_to_be_invoked = (UnityEngine.LightAnchor)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.frameSpace);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_anchorPosition(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.LightAnchor gen_to_be_invoked = (UnityEngine.LightAnchor)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.anchorPosition);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_anchorPositionOverride(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.LightAnchor gen_to_be_invoked = (UnityEngine.LightAnchor)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.anchorPositionOverride);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_anchorPositionOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.LightAnchor gen_to_be_invoked = (UnityEngine.LightAnchor)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.anchorPositionOffset);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_yaw(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.LightAnchor gen_to_be_invoked = (UnityEngine.LightAnchor)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.yaw = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pitch(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.LightAnchor gen_to_be_invoked = (UnityEngine.LightAnchor)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.pitch = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_roll(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.LightAnchor gen_to_be_invoked = (UnityEngine.LightAnchor)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.roll = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_distance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.LightAnchor gen_to_be_invoked = (UnityEngine.LightAnchor)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.distance = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_frameSpace(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.LightAnchor gen_to_be_invoked = (UnityEngine.LightAnchor)translator.FastGetCSObj(L, 1);
                UnityEngine.LightAnchor.UpDirection gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.frameSpace = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_anchorPositionOverride(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.LightAnchor gen_to_be_invoked = (UnityEngine.LightAnchor)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.anchorPositionOverride = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_anchorPositionOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.LightAnchor gen_to_be_invoked = (UnityEngine.LightAnchor)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.anchorPositionOffset = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
