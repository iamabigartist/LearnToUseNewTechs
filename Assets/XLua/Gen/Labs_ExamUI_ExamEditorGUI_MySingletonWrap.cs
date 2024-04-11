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
    public class LabsExamUIExamEditorGUIMySingletonWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Labs.ExamUI.ExamEditorGUI.MySingleton);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 3, 3);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Update", _m_Update);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Modify", _m_Modify);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Log", _m_Log);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_Number", _g_get_m_Number);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_Strings", _g_get_m_Strings);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CurrentWindow", _g_get_CurrentWindow);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_Number", _s_set_m_Number);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_Strings", _s_set_m_Strings);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "CurrentWindow", _s_set_CurrentWindow);
            
			
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
					
					var gen_ret = new Labs.ExamUI.ExamEditorGUI.MySingleton();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Labs.ExamUI.ExamEditorGUI.MySingleton constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Update(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Labs.ExamUI.ExamEditorGUI.MySingleton gen_to_be_invoked = (Labs.ExamUI.ExamEditorGUI.MySingleton)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Update(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Modify(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Labs.ExamUI.ExamEditorGUI.MySingleton gen_to_be_invoked = (Labs.ExamUI.ExamEditorGUI.MySingleton)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Modify(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Log(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Labs.ExamUI.ExamEditorGUI.MySingleton gen_to_be_invoked = (Labs.ExamUI.ExamEditorGUI.MySingleton)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Log(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_Number(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamUI.ExamEditorGUI.MySingleton gen_to_be_invoked = (Labs.ExamUI.ExamEditorGUI.MySingleton)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.m_Number);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_Strings(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamUI.ExamEditorGUI.MySingleton gen_to_be_invoked = (Labs.ExamUI.ExamEditorGUI.MySingleton)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.m_Strings);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CurrentWindow(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamUI.ExamEditorGUI.MySingleton gen_to_be_invoked = (Labs.ExamUI.ExamEditorGUI.MySingleton)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.CurrentWindow);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_Number(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamUI.ExamEditorGUI.MySingleton gen_to_be_invoked = (Labs.ExamUI.ExamEditorGUI.MySingleton)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.m_Number = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_Strings(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamUI.ExamEditorGUI.MySingleton gen_to_be_invoked = (Labs.ExamUI.ExamEditorGUI.MySingleton)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.m_Strings = (System.Collections.Generic.List<string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<string>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_CurrentWindow(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamUI.ExamEditorGUI.MySingleton gen_to_be_invoked = (Labs.ExamUI.ExamEditorGUI.MySingleton)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.CurrentWindow = (Labs.ExamUI.ExamEditorGUI.MySingletonWindow)translator.GetObject(L, 2, typeof(Labs.ExamUI.ExamEditorGUI.MySingletonWindow));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
