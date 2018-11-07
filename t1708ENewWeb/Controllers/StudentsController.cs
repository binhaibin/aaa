using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using t1708ENewWeb.Models;

namespace t1708ENewWeb.Controllers
{
    public class StudentsController : Controller
    {
        private readonly t1708ENewWebContext _context;

        public StudentsController(t1708ENewWebContext context)
        {
            _context = context;
         

        }

        // GET: Students
        public async Task<IActionResult> Index()
        {
            return View(await _context.Student.ToListAsync());
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.Include(m=>m.Marks)
                .FirstOrDefaultAsync(m => m.RollNumber == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RollNumber,FirstName,LastName,Email,CreateAt,UpdateAt,Status")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("RollNumber,FirstName,LastName,Email,CreateAt,UpdateAt,Status")] Student student)
        {
            if (id != student.RollNumber)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.RollNumber))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Student
                .FirstOrDefaultAsync(m => m.RollNumber == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(string id)
        //{
        //    var student = await _context.Student.FindAsync(id);
        //    _context.Student.Remove(student);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool StudentExists(string id)
        {
            return _context.Student.Any(e => e.RollNumber == id);
        }
        [HttpPost]
        public IActionResult Del(string id)
        {
            var exisProduct = _context.Student.Find(id);
            if (exisProduct == null)
            {
                return NotFound();
            }


            _context.Student.Remove(exisProduct);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        public IActionResult DeleteMany(string ids)
        {
            var num = ids.Split(",").Length;

            foreach (var id in ids.Split(","))
            {
                var exisStudents = _context.Student.Find(id);
                if (exisStudents == null)
                {
                    return NotFound();
                }

                _context.Student.Remove(exisStudents ?? throw new InvalidAsynchronousStateException());
            }

            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
