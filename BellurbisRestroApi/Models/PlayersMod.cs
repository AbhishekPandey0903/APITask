using System.ComponentModel.DataAnnotations;

namespace BellurbisRestroApi.Models
{
    public class PlayersMod
    {
        [Key]
        public int PlayersId { get; set; }
        public string PlayerName { get; set; }

        public string PlayerDOB { get; set; }

        public string PlayerPrimaryAdd { get; set; }
        public string PlayerAlternateAdd { get; set; }
        public string PlayerOfficeAdd { get; set; }
        public string PlayerMobNo { get; set; }
        public string PlayerEmail { get; set; }
        public string PlayerDL { get; set; }
        public string PlayerPassport { get; set; }
        public string PlayerCountry { get; set; }
        public string PlayerState { get; set; }
        public string PlayerCity { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PlayerPostal { get; set; }








    }
}
