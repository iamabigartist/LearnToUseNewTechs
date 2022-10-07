﻿// Copyright (c) 2015 - 2022 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System;
using UnityEngine;

namespace Doozy.Runtime.Nody.Nodes.Internal
{
    /// <summary>
    /// Base class for system nodes.
    /// <para/> A system node is a specialized node that performs graph specific tasks in a flow graph.
    /// </summary>
    [Serializable]
    public abstract class SystemNode : FlowNode
    {
        [SerializeField] private SystemNodeType SystemNodeType;
        public SystemNodeType systemNodeType => SystemNodeType;
        
        protected SystemNode(SystemNodeType type) : base(NodeType.System)
        {
            canBeDeleted = false;
            SystemNodeType = type;
        }
    }
}
