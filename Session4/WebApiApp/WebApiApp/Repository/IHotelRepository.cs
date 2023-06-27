using WebApiApp.Context;

namespace WebApiApp.Repository
{
    public interface IHotelRepository
    {
        List<Hotel> GetAllRepo();
        Hotel GetByIdRepo(int id);

        void AddRepo(Hotel hotel);

        void UpdateRepo(int id,Hotel hotel);
        void DeleteRepo(int id);

    }
}
