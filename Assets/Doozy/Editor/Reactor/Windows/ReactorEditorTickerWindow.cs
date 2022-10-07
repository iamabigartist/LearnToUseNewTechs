﻿// Copyright (c) 2015 - 2022 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using Doozy.Editor.EditorUI.Windows.Internal;
using Doozy.Editor.Reactor.Components;
using Doozy.Editor.UIElements;
using Doozy.Runtime.UIElements.Extensions;
using UnityEditor;
using UnityEngine;

namespace Doozy.Editor.Reactor.Windows
{
    public class ReactorEditorTickerWindow : FluidWindow<ReactorEditorTickerWindow>
    {
        private const string WINDOW_TITLE = "Editor Heartbeat";

        // [MenuItem(ReactorWindow.k_WindowMenuPath + WINDOW_TITLE, priority = -700)]
        internal static void Open() => InternalOpenWindow(WINDOW_TITLE);

        private TickerVisualizer m_TickerVisualizer;

        protected override void CreateGUI()
        {
            root
                .RecycleAndClear()
                .AddChild
                (
                    m_TickerVisualizer =
                        new TickerVisualizer
                        (
                            TickerVisualizer.TickerType.Editor,
                            null
                            // ReactorWindow.Open
                        )
                );
            EditorApplication.playModeStateChanged += TickVisualizer;
        }

        private void TickVisualizer(PlayModeStateChange playModeStateChange) =>
            m_TickerVisualizer?.OnTick();

        protected override void OnEnable()
        {
            base.OnEnable();
            minSize = maxSize = new Vector2(230, 44);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            EditorApplication.playModeStateChanged -= TickVisualizer;
            m_TickerVisualizer?.Dispose();
        }
    }
}
