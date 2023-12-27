using ASPwebApp.Entities;
using ASPwebApp.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASPwebApp.Controllers
{
    public class DoctorController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public DoctorController(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            List<DoctorModel> doctors =
                 _databaseContext.Doctors.ToList().Select(x => _mapper.Map<DoctorModel>(x)).ToList();

            return View(doctors);
        }



        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateDoctorModel model)
        {
            if (ModelState.IsValid)
            {

                if (_databaseContext.Users.Any(x => x.Username.ToLower() == model.Username.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.Username), "Doctor Username is already exists.");
                    return View(model);
                }

                Doctor doctor = _mapper.Map<Doctor>(model);

                _databaseContext.Doctors.Add(doctor);
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        public IActionResult Edit(Guid id)
        {
            Doctor doctor = _databaseContext.Doctors.Find(id);
            EditDoctorModel model = _mapper.Map<EditDoctorModel>(doctor);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, EditDoctorModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.Doctors.Any(x => x.Username.ToLower() == model.Username.ToLower() && x.Id != id))
                {
                    ModelState.AddModelError(nameof(model.Username), "Doctor Username is already exists.");
                    return View(model);
                }

                Doctor doctor = _databaseContext.Doctors.Find(id);

                _mapper.Map(model, doctor);
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        public IActionResult Delete(Guid id)
        {

            Doctor doctor = _databaseContext.Doctors.Find(id);

            if (doctor != null)
            {
                _databaseContext.Doctors.Remove(doctor);
                _databaseContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));

        }

    }
}
