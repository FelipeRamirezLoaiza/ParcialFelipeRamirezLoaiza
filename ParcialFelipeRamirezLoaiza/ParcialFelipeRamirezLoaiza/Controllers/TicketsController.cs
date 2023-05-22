using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParcialFelipeRamirezLoaiza.DAL;
using ParcialFelipeRamirezLoaiza.DAL.Entities;
using System.Diagnostics.Metrics;

namespace ParcialFelipeRamirezLoaiza.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TicketsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public TicketsController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTickets()
        {
            var tickets = await _context.Tickets.ToListAsync(); // Select * From Tickets

            if (tickets == null) return NotFound();

            return tickets;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get/{id}")]
        public async Task<ActionResult<Ticket>> GetTicketsById(Guid? id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(c => c.Id == id);

            if (ticket == null) return NotFound();

            return Ok(ticket);
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult> CreateTicket(Ticket ticket)
        {
            try
            {
                ticket.Id = Guid.NewGuid();

                _context.Tickets.Add(ticket);
                await _context.SaveChangesAsync(); // Aquí es donde se hace el Insert Into...
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    return Conflict(String.Format("ya existe el ticket con esa Id", ticket.Id));
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return Ok(ticket);
        }

        [HttpPut, ActionName("Edit")]
        [Route("Edit/{id}")]
        public async Task<ActionResult> EditTicket(Guid? id, Ticket ticket)
        {
            try
            {
                if (id != ticket.Id) return NotFound("Country not found");

                _context.Tickets.Update(ticket);
                await _context.SaveChangesAsync(); // Aquí es donde se hace el Update...
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException.Message.Contains("duplicate"))
                    return Conflict(String.Format("ya existe el ticket con esa Id", ticket.Id));
            }
            return Ok(ticket);
        }
    }
}
