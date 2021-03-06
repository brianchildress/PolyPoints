﻿using Polypoints.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;

namespace Polypoints.Controllers
{
    [Authorize]
    public class ClientsController : Controller
    {
        //
        // GET: /Clients/
        
        public ActionResult Index()
        {
            {
                using (var db = new polypointsEntities())
                {
                    return View(db.Clients.Include(c => c.ClientUsers).ToList());
                }
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Client client)
        {
            try
            {
                using (var db = new polypointsEntities())
                {
                    db.Clients.Add(client);
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new polypointsEntities())
            {
                var _clients = db.Clients.Where(c => c.ClientID == id)
                    .Include(c => c.ClientUsers.Select(cu => cu.Role))
                    .Include(clients => clients.ClientUsers.Select(cu => cu.UserProfile))
                    .FirstOrDefault();
                
                return View(_clients);
            }
        }
        public ActionResult Edit(int id)
        {
            using (var db = new polypointsEntities())
            {
                return View(db.Clients.Find(id));
            }
        }
        [HttpPost]
        public ActionResult Edit(int id, Client client)
        {
            try
            {
                using (var db = new polypointsEntities())
                {
                    db.Entry(client).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            using (var db = new polypointsEntities())
            {
                return View(db.Clients.Find(id));
            }
        }
        [HttpPost]
        public ActionResult Delete(int id, Client client)
        {
            try
            {
                using (var db = new polypointsEntities())
                {
                    db.Entry(client).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

    }
}
