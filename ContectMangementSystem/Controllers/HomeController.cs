using ContectMangementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ContectMangementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ContactEntity _contactEntity;
        
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ContactEntity contactEntity)
        {
            _logger = logger;
            _contactEntity = contactEntity;
        }

        public IActionResult Index()
        {
            var data = _contactEntity.Set<ContactModel>().ToList();

            if(data!=null)
            {
                ViewBag.ContactList=data;
            }

            var favList = _contactEntity.Set<ContactModel>().Where(s=>s.IsFav.Equals(true)).ToList();

            if (favList != null)
            {
                ViewBag.favList = favList;
            }

            return View();
        }

        [HttpPost]
        public IActionResult SaveConatct(ContactModel contactModel)
        {
            try
            {
                if(contactModel.ContactId==0)
                {
                    contactModel.IsFav = false;
                    _contactEntity.Add(contactModel);
                    int count = _contactEntity.SaveChanges();
                }
                else
                {
                    var data = (_contactEntity.Set<ContactModel>().ToList()).Where(id => id.ContactId.Equals(contactModel.ContactId)).FirstOrDefault();
 
                    data.FirstName = contactModel.FirstName;
                    data.LastName = contactModel.LastName;
                    data.Email = contactModel.Email;
                    data.Password = contactModel.Password;
                    data.Phone = contactModel.Phone;
                    data.Address = contactModel.Address;
                    data.IsFav = contactModel.IsFav;
                    int count = _contactEntity.SaveChanges();

                    
                }
            }
            catch (Exception)
            {

                throw;
            }


            return RedirectToAction("Index");
        }

        public JsonResult EditContact(long ContactId)
        {
            var data = (_contactEntity.Set<ContactModel>().ToList()).Where(id => id.ContactId.Equals(ContactId)).FirstOrDefault();
            return Json(data);
        }

        public IActionResult DeleteContact(long id)
        {
             
            var data = _contactEntity.Set<ContactModel>().Where(s => s.ContactId.Equals(id)).FirstOrDefault();
            if (data != null)
                data.ContactId = id;
            _contactEntity.Remove(data);
            var count = _contactEntity.SaveChanges();

            return RedirectToAction("Index");

        }

        public IActionResult MarkFav(long id)
        {
            var data = (_contactEntity.Set<ContactModel>().ToList()).Where(r => r.ContactId.Equals(id)).FirstOrDefault();
            data.IsFav = true;
            int count = _contactEntity.SaveChanges();

            return RedirectToAction("Index");
        }
        
        public IActionResult unMarkFav(long id)
        {
            var data = (_contactEntity.Set<ContactModel>().ToList()).Where(r => r.ContactId.Equals(id)).FirstOrDefault();
            data.IsFav = false;
            int count = _contactEntity.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
