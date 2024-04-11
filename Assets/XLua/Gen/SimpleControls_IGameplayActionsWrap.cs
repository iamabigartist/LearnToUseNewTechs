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
    public class SimpleControlsIGameplayActionsWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(SimpleControls.IGameplayActions);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnFire", _m_OnFire);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnMove", _m_OnMove);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnLook", _m_OnLook);
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "SimpleControls.IGameplayActions does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnFire(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                SimpleControls.IGameplayActions gen_to_be_invoked = (SimpleControls.IGameplayActions)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_OnMove(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                SimpleControls.IGameplayActions gen_to_be_invoked = (SimpleControls.IGameplayActions)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                SimpleControls.IGameplayActions gen_to_be_invoked = (SimpleControls.IGameplayActions)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.InputSystem.InputAction.CallbackContext _context;translator.Get(L, 2, out _context);
                    
                    gen_to_be_invoked.OnLook( _context );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
