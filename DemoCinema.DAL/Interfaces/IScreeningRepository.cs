using DemoCinema.DAL.Entities;

namespace DemoCinema.DAL.Interfaces
{
    public interface IScreeningRepository
    {
        int Insert(ScreeningEntity data);
        void Delete(int id);
        void Cancel(int id);
        IEnumerable<ScreeningEntity> GetMany(Func<ScreeningEntity, bool> filterCondition);
    }
}
