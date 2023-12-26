using ASPwebApp.Entities;
using Microsoft.AspNetCore.Mvc;

public class CalismaSaatleriController : Controller
{
    private readonly DatabaseContext _databaseContext;

    public CalismaSaatleriController(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public IActionResult Index()
    {
        // Doktorun çalışma saatlerini veritabanından al ve ekranda göster
        // Bu sadece örnek bir kod, gerçek projede kullanıcı oturumu açık olan doktorun bilgilerini almalısınız
        var calismaSaatleri = _databaseContext.CalismaSaatleri.Where(x => x.DoktorId == 1).ToList();

        return View(calismaSaatleri);
    }

    public IActionResult Ekle()
    {
        // Çalışma saatleri ekleme ekranı
        return View();
    }

    [HttpPost]
    public IActionResult Ekle(CalismaSaatleriModel model)
    {
        // Çalışma saatlerini veritabanına ekleme işlemleri
        // Bu sadece örnek bir kod, gerçek projede kullanıcı oturumu açık olan doktorun bilgilerini ve çalışma saatlerini eklemelisiniz
        model.DoktorId = 1; // Örnek doktor ID
        _databaseContext.CalismaSaatleri.Add(model);
        _databaseContext.SaveChanges();

        return RedirectToAction("Index");
    }
}
