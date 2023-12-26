namespace ASPwebApp.Entities
{
    public class Poliklinik
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Aciklama { get; set; }

        // İlişkiler
        public int AnaBilimDaliId { get; set; }
        public AnaBilimDali AnaBilimDali { get; set; }

        public ICollection<Doktor> Doktorlar { get; set; }
        // Diğer ilişkiler eklenmeli
    }

}
