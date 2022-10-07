﻿// Copyright (c) 2015 - 2022 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System;
using System.Collections.Generic;
using System.Linq;
using Doozy.Editor.Common.Extensions;
using Doozy.Editor.EditorUI;
using Doozy.Editor.EditorUI.Components;
using Doozy.Editor.EditorUI.Utils;
using Doozy.Editor.Reactor.Internal;
using Doozy.Runtime.Colors;
using Doozy.Runtime.Common.Extensions;
using Doozy.Runtime.Reactor.Extensions;
using Doozy.Runtime.Reactor.Reactions;
using Doozy.Runtime.UIElements.Extensions;
using UnityEditor;
using UnityEditor.Sprites;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;
using EditorStyles = Doozy.Editor.EditorUI.EditorStyles;
using Object = UnityEngine.Object;
// ReSharper disable MemberCanBePrivate.Global

namespace Doozy.Editor.Reactor.Components
{
    /// <summary>
    /// Sprite Animation Info VisualElement
    /// </summary>
    public class SpriteAnimationInfo : VisualElement, IDisposable
    {
        public TemplateContainer templateContainer { get; }
        public VisualElement layoutContainer { get; }
        public VisualElement content { get; }
        public Image previewImageContainer { get; }
        public Image previewImage { get; }
        public VisualElement detailsContainer { get; }
        public Label animationName { get; }
        public Label numberOfFrames { get; }
        public Label textureSize { get; }
        public VisualElement playerContainer { get; }
        public Label pathLabel { get; }

        public Texture2DReaction reaction { get; private set; }
        public FluidButton playForwardButton { get; private set; }
        public FluidButton playReversedButton { get; private set; }
        public FluidButton setSpriteButton { get; private set; }

        public Slider playerSlider { get; private set; }

        public SerializedProperty arrayProperty { get; }

        public List<Texture2D> textures { get; } = new List<Texture2D>();

        public int frameCount => arrayProperty?.arraySize ?? 0;

        private const float PLAYER_SPACING = DesignUtils.k_Spacing * 0.5f;

        public UnityAction<Sprite> spriteSetter { get; set; }

        public void Dispose()
        {
            reaction?.Recycle();
            playForwardButton?.Recycle();
            playReversedButton?.Recycle();
            setSpriteButton?.Recycle();
        }

