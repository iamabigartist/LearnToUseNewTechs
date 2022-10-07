﻿// Copyright (c) 2015 - 2022 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System;
using UnityEngine;
using UnityEngine.Events;

namespace Doozy.Runtime.Mody.Actions
{
    /// <summary> <see cref="MetaModyAction{T}"/> with a MonoBehaviour value </summary>
    [Serializable]
    public class MonoBehaviourModyAction: MetaModyAction<MonoBehaviour>
    {
        public MonoBehaviourModyAction(MonoBehaviour behaviour, string actionName, UnityAction<MonoBehaviour> callback)
            : base(behaviour, actionName, callback)
        {
        }
    }
}
