using Spongeware.Utils;

namespace Spongeware.Modules.Module
{
    class NoFireRate : Spongeware.Module
    {
        public NoFireRate() : base("NoFireRate", "Combat", "No shooting speed limit")
        {

        }

        public override void onUpdate()
        {
            PrivateAccess.SetPrivateProperty(player(), "fireTimer", 0);
        }
    }
}