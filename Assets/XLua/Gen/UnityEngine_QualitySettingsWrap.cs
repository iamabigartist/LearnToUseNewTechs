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
    public class UnityEngineQualitySettingsWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(UnityEngine.QualitySettings);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 18, 50, 46);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "IncreaseLevel", _m_IncreaseLevel_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DecreaseLevel", _m_DecreaseLevel_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetQualityLevel", _m_SetQualityLevel_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "ForEach", _m_ForEach_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetLODSettings", _m_SetLODSettings_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "SetTextureMipmapLimitSettings", _m_SetTextureMipmapLimitSettings_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetTextureMipmapLimitSettings", _m_GetTextureMipmapLimitSettings_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetRenderPipelineAssetAt", _m_GetRenderPipelineAssetAt_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetQualityLevel", _m_GetQualityLevel_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetQualitySettings", _m_GetQualitySettings_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IsPlatformIncluded", _m_IsPlatformIncluded_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "TryIncludePlatformAt", _m_TryIncludePlatformAt_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "TryExcludePlatformAt", _m_TryExcludePlatformAt_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetActiveQualityLevelsForPlatform", _m_GetActiveQualityLevelsForPlatform_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetActiveQualityLevelsForPlatformCount", _m_GetActiveQualityLevelsForPlatformCount_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetAllRenderPipelineAssetsForPlatform", _m_GetAllRenderPipelineAssetsForPlatform_xlua_st_);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "activeQualityLevelChanged", _e_activeQualityLevelChanged);
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "pixelLightCount", _g_get_pixelLightCount);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "shadows", _g_get_shadows);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "shadowProjection", _g_get_shadowProjection);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "shadowCascades", _g_get_shadowCascades);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "shadowDistance", _g_get_shadowDistance);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "shadowResolution", _g_get_shadowResolution);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "shadowmaskMode", _g_get_shadowmaskMode);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "shadowNearPlaneOffset", _g_get_shadowNearPlaneOffset);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "shadowCascade2Split", _g_get_shadowCascade2Split);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "shadowCascade4Split", _g_get_shadowCascade4Split);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "lodBias", _g_get_lodBias);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "anisotropicFiltering", _g_get_anisotropicFiltering);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "globalTextureMipmapLimit", _g_get_globalTextureMipmapLimit);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "maximumLODLevel", _g_get_maximumLODLevel);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "enableLODCrossFade", _g_get_enableLODCrossFade);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "particleRaycastBudget", _g_get_particleRaycastBudget);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "softParticles", _g_get_softParticles);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "softVegetation", _g_get_softVegetation);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "vSyncCount", _g_get_vSyncCount);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "realtimeGICPUUsage", _g_get_realtimeGICPUUsage);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "antiAliasing", _g_get_antiAliasing);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "asyncUploadTimeSlice", _g_get_asyncUploadTimeSlice);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "asyncUploadBufferSize", _g_get_asyncUploadBufferSize);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "asyncUploadPersistentBuffer", _g_get_asyncUploadPersistentBuffer);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "realtimeReflectionProbes", _g_get_realtimeReflectionProbes);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "billboardsFaceCameraPosition", _g_get_billboardsFaceCameraPosition);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "useLegacyDetailDistribution", _g_get_useLegacyDetailDistribution);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "resolutionScalingFixedDPIFactor", _g_get_resolutionScalingFixedDPIFactor);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "terrainQualityOverrides", _g_get_terrainQualityOverrides);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "terrainPixelError", _g_get_terrainPixelError);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "terrainDetailDensityScale", _g_get_terrainDetailDensityScale);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "terrainBasemapDistance", _g_get_terrainBasemapDistance);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "terrainDetailDistance", _g_get_terrainDetailDistance);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "terrainTreeDistance", _g_get_terrainTreeDistance);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "terrainBillboardStart", _g_get_terrainBillboardStart);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "terrainFadeLength", _g_get_terrainFadeLength);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "terrainMaxTrees", _g_get_terrainMaxTrees);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "renderPipeline", _g_get_renderPipeline);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "skinWeights", _g_get_skinWeights);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "count", _g_get_count);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "streamingMipmapsActive", _g_get_streamingMipmapsActive);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "streamingMipmapsMemoryBudget", _g_get_streamingMipmapsMemoryBudget);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "streamingMipmapsRenderersPerFrame", _g_get_streamingMipmapsRenderersPerFrame);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "streamingMipmapsMaxLevelReduction", _g_get_streamingMipmapsMaxLevelReduction);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "streamingMipmapsAddAllCameras", _g_get_streamingMipmapsAddAllCameras);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "streamingMipmapsMaxFileIORequests", _g_get_streamingMipmapsMaxFileIORequests);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "maxQueuedFrames", _g_get_maxQueuedFrames);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "names", _g_get_names);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "desiredColorSpace", _g_get_desiredColorSpace);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "activeColorSpace", _g_get_activeColorSpace);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "pixelLightCount", _s_set_pixelLightCount);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "shadows", _s_set_shadows);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "shadowProjection", _s_set_shadowProjection);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "shadowCascades", _s_set_shadowCascades);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "shadowDistance", _s_set_shadowDistance);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "shadowResolution", _s_set_shadowResolution);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "shadowmaskMode", _s_set_shadowmaskMode);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "shadowNearPlaneOffset", _s_set_shadowNearPlaneOffset);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "shadowCascade2Split", _s_set_shadowCascade2Split);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "shadowCascade4Split", _s_set_shadowCascade4Split);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "lodBias", _s_set_lodBias);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "anisotropicFiltering", _s_set_anisotropicFiltering);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "globalTextureMipmapLimit", _s_set_globalTextureMipmapLimit);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "maximumLODLevel", _s_set_maximumLODLevel);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "enableLODCrossFade", _s_set_enableLODCrossFade);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "particleRaycastBudget", _s_set_particleRaycastBudget);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "softParticles", _s_set_softParticles);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "softVegetation", _s_set_softVegetation);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "vSyncCount", _s_set_vSyncCount);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "realtimeGICPUUsage", _s_set_realtimeGICPUUsage);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "antiAliasing", _s_set_antiAliasing);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "asyncUploadTimeSlice", _s_set_asyncUploadTimeSlice);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "asyncUploadBufferSize", _s_set_asyncUploadBufferSize);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "asyncUploadPersistentBuffer", _s_set_asyncUploadPersistentBuffer);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "realtimeReflectionProbes", _s_set_realtimeReflectionProbes);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "billboardsFaceCameraPosition", _s_set_billboardsFaceCameraPosition);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "useLegacyDetailDistribution", _s_set_useLegacyDetailDistribution);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "resolutionScalingFixedDPIFactor", _s_set_resolutionScalingFixedDPIFactor);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "terrainQualityOverrides", _s_set_terrainQualityOverrides);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "terrainPixelError", _s_set_terrainPixelError);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "terrainDetailDensityScale", _s_set_terrainDetailDensityScale);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "terrainBasemapDistance", _s_set_terrainBasemapDistance);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "terrainDetailDistance", _s_set_terrainDetailDistance);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "terrainTreeDistance", _s_set_terrainTreeDistance);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "terrainBillboardStart", _s_set_terrainBillboardStart);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "terrainFadeLength", _s_set_terrainFadeLength);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "terrainMaxTrees", _s_set_terrainMaxTrees);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "renderPipeline", _s_set_renderPipeline);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "skinWeights", _s_set_skinWeights);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "streamingMipmapsActive", _s_set_streamingMipmapsActive);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "streamingMipmapsMemoryBudget", _s_set_streamingMipmapsMemoryBudget);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "streamingMipmapsRenderersPerFrame", _s_set_streamingMipmapsRenderersPerFrame);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "streamingMipmapsMaxLevelReduction", _s_set_streamingMipmapsMaxLevelReduction);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "streamingMipmapsAddAllCameras", _s_set_streamingMipmapsAddAllCameras);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "streamingMipmapsMaxFileIORequests", _s_set_streamingMipmapsMaxFileIORequests);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "maxQueuedFrames", _s_set_maxQueuedFrames);
            
			
			Utils.EndClassRegister(type, L, translator);
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "UnityEngine.QualitySettings does not have a constructor!");
        }
        
		
        
		
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IncreaseLevel_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 0) 
                {
                    
                    UnityEngine.QualitySettings.IncreaseLevel(  );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool _applyExpensiveChanges = LuaAPI.lua_toboolean(L, 1);
                    
                    UnityEngine.QualitySettings.IncreaseLevel( _applyExpensiveChanges );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.QualitySettings.IncreaseLevel!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DecreaseLevel_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 0) 
                {
                    
                    UnityEngine.QualitySettings.DecreaseLevel(  );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 1&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 1)) 
                {
                    bool _applyExpensiveChanges = LuaAPI.lua_toboolean(L, 1);
                    
                    UnityEngine.QualitySettings.DecreaseLevel( _applyExpensiveChanges );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.QualitySettings.DecreaseLevel!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetQualityLevel_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)) 
                {
                    int _index = LuaAPI.xlua_tointeger(L, 1);
                    
                    UnityEngine.QualitySettings.SetQualityLevel( _index );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    int _index = LuaAPI.xlua_tointeger(L, 1);
                    bool _applyExpensiveChanges = LuaAPI.lua_toboolean(L, 2);
                    
                    UnityEngine.QualitySettings.SetQualityLevel( _index, _applyExpensiveChanges );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.QualitySettings.SetQualityLevel!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ForEach_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<System.Action>(L, 1)) 
                {
                    System.Action _callback = translator.GetDelegate<System.Action>(L, 1);
                    
                    UnityEngine.QualitySettings.ForEach( _callback );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 1&& translator.Assignable<System.Action<int, string>>(L, 1)) 
                {
                    System.Action<int, string> _callback = translator.GetDelegate<System.Action<int, string>>(L, 1);
                    
                    UnityEngine.QualitySettings.ForEach( _callback );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.QualitySettings.ForEach!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetLODSettings_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 3)) 
                {
                    float _lodBias = (float)LuaAPI.lua_tonumber(L, 1);
                    int _maximumLODLevel = LuaAPI.xlua_tointeger(L, 2);
                    bool _setDirty = LuaAPI.lua_toboolean(L, 3);
                    
                    UnityEngine.QualitySettings.SetLODSettings( _lodBias, _maximumLODLevel, _setDirty );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    float _lodBias = (float)LuaAPI.lua_tonumber(L, 1);
                    int _maximumLODLevel = LuaAPI.xlua_tointeger(L, 2);
                    
                    UnityEngine.QualitySettings.SetLODSettings( _lodBias, _maximumLODLevel );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.QualitySettings.SetLODSettings!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetTextureMipmapLimitSettings_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _groupName = LuaAPI.lua_tostring(L, 1);
                    UnityEngine.TextureMipmapLimitSettings _textureMipmapLimitSettings;translator.Get(L, 2, out _textureMipmapLimitSettings);
                    
                    UnityEngine.QualitySettings.SetTextureMipmapLimitSettings( _groupName, _textureMipmapLimitSettings );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTextureMipmapLimitSettings_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _groupName = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = UnityEngine.QualitySettings.GetTextureMipmapLimitSettings( _groupName );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetRenderPipelineAssetAt_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 1);
                    
                        var gen_ret = UnityEngine.QualitySettings.GetRenderPipelineAssetAt( _index );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetQualityLevel_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    
                        var gen_ret = UnityEngine.QualitySettings.GetQualityLevel(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetQualitySettings_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        var gen_ret = UnityEngine.QualitySettings.GetQualitySettings(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsPlatformIncluded_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _buildTargetGroupName = LuaAPI.lua_tostring(L, 1);
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        var gen_ret = UnityEngine.QualitySettings.IsPlatformIncluded( _buildTargetGroupName, _index );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryIncludePlatformAt_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _buildTargetGroupName = LuaAPI.lua_tostring(L, 1);
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    System.Exception _error;
                    
                        var gen_ret = UnityEngine.QualitySettings.TryIncludePlatformAt( _buildTargetGroupName, _index, out _error );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _error);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_TryExcludePlatformAt_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _buildTargetGroupName = LuaAPI.lua_tostring(L, 1);
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    System.Exception _error;
                    
                        var gen_ret = UnityEngine.QualitySettings.TryExcludePlatformAt( _buildTargetGroupName, _index, out _error );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _error);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetActiveQualityLevelsForPlatform_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _buildTargetGroupName = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = UnityEngine.QualitySettings.GetActiveQualityLevelsForPlatform( _buildTargetGroupName );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetActiveQualityLevelsForPlatformCount_xlua_st_(RealStatePtr L)
        {
		    try {
            
            
            
                
                {
                    string _buildTargetGroupName = LuaAPI.lua_tostring(L, 1);
                    
                        var gen_ret = UnityEngine.QualitySettings.GetActiveQualityLevelsForPlatformCount( _buildTargetGroupName );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetAllRenderPipelineAssetsForPlatform_xlua_st_(RealStatePtr L)
        {
		    try {
            
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    string _buildTargetGroupName = LuaAPI.lua_tostring(L, 1);
                    System.Collections.Generic.List<UnityEngine.Rendering.RenderPipelineAsset> _renderPipelineAssets = (System.Collections.Generic.List<UnityEngine.Rendering.RenderPipelineAsset>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.Rendering.RenderPipelineAsset>));
                    
                    UnityEngine.QualitySettings.GetAllRenderPipelineAssetsForPlatform( _buildTargetGroupName, ref _renderPipelineAssets );
                    translator.Push(L, _renderPipelineAssets);
                        
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pixelLightCount(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, UnityEngine.QualitySettings.pixelLightCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shadows(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.QualitySettings.shadows);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shadowProjection(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.QualitySettings.shadowProjection);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shadowCascades(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, UnityEngine.QualitySettings.shadowCascades);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shadowDistance(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushnumber(L, UnityEngine.QualitySettings.shadowDistance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shadowResolution(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.QualitySettings.shadowResolution);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shadowmaskMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.QualitySettings.shadowmaskMode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shadowNearPlaneOffset(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushnumber(L, UnityEngine.QualitySettings.shadowNearPlaneOffset);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shadowCascade2Split(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushnumber(L, UnityEngine.QualitySettings.shadowCascade2Split);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_shadowCascade4Split(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushUnityEngineVector3(L, UnityEngine.QualitySettings.shadowCascade4Split);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lodBias(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushnumber(L, UnityEngine.QualitySettings.lodBias);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_anisotropicFiltering(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.QualitySettings.anisotropicFiltering);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_globalTextureMipmapLimit(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, UnityEngine.QualitySettings.globalTextureMipmapLimit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maximumLODLevel(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, UnityEngine.QualitySettings.maximumLODLevel);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_enableLODCrossFade(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, UnityEngine.QualitySettings.enableLODCrossFade);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_particleRaycastBudget(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, UnityEngine.QualitySettings.particleRaycastBudget);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_softParticles(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, UnityEngine.QualitySettings.softParticles);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_softVegetation(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, UnityEngine.QualitySettings.softVegetation);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_vSyncCount(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, UnityEngine.QualitySettings.vSyncCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_realtimeGICPUUsage(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, UnityEngine.QualitySettings.realtimeGICPUUsage);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_antiAliasing(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, UnityEngine.QualitySettings.antiAliasing);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_asyncUploadTimeSlice(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, UnityEngine.QualitySettings.asyncUploadTimeSlice);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_asyncUploadBufferSize(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, UnityEngine.QualitySettings.asyncUploadBufferSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_asyncUploadPersistentBuffer(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, UnityEngine.QualitySettings.asyncUploadPersistentBuffer);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_realtimeReflectionProbes(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, UnityEngine.QualitySettings.realtimeReflectionProbes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_billboardsFaceCameraPosition(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, UnityEngine.QualitySettings.billboardsFaceCameraPosition);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_useLegacyDetailDistribution(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, UnityEngine.QualitySettings.useLegacyDetailDistribution);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_resolutionScalingFixedDPIFactor(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushnumber(L, UnityEngine.QualitySettings.resolutionScalingFixedDPIFactor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_terrainQualityOverrides(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.QualitySettings.terrainQualityOverrides);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_terrainPixelError(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushnumber(L, UnityEngine.QualitySettings.terrainPixelError);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_terrainDetailDensityScale(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushnumber(L, UnityEngine.QualitySettings.terrainDetailDensityScale);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_terrainBasemapDistance(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushnumber(L, UnityEngine.QualitySettings.terrainBasemapDistance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_terrainDetailDistance(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushnumber(L, UnityEngine.QualitySettings.terrainDetailDistance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_terrainTreeDistance(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushnumber(L, UnityEngine.QualitySettings.terrainTreeDistance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_terrainBillboardStart(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushnumber(L, UnityEngine.QualitySettings.terrainBillboardStart);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_terrainFadeLength(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushnumber(L, UnityEngine.QualitySettings.terrainFadeLength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_terrainMaxTrees(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushnumber(L, UnityEngine.QualitySettings.terrainMaxTrees);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_renderPipeline(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.QualitySettings.renderPipeline);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_skinWeights(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.QualitySettings.skinWeights);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_count(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, UnityEngine.QualitySettings.count);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_streamingMipmapsActive(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, UnityEngine.QualitySettings.streamingMipmapsActive);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_streamingMipmapsMemoryBudget(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushnumber(L, UnityEngine.QualitySettings.streamingMipmapsMemoryBudget);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_streamingMipmapsRenderersPerFrame(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, UnityEngine.QualitySettings.streamingMipmapsRenderersPerFrame);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_streamingMipmapsMaxLevelReduction(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, UnityEngine.QualitySettings.streamingMipmapsMaxLevelReduction);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_streamingMipmapsAddAllCameras(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, UnityEngine.QualitySettings.streamingMipmapsAddAllCameras);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_streamingMipmapsMaxFileIORequests(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, UnityEngine.QualitySettings.streamingMipmapsMaxFileIORequests);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxQueuedFrames(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, UnityEngine.QualitySettings.maxQueuedFrames);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_names(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.QualitySettings.names);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_desiredColorSpace(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.QualitySettings.desiredColorSpace);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_activeColorSpace(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, UnityEngine.QualitySettings.activeColorSpace);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pixelLightCount(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.pixelLightCount = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shadows(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.ShadowQuality gen_value;translator.Get(L, 1, out gen_value);
				UnityEngine.QualitySettings.shadows = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shadowProjection(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.ShadowProjection gen_value;translator.Get(L, 1, out gen_value);
				UnityEngine.QualitySettings.shadowProjection = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shadowCascades(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.shadowCascades = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shadowDistance(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.shadowDistance = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shadowResolution(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.ShadowResolution gen_value;translator.Get(L, 1, out gen_value);
				UnityEngine.QualitySettings.shadowResolution = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shadowmaskMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.ShadowmaskMode gen_value;translator.Get(L, 1, out gen_value);
				UnityEngine.QualitySettings.shadowmaskMode = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shadowNearPlaneOffset(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.shadowNearPlaneOffset = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shadowCascade2Split(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.shadowCascade2Split = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_shadowCascade4Split(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.Vector3 gen_value;translator.Get(L, 1, out gen_value);
				UnityEngine.QualitySettings.shadowCascade4Split = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_lodBias(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.lodBias = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_anisotropicFiltering(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.AnisotropicFiltering gen_value;translator.Get(L, 1, out gen_value);
				UnityEngine.QualitySettings.anisotropicFiltering = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_globalTextureMipmapLimit(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.globalTextureMipmapLimit = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maximumLODLevel(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.maximumLODLevel = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_enableLODCrossFade(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.enableLODCrossFade = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_particleRaycastBudget(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.particleRaycastBudget = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_softParticles(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.softParticles = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_softVegetation(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.softVegetation = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_vSyncCount(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.vSyncCount = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_realtimeGICPUUsage(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.realtimeGICPUUsage = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_antiAliasing(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.antiAliasing = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_asyncUploadTimeSlice(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.asyncUploadTimeSlice = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_asyncUploadBufferSize(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.asyncUploadBufferSize = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_asyncUploadPersistentBuffer(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.asyncUploadPersistentBuffer = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_realtimeReflectionProbes(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.realtimeReflectionProbes = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_billboardsFaceCameraPosition(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.billboardsFaceCameraPosition = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_useLegacyDetailDistribution(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.useLegacyDetailDistribution = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_resolutionScalingFixedDPIFactor(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.resolutionScalingFixedDPIFactor = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_terrainQualityOverrides(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.TerrainQualityOverrides gen_value;translator.Get(L, 1, out gen_value);
				UnityEngine.QualitySettings.terrainQualityOverrides = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_terrainPixelError(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.terrainPixelError = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_terrainDetailDensityScale(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.terrainDetailDensityScale = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_terrainBasemapDistance(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.terrainBasemapDistance = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_terrainDetailDistance(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.terrainDetailDistance = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_terrainTreeDistance(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.terrainTreeDistance = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_terrainBillboardStart(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.terrainBillboardStart = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_terrainFadeLength(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.terrainFadeLength = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_terrainMaxTrees(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.terrainMaxTrees = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_renderPipeline(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    UnityEngine.QualitySettings.renderPipeline = (UnityEngine.Rendering.RenderPipelineAsset)translator.GetObject(L, 1, typeof(UnityEngine.Rendering.RenderPipelineAsset));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_skinWeights(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			UnityEngine.SkinWeights gen_value;translator.Get(L, 1, out gen_value);
				UnityEngine.QualitySettings.skinWeights = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_streamingMipmapsActive(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.streamingMipmapsActive = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_streamingMipmapsMemoryBudget(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.streamingMipmapsMemoryBudget = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_streamingMipmapsRenderersPerFrame(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.streamingMipmapsRenderersPerFrame = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_streamingMipmapsMaxLevelReduction(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.streamingMipmapsMaxLevelReduction = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_streamingMipmapsAddAllCameras(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.streamingMipmapsAddAllCameras = LuaAPI.lua_toboolean(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_streamingMipmapsMaxFileIORequests(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.streamingMipmapsMaxFileIORequests = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxQueuedFrames(RealStatePtr L)
        {
		    try {
                
			    UnityEngine.QualitySettings.maxQueuedFrames = LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _e_activeQualityLevelChanged(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    int gen_param_count = LuaAPI.lua_gettop(L);
                System.Action<int, int> gen_delegate = translator.GetDelegate<System.Action<int, int>>(L, 2);
                if (gen_delegate == null) {
                    return LuaAPI.luaL_error(L, "#2 need System.Action<int, int>!");
                }
                
				
				if (gen_param_count == 2 && LuaAPI.xlua_is_eq_str(L, 1, "+")) {
					UnityEngine.QualitySettings.activeQualityLevelChanged += gen_delegate;
					return 0;
				} 
				
				
				if (gen_param_count == 2 && LuaAPI.xlua_is_eq_str(L, 1, "-")) {
					UnityEngine.QualitySettings.activeQualityLevelChanged -= gen_delegate;
					return 0;
				} 
				
			} catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
			return LuaAPI.luaL_error(L, "invalid arguments to UnityEngine.QualitySettings.activeQualityLevelChanged!");
        }
        
    }
}
