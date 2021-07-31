namespace Spongeware.Modules.Module
{
    class InfAmmo : Spongeware.Module
    {
        public InfAmmo() : base("InfAmmo", "Combat", "Never reload")
        {

        }

        public override void onUpdate()
        {
            PlayerMovement.ammo = 4;
        }
    }
}
