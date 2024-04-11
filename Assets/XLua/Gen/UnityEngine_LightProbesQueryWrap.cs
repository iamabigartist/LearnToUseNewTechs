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
    public class UnityEngineLightProbesQueryWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.LightProbesQuery);
			Utils.BeginObjectRegister(type, L, translator, 0, 3, 1, 0);
			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Dispose", _m_Dispose);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CalculateInterpolatedLightAndOcclusionProbe", _m_CalculateInterpolatedLightAndOcclusionProbe);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CalculateInterpolatedLightAndOcclusionProbes", _m_CalculateInterpolatedLightAndOcclusionProbes);
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsCreated", _g_get_IsCreated);
            
			
			
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
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<Unity.Collections.Allocator>(L, 2))
				{
					Unity.Collections.Allocator _allocator;translator.Get(L, 2, out _allocator);
					
					var gen_ret = new UnityEngine.LightProbesQuery(_allocator);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
				if (LuaAPI.lua_gettop(L) == 1)
				{
				    translator.Push(L, default(UnityEngine.LightProbesQuery));
			        return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.LightProbesQuery constructor!");
            
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Dispose(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.LightProbesQuery gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.Dispose(  );
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<Unity.Jobs.JobHandle>(L, 2)) 
                {
                    Unity.Jobs.JobHandle _inputDeps;translator.Get(L, 2, out _inputDeps);
                    
                        var gen_ret = gen_to_be_invoked.Dispose( _inputDeps );
                        translator.Push(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.LightProbesQuery.Dispose!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalculateInterpolatedLightAndOcclusionProbe(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.LightProbesQuery gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 2, out _position);
                    int _tetrahedronIndex = LuaAPI.xlua_tointeger(L, 3);
                    UnityEngine.Rendering.SphericalHarmonicsL2 _lightProbe;
                    UnityEngine.Vector4 _occlusionProbe;
                    
                    gen_to_be_invoked.CalculateInterpolatedLightAndOcclusionProbe( _position, ref _tetrahedronIndex, out _lightProbe, out _occlusionProbe );
                    LuaAPI.xlua_pushinteger(L, _tetrahedronIndex);
                        
                    translator.Push(L, _lightProbe);
                        
                    translator.PushUnityEngineVector4(L, _occlusionProbe);
                        
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 3;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalculateInterpolatedLightAndOcclusionProbes(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                UnityEngine.LightProbesQuery gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    Unity.Collections.NativeArray<UnityEngine.Vector3> _positions;translator.Get(L, 2, out _positions);
                    Unity.Collections.NativeArray<int> _tetrahedronIndices;translator.Get(L, 3, out _tetrahedronIndices);
                    Unity.Collections.NativeArray<UnityEngine.Rendering.SphericalHarmonicsL2> _lightProbes;translator.Get(L, 4, out _lightProbes);
                    Unity.Collections.NativeArray<UnityEngine.Vector4> _occlusionProbes;translator.Get(L, 5, out _occlusionProbes);
                    
                    gen_to_be_invoked.CalculateInterpolatedLightAndOcclusionProbes( _positions, _tetrahedronIndices, _lightProbes, _occlusionProbes );
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsCreated(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                UnityEngine.LightProbesQuery gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsCreated);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		
    }
}
