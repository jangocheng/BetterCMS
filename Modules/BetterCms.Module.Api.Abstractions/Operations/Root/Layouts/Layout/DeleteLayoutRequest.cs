﻿using System;
using System.Runtime.Serialization;

using BetterCms.Module.Api.Infrastructure;

namespace BetterCms.Module.Api.Operations.Root.Layouts.Layout
{
    /// <summary>
    /// Request for layout delete operation.
    /// </summary>
    [DataContract]
    [Serializable]
    public class DeleteLayoutRequest : DeleteRequestBase
    {
    }
}