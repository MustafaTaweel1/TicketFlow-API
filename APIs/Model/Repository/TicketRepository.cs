using APIs.Model.IRepository;
using APIs.Model.models;
using Microsoft.EntityFrameworkCore;
using System.Net.Sockets;
using webAPI.Model;

namespace APIs.Model.Repository
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


            return await _db.tickets.Include(t => t.Creator).Include(t => t.Handler).ToListAsync();
        }


        // get by ID
        public async Task<Ticket> Get(int id)
        {
            return await _db.tickets.Include(t => t.Creator).Include(t => t.Handler).FirstOrDefaultAsync(t => t.id == id);

        }

        public async Task<IEnumerable<Ticket>> GetStatus(int getStatus)
        {
            return await _db.tickets.Where(or => or.status == getStatus).ToListAsync();

            //return output;
        }

        // GET BY CURRENCY CODE AND NAME  



        public async Task<Ticket> Post(Ticket ticket)
        {
            ticket.Handler = _db.users.FirstOrDefault(u => u.id == 3);

            _db.tickets.AddAsync(ticket);
            await _db.SaveChangesAsync();
            return ticket;
        }

        public async Task Put(Ticket ticket)
        {
            _db.Entry(ticket).State = EntityState.Modified;

            await _db.SaveChangesAsync();

        }


        public async Task<IEnumerable<Ticket>> GetUser_Create(int id_create)
        {
            var myticket = await _db.tickets.Where(user => user.id_create.Equals(id_create)).Include(t => t.Creator).Include(t => t.Handler).ToListAsync();
            return myticket;
        }

        public async Task<IEnumerable<Ticket>> GetUser_Take(int id_user)
        {
            var myticket = await _db.tickets.Where(user => user.take_user.Equals(id_user)).Include(t => t.Creator).Include(t => t.Handler).ToListAsync();
            return myticket;
        }

		public async Task<IEnumerable<Ticket>> GetDepartment(int dep_id)
		{
			return await _db.tickets.Include(t => t.Creator).Include(t => t.Handler).Where(or => or.department == dep_id).ToListAsync();

		}
	}
}
