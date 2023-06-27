using WebApiApp.Context;
using WebApiApp.Repository;

namespace WebApiApp.Service
{
    public class HotelService : IHotelService
    {
        readonly IHotelRepository _repository;
        public HotelService(IHotelRepository repository) 
        { 
            _repository = repository;
        }
        public void AddServ(Hotel hotel)
        {
           _repository.AddRepo(hotel);
        }

        public void DeleteServ(int id)
        {
            _repository.DeleteRepo(id);
        }

        public List<Hotel> GetAllserv()
        {
           return _repository.GetAllRepo();
        }

        public Hotel GetByIdServ(int id)
        {
           return _repository.GetByIdRepo(id);
        }

        public void UpdateServ(int id, Hotel hotel)
        {
            _repository.UpdateRepo(id, hotel);
        }
    }
}
