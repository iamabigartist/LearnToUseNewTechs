﻿// Copyright (c) 2015 - 2022 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System;
using Doozy.Runtime.Mody;
using UnityEngine;

namespace Doozy.Runtime.UIManager
{
    /// <summary> Event class used by an UISelectable for its selectable states </summary>
    [Serializable]
    public struct UISelectableState
    {
        [SerializeField] private UISelectionState StateType;
        [SerializeField] private ModyEvent StateEvent;

        /// <summary> State type </summary>
        public UISelectionState stateType => StateType;
        /// <summary> State events </summary>
        public ModyEvent stateEvent => StateEvent;

        /// <summary> Create a UISelectable State </summary>
        /// <param name="type"> Type of the state </param>
        public UISelectableState(UISelectionState type)
        {
            StateType = type;
            StateEvent = new ModyEvent(type.ToString());
        }
    }
}
