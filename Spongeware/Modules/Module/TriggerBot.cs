using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Spongeware.Modules.Module
{
    class TriggerBot : Spongeware.Module
    {
        public TriggerBot() : base("TriggerBot", "Combat", "Auto ")
        {
        }

        public override void onUpdate()
        {
            RaycastHit raycastHit;
            if (Physics.Raycast(player().fpsCam.transform.position, player().fpsCam.transform.forward, out raycastHit, 500f, LayerMask.GetMask(new string[]
            {
                "Shootable"
            })))
            {
                MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp | MouseOperations.MouseEventFlags.LeftDown);
            }
        }
    }
}
