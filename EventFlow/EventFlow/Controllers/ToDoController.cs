using EventFlow.Data;
using EventFlow.Models.DTO;
using EventFlow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventFlow.Controllers
{
    public class ToDoController:Controller
    {
        private readonly ApplicationDbContext _context;
        public ToDoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<ToDo> ObjToDoList = await _context.ToDos.ToListAsync();

            var ToDoDto = new List<ToDoDTO>();

            foreach (var ToDo in ObjToDoList)
            {
                ToDoDto.Add(new ToDoDTO()
                {
                    Id = ToDo.Id,
                    Title = ToDo.Title,
                    Description = ToDo.Description,
                    Type = ToDo.Type,
                    UserId = ToDo.UserId
                });
            }

            return View(ToDoDto);

        }
        public async Task<IActionResult> Detail(int id)
        {
            var todo = await _context.ToDos.FirstOrDefaultAsync(c => c.Id == id);
            if(todo == null)
            {
                return RedirectToAction("Index");
            }
            return View(todo);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ToDoRequest todoRequest)
        {
            if (ModelState.IsValid)
            {
                var todoModel = new ToDo
                {
                    Title = todoRequest.Title,
                    Type = todoRequest.Type,
                    Description = todoRequest.Description,
                    UserId = 1
                };
                _context.ToDos.Add(todoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(todoRequest);
        }

        public async Task<IActionResult> Delete(int id)
        {

            var todo = await _context.ToDos.FindAsync(id);

            if (todo == null)
            {
                return View("Error");
            }
            return View(todo);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteItem(int id)
        {

            var todo = await _context.ToDos.FindAsync(id);

            if (todo == null)
            {
                return View("Error");
            }

            _context.Remove(todo);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");


        }


        public async Task<IActionResult> Edit(int id)
        {
            var todo = await _context.ToDos.FindAsync(id);

            if (todo == null)
            {
                return View("Error");
            }
            return View(todo);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ToDoRequest todoRequest)
        {
            if (ModelState.IsValid)
            {
                var todoModel = new ToDo
                {
                    Id = todoRequest.Id,
                    Title = todoRequest.Title,                
                    Type = todoRequest.Type,
                    Description = todoRequest.Description,
                    UserId = 1
                };
                _context.ToDos.Update(todoModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(todoRequest);
        }

    }
}

