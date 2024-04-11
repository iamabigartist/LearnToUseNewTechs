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
    public class LabsExamEffectProcessorBattleMechanicsSystemEntryManagerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Labs.ExamEffectProcessor.BattleMechanicsSystem.EntryManager);
			Utils.BeginObjectRegister(type, L, translator, 0, 1, 1, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ExecuteFrame", _m_ExecuteFrame);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "entry_request_list", _g_get_entry_request_list);
            
			
			
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
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<System.Collections.Generic.LinkedList<Labs.ExamEffectProcessor.BattleMechanicsSystem.IEntryPoint>>(L, 2))
				{
					System.Collections.Generic.LinkedList<Labs.ExamEffectProcessor.BattleMechanicsSystem.IEntryPoint> _entry_request_list = (System.Collections.Generic.LinkedList<Labs.ExamEffectProcessor.BattleMechanicsSystem.IEntryPoint>)translator.GetObject(L, 2, typeof(System.Collections.Generic.LinkedList<Labs.ExamEffectProcessor.BattleMechanicsSystem.IEntryPoint>));
					
					var gen_ret = new Labs.ExamEffectProcessor.BattleMechanicsSystem.EntryManager(_entry_request_list);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Labs.ExamEffectProcessor.BattleMechanicsSystem.EntryManager constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExecuteFrame(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Labs.ExamEffectProcessor.BattleMechanicsSystem.EntryManager gen_to_be_invoked = (Labs.ExamEffectProcessor.BattleMechanicsSystem.EntryManager)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ExecuteFrame(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_entry_request_list(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamEffectProcessor.BattleMechanicsSystem.EntryManager gen_to_be_invoked = (Labs.ExamEffectProcessor.BattleMechanicsSystem.EntryManager)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.entry_request_list);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
