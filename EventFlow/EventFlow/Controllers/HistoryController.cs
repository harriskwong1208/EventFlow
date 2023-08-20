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
            for (int j = 0; j < HistoryDto.Count; j++)
            {
                for (int i = 0; i < HistoryDto.Count-1; i++)
                {
                    if (DateTime.Compare(HistoryDto[i].Date, HistoryDto[i + 1].Date) > 0)
                    {
                        var temp = HistoryDto[i];
                        HistoryDto[i] = HistoryDto[i + 1];
                        HistoryDto[i + 1] = temp;
                    }
                }
            }
            return View(HistoryDto);

        }
    }
}

