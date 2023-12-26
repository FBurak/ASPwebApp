// Controllers/DoctorPanelController.cs
using ASPwebApp.Entities;
using Microsoft.AspNetCore.Mvc;

public class DoctorPanelController : Controller
{
    private readonly DatabaseContext _databaseContext;

    public DoctorPanelController(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public IActionResult Index()
    {
        // Doktorun çalışma saatlerini al ve ekranda göster
        // Bu sadece örnek bir kod, gerçek projede kullanıcı oturumu açık olan doktorun bilgilerini almalısınız
        var calismaSaatleri = _databaseContext.CalismaSaatleri.Where(x => x.DoktorId == 1).ToList();

        return View(calismaSaatleri);
    }

    public IActionResult EditCalismaSaatleri(int id)
    {
        // Çalışma saatlerini düzenleme ekranı
        var calismaSaatleri = _databaseContext.CalismaSaatleri.Find(id);

        return View(calismaSaatleri);
    }

    [HttpPost]
    public IActionResult EditCalismaSaatleri(CalismaSaatleriModel model)
    {
        // Çalışma saatlerini güncelleme işlemleri
        _databaseContext.CalismaSaatleri.Update(model);
        _databaseContext.SaveChanges();

        return RedirectToAction("Index");
    }
}
