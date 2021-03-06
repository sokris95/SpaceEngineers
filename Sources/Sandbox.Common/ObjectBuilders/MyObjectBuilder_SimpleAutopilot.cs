﻿using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VRageMath;

namespace Sandbox.Common.ObjectBuilders
{
    [ProtoContract]
    [MyObjectBuilderDefinition]
    public class MyObjectBuilder_SimpleAutopilot : MyObjectBuilder_AutopilotBase
    {
        [ProtoMember(1)]
        public Vector3D Destination;

        [ProtoMember(2)]
        public Vector3 Direction;
    }
}
