using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RandevuDemo.Data;
using RandevuDemo.Data.Entities;

namespace RandevuDemo.Pages.Musteri
{
    public class RandevuModel : PageModel
    {

        public DataContext _dataContext;
        public RandevuModel(DataContext dataContect)
        {
            _dataContext = dataContect;

        }
        public string Mesaj { get; set; }
        public MusteriEntitiy? musteri;
        public List<KuaforEntitiy>? Kuaforler;
        public List<RandevuEntitiy>? randevular;

        public ActionResult OnGet()
        {
            int? musteriId = HttpContext.Session.GetInt32("MusteriId");
            if(musteriId == null ||musteriId == 0)
            {
              return  Redirect("/");
            }
            musteri = _dataContext.Musteriler.Where(musteri => musteri.Id == musteriId).FirstOrDefault();

            Kuaforler = _dataContext.Kuaforler.Include(q => q.KuaforDukkani).ToList();
            randevular = _dataContext.Randevular.Include(q => q.Durum).Include("Kuafor.KuaforDukkani").Where(q => q.MusteriId == musteriId).ToList();

            return Page();

        }

        public ActionResult OnPost(MusteriRandevuModel musteriRandevuModel)
        {
            int? musteriId = HttpContext.Session.GetInt32("MusteriId");
            if (musteriId == null || musteriId == 0)
            {
                return Redirect("/");
            }

            var randevu = new RandevuEntitiy();
            randevu.KuaforId = musteriRandevuModel.KuaforId;
            randevu.MusteriId = musteriId ?? 0;
            randevu.Tarih = musteriRandevuModel.Tarih;
            randevu.Saat = musteriRandevuModel.Saat;
            randevu.DurumId = 1;

            _dataContext.Randevular.Add(randevu);
            _dataContext.SaveChanges();


            musteri = _dataContext.Musteriler.Where(musteri => musteri.Id == musteriId).FirstOrDefault();

            Kuaforler = _dataContext.Kuaforler.Include(q => q.KuaforDukkani).ToList();
            randevular = _dataContext.Randevular.Include(q => q.Durum).Include("Kuafor.KuaforDukkani").Where(q => q.MusteriId == musteriId).ToList();
            return Page();

        }

        public class MusteriRandevuModel
        {
            public int KuaforId { get; set; }
            public DateTime Tarih { get; set; }
            public string Saat { get; set; }

        }
    }
}
