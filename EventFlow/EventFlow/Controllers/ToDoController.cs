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
    }
}

