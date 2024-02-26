using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;

namespace webAPI.Model
{
    public class TicketRepository : ITickets<Ticket>
    {
        db _db;
        public TicketRepository(db db)
        {
            _db = db;
        }

        public async Task Delete(int id)
        {
            var getid = await _db.tickets.FindAsync(id);
            _db.tickets.Remove(getid);
            await _db.SaveChangesAsync();
        }
        public async Task<IEnumerable<Ticket>> Get()
        {
            return await _db.tickets.ToListAsync();
        }


        // get by ID
        public async Task<Ticket> Get(int id)
        {

            return await _db.tickets.FindAsync(id);
        }

        public async Task<IEnumerable<Ticket>> GetStatus(int getStatus)
        {
            return await _db.tickets.Where(or => or.status == (getStatus)).ToListAsync();

//return output;
        }

        // GET BY CURRENCY CODE AND NAME  
        public async Task<IEnumerable<Ticket>> Get(string creatorName, int status)
        {

            var tickets = await _db.tickets

                .Where(tickets => tickets.creatorName.Equals(creatorName))
                .ToListAsync();

            // Perform case-sensitive password comparison on the client side
            return tickets.Where(tickets => tickets.status.Equals(status));
        }


        public async Task<Ticket> Post(Ticket ticket)
        {
            _db.tickets.AddAsync(ticket);
            await _db.SaveChangesAsync();
            return ticket;
        }

        public async Task Put(Ticket ticket)
        {
            _db.Entry(ticket).State = EntityState.Modified;

            await _db.SaveChangesAsync();

        }
    }
}
