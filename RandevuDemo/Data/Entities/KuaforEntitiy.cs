using System.ComponentModel.DataAnnotations.Schema;

namespace RandevuDemo.Data.Entities
{
    [Table("Kuaforler")]
    public class KuaforEntitiy
    {
        public int Id { get; set; }
        public int KuaforDukkaniId { get; set; }
        public string Ad { get; set; } = string.Empty;
        public string Soyad { get; set; } = string.Empty;

        public KuaforDukkaniEntitiy KuaforDukkani { get; set; }

        public List<RandevuEntitiy> Randevular { get; set; }


    }
}
