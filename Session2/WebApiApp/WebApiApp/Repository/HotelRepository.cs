using Microsoft.EntityFrameworkCore;
using WebApiApp.Context;

namespace WebApiApp.Repository
{
    public class HotelRepository : IHotelRepository
    {
        readonly AppDbContext _context;
        public HotelRepository(AppDbContext context)
        {
            _context = context;
        }
        public void AddRepo(Hotel hotel)
        {
            _context.Add(hotel);
            _context.SaveChanges();
        }

        public void DeleteRepo(int id)
        {
          Hotel hotel=  _context.Hotels.FirstOrDefault(u => u.Id == id);
            _context.Remove(hotel);
            _context.SaveChanges();
        }

        public List<Hotel> GetAllRepo()
        {
            
            return  _context.Hotels.ToList();
        }

        public Hotel GetByIdRepo(int id)
        {

            var hotel = _context.Hotels.Find(id);
            return hotel;
        }

        public void UpdateRepo(int id, Hotel hotel)
        {
            Hotel h=_context.Hotels.FirstOrDefault(x => x.Id == id);

            if (h != null)
            {
                h.Address = hotel.Address;
                h.Name = hotel.Name;
                h.Rating = hotel.Rating;
                h.CountryId = hotel.CountryId;

                
            }
           
            _context.SaveChanges();
        }
    }
}
