﻿// Copyright (c) 2015 - 2022 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System;
using UnityEngine;
using UnityEngine.Events;

namespace Doozy.Runtime.Mody.Actions
{
    /// <summary> <see cref="MetaModyAction{T}"/> with a ScriptableObject value </summary>
    [Serializable]
    public class ScriptableObjectModyAction : MetaModyAction<ScriptableObject>
    {
        public ScriptableObjectModyAction(MonoBehaviour behaviour, string actionName, UnityAction<ScriptableObject> callback)
            : base(behaviour, actionName, callback)
        {
        }
        
        public override bool SetValue(object objectValue) =>
            SetValue(objectValue, false);
    }
}
