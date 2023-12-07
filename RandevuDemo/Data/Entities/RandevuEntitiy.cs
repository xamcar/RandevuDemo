using System.ComponentModel.DataAnnotations.Schema;

namespace RandevuDemo.Data.Entities
{
    [Table("Randevular")]
    public class RandevuEntitiy
    {
        public int Id { get; set; }
        public int KuaforId { get; set; }
        public int MusteriId { get; set; }
        public DateTime Tarih { get; set; }

        public string Saat { get; set; } = string.Empty;

        public int DurumId { get; set; }

        public RandevuDurumEntitiy Durum { get; set; }
        public KuaforEntitiy Kuafor { get; set; }
        public MusteriEntitiy Musteri { get; set; }
    }
}
