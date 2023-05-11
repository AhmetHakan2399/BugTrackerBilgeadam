namespace BugTrackerIdentityProject.Data
{
    public class DetayViewModel
    {
        public int Id { get; set; }
        public string KullaniciAdi { get; set; }
        public string KullaniciRolü { get; set; }
        public string KullaniciId { get; set; }
        public string HataBaslik { get; set; }
        public string HataDetay { get; set; }
        public string HataDurum { get; set; }
        public string HataÖncelik { get; set; }
        public DateTime KayıtTarihi { get; set; }
        public int HataId { get; set; }
        public int YorumId { get; set; }
        public string Aciklama { get; set; }


    }
}