        public SpriteAnimationInfo(SerializedProperty arrayProperty)
        {
            this.arrayProperty = arrayProperty;

            Add(templateContainer = EditorLayouts.Reactor.AnimationInfo.CloneTree());
            templateContainer
                .AddStyle(EditorStyles.Reactor.AnimationInfo);

            layoutContainer = templateContainer.Q<VisualElement>(nameof(layoutContainer));
            content = layoutContainer.Q<VisualElement>(nameof(content));
            previewImageContainer = content.Q<Image>(nameof(previewImageContainer));
            previewImage = previewImageContainer.Q<Image>(nameof(previewImage));
            detailsContainer = content.Q<VisualElement>(nameof(detailsContainer));
            animationName = detailsContainer.Q<Label>(nameof(animationName));
            numberOfFrames = detailsContainer.Q<Label>(nameof(numberOfFrames));
            textureSize = detailsContainer.Q<Label>(nameof(textureSize));
            playerContainer = detailsContainer.Q<VisualElement>(nameof(playerContainer));
            pathLabel = layoutContainer.Q<Label>(nameof(pathLabel));

            layoutContainer
                .SetStyleBackgroundColor(EditorColors.Default.FieldBackground)
                .SetStyleBorderColor(EditorColors.Default.Selection);

            previewImageContainer
                .SetStyleBackgroundImage(EditorTextures.EditorUI.Placeholders.TransparencyGrid)
                .SetStyleBackgroundImageTintColor(Color.gray.WithAlpha(0.5f));

            numberOfFrames
                .SetStyleColor(EditorColors.Default.TextDescription)
                .SetStyleUnityFont(EditorFonts.Inter.Light);

            textureSize
                .SetStyleColor(EditorColors.Default.TextDescription)
                .SetStyleUnityFont(EditorFonts.Inter.Light);

            pathLabel
                .SetStyleColor(EditorColors.Default.TextDescription)
                .SetStyleUnityFont(EditorFonts.Inter.Regular);

            previewImageContainer.RegisterCallback<MouseEnterEvent>(evt =>
            {
                if (reaction == null) return;
                if (reaction.isActive) return;
                reaction.Play();
            });

            previewImageContainer.RegisterCallback<MouseUpEvent>(evt =>
            {
                if (reaction == null) return;

                const int leftMouseButton = 0;
                const int rightMouseButton = 1;

                switch (evt.button)
                {
                    case leftMouseButton:
                        reaction.Play(); //play forward
                        break;
                    case rightMouseButton:
                        reaction.Play(true); //play in reverse
                        break;
                }
            });

            VisualElement controlsLine =
                new VisualElement()
                    .SetStyleFlexDirection(FlexDirection.Row)
                    .SetStylePadding(PLAYER_SPACING);

            playerContainer
                .AddChild(controlsLine);

            playerSlider =
                new Slider(0f, 1f)
                    .SetStyleFlexGrow(1)
                    .SetStyleMargins(PLAYER_SPACING)
                    .SetStylePadding(0);

            playerSlider.RegisterValueChangedCallback(evt =>
            {
                if (reaction == null) return;
                if (reaction.isActive) return;
                reaction?.SetFrameAtProgress(Mathf.Clamp01(evt.newValue));
                UpdateFramesLabel();
            });

            playerSlider.RegisterCallback<MouseDownEvent>(evt =>
            {
                if (reaction == null) return;
                if (!reaction.isActive) return;
                reaction?.Stop();
            });

            Update();

            playForwardButton =
                FluidButton.Get()
                    .SetIcon(EditorSpriteSheets.EditorUI.Icons.PlayForward)
                    .SetAccentColor(EditorSelectableColors.EditorUI.LightGreen)
                    .SetTooltip("Play Forward")
                    .SetElementSize(ElementSize.Small)
                    .SetButtonStyle(ButtonStyle.Clear)
                    .SetOnClick(() => reaction?.Play()); //play forward

            playReversedButton =
                FluidButton.Get()
                    .SetIcon(EditorSpriteSheets.EditorUI.Icons.PlayReverse)
                    .SetAccentColor(EditorSelectableColors.EditorUI.LightGreen)
                    .SetTooltip("Play Reversed")
                    .SetElementSize(ElementSize.Small)
                    .SetButtonStyle(ButtonStyle.Clear)
                    .SetOnClick(() => reaction?.Play(true)); //play in reverse

            setSpriteButton =
                FluidButton.Get()
                    .SetIcon(EditorSpriteSheets.EditorUI.Icons.Sprite)
                    .SetAccentColor(EditorSelectableColors.EditorUI.LightGreen)
                    .SetTooltip("Set Sprite")
                    .SetLabelText("Set Sprite")
                    .SetElementSize(ElementSize.Small)
                    .SetButtonStyle(ButtonStyle.Contained)
                    .SetStyleMarginLeft(PLAYER_SPACING)
                    .SetOnClick(() =>
                    {
                        if (reaction == null) return;
                        if (reaction.current == null) return;
                        if (spriteSetter == null) return;
                        string assetPath = AssetDatabase.GetAssetPath(arrayProperty.GetArrayElementAtIndex(reaction.currentFrame).objectReferenceValue);
                        Texture texture = AssetDatabase.LoadAssetAtPath<Texture>(assetPath);
                        if (!texture.IsSpriteSheet())
                        {
                            //not a sprite sheet -> load as sprite
                            spriteSetter.Invoke(AssetDatabase.LoadAssetAtPath<Sprite>(assetPath));
                            return;
                        }
                        //is sprite sheet -> get the sprite at current frame (the one visible in the preview)
                        var sprites = new List<Sprite>(AssetDatabase.LoadAllAssetRepresentationsAtPath(assetPath).OfType<Sprite>());
                        spriteSetter.Invoke(sprites[reaction.currentFrame]);
                    }); //set sprite


            controlsLine
                .AddChild(playForwardButton)
                .AddChild(playerSlider.SetStyleMarginLeft(PLAYER_SPACING))
                .AddChild(playReversedButton)
                .AddChild(setSpriteButton);
        }

