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
    public class LabsExamBattleSystemExamActionTreeTaskTreeWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Labs.ExamBattleSystem.ExamActionTree.TaskTree);
			Utils.BeginObjectRegister(type, L, translator, 0, 1, 0, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddNode", _m_AddNode);
			
			
			
			
			
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
					
					var gen_ret = new Labs.ExamBattleSystem.ExamActionTree.TaskTree();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Labs.ExamBattleSystem.ExamActionTree.TaskTree constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddNode(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Labs.ExamBattleSystem.ExamActionTree.TaskTree gen_to_be_invoked = (Labs.ExamBattleSystem.ExamActionTree.TaskTree)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Labs.ExamBattleSystem.ExamActionTree.Procedure _procedure;translator.Get(L, 2, out _procedure);
                    Labs.ExamBattleSystem.ExamActionTree.TaskNode[] _before_nodes = (Labs.ExamBattleSystem.ExamActionTree.TaskNode[])translator.GetObject(L, 3, typeof(Labs.ExamBattleSystem.ExamActionTree.TaskNode[]));
                    Labs.ExamBattleSystem.ExamActionTree.TaskNode[] _after_nodes = (Labs.ExamBattleSystem.ExamActionTree.TaskNode[])translator.GetObject(L, 4, typeof(Labs.ExamBattleSystem.ExamActionTree.TaskNode[]));
                    
                    gen_to_be_invoked.AddNode( _procedure, _before_nodes, _after_nodes );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		
    }
}
