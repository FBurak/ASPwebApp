namespace ASPwebApp.Entities
{
    public class Doktor
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string UzmanlikAlani { get; set; }

        // İlişkiler
        public int PoliklinikId { get; set; }
        public Poliklinik Poliklinik { get; set; }

        public ICollection<CalismaSaatleri> CalismaSaatleri { get; set; }
        public ICollection<Randevu> Randevular { get; set; }
        // Diğer ilişkiler eklenmeli
    }

}
