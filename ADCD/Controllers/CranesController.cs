using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ADCD.Data;
using ADCD.Models;
using ADCD.Views.ViewModels;

namespace ADCD.Controllers
{
    public class CranesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CranesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cranes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cranes.ToListAsync());
        }

        // GET: Cranes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = new OrderViewModel();

            order.CraneId = await _context.Cranes
                .Where(x => x.CraneId == id)
                .Select(x => x.CraneId)
                .FirstOrDefaultAsync();

            if (order.CraneId < 0)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Cranes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OrderViewModel model)
        {
            if (ModelState.IsValid)
            {
                var crane = await _context.Cranes.FirstOrDefaultAsync(x => x.CraneId == model.CraneId);

                if (crane == null)
                {
                    return NotFound();
                }

                var company = new Company
                {
                    CompanyName = model.CompanyName,
                    Address = model.CompanyAddress.Street + ", " + model.CompanyAddress.City + " " +
                        model.CompanyAddress.State + ", " + model.CompanyAddress.ZipCode
                };

                _context.Add(company);


                var contact = new Contact
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Phone = model.Phone,
                    Company = company
                };
                _context.Add(contact);



                var jobsite = new Jobsite
                {
                    JobsiteName = model.JobsiteName,
                    Address = model.JobsiteAddress.Street + ", " + model.JobsiteAddress.City + " " +
                        model.JobsiteAddress.State + ", " + model.JobsiteAddress.ZipCode
                };

                var order = new Order
                {
                    OrderDate = DateTime.Today,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    Company = company,
                    Crane = crane,
                    Jobsite = jobsite
                };

                _context.Add(order);
                _context.Add(jobsite);
                await _context.SaveChangesAsync();

                return View("Confirmation");
            }

            return View("Details", model);
            
        }

        // POST: Cranes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CraneId,CraneType,Capacity,BoomLength,JibLength,PerHourRate,Image")] Crane crane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(crane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(crane);
        }*/

        private bool CraneExists(int id)
        {
            return _context.Cranes.Any(e => e.CraneId == id);
        }
    }
}
