using WebApiApp.Context;

namespace WebApiApp.Service
{
    public interface IHotelService
    {
        List<Hotel> GetAllserv();
        Hotel GetByIdServ(int id);

        void AddServ(Hotel hotel);

        void UpdateServ(int id, Hotel hotel);

        void DeleteServ(int id);    
    }
}
