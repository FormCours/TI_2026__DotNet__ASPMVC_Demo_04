using DemoCinema.BLL.Models;
using DemoCinema.DAL.Entities;

namespace DemoCinema.BLL.Interfaces
{
    public interface IScreeningService
    {
        ScreeningModel Add(ScreeningModel data);
        bool Delete(int id);
        bool Cancel(int id);
        IEnumerable<ScreeningModel> GetByDate(DateTime date);
        IEnumerable<ScreeningModel> GetByMovie(int movieId);
    }
}
