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
                    UserId = Upcoming.UserId
                });
            }
            
            return View(UpcomingDto);
        
            //return View(ObjUpcomingList);
        }
    }
}
