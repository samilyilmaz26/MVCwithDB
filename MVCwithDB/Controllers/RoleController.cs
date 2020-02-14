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
         
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
} 