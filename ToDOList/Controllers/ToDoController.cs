using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDOList.Infastructure;
using ToDOList.Models;

namespace ToDOList.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoContext context;
    

        public ToDoController(ToDoContext context)
        {
            this.context = context;
        }
        // GET /
        public async Task<ActionResult> Index()
        {
            IQueryable<ToDo> items = from i in context.ToDoList orderby i.Id select i;
            List<ToDo> toDOLists = await items.ToListAsync();

            return View(toDOLists);
        }
        //GET 

        public IActionResult Create() => View();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ToDo item)
        {
            if (ModelState.IsValid)
            {
                context.Add(item);
                await context.SaveChangesAsync();
                TempData["Success"] = "Added the item successfully";
                return RedirectToAction("Index");
            }
            return View(item);
        }
        public async Task<ActionResult> Edit(int id)
        {
            ToDo item = await context.ToDoList.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ToDo item)
        {
            if (ModelState.IsValid)
            {
                context.Update(item);
                await context.SaveChangesAsync();
                TempData["Success"] = "Edited the item successfully";
                return RedirectToAction("Index");
            }
            return View(item);
        }
        public async Task<ActionResult> Delete(int id)
        {
            ToDo item = await context.ToDoList.FindAsync(id);
            if (item == null)
            {
                TempData["Error"] = "Item does not exist";
            }
            else
            {
                context.ToDoList.Remove(item);
                await context.SaveChangesAsync();
                TempData["Success"] = "Deleted the item successfully";
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> IsDone(int id)
        {
            ToDo item = await context.ToDoList.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            else 
            {
                if (item.IsDone == true)
                {
                    item.IsDone = false;
                  
                    await context.SaveChangesAsync();
                    context.Update(item);
                }
                else
                {
                    item.IsDone = true;

                    await context.SaveChangesAsync();
                    context.Update(item);
                }
            }
            return RedirectToAction("Index");
        }     
    }
  
}
