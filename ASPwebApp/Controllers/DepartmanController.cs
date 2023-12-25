using ASPwebApp.Entities;
using ASPwebApp.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace ASPwebApp.Controllers
{
    [Authorize]
    public class DepartmanController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        public DepartmanController(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List<DepartmanModel> departmans =
                _databaseContext.Departmans.ToList().Select(x => _mapper.Map<DepartmanModel>(x)).ToList();

            return View(departmans);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DepartmanModel model)
        {
            if (ModelState.IsValid)
            {
                Departman departman = _mapper.Map<Departman>(model);

                _databaseContext.Departmans.Add(departman);
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }

    }
}
