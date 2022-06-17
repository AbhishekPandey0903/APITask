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
    public class ListOfResAndPaly
    {
        public PlayersMod pl { get; set; }
        public List<PlayersMod> pls { get; set; }
        public List<RestroMod> rts { get; set; }
        public RestroMod rt { get; set; }
    }
}
