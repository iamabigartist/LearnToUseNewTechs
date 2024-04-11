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
    public class LabsExamUIExamEditorGUIMySingletonWindowWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Labs.ExamUI.ExamEditorGUI.MySingletonWindow);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 4, 4);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "MouseOverWindow", _g_get_MouseOverWindow);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "FocusWindow", _g_get_FocusWindow);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SelectedObject", _g_get_SelectedObject);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "SelectedContextObject", _g_get_SelectedContextObject);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "MouseOverWindow", _s_set_MouseOverWindow);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "FocusWindow", _s_set_FocusWindow);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "SelectedObject", _s_set_SelectedObject);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "SelectedContextObject", _s_set_SelectedContextObject);
            
			
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
					
					var gen_ret = new Labs.ExamUI.ExamEditorGUI.MySingletonWindow();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Labs.ExamUI.ExamEditorGUI.MySingletonWindow constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_MouseOverWindow(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamUI.ExamEditorGUI.MySingletonWindow gen_to_be_invoked = (Labs.ExamUI.ExamEditorGUI.MySingletonWindow)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.MouseOverWindow);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_FocusWindow(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamUI.ExamEditorGUI.MySingletonWindow gen_to_be_invoked = (Labs.ExamUI.ExamEditorGUI.MySingletonWindow)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.FocusWindow);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SelectedObject(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamUI.ExamEditorGUI.MySingletonWindow gen_to_be_invoked = (Labs.ExamUI.ExamEditorGUI.MySingletonWindow)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.SelectedObject);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_SelectedContextObject(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamUI.ExamEditorGUI.MySingletonWindow gen_to_be_invoked = (Labs.ExamUI.ExamEditorGUI.MySingletonWindow)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.SelectedContextObject);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_MouseOverWindow(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamUI.ExamEditorGUI.MySingletonWindow gen_to_be_invoked = (Labs.ExamUI.ExamEditorGUI.MySingletonWindow)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.MouseOverWindow = (UnityEditor.EditorWindow)translator.GetObject(L, 2, typeof(UnityEditor.EditorWindow));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_FocusWindow(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamUI.ExamEditorGUI.MySingletonWindow gen_to_be_invoked = (Labs.ExamUI.ExamEditorGUI.MySingletonWindow)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.FocusWindow = (UnityEditor.EditorWindow)translator.GetObject(L, 2, typeof(UnityEditor.EditorWindow));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SelectedObject(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamUI.ExamEditorGUI.MySingletonWindow gen_to_be_invoked = (Labs.ExamUI.ExamEditorGUI.MySingletonWindow)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.SelectedObject = (UnityEngine.Object)translator.GetObject(L, 2, typeof(UnityEngine.Object));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_SelectedContextObject(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamUI.ExamEditorGUI.MySingletonWindow gen_to_be_invoked = (Labs.ExamUI.ExamEditorGUI.MySingletonWindow)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.SelectedContextObject = (UnityEngine.Object)translator.GetObject(L, 2, typeof(UnityEngine.Object));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
