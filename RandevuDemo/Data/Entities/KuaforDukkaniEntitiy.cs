using System.ComponentModel.DataAnnotations.Schema;

namespace RandevuDemo.Data.Entities
{
    [Table("KuaforDukkanlari")]
    public class KuaforDukkaniEntitiy
    {
        public int Id { get; set; }
        public string Ad { get; set; } = string.Empty;
        public string Il { get; set; } = string.Empty;
        public string Ilce { get; set; } = string.Empty;
        public string Adres { get; set; } = string.Empty;

        public List<KuaforEntitiy> Kuaforler { get; set; }

    }
}
