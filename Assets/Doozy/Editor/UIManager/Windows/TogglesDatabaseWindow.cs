﻿// Copyright (c) 2015 - 2022 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using Doozy.Editor.EditorUI.Components;
using Doozy.Editor.EditorUI.Windows.Internal;
using Doozy.Editor.UIElements;
using Doozy.Editor.UIManager.Layouts.Databases;
using Doozy.Runtime.UIElements.Extensions;
using UnityEditor;
using UnityEngine;

namespace Doozy.Editor.UIManager.Windows
{
    public class TogglesDatabaseWindow : FluidWindow<TogglesDatabaseWindow>
    {
        private const string WINDOW_TITLE = "Toggles Database";

        // [MenuItem(UIManagerWindow.k_WindowMenuPath  + "Databases/" +  WINDOW_TITLE, priority = -700)]
        public static void Open() => InternalOpenWindow(WINDOW_TITLE);

        protected override void CreateGUI()
        {
            windowLayout = new TogglesDatabaseWindowLayout();
            root
                .RecycleAndClear()
                .AddChild(windowLayout);
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            minSize = new Vector2(500, 500);
        }
        
        protected override void OnDestroy()
        {
            base.OnDestroy();
            var layout = (FluidWindowLayout)windowLayout;
            if (layout == null) return;
            layout?.OnDestroy();
            layout?.Dispose();
        }
    }
}
