using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPwebApp.Entities
{
    [Table("Departmans")]
    public class Departman
    {
        [Key]
        public int DepartmanId { get; set; }

        public string? Name { get; set; }
    }
}
