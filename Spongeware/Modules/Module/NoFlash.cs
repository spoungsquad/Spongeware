namespace Spongeware.Modules.Module
{
    class NoFlash : Spongeware.Module
    {
        public NoFlash() : base("NoFlash", "Visual", "Disables the muzzle flash", null)
        {

        }

        public override void onUpdate()
        {
            player().muzzleFlash.Stop();
        }
    }
}
