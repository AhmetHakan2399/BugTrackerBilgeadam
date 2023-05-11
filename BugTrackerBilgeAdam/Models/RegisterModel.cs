using System.ComponentModel.DataAnnotations;

namespace BugTrackerIdentityProject.Models
{
    public class RegisterModel
    {
        [Required]
        public string AdiSoyAdi { get; set; }
        [Required]
        public string Sifre { get; set; }
        [Required]
        public string KullaniciAdi { get; set; }
        //[Required]
        public string KullaniciRolü { get; set; }
        public string SifreTekrar { get; set; }
    }
}
