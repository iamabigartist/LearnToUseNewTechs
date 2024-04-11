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
    public class LabsExamBattleSystemExamFullBattleSystemCategoryTreeCategoryNodeWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode);
			Utils.BeginObjectRegister(type, L, translator, 0, 1, 3, 3);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "get_Item", _m_get_Item);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "parent_category", _g_get_parent_category);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "children_category_dict", _g_get_children_category_dict);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "category_value", _g_get_category_value);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "parent_category", _s_set_parent_category);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "children_category_dict", _s_set_children_category_dict);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "category_value", _s_set_category_value);
            
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "BFS", _m_BFS_xlua_st_);
            
			
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) >= 2 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING) && (LuaTypes.LUA_TNONE == LuaAPI.lua_type(L, 3) || translator.Assignable<Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode>(L, 3)))
				{
					string _category_value = LuaAPI.lua_tostring(L, 2);
					Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode[] _children_category_list = translator.GetParams<Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode>(L, 3);
					
					var gen_ret = new Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode(_category_value, _children_category_list);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_get_Item(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode gen_to_be_invoked = (Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
					string key = LuaAPI.lua_tostring(L, 2);
					translator.Push(L, gen_to_be_invoked[key]);
					
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BFS_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode _root = (Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode)translator.GetObject(L, 1, typeof(Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode));
                    
                        var gen_ret = Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode.BFS( _root );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_parent_category(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode gen_to_be_invoked = (Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.parent_category);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_children_category_dict(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode gen_to_be_invoked = (Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.children_category_dict);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_category_value(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode gen_to_be_invoked = (Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.category_value);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_parent_category(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode gen_to_be_invoked = (Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.parent_category = (Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode)translator.GetObject(L, 2, typeof(Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_children_category_dict(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode gen_to_be_invoked = (Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.children_category_dict = (System.Collections.Generic.Dictionary<string, Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode>)translator.GetObject(L, 2, typeof(System.Collections.Generic.Dictionary<string, Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_category_value(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode gen_to_be_invoked = (Labs.ExamBattleSystem.ExamFullBattleSystem.CategoryTree.CategoryNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.category_value = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
    }
}
