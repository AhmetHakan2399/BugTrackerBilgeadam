using Microsoft.AspNetCore.Identity;

namespace BugTrackerIdentityProject.Data
{
    public class Hata
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; }

        public string HataBaslik { get; set; }
        public string HataDetay { get; set; }
        public string HataDurum { get; set; }
        public DateTime KayitTarihi { get; set; }
    }
}
