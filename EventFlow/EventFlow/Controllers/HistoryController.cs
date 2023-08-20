using EventFlow.Data;
using EventFlow.Models.DTO;
using EventFlow.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventFlow.Controllers
{
    public class HistoryController:Controller
    {
        private readonly ApplicationDbContext _context;
        public HistoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<History> ObjHistoryList = await _context.Histories.ToListAsync();

            var HistoryDto = new List<HistoryDTO>();

            foreach (var History in ObjHistoryList)
            {
                HistoryDto.Add(new HistoryDTO()
                {
                    Id = History.Id,
                    Title = History.Title,
                    Completion = History.Completion,
                    Date = History.Date,
                    UserId = History.UserId
                });
            }

            return View(HistoryDto);

        }
    }
}

