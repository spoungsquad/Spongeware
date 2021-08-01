using UnityEngine;
using Spongeware.Utils;

namespace Spongeware.Modules.Module
{
    class TriggerBot : Spongeware.Module
    {
        public TriggerBot() : base("TriggerBot", "Combat", "Automatcally shoots if you're looking at a shootable object")
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
