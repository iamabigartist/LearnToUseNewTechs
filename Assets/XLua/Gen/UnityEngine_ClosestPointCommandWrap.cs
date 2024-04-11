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
    public class UnityEngineClosestPointCommandWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.ClosestPointCommand);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 5, 5);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "point", _g_get_point);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "colliderInstanceID", _g_get_colliderInstanceID);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "position", _g_get_position);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "rotation", _g_get_rotation);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "scale", _g_get_scale);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "point", _s_set_point);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "colliderInstanceID", _s_set_colliderInstanceID);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "position", _s_set_position);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "rotation", _s_set_rotation);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "scale", _s_set_scale);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "ScheduleBatch", _m_ScheduleBatch_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 6 && translator.Assignable<UnityEngine.Vector3>(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && translator.Assignable<UnityEngine.Vector3>(L, 4) && translator.Assignable<UnityEngine.Quaternion>(L, 5) && translator.Assignable<UnityEngine.Vector3>(L, 6))
				{
					UnityEngine.Vector3 _point;translator.Get(L, 2, out _point);
					int _colliderInstanceID = LuaAPI.xlua_tointeger(L, 3);
					UnityEngine.Vector3 _position;translator.Get(L, 4, out _position);
					UnityEngine.Quaternion _rotation;translator.Get(L, 5, out _rotation);
					UnityEngine.Vector3 _scale;translator.Get(L, 6, out _scale);
					
					var gen_ret = new UnityEngine.ClosestPointCommand(_point, _colliderInstanceID, _position, _rotation, _scale);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 6 && translator.Assignable<UnityEngine.Vector3>(L, 2) && translator.Assignable<UnityEngine.Collider>(L, 3) && translator.Assignable<UnityEngine.Vector3>(L, 4) && translator.Assignable<UnityEngine.Quaternion>(L, 5) && translator.Assignable<UnityEngine.Vector3>(L, 6))
				{
					UnityEngine.Vector3 _point;translator.Get(L, 2, out _point);
					UnityEngine.Collider _collider = (UnityEngine.Collider)translator.GetObject(L, 3, typeof(UnityEngine.Collider));
					UnityEngine.Vector3 _position;translator.Get(L, 4, out _position);
					UnityEngine.Quaternion _rotation;translator.Get(L, 5, out _rotation);
					UnityEngine.Vector3 _scale;translator.Get(L, 6, out _scale);
					
					var gen_ret = new UnityEngine.ClosestPointCommand(_point, _collider, _position, _rotation, _scale);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
				if (LuaAPI.lua_gettop(L) == 1)
				{
				    translator.Push(L, default(UnityEngine.ClosestPointCommand));
			        return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.ClosestPointCommand constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ScheduleBatch_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<Unity.Collections.NativeArray<UnityEngine.ClosestPointCommand>>(L, 1)&& translator.Assignable<Unity.Collections.NativeArray<UnityEngine.Vector3>>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& translator.Assignable<Unity.Jobs.JobHandle>(L, 4)) 
                {
                    Unity.Collections.NativeArray<UnityEngine.ClosestPointCommand> _commands;translator.Get(L, 1, out _commands);
                    Unity.Collections.NativeArray<UnityEngine.Vector3> _results;translator.Get(L, 2, out _results);
                    int _minCommandsPerJob = LuaAPI.xlua_tointeger(L, 3);
                    Unity.Jobs.JobHandle _dependsOn;translator.Get(L, 4, out _dependsOn);
                    
                        var gen_ret = UnityEngine.ClosestPointCommand.ScheduleBatch( _commands, _results, _minCommandsPerJob, _dependsOn );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<Unity.Collections.NativeArray<UnityEngine.ClosestPointCommand>>(L, 1)&& translator.Assignable<Unity.Collections.NativeArray<UnityEngine.Vector3>>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    Unity.Collections.NativeArray<UnityEngine.ClosestPointCommand> _commands;translator.Get(L, 1, out _commands);
                    Unity.Collections.NativeArray<UnityEngine.Vector3> _results;translator.Get(L, 2, out _results);
                    int _minCommandsPerJob = LuaAPI.xlua_tointeger(L, 3);
                    
                        var gen_ret = UnityEngine.ClosestPointCommand.ScheduleBatch( _commands, _results, _minCommandsPerJob );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.ClosestPointCommand.ScheduleBatch!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_point(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ClosestPointCommand gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.point);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_colliderInstanceID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ClosestPointCommand gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.colliderInstanceID);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_position(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ClosestPointCommand gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.position);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rotation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ClosestPointCommand gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.PushUnityEngineQuaternion(L, gen_to_be_invoked.rotation);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_scale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ClosestPointCommand gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.scale);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_point(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ClosestPointCommand gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.point = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_colliderInstanceID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ClosestPointCommand gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.colliderInstanceID = LuaAPI.xlua_tointeger(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_position(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ClosestPointCommand gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.position = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_rotation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ClosestPointCommand gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.Quaternion gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.rotation = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_scale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.ClosestPointCommand gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.scale = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
