using Microsoft.AspNetCore.Identity;

namespace BugTrackerIdentityProject.Data
{
    public class Yorum
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual List<IdentityUser> User { get; set; }
        public int HataId { get; set; }
        public  Hata Hata { get; set; }
        public  string Aciklama { get; set; }
        //public List<Hata> Hatalar { get; set; } = new List<Hata>();
    }
}
