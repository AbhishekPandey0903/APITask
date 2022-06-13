using System.ComponentModel.DataAnnotations;

namespace BellurbisRestroApi.Models
{
    public class LinkMod
    {
        [Key]
        public int Id { get; set; }
        public int RestroId { get; set; }
        public int PlayersId { get; set; }
        public bool Fav { get; set; }

    }
}
