using DemoCinema.DAL.Entities;
using DemoCinema.DAL.Interfaces;

namespace DemoCinema.DAL.Repositories
{
    public class ScreeningStaticRepository : IScreeningRepository
    {
        private readonly DataStaticContext context;
        public ScreeningStaticRepository(DataStaticContext context)
        {
            this.context = context;
        }


        public int Insert(ScreeningEntity data)
        {
            ScreeningEntity ScreeningToAdd = new ScreeningEntity
            {
                Id = context.NextScreeningId,
                MovieId = data.MovieId,
                Duration = data.Duration,
                Schedule = data.Schedule,
                IsCancel = false
            };
            context.NextScreeningId++;

            context.Screenings.Add(ScreeningToAdd);

            return ScreeningToAdd.Id;
        }

        public void Delete(int id)
        {
            ScreeningEntity screening = context.Screenings.Single(s => s.Id == id);
            context.Screenings.Remove(screening);
        }

        public void Cancel(int id)
        {
            ScreeningEntity screening = context.Screenings.Single(s => s.Id == id);
            screening.IsCancel = true;
        }

        public IEnumerable<ScreeningEntity> GetMany(Func<ScreeningEntity, bool> filterCondition)
        {
            return context.Screenings.Where(filterCondition);
        }

    }
}
