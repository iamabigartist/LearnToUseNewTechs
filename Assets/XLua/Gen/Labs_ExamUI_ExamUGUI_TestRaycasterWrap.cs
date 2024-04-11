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
    public class LabsExamUIExamUGUITestRaycasterWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Labs.ExamUI.ExamUGUI.TestRaycaster);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 2, 2);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_EventSystem", _g_get_m_EventSystem);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "m_GraphicRaycaster", _g_get_m_GraphicRaycaster);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_EventSystem", _s_set_m_EventSystem);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "m_GraphicRaycaster", _s_set_m_GraphicRaycaster);
            
			
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
					
					var gen_ret = new Labs.ExamUI.ExamUGUI.TestRaycaster();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Labs.ExamUI.ExamUGUI.TestRaycaster constructor!");
            
        }
        
		
        
		
        
        
        
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_EventSystem(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamUI.ExamUGUI.TestRaycaster gen_to_be_invoked = (Labs.ExamUI.ExamUGUI.TestRaycaster)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.m_EventSystem);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_m_GraphicRaycaster(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamUI.ExamUGUI.TestRaycaster gen_to_be_invoked = (Labs.ExamUI.ExamUGUI.TestRaycaster)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.m_GraphicRaycaster);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_EventSystem(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamUI.ExamUGUI.TestRaycaster gen_to_be_invoked = (Labs.ExamUI.ExamUGUI.TestRaycaster)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.m_EventSystem = (UnityEngine.EventSystems.EventSystem)translator.GetObject(L, 2, typeof(UnityEngine.EventSystems.EventSystem));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_m_GraphicRaycaster(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamUI.ExamUGUI.TestRaycaster gen_to_be_invoked = (Labs.ExamUI.ExamUGUI.TestRaycaster)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.m_GraphicRaycaster = (UnityEngine.UI.GraphicRaycaster)translator.GetObject(L, 2, typeof(UnityEngine.UI.GraphicRaycaster));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
