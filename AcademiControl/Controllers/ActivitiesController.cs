using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AcademiControl.Context;
using AcademiControl.Models;
using AcademiControl.Commands.Projects;
using AcademiControl.Handlers;
using AcademiControl.Commands.Activities;

namespace AcademiControl.Controllers
{
    public class ActivitiesController : Controller
    {
        private readonly DBContext _context;

        public ActivitiesController(DBContext context)
        {
            _context = context;
        }

        // GET: Activities
        public async Task<IActionResult> Index()
        {
              return _context.Activities != null ? 
                          View(await _context.Activities.ToListAsync()) :
                          Problem("Entity set 'DBContext.Activities'  is null.");
        }

        // GET: Activities/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Activities == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // GET: Activities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Activities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<IActionResult> Create([FromBody] CreateActivityCommand command, [FromServices] ActivitiesHandlers handlers)
        {
            handlers.Handle(command);
            return View("Index");
        }

        // GET: Activities/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Activities == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities.FindAsync(id);
            if (activity == null)
            {
                return NotFound();
            }
            return View(activity);
        }

        // POST: Activities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] UpdateActivityCommand command, [FromServices] ActivitiesHandlers handlers)
        {
            handlers.Handle(command);
            return View();
        }


        // GET: Activities/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Activities == null)
            {
                return NotFound();
            }

            var activity = await _context.Activities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (activity == null)
            {
                return NotFound();
            }

            return View(activity);
        }

        // POST: Activities/Delete/5
        [HttpPost, ActionName("Delete")]

        public async Task<IActionResult> DeleteConfirmed([FromBody] DeleteActivityCommand command, [FromServices] ActivitiesHandlers handlers)
        {
            handlers.Handle(command);
            return RedirectToAction(nameof(Index));
        }
        private bool ActivityExists(Guid id)
        {
          return (_context.Activities?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
