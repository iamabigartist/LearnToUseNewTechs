﻿// Copyright (c) 2015 - 2022 Doozy Entertainment. All Rights Reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement
// A Copy of the EULA APPENDIX 1 is available at http://unity3d.com/company/legal/as_terms

using System;
// ReSharper disable ClassNeverInstantiated.Global

namespace Doozy.Runtime.Common.Attributes
{
    /// <summary>
    /// Attribute used by the <see cref="Doozy.Editor.Common.Utils.DomainReloadHandler"/> to execute a method on reload
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class ExecuteOnReloadAttribute : Attribute
    {
        /// <summary> On reload, execute method </summary>
        public ExecuteOnReloadAttribute() {}
    }
}
