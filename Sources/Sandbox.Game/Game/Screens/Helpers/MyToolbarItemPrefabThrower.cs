﻿using Sandbox.Common.ObjectBuilders;
using Sandbox.Definitions;
using Sandbox.Game.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sandbox.Game.World;
using Sandbox.Game.Entities;

namespace Sandbox.Game.Screens.Helpers
{
    [MyToolbarItemDescriptor(typeof(MyObjectBuilder_ToolbarItemPrefabThrower))]
    class MyToolbarItemPrefabThrower : MyToolbarItemDefinition
    {
        public override bool Init(MyObjectBuilder_ToolbarItem data)
        {
            bool init = base.Init(data);
            ActivateOnClick = false;
            return init;
        }

        public override bool Activate()
        {
            if (Definition == null)
                return false;

            MySessionComponentThrower.Static.Enabled = Sandbox.Engine.Utils.MyFakes.ENABLE_PREFAB_THROWER;
            MySessionComponentThrower.Static.CurrentDefinition = (MyPrefabThrowerDefinition)Definition;
            var controlledObject = MySession.ControlledEntity as IMyControllableEntity;
            if (controlledObject != null)
            {
                controlledObject.SwitchToWeapon(null);
            }

            return true;
        }

        public override bool AllowedInToolbarType(MyToolbarType type)
        {
            return type == MyToolbarType.Character || type == MyToolbarType.Spectator;
        }

        public override MyToolbarItem.ChangeInfo Update(Entities.MyEntity owner, long playerID = 0)
        {
            var blockDefinition = MySessionComponentThrower.Static.Enabled ? MySessionComponentThrower.Static.CurrentDefinition : null;
            WantsToBeSelected = MySessionComponentThrower.Static.Enabled && blockDefinition != null && blockDefinition.Id.SubtypeId == (this.Definition as MyPrefabThrowerDefinition).Id.SubtypeId;
            return ChangeInfo.None;
        }
    }
}
