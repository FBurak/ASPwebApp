﻿using ASPwebApp.Entities;
using ASPwebApp.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace ASPwebApp.Controllers
{
    public class UserController : Controller
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;


        public UserController(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
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
    }
}