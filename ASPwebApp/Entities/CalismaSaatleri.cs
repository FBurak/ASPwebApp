namespace ASPwebApp.Entities
{
    public class CalismaSaatleri
    {
        public int Id { get; set; }
        public DayOfWeek Gun { get; set; }
        public TimeSpan BaslangicSaati { get; set; }
        public TimeSpan BitisSaati { get; set; }

        // İlişkiler
        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; }
    }

}
