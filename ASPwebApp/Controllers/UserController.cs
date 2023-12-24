using ASPwebApp.Entities;
using ASPwebApp.Helpers;
using ASPwebApp.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASPwebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        private readonly IHasher _hasher;


        public UserController(DatabaseContext databaseContext, IMapper mapper, IHasher hasher)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
            _hasher = hasher;
        }

        public IActionResult Index()
        {   
            List<UserModel> users = 
                _databaseContext.Users.ToList().Select(x => _mapper.Map<UserModel>(x)).ToList();
            
            
            return View(users);
        }
        public IActionResult Create()
        {
           return View();
        }


        [HttpPost]
        public IActionResult Create(CreateUserModel model)
        {
            if (ModelState.IsValid)
            {

                if (_databaseContext.Users.Any(x=>x.Username.ToLower()==model.Username.ToLower()))
                {
                    ModelState.AddModelError(nameof(model.Username),"Username is already exists.");
                    return View(model);
                }

                User user = _mapper.Map<User>(model);
                user.Password = _hasher.DoMD5HashedString(model.Password);

                _databaseContext.Users.Add(user);
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }



        public IActionResult Edit(Guid id)
        {
            User user = _databaseContext.Users.Find(id);
            EditUserModel model = _mapper.Map<EditUserModel>(user);
            return View(model);
        }


        [HttpPost]
        public IActionResult Edit(Guid id , EditUserModel model)
        {
            if (ModelState.IsValid)
            {
                if (_databaseContext.Users.Any(x => x.Username.ToLower() == model.Username.ToLower() && x.Id!=id ))
                {
                    ModelState.AddModelError(nameof(model.Username), "Username is already exists.");
                    return View(model);
                }

                User user = _databaseContext.Users.Find(id);

                _mapper.Map(model, user);
                _databaseContext.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        public IActionResult Delete(Guid id)
        {
           
            User user = _databaseContext.Users.Find(id);

            if (user!=null)
            {
                _databaseContext.Users.Remove(user);
                _databaseContext.SaveChanges();
            }                                
            
             return RedirectToAction(nameof(Index));
         
        }



    }
}
