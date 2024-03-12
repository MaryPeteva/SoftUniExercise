using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using SeminarHub.Data;
using SeminarHub.Data.Models;
using SeminarHub.Models;
using System.Globalization;
using System.Linq;
using System.Security.Claims;

namespace SeminarHub.Controllers
{
    public class SeminarController : Controller
    {
        private readonly SeminarHubDbContext context;
        public SeminarController(SeminarHubDbContext _context)
        {
            context = _context;
        }
        public async Task<IActionResult> All()
        {
            var seminars = await context.Seminars
                                        .Include(s => s.Category)
                                        .AsNoTracking()
                                        .Select(s => new SeminarPartial(
                                            s.Id,
                                            s.Topic,
                                            s.Lecturer,
                                            s.DateAndTime,
                                            s.Organizer.Email,
                                            new CategoryModel
                                            {
                                                Id = s.Category.Id,
                                                Name = s.Category.Name
                                            }
                                        ))
                                        .ToListAsync();

            return View(seminars);
        }



        [HttpGet]
        public async Task<IActionResult> Add() 
        {
            var newSeminar = new SeminarModel();
            newSeminar.Categories = await GetCategories();
            return View(newSeminar);
        }

        [HttpPost]
        public async Task<IActionResult> Add(SeminarModel seminar)
        {
            var newSeminar = new Seminar()
            {
                Topic = seminar.Topic,
                Lecturer = seminar.Lecturer,
                Detail = seminar.Details,
                DateAndTime = seminar.DateAndTime,
                Duration = seminar.Duration,
                Category = seminar.Category,
                CategoryId = seminar.CategoryId,
                OrganizerId = GetUserId(),

            };

            await context.Seminars.AddAsync(newSeminar);
            await context.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var seminar = await context.Seminars
                .FindAsync(id);

            if (seminar == null)
            {
                return BadRequest();
            }

            if (seminar.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            var newSem = new SeminarModel()
            {
                Topic = seminar.Topic,
                Lecturer = seminar.Lecturer,
                Details = seminar.Detail,
                DateAndTime = seminar.DateAndTime,
                Duration = seminar.Duration,
                Category = seminar.Category,
                CategoryId = seminar.CategoryId,
            };

            newSem.Categories = await GetCategories();

            return View(newSem);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SeminarModel seminar, int id)
        {
            var updatedSem = await context.Seminars
                .FindAsync(id);

            if (updatedSem == null)
            {
                return BadRequest();
            }

            if (updatedSem.OrganizerId != GetUserId())
            {
                return Unauthorized();
            }

            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            updatedSem.Topic = seminar.Topic;
            updatedSem.Lecturer = seminar.Lecturer;
            updatedSem.Detail = seminar.Details;
            updatedSem.DateAndTime = seminar.DateAndTime;
            updatedSem.Duration = seminar.Duration;
            updatedSem.Category = seminar.Category;
            updatedSem.CategoryId = seminar.CategoryId;

            await context.SaveChangesAsync();

            return RedirectToAction(nameof(All));
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var seminar = await context.Seminars
                .Where(s => s.Id == id)
                .Include(s => s.SeminarsParticipants)
                .FirstOrDefaultAsync();

            if (seminar == null)
            {
                return BadRequest();
            }

            string userId = GetUserId();

            if (!seminar.SeminarsParticipants.Any(p => p.ParticipantId == userId))
            {
                seminar.SeminarsParticipants.Add(new SeminarParticipant()
                {
                    SeminarId = seminar.Id,
                    ParticipantId = userId
                });

                await context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Joined));
        }

        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            string userId = GetUserId();

            var currentUser = await context.SeminarParticipants
                .Where(sp => sp.ParticipantId == userId)
                .Select(sp => sp.Seminar)
                .ToListAsync();

            return View(currentUser);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var model = await context.Seminars
                .Where(e => e.Id == id)
                .AsNoTracking()
                .Select(e => new SeminarModel()
                {
                    Id = e.Id,
                    Topic = e.Topic,
                    Lecturer = e.Lecturer,
                    Details = e.Detail,
                    DateAndTime = e.DateAndTime,
                    Organizer = e.Organizer,
                    Duration = e.Duration,
                    Category = e.Category

                })
                .FirstOrDefaultAsync();

            if (model == null)
            {
                return BadRequest();
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id) 
        {
            var seminar = await context.Seminars.FindAsync(id);           
            context.Seminars.Remove(seminar);
            await context.SaveChangesAsync();
            return RedirectToAction("All", "Seminar");
        }

        private async Task<IEnumerable<CategoryModel>> GetCategories()
        {
            return await context.Categories
                .AsNoTracking()
                .Select(t => new CategoryModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
    }
}
