using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCwithDB.Context;
using MVCwithDB.DTOs;
using MVCwithDB.Entities;
using MVCwithDB.Models;

namespace MVCwithDB.Controllers
{
    public class RoleController : Controller
    {
        PersonelContext _db;
        RoleModel _model;
        public RoleController(PersonelContext db ,RoleModel model)
        {
            _db = db;
            _model = model;
        }
        public IActionResult Index()
        {
            
            // Anonim Yaklaşım:
            //var rlist = _db.Set<Roles>().Select(x => new
            //{
            //    x.RoleId, x.RoleAd

            //}).ToList();

            // DTo Yaklaşım 
            _model.rlist = _db.Set<Roles>().Select(x => new RolesDTO
            {
                RoleAd = x.RoleAd, RolId = x.RoleId
            }).ToList();
           
            return View(_model);
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            _model.Roles = _db.Set<Roles>().Find(id);
            return View(_model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(RoleModel model)
        {
            
            _db.Entry(model.Roles).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return  RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult  Create ()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(RoleModel model)
        {
               //  _db.Set<Roles>().Add(model.Roles);
            _db.Entry(model.Roles).State = EntityState.Added;
             // yyyy
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            _model.Roles = _db.Set<Roles>().Find(id);
            return View(_model);
        }
        [HttpPost]
        public IActionResult Delete(RoleModel model)
        {
            //  _db.Set<Roles>().Remove(model.Roles);
            _db.Entry(model.Roles).State = EntityState.Deleted;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // TEK SAYFADA YÖNETİM

        //[HttpGet]
        //public IActionResult Edit(int id)
        //{
        //    ViewBag.Baslik = "Edit";
        //    ViewBag.BtnText = "Save";
        //    ViewBag.btnClass = "btn btn-primary";
        //    _model.Roles = _db.Set<Roles>().Find(id);
        //    return View(_model);
        //}
        //[HttpGet]
        //public IActionResult Delete(int id)
        //{
        //    ViewBag.Baslik = "Delete";
        //    ViewBag.BtnText = "Delete";
        //    ViewBag.btnClass = "btn btn-danger";
        //    _model.Roles = _db.Set<Roles>().Find(id);
        //    return View("Edit", _model);
        //}
    }
} 