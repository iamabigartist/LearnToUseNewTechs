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
    public class UnityEngineOverlapBoxCommandWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.OverlapBoxCommand);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 5, 5);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "center", _g_get_center);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "halfExtents", _g_get_halfExtents);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "orientation", _g_get_orientation);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "physicsScene", _g_get_physicsScene);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "queryParameters", _g_get_queryParameters);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "center", _s_set_center);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "halfExtents", _s_set_halfExtents);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "orientation", _s_set_orientation);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "physicsScene", _s_set_physicsScene);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "queryParameters", _s_set_queryParameters);
            
			
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
				if(LuaAPI.lua_gettop(L) == 5 && translator.Assignable<UnityEngine.Vector3>(L, 2) && translator.Assignable<UnityEngine.Vector3>(L, 3) && translator.Assignable<UnityEngine.Quaternion>(L, 4) && translator.Assignable<UnityEngine.QueryParameters>(L, 5))
				{
					UnityEngine.Vector3 _center;translator.Get(L, 2, out _center);
					UnityEngine.Vector3 _halfExtents;translator.Get(L, 3, out _halfExtents);
					UnityEngine.Quaternion _orientation;translator.Get(L, 4, out _orientation);
					UnityEngine.QueryParameters _queryParameters;translator.Get(L, 5, out _queryParameters);
					
					var gen_ret = new UnityEngine.OverlapBoxCommand(_center, _halfExtents, _orientation, _queryParameters);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 6 && translator.Assignable<UnityEngine.PhysicsScene>(L, 2) && translator.Assignable<UnityEngine.Vector3>(L, 3) && translator.Assignable<UnityEngine.Vector3>(L, 4) && translator.Assignable<UnityEngine.Quaternion>(L, 5) && translator.Assignable<UnityEngine.QueryParameters>(L, 6))
				{
					UnityEngine.PhysicsScene _physicsScene;translator.Get(L, 2, out _physicsScene);
					UnityEngine.Vector3 _center;translator.Get(L, 3, out _center);
					UnityEngine.Vector3 _halfExtents;translator.Get(L, 4, out _halfExtents);
					UnityEngine.Quaternion _orientation;translator.Get(L, 5, out _orientation);
					UnityEngine.QueryParameters _queryParameters;translator.Get(L, 6, out _queryParameters);
					
					var gen_ret = new UnityEngine.OverlapBoxCommand(_physicsScene, _center, _halfExtents, _orientation, _queryParameters);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
				if (LuaAPI.lua_gettop(L) == 1)
				{
				    translator.Push(L, default(UnityEngine.OverlapBoxCommand));
			        return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.OverlapBoxCommand constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ScheduleBatch_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& translator.Assignable<Unity.Collections.NativeArray<UnityEngine.OverlapBoxCommand>>(L, 1)&& translator.Assignable<Unity.Collections.NativeArray<UnityEngine.ColliderHit>>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& translator.Assignable<Unity.Jobs.JobHandle>(L, 5)) 
                {
                    Unity.Collections.NativeArray<UnityEngine.OverlapBoxCommand> _commands;translator.Get(L, 1, out _commands);
                    Unity.Collections.NativeArray<UnityEngine.ColliderHit> _results;translator.Get(L, 2, out _results);
                    int _minCommandsPerJob = LuaAPI.xlua_tointeger(L, 3);
                    int _maxHits = LuaAPI.xlua_tointeger(L, 4);
                    Unity.Jobs.JobHandle _dependsOn;translator.Get(L, 5, out _dependsOn);
                    
                        var gen_ret = UnityEngine.OverlapBoxCommand.ScheduleBatch( _commands, _results, _minCommandsPerJob, _maxHits, _dependsOn );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<Unity.Collections.NativeArray<UnityEngine.OverlapBoxCommand>>(L, 1)&& translator.Assignable<Unity.Collections.NativeArray<UnityEngine.ColliderHit>>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    Unity.Collections.NativeArray<UnityEngine.OverlapBoxCommand> _commands;translator.Get(L, 1, out _commands);
                    Unity.Collections.NativeArray<UnityEngine.ColliderHit> _results;translator.Get(L, 2, out _results);
                    int _minCommandsPerJob = LuaAPI.xlua_tointeger(L, 3);
                    int _maxHits = LuaAPI.xlua_tointeger(L, 4);
                    
                        var gen_ret = UnityEngine.OverlapBoxCommand.ScheduleBatch( _commands, _results, _minCommandsPerJob, _maxHits );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.OverlapBoxCommand.ScheduleBatch!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_center(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.OverlapBoxCommand gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.center);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_halfExtents(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.OverlapBoxCommand gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.halfExtents);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_orientation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.OverlapBoxCommand gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.PushUnityEngineQuaternion(L, gen_to_be_invoked.orientation);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_physicsScene(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.OverlapBoxCommand gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.Push(L, gen_to_be_invoked.physicsScene);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_queryParameters(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.OverlapBoxCommand gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                translator.Push(L, gen_to_be_invoked.queryParameters);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_center(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.OverlapBoxCommand gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.center = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_halfExtents(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.OverlapBoxCommand gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.halfExtents = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_orientation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.OverlapBoxCommand gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.Quaternion gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.orientation = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_physicsScene(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.OverlapBoxCommand gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.PhysicsScene gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.physicsScene = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_queryParameters(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.OverlapBoxCommand gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                UnityEngine.QueryParameters gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.queryParameters = gen_value;
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
