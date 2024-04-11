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
    public class SimpleController_UsingPlayerInputWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(SimpleController_UsingPlayerInput);
			Utils.BeginObjectRegister(type, L, translator, 0, 5, 4, 4);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnMove", _m_OnMove);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnLook", _m_OnLook);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnFire", _m_OnFire);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnGUI", _m_OnGUI);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Update", _m_Update);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "moveSpeed", _g_get_moveSpeed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "rotateSpeed", _g_get_rotateSpeed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "burstSpeed", _g_get_burstSpeed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "projectile", _g_get_projectile);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "moveSpeed", _s_set_moveSpeed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "rotateSpeed", _s_set_rotateSpeed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "burstSpeed", _s_set_burstSpeed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "projectile", _s_set_projectile);
            
			
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
					
					var gen_ret = new SimpleController_UsingPlayerInput();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to SimpleController_UsingPlayerInput constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnMove(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                SimpleController_UsingPlayerInput gen_to_be_invoked = (SimpleController_UsingPlayerInput)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.InputSystem.InputAction.CallbackContext _context;translator.Get(L, 2, out _context);
                    
                    gen_to_be_invoked.OnMove( _context );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnLook(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                SimpleController_UsingPlayerInput gen_to_be_invoked = (SimpleController_UsingPlayerInput)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.InputSystem.InputAction.CallbackContext _context;translator.Get(L, 2, out _context);
                    
                    gen_to_be_invoked.OnLook( _context );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnFire(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                SimpleController_UsingPlayerInput gen_to_be_invoked = (SimpleController_UsingPlayerInput)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.InputSystem.InputAction.CallbackContext _context;translator.Get(L, 2, out _context);
                    
                    gen_to_be_invoked.OnFire( _context );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnGUI(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                SimpleController_UsingPlayerInput gen_to_be_invoked = (SimpleController_UsingPlayerInput)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnGUI(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                SimpleController_UsingPlayerInput gen_to_be_invoked = (SimpleController_UsingPlayerInput)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Update(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_moveSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                SimpleController_UsingPlayerInput gen_to_be_invoked = (SimpleController_UsingPlayerInput)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.moveSpeed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rotateSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                SimpleController_UsingPlayerInput gen_to_be_invoked = (SimpleController_UsingPlayerInput)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.rotateSpeed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_burstSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                SimpleController_UsingPlayerInput gen_to_be_invoked = (SimpleController_UsingPlayerInput)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.burstSpeed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_projectile(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                SimpleController_UsingPlayerInput gen_to_be_invoked = (SimpleController_UsingPlayerInput)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.projectile);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_moveSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                SimpleController_UsingPlayerInput gen_to_be_invoked = (SimpleController_UsingPlayerInput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.moveSpeed = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_rotateSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                SimpleController_UsingPlayerInput gen_to_be_invoked = (SimpleController_UsingPlayerInput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.rotateSpeed = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_burstSpeed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                SimpleController_UsingPlayerInput gen_to_be_invoked = (SimpleController_UsingPlayerInput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.burstSpeed = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_projectile(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                SimpleController_UsingPlayerInput gen_to_be_invoked = (SimpleController_UsingPlayerInput)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.projectile = (UnityEngine.GameObject)translator.GetObject(L, 2, typeof(UnityEngine.GameObject));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
