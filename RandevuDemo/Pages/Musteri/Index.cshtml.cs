using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RandevuDemo.Data;
using RandevuDemo.Data.Entities;

namespace RandevuDemo.Pages.Musteri
{
    public class IndexModel : PageModel
    {

        public string Mesaj { get; set; }
        public MusteriGirisModel PostData { get; set; }


        public DataContext _dataContect;
        public IndexModel(DataContext dataContect )
        {
            _dataContect = dataContect;

        }
        public void OnGet()
        {
            PostData = new MusteriGirisModel();
        }


        public ActionResult OnPost(MusteriGirisModel musteriGirisModel)
        {
            PostData = musteriGirisModel;
            if (ModelState.IsValid)
            {
                var kayitliMusteri = _dataContect.Musteriler.Where(musteri => musteri.Username == musteriGirisModel.Username).FirstOrDefault();
                if(kayitliMusteri == null)
                {
                    var musteri = new Data.Entities.MusteriEntitiy();
                    musteri.Username = musteriGirisModel.Username;
                    musteri.Ad = musteriGirisModel.Ad;
                    musteri.Soyad = musteriGirisModel.Soyad;
                    musteri.DogumTarihi = musteriGirisModel.DogumTarihi;

                    _dataContect.Musteriler.Add(musteri);
                    _dataContect.SaveChanges();

                    HttpContext.Session.SetInt32("MusteriId", musteri.Id);
                    return Redirect("/randevu");

                }
                HttpContext.Session.SetInt32("MusteriId", kayitliMusteri.Id);
                return Redirect("/randevu");

            }
            else
            {
              
                Mesaj = "Bilgileriniz hatalýdýr..";
            }

            return Page();
        }


        public class MusteriGirisModel
        {
            public long Username { get; set; }
            public string Ad { get; set; } = string.Empty;
            public string Soyad { get; set; } = string.Empty;
            public DateTime DogumTarihi { get; set; }

        }
    }
}
