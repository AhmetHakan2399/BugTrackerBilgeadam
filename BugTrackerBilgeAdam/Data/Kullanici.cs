using Microsoft.AspNetCore.Identity;

namespace BugTrackerIdentityProject.Data
{
    public class Kullanici : IdentityUser
    {
        public string AdiSoyAdi { get; set; }
        public string KullaniciRolü { get; set; }
    }
}
