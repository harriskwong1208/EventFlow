using EventFlow.Data;
using EventFlow.Models;
using EventFlow.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventFlow.Controllers
{
    public class UpcomingController : Controller
    {
        private readonly ApplicationDbContext _context;
        public UpcomingController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Upcoming> ObjUpcomingList = await _context.Upcomings.ToListAsync();
            
            var UpcomingDto = new List<UpcomingDTO>();

            foreach(var Upcoming in ObjUpcomingList)
            {
                UpcomingDto.Add(new UpcomingDTO()
                {
                    Id = Upcoming.Id,
                    Title = Upcoming.Title,
                    Priority = Upcoming.Priority,
                    Date = Upcoming.Date,
                    Type = Upcoming.Type,
                    Description = Upcoming.Description,
                    UserId = Upcoming.UserId
                });
            }
            for (int j = 0; j < UpcomingDto.Count; j++)
            {
                for (int i = 0; i < UpcomingDto.Count - 1; i++)
                {
                    if (DateTime.Compare(UpcomingDto[i].Date, UpcomingDto[i + 1].Date) > 0)
                    {
                        var temp = UpcomingDto[i];
                        UpcomingDto[i] = UpcomingDto[i + 1];
                        UpcomingDto[i + 1] = temp;
                    }
                }
            }
            return View(UpcomingDto);
        
        }

        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Create(UpcomingRequest upcomingRequest)
        {
            if (ModelState.IsValid)
            {
                var upcomingModel = new Upcoming
                {
                    Title = upcomingRequest.Title,
                    Date = upcomingRequest.Date,
                    Priority = upcomingRequest.Priority,
                    Type = upcomingRequest.Type,
                    Description = upcomingRequest.Description,
                    UserId = 1
                };
                _context.Upcomings.Add(upcomingModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }   

            return View(upcomingRequest);
        }
        

   
    }
}
