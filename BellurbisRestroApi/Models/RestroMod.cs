using System.ComponentModel.DataAnnotations;

namespace BellurbisRestroApi.Models
{
    public class RestroMod
    {
        [Key]
        public int RestroId { get; set; }
        public string RestroName { get; set; }
        public string RestroAddress { get; set; }
        public string RestroContact { get; set; }
        public string RestroTiming { get; set; }
    }
}
