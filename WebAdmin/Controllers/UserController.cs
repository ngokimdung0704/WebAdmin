using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Persistence.Infrastructure;
using Service;
using WebAdmin.ConfigurationData;
using WebAdmin.Models;

namespace WebAdmin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._userService = userService;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public IActionResult Index()
        {
            var users = _userService.GetAll();
            var userModels = _mapper.Map<List<UserRawViewModel>>(users);
            return View(userModels);
        }

        public IActionResult Detail(int id)
        {
            var user = _userService.Find(id);
            if(user == null) return NotFound("Cannot find the user.");

            var userModel = _mapper.Map<UserDetailViewModel>(user);

            if(TempData["IsExisted"] != null) ModelState.AddModelError("IsExisted", TempData["IsExisted"].ToString());

            return View(userModel);
        }

        public IActionResult Delete(int id)
        {
            var user = _userService.Find(id);
            if(user == null) return NotFound("Cannot find the user.");

            _userService.Detele(user);
            _unitOfWork.Commit();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(UserDetailViewModel model)
        {
            bool IsExisted = _userService.GetAll(x => (x.Username == model.Username || x.Email == model.Email) 
                                                      && x.Id != model.Id).Count() >= 1;

            if(IsExisted) 
            {
                TempData["IsExisted"] = "Username or Email is existed before.";
                return RedirectToAction("Detail", new { @id = model.Id });
            }

            var user = _userService.Find(model.Id);
            _mapper.Map(model, user);

            _userService.Update(user);
            _unitOfWork.Commit();
            TempData["Success"] = "Update User successfully.";

            return RedirectToAction("Detail", new { @id = user.Id });
        }

        [HttpGet]
        public IActionResult UpdatePassword(int id)
        {
            var user = _userService.Find(id);
            if(user == null) return NotFound("Cannot find the user.");

            var userModel = _mapper.Map<UserUpdatePasswordViewModel>(user);

            return View(userModel);
        }

        [HttpPost]
        public IActionResult UpdatePassword(UserUpdatePasswordViewModel model)
        {
            var user = _userService.Find(model.Id);
            model.Password = CommonData.ConvertStringtoMD5(model.Password);

            _mapper.Map(model, user);

            _userService.Update(user);
            _unitOfWork.Commit();

            TempData["Success"] = "Update Password successfully.";

            return View(model);
        }
        
        public IActionResult Create()
        {
            return View(new UserCreateViewModel());
        }

        [HttpPost]
        public IActionResult Create(UserCreateViewModel model)
        {
            bool IsExist = _userService.GetAll(x => x.Username == model.Username || x.Email == model.Email).Count() >= 1;
            if(IsExist) 
            {
                ModelState.AddModelError("IsExisted", "Username or Email is existed before.");
                return View(model);
            }

            string password = CommonData.ConvertStringtoMD5(model.Password);

            var user = _mapper.Map<User>(model);
            user.Password = password;

            _userService.Add(user);
            _unitOfWork.Commit();

            return RedirectToAction("Index");
        }
    }
}