using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskBoard.Data;
using TaskBoard.Data.Models;
using TaskBoard.Models;

namespace TaskBoard.Controllers
{
    public class BoardController : Controller
    {
        private readonly TaskBoardDbContext _context;
        public BoardController(TaskBoardDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var boards = await _context.Boards
                                       .AsNoTracking()
                                       .Select(b => new BoardModel()
                                       {
                                           Id = b.Id,
                                           Name = b.Name
                                       })
                                       .ToListAsync();
            return View(boards);
        }

        [HttpGet]
        public async Task<IActionResult> Add() 
        {
            var board = new BoardModel();
            return View(board);
        }

        [HttpPost]
        public async Task<IActionResult> Add(BoardModel newBoard) 
        {
            var board = new Board()
            {
                Name = newBoard.Name
            };
            await _context.Boards.AddAsync(board);
            await _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
