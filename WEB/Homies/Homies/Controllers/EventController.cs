using Homies.Data;
using Homies.Data.Models;
using Homies.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly HomiesDbContext context;
        public EventController(HomiesDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var events = await context.Events
                                      .AsNoTracking()
                                      .Select(e => new EventPrimalInfo()
                                      {
                                          Id = e.Id,
                                          Name = e.Name,
                                          Start = e.Start,
                                          Type = e.Type.Name,
                                          Organiser = e.Organiser.UserName
                                      })
                                      .ToListAsync();
            return View(events);
        }

        [HttpGet]
        public async Task<IActionResult> Add() 
        {
            var newEvent = new EventModel();
            newEvent.Types = await GetEventTypes();
            return View(newEvent);
        }

        [HttpPost]
        public async Task<IActionResult> Add(EventModel ev)
        {
            var newEvent = new Event()
            {
                CreatedOn = DateTime.Now,
                Name = ev.Name,
                Description = ev.Description,
                OrganiserId = GetUserId(),
                TypeId = ev.TypeId,
                Start = ev.Start,
                End = ev.End
            };

            await context.Events.AddAsync(newEvent);
            await context.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var eventToEdit = await context.Events.FindAsync(id);
            if (eventToEdit == null)
            {
                return BadRequest();
            }

            if (eventToEdit.OrganiserId != GetUserId())
            {
                return Unauthorized();
            }

            var editEvent = new EventModel()
            {
                Name = eventToEdit.Name,
                Description = eventToEdit.Description,
                Start = eventToEdit.Start, 
                End = eventToEdit.End,     
                TypeId = eventToEdit.TypeId,
                Types = await GetEventTypes()
            };
            return View(editEvent);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EventModel editEvent, int id) 
        {
            var ev = await context.Events.FindAsync(id);
            if (ev == null) 
            {
                return BadRequest();
            }

            if (ev.OrganiserId != GetUserId()) 
            {
                return Unauthorized();
            }

            // Update the event properties only if the corresponding property in the editEvent model is not null or empty
            if (!string.IsNullOrEmpty(editEvent.Name))
            {
                ev.Name = editEvent.Name;
            }

            if (!string.IsNullOrEmpty(editEvent.Description))
            {
                ev.Description = editEvent.Description;
            }

            if (editEvent.Start != default(DateTime))
            {
                ev.Start = editEvent.Start;
            }


            if (editEvent.End != default(DateTime))
            {
                ev.End = editEvent.End;
            }

            ev.TypeId = editEvent.TypeId;
            await context.SaveChangesAsync();

            return RedirectToAction("All");
        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        [HttpPost]
        private async Task<IEnumerable<EventTypeModel>> GetEventTypes()
        {
            return await context.Types
                .AsNoTracking()
                .Select(t => new EventTypeModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
                .ToListAsync();
        }


    }
}
