using ASPwebApp.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ASPwebApp.Controllers
{
    [Authorize]
    public class MakeAppointmentController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public MakeAppointmentController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<IActionResult> Index()
        {
            var makeappointments = await _databaseContext.Makeapms.Include(x=>x.User).Include(x => x.Appointment).ToListAsync();
            return View(makeappointments);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Users = new SelectList(await _databaseContext.Users.ToListAsync(),"Id", "FullName");
            ViewBag.Appointments = new SelectList(await _databaseContext.Appointments.ToListAsync(),"AppId","Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Makeapm model)
        {
            model.AppointmentMakeTime = DateTime.Now;
            _databaseContext.Makeapms.Add(model);
            await _databaseContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }
}