        public void Update()
        {
            Sprite sprite =
                arrayProperty.arraySize == 0
                    ? null
                    : arrayProperty.GetArrayElementAtIndex(0).objectReferenceValue as Sprite;

            int numberOfFramesCount = frameCount;

            bool hasReference = sprite != null;
            DisplayStyle displayStyle = hasReference ? DisplayStyle.Flex : DisplayStyle.None;

            if (sprite != null) previewImage.SetStyleBackgroundImage(sprite.ToTexture2D());
            animationName?.SetStyleDisplay(displayStyle);
            playForwardButton?.SetStyleDisplay(displayStyle);
            playReversedButton?.SetStyleDisplay(displayStyle);
            pathLabel.SetStyleDisplay(displayStyle);
            numberOfFrames.SetStyleDisplay(displayStyle);
            textureSize.SetStyleDisplay(displayStyle);

            if (!hasReference)
                return;

            numberOfFrames.SetText($"{numberOfFramesCount} Frames");
            textureSize.SetText($"W: {sprite.rect.width}px\nH: {sprite.rect.height}px");

            string assetPath = AssetDatabase.GetAssetPath(sprite);
            string[] splitPath = assetPath.Split('/');
            assetPath = string.Empty;
            for (int i = 0; i < splitPath.Length - 1; i++)
            {
                bool lastItem = i == splitPath.Length - 2;
                assetPath += $"{splitPath[i]}/";
            }
            assetPath = assetPath.RemoveLastCharacter();

            animationName.SetText($"{splitPath[splitPath.Length - 2]}");
            pathLabel.SetText($"{assetPath}");

            textures.Clear();
            for (int i = 0; i < arrayProperty.arraySize; i++)
            {
                Object objectReferenceValue = arrayProperty.GetArrayElementAtIndex(i).objectReferenceValue;
                if (objectReferenceValue == null) continue;
                textures.Add(((Sprite)objectReferenceValue).ToTexture2D());
            }

            reaction?.Recycle();
            reaction = GetAnimation(previewImage, textures);

            reaction.OnPlayCallback += () =>
            {
                UpdateSliderValue();
                UpdateFramesLabel();
            };

            reaction.OnStopCallback += () =>
            {
                UpdateSliderValue();
                UpdateFramesLabel();
            };

            reaction.OnUpdateCallback += () =>
            {
                UpdateFramesLabel();
                if (!reaction.isActive)
                    return;
                UpdateSliderValue();
            };
        }

        public SpriteAnimationInfo HideSetSpriteButton(bool hide)
        {
            setSpriteButton?.SetStyleDisplay(hide ? DisplayStyle.None : DisplayStyle.Flex);
            return this;
        }

        private void UpdateFramesLabel()
        {
            numberOfFrames.text =
                reaction == null
                    ? "-/- Frames"
                    : $"{reaction.currentFrame + 1}/{reaction.numberOfFrames} Frames";
        }

        private void UpdateSliderValue()
        {
            playerSlider.value = reaction.progress;
            playerSlider.MarkDirtyRepaint();
        }


        private static Texture2DReaction GetAnimation(VisualElement previewImage, IEnumerable<Texture2D> textures) =>
            previewImage.GetTexture2DReaction(textures).SetEditorHeartbeat();

    }
}
