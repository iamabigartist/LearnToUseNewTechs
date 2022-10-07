﻿// Copyright (c) 2015 - 2022 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using Doozy.Editor.EditorUI.Fields;
using Doozy.Runtime.Common;
using Doozy.Runtime.Common.Extensions;
using Doozy.Runtime.UIElements.Extensions;
using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace Doozy.Editor.Common.Drawers
{
    [CustomPropertyDrawer(typeof(RandomFloat), true)]
    public class RandomFloatDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {}

        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            const float width = 40;
            FloatField min = NewFloatField("MIN", width, "min");
            FloatField max = NewFloatField("MAX", width, "max");

            VisualElement drawer =
                new VisualElement()
                    .SetStyleFlexDirection(FlexDirection.Row)
                    .AddChild(min)
                    .AddSpace(4, 0)
                    .AddChild(max);

            return drawer;
        }

        private static FloatField NewFloatField(string bindingPath, float width, string infoLabelText)
        {
            FloatField field =
                new FloatField { bindingPath = bindingPath }
                    .SetStylePadding(0)
                    .SetStyleMargins(0)
                    .SetStyleFlexGrow(1)
                    .SetStyleWidth(width);

            if (!infoLabelText.IsNullOrEmpty())
            {
                field.Q(FloatField.textInputUssName)
                    .SetStyleHeight(18)
                    .AddChild(new FieldInfoLabel(infoLabelText));
            }

            return field;
        }
    }
}
