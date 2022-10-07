﻿// Copyright (c) 2015 - 2022 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System;
using UnityEngine;
using UnityEngine.UI;

namespace Doozy.Runtime.Reactor.Targets
{
    /// <summary>
    /// Connects a Image component with a Reactor animator.
    /// </summary>
    [Serializable]
    [RequireComponent(typeof(Image))]
    [AddComponentMenu("Reactor/Targets/Image Sprite Target")]
    public class ImageSpriteTarget : ReactorMetaSpriteTarget<Image>
    {
        #if UNITY_EDITOR
        private void Reset()
        {
            Target = Target ? Target : GetComponent<Image>();
        }
        #endif

        public override Type targetType => typeof(Image);

        public override Sprite GetSprite() =>
            Target == null ? null : Target.sprite;

        public override void SetSprite(Sprite value)
        {
            if (Target == null)
                return;

            Target.sprite = value;
        }
    }
}
