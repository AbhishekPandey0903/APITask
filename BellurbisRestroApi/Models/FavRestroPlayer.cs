namespace BellurbisRestroApi.Models
{
    public class FavRestroPlayer
    {
        public FavRestroPlayer()
        {
            pl = new PlayersMod();
            rt = new RestroMod();
            fv = new LinkMod();
        }
        public PlayersMod pl { get; set; }
        public RestroMod rt { get; set; }
        public LinkMod fv { get; set; }
    }
}
