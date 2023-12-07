using System.ComponentModel.DataAnnotations.Schema;

namespace RandevuDemo.Data.Entities
{
    [Table("Musteriler")]
    public class MusteriEntitiy
    {
        public int Id { get; set; }
        public long Username { get; set; }
        public string Ad { get; set; } = string.Empty;
        public string Soyad { get; set; } = string.Empty;
        public DateTime DogumTarihi { get; set; }


    }
}
