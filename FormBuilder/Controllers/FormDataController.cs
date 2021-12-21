#nullable disable
using FormBuilder.Data;
using FormBuilder.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FormBuilder.Controllers
{
    public class FormDataController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FormDataController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FormData
        public async Task<IActionResult> Index()
        {
            return View(await _context.Forms.ToListAsync());
        }

        // GET: FormData/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formData = await _context.Forms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formData == null)
            {
                return NotFound();
            }

            return View(formData);
        }

        // GET: FormData/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FormData/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(include: "Id,Name,CreatedDate")] FormData formData)
        {
            if (ModelState.IsValid)
            {
                _context.Forms.Add(formData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formData);
        }
        public async Task<IActionResult> FormFieldAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formData = await _context.Forms.FindAsync(id);
            if (formData == null)
            {
                return NotFound();
            }
            FormElement element = new();
            element.FormData = formData;
            element.FormDataId = id;
            return View(element);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FormField(int id, [Bind("ElementId,ElementLabel,ElementType,ElementValue,FormDataId")] FormElement formElement)
        {
            if (id != formElement.FormDataId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Elements.Add(formElement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(formElement);
        }
        public async Task<IActionResult> FormCreateField(int id)
        {
            return View(await _context.Elements.ToListAsync());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> FormCreateField(int id, FormElement formElement)
        {
            if (ModelState.IsValid)
            {
                return View(formElement);
            }
            return View();
        }
        // GET: FormData/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formData = await _context.Forms.FindAsync(id);
            if (formData == null)
            {
                return NotFound();
            }
            return View(formData);
        }

        // POST: FormData/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CreatedDate")] FormData formData)
        {
            if (id != formData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Forms.Update(formData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FormDataExists(formData.Id))
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
            return View(formData);
        }

        // GET: FormData/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var formData = await _context.Forms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (formData == null)
            {
                return NotFound();
            }

            return View(formData);
        }

        // POST: FormData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var formData = await _context.Forms.FindAsync(id);
            _context.Forms.Remove(formData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormDataExists(int id)
        {
            return _context.Forms.Any(e => e.Id == id);
        }
    }
}
