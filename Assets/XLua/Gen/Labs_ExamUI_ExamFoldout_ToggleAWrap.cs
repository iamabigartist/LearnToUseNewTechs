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
    public class LabsExamUIExamFoldoutToggleAWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Labs.ExamUI.ExamFoldout.ToggleA);
			Utils.BeginObjectRegister(type, L, translator, 0, 1, 3, 2);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetValue", _m_SetValue);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "contentContainer", _g_get_contentContainer);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Value", _g_get_Value);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "OnValueChanged", _g_get_OnValueChanged);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "Value", _s_set_Value);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "OnValueChanged", _s_set_OnValueChanged);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 5, 0, 0);
			
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "UssName", Labs.ExamUI.ExamFoldout.ToggleA.UssName);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "IconUssName", Labs.ExamUI.ExamFoldout.ToggleA.IconUssName);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "IconOnUssName", Labs.ExamUI.ExamFoldout.ToggleA.IconOnUssName);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "IconOffUssName", Labs.ExamUI.ExamFoldout.ToggleA.IconOffUssName);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					var gen_ret = new Labs.ExamUI.ExamFoldout.ToggleA();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Labs.ExamUI.ExamFoldout.ToggleA constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetValue(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Labs.ExamUI.ExamFoldout.ToggleA gen_to_be_invoked = (Labs.ExamUI.ExamFoldout.ToggleA)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    bool _new_value = LuaAPI.lua_toboolean(L, 2);
                    bool _notify = LuaAPI.lua_toboolean(L, 3);
                    
                    gen_to_be_invoked.SetValue( _new_value, _notify );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_contentContainer(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamUI.ExamFoldout.ToggleA gen_to_be_invoked = (Labs.ExamUI.ExamFoldout.ToggleA)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.contentContainer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Value(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamUI.ExamFoldout.ToggleA gen_to_be_invoked = (Labs.ExamUI.ExamFoldout.ToggleA)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.Value);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnValueChanged(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamUI.ExamFoldout.ToggleA gen_to_be_invoked = (Labs.ExamUI.ExamFoldout.ToggleA)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.OnValueChanged);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_Value(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamUI.ExamFoldout.ToggleA gen_to_be_invoked = (Labs.ExamUI.ExamFoldout.ToggleA)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.Value = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnValueChanged(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamUI.ExamFoldout.ToggleA gen_to_be_invoked = (Labs.ExamUI.ExamFoldout.ToggleA)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.OnValueChanged = translator.GetDelegate<System.Action<bool>>(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
