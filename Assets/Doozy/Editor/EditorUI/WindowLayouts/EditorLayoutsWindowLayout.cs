﻿// Copyright (c) 2015 - 2022 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System.Collections.Generic;
using Doozy.Editor.EditorUI.Components;
using Doozy.Editor.EditorUI.Components.Internal;
using Doozy.Editor.EditorUI.Editors;
using Doozy.Editor.EditorUI.ScriptableObjects.Layouts;
using Doozy.Runtime.UIElements.Extensions;
using UnityEngine;
using UnityEngine.UIElements;
// ReSharper disable UnusedType.Global

namespace Doozy.Editor.EditorUI.WindowLayouts
{
    public sealed class EditorLayoutsWindowLayout : EditorUIDatabaseWindowLayout, IEditorUIDatabaseWindowLayout
    {
        public int order => 300;
        
        public override string layoutName => "Layouts";
        public override Texture2D staticIconTexture => EditorTextures.EditorUI.Icons.EditorLayoutGroup;
        public override List<Texture2D> animatedIconTextures => EditorSpriteSheets.EditorUI.Components.EditorLayoutGroup;

        protected override int maximumNumberOfItemsVisibleAtOnce => 10;

        public EditorLayoutsWindowLayout()
        {
            AddHeader("Editor Layouts", "EditorUI registered .uxml layouts (VisualTreeAssets)", animatedIconTextures);

            InitializeRefreshDatabaseButton
            (
                "Refresh Database",
                "Search for all registered layouts groups",
                selectableAccentColor,
                () => EditorDataLayoutDatabase.instance.RefreshDatabase()
            );

            //SIDE MENU - ToolbarContainer - Refresh Database button
            sideMenu.toolbarContainer
                .SetStyleDisplay(DisplayStyle.Flex)
                .AddChild(refreshDatabaseButton);

            //SIDE MENU BUTTONS & CONTENT
            foreach (EditorDataLayoutGroup group in EditorDataLayoutDatabase.instance.Database)
            {
                //SIDE MENU BUTTON
                FluidToggleButtonTab sideMenuButton = sideMenu.AddButton($"{group.groupName}", selectableAccentColor);

                //TARGET OBJECT CUSTOM EDITOR
                var editor = (EditorDataLayoutGroupEditor)UnityEditor.Editor.CreateEditor(group);

                //CLEAN NAMED REFERENCES
                ISearchable searchable = editor;
                VisualElement visualElement = editor.CreateInspectorGUI(); // <<< EDITOR GETS GENERATED HERE
                FluidListView fluidListView = editor.fluidListView;
                FluidButton selectAssetButton = GetNewSelectAssetButton($"{group.groupName}", staticIconTexture, group);

                //REMOVE ELEMENTS THAT ARE LESS IMPORTANT AND CREATE VISUAL CLUTTER
                editor.loadFilesFromFolderButton.SetStyleDisplay(DisplayStyle.None);
                editor.nameComponentField.SetStyleDisplay(DisplayStyle.None);
                editor.fluidListView.listTitle.SetStyleDisplay(DisplayStyle.None);
                editor.fluidListView.listDescription.SetStyleDisplay(DisplayStyle.None);

                sideMenuButton.OnValueChanged += evt =>
                {
                    if (!evt.newValue) return;
                    SideMenuButtonClick(fluidListView, visualElement, selectAssetButton);
                };

                //ADD THE SEARCHABLE TO THE SIDE MENU SearchBox
                sideMenu.searchBox.AddSearchable(searchable);

                //ADD ENTRY TO SEARCHABLE ITEMS LIST (this is needed to generate the complex search results)
                searchableItems.Add(searchable, new FluidSearchableItem(searchable, visualElement, fluidListView, selectAssetButton));
            }
        }
    }
}
