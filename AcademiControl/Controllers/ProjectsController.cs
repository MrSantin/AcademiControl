﻿using System;
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

namespace AcademiControl.Controllers
{
    public class ProjectsController : Controller
    {
        private readonly DBContext _context;
        private const string Bind = "Name,Description,OwnerId";

        public ProjectsController(DBContext context)
        {
            _context = context;
        }

        // GET: Projects
        public async Task<IActionResult> Index()
        {
              return _context.Projects != null ? 
                          View(await _context.Projects.ToListAsync()) :
                          Problem("Entity set 'DBContext.Projects'  is null.");
        }

        // GET: Projects/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .Include(x => x.ProjectOwner)
                .FirstOrDefaultAsync(m => m.Id == id)
                ;
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // GET: Projects/Create
        public IActionResult Create()
        {
            //   var project = _context.Projects.Include(m => m.ProjectOwner);
            // ViewData["OwnerList"] = new SelectList(_context.Staff, "Id", "Name"); // Criando lista para mostrar no frontend
           
            var ownerList = new SelectList(_context.Staff.ToList(), "Id", "Name");
            // Atribua a lista ao ViewBag para torná-la disponível na view
            ViewBag.OwnerList = ownerList;


            return View();

       
    }



        // POST: Projects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public IActionResult Create([FromBody] CreateProjectCommand command, [FromServices] ProjectHandlers handlers)
        {
            handlers.Handle(command);
            return View("Index");
        }

        // GET: Projects/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects.Include(x => x.ProjectOwner).FirstOrDefaultAsync(x => x.Id == id);

            if (project == null)
            {
                return NotFound();
            }

            var ownerList = new SelectList(_context.Staff.ToList(), "Id", "Name");
            // Atribua a lista ao ViewBag para torná-la disponível na view
            ViewBag.OwnerList = ownerList;

            return View(project);
        }

        // POST: Projects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody] UpdateProjectCommand command, [FromServices] ProjectHandlers handlers)
        {
            handlers.Handle(command);
            return View();
        }

        // GET: Projects/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Projects == null)
            {
                return NotFound();
            }

            var project = await _context.Projects
                .FirstOrDefaultAsync(m => m.Id == id);
            if (project == null)
            {
                return NotFound();
            }

            return View(project);
        }

        // POST: Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed([FromBody] DeleteProjectCommand command, [FromServices] ProjectHandlers handlers)
        {
            handlers.Handle(command);
            return RedirectToAction(nameof(Index));
        }

        private bool ProjectExists(Guid id)
        {
          return (_context.Projects?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
