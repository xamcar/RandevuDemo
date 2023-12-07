using System.ComponentModel.DataAnnotations.Schema;

namespace RandevuDemo.Data.Entities
{
    [Table("RandevuDurumlar")]
    public class RandevuDurumEntitiy
    {
        public int Id { get; set; }
        public string Durum { get; set; } = string.Empty;
    }
}
