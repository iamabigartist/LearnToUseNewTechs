﻿// Copyright (c) 2015 - 2022 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using Doozy.Editor.Common.Addons;
using Doozy.Editor.Common.Automation.Generators;
using Doozy.Editor.Common.Utils;
using Doozy.Editor.EditorUI.ScriptableObjects;
using Doozy.Editor.Reactor.ScriptableObjects;
using Doozy.Editor.Signals;
using Doozy.Editor.Signals.ScriptableObjects;
using Doozy.Editor.UIManager.ScriptableObjects;
using Doozy.Editor.UIManager.UIMenu;
using Doozy.Runtime.Reactor.ScriptableObjects;
using Doozy.Runtime.UIManager.ScriptableObjects;
using UnityEditor;
using UnityEngine;
// ReSharper disable MemberCanBePrivate.Global

namespace Doozy.Editor.Common.ScriptableObjects
{
    public class UpdateBot : SingletonEditorScriptableObject<UpdateBot>
    {
        public bool Update = false;

        [InitializeOnLoadMethod]
        public static void Initialize()
        {
            if (!instance.Update) return;
            if (EditorApplication.isPlayingOrWillChangePlaymode) return;
            if (EditorApplication.isCompiling || EditorApplication.isUpdating)
            {
                DelayedCall.Run(2f, Initialize);
                return;
            }
            Run();
            instance.Update = false;
            EditorUtility.SetDirty(instance);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }

        public static void Run()
        {
            if (EditorApplication.isPlayingOrWillChangePlaymode) return;
            if (EditorApplication.isCompiling || EditorApplication.isUpdating)
            {
                DelayedCall.Run(2f, Run);
                return;
            }

            #if DOOZY_42
            Debug.Log($"[{nameof(UpdateBot)}] Update Bot cannot automatically execute if 42 is enabled");
            return;
            #endif

            #pragma warning disable CS0162
            Execute();
            #pragma warning restore CS0162
        }

        [MenuItem("Tools/Doozy/Refresh/Global Refresh", priority = -400)]
        public static void Execute()
        {
            if (!EditorUtility.DisplayDialog
                (
                    $"Refresh Doozy UI Manager?",
                    "Validate the folder structure." +
                    "\n\n" +
                    "Re-write all the helper classes for Id databases." +
                    "\n\n" +
                    "Validate and create all the settings scriptable objects. (does not change existing settings)" +
                    "\n\n" +
                    "Regenerate all the databases with the latest registered items, from the source files." +
                    "\n\n" +
                    "Takes a few minutes, depending on the number of source files and your computer's performance." +
                    "\n\n" +
                    "This operation cannot be undone!",
                    "Yes",
                    "No"
                )
               )
                return;

            //Create Folders
            //../Doozy/Runtime/Data/Resources
            if (!AssetDatabase.IsValidFolder($"{Runtime.RuntimePath.path}/Data/Resources"))
                AssetDatabase.CreateFolder($"{Runtime.RuntimePath.path}/Data", "Resources");

            //Editor
            EditorUISettings.Restore();
            EditorUISettings.instance.Refresh();

            //Category Names databases
            StreamIdDatabase.Restore();
            UIButtonIdDatabase.Restore();
            UISliderIdDatabase.Restore();
            UITagIdDatabase.Restore();
            UIToggleIdDatabase.Restore();
            UIViewIdDatabase.Restore();
            
            //PrefabLink Databases
            UITooltipDatabase.Restore();
            UIPopupDatabase.Restore();

            //UIMenu
            UIMenuSettings.Restore();
            UIMenuItemsDatabase.Restore();
            UIMenuItemsDatabase.instance.RefreshDatabase(false);

            //UIAnimation Preset Database
            UIAnimationPresetDatabase.instance.RefreshDatabase();

            //UITooltip Database
            UITooltipDatabase.instance.RefreshDatabase();

            //UIPopup Database
            UIPopupDatabase.instance.RefreshDatabase();
            
            //Progressor Database
            ProgressorIdDatabase.Restore();
            
            //Reactor Settings
            ReactorSettings.Restore();

            //Signals - Refresh Providers
            SignalsUtils.RefreshProviders();

            //UIManager Input Settings
            UIManagerInputSettings.Restore();
            
            //Addons Database
            AddonInfoDatabase.RefreshDatabase();

            CreateAssemblyDefinitions();
            SetupInputSystem();
        }

        public static void CreateAssemblyDefinitions()
        {
            AssemblyDefinitionsGenerator.Run(true, true);
        }

        public static void SetupInputSystem()
        {
            #if ENABLE_INPUT_SYSTEM

            if (DefineSymbolsUtils.HasGlobalDefine("LEGACY_INPUT_MANGER"))
            {
                DefineSymbolsUtils.RemoveGlobalDefine("LEGACY_INPUT_MANGER"); //remove the wrongly spelled define
                DefineSymbolsUtils.AddGlobalDefine("LEGACY_INPUT_MANAGER");   //add the correct spelled define
                return;
            }

            //check for the new input system define
            if (!DefineSymbolsUtils.HasGlobalDefine("INPUT_SYSTEM_PACKAGE"))
            {
                //new input system define not found
                //check for the old input system define
                if (DefineSymbolsUtils.HasGlobalDefine("LEGACY_INPUT_MANAGER"))
                {
                    //old input system define found
                    #if !ENABLE_LEGACY_INPUT_MANAGER
                    //old input system not enabled -> add new input system define
                    DefineSymbolsUtils.RemoveGlobalDefine("LEGACY_INPUT_MANAGER"); //remove the old input system define
                    DefineSymbolsUtils.AddGlobalDefine("INPUT_SYSTEM_PACKAGE");    //add the new input system define
                    #endif
                    return;
                }

                DefineSymbolsUtils.AddGlobalDefine("INPUT_SYSTEM_PACKAGE"); //add the new input system define
                return;
            }

            #elif ENABLE_LEGACY_INPUT_MANAGER
            if (!DefineSymbolsUtils.HasGlobalDefine("LEGACY_INPUT_MANAGER")) //check for the old input system define
            {
                DefineSymbolsUtils.RemoveGlobalDefine("INPUT_SYSTEM_PACKAGE"); //remove the new input system define
                DefineSymbolsUtils.AddGlobalDefine("LEGACY_INPUT_MANAGER");     //add the new input system define
                return;
            }

            #endif
        }
    }
}
