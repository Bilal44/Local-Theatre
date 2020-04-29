﻿using AssessmentLocalTheatre.Extensions;
using AssessmentLocalTheatre.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AssessmentLocalTheatre.Controllers
{
    /// <summary>
    /// Main ApplicationUser controller.
    /// Contains all methods for performing CRUD functions on the ApplicationUser class.
    /// </summary>

    // Restrict controller access to Roles.
    //[Authorize(Roles = "Admin")]
    public class ApplicationUserController : Controller
    {
        // Instance of the database.
        private ApplicationDbContext context = new ApplicationDbContext();

        // GET: ApplicationUser
        /// <summary>
        /// Loads the Index view.
        /// </summary>
        /// <returns>Index view.</returns>
        public ActionResult Index()
        {
            if (ModelState.IsValid)
            {
                try
                {

                }
                catch (Exception ex)
                {

                }
            }
            return View();
        }

        // GET: ApplicationUser
        /// <summary>
        /// Loads the ViewAllStaff view.
        /// </summary>
        /// <returns>ViewAllStaff view.</returns>
        public ActionResult ViewAllStaff()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // All authors and admins are staff.
                    var staff = context.Users.OfType<Staff>().ToList();
                    return View(staff.ToList());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    this.AddNotification("Error loading Index view: " + ex, NotificationType.WARNING);
                    return View();
                }
            }
            return View();
        }

        // GET: ApplicationUser
        /// <summary>
        /// Loads the ViewAllMembers view.
        /// </summary>
        /// <returns>ViewAllMembers view.</returns>
        public ActionResult ViewAllMembers()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var names = Roles.GetUsersInRole("Member");
                    var members = new List<ApplicationUser>();
                    foreach (var name in names)
                    {
                        foreach (ApplicationUser user in context.Users)
                        {
                            if (user.UserName.Equals(name)) members.Add(user);
                        }
                    }

                    return View(members.ToList());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    this.AddNotification("Error loading Index view: " + ex, NotificationType.WARNING);
                    return View();
                }
            }
            return View();
        }

        // GET: ApplicationUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        

        // GET: ApplicationUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApplicationUser/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}