using ASPwebApp.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPwebApp.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public AppointmentController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<IActionResult> Index()
        {
            var appointments = await _databaseContext.Appointments.ToListAsync();
            return View(appointments);
        }
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Appointment model)
        {
            _databaseContext.Appointments.Add(model);
            await _databaseContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var appointment = await _databaseContext.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id , Appointment model)
        {
            if (id!=model.AppId)
            {
                return NotFound();
            }
            if (ModelState.IsValid) 
            {
                try
                {
                    _databaseContext.Update(model);
                    await _databaseContext.SaveChangesAsync();
                }
                catch (DbUpdateException)
                {
                    if (!_databaseContext.Appointments.Any(o=>o.AppId == model.AppId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                    
                }
            return RedirectToAction("Index");
            }    
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var appointment = await _databaseContext.Appointments.FindAsync(id);

            if (appointment == null)
            {
                return NotFound();
            }
            return View(appointment);
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            var appointment = await _databaseContext.Appointments.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            _databaseContext.Appointments.Remove(appointment);
            await _databaseContext.SaveChangesAsync();   
            return RedirectToAction("Index");   
        }





    }
}
