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
    public class LabsExamBattleSystemExamActionTreeTaskNodeWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Labs.ExamBattleSystem.ExamActionTree.TaskNode);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 3, 3);
			
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "prev_nodes", _g_get_prev_nodes);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "next_nodes", _g_get_next_nodes);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "cur_procedure", _g_get_cur_procedure);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "prev_nodes", _s_set_prev_nodes);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "next_nodes", _s_set_next_nodes);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "cur_procedure", _s_set_cur_procedure);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "SetOrder", _m_SetOrder_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<Labs.ExamBattleSystem.ExamActionTree.Procedure>(L, 2))
				{
					Labs.ExamBattleSystem.ExamActionTree.Procedure _cur_procedure;translator.Get(L, 2, out _cur_procedure);
					
					var gen_ret = new Labs.ExamBattleSystem.ExamActionTree.TaskNode(_cur_procedure);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Labs.ExamBattleSystem.ExamActionTree.TaskNode constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetOrder_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    Labs.ExamBattleSystem.ExamActionTree.TaskNode _node_before = (Labs.ExamBattleSystem.ExamActionTree.TaskNode)translator.GetObject(L, 1, typeof(Labs.ExamBattleSystem.ExamActionTree.TaskNode));
                    Labs.ExamBattleSystem.ExamActionTree.TaskNode _node_after = (Labs.ExamBattleSystem.ExamActionTree.TaskNode)translator.GetObject(L, 2, typeof(Labs.ExamBattleSystem.ExamActionTree.TaskNode));
                    
                    Labs.ExamBattleSystem.ExamActionTree.TaskNode.SetOrder( _node_before, _node_after );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_prev_nodes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamBattleSystem.ExamActionTree.TaskNode gen_to_be_invoked = (Labs.ExamBattleSystem.ExamActionTree.TaskNode)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.prev_nodes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_next_nodes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamBattleSystem.ExamActionTree.TaskNode gen_to_be_invoked = (Labs.ExamBattleSystem.ExamActionTree.TaskNode)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.next_nodes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cur_procedure(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamBattleSystem.ExamActionTree.TaskNode gen_to_be_invoked = (Labs.ExamBattleSystem.ExamActionTree.TaskNode)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.cur_procedure);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_prev_nodes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamBattleSystem.ExamActionTree.TaskNode gen_to_be_invoked = (Labs.ExamBattleSystem.ExamActionTree.TaskNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.prev_nodes = (System.Collections.Generic.List<Labs.ExamBattleSystem.ExamActionTree.TaskNode>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Labs.ExamBattleSystem.ExamActionTree.TaskNode>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_next_nodes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamBattleSystem.ExamActionTree.TaskNode gen_to_be_invoked = (Labs.ExamBattleSystem.ExamActionTree.TaskNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.next_nodes = (System.Collections.Generic.List<Labs.ExamBattleSystem.ExamActionTree.TaskNode>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Labs.ExamBattleSystem.ExamActionTree.TaskNode>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_cur_procedure(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamBattleSystem.ExamActionTree.TaskNode gen_to_be_invoked = (Labs.ExamBattleSystem.ExamActionTree.TaskNode)translator.FastGetCSObj(L, 1);
                Labs.ExamBattleSystem.ExamActionTree.Procedure gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.cur_procedure = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
