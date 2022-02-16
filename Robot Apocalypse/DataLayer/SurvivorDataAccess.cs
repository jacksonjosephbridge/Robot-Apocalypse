using Robot_Apocalypse.Abstractions;
using Robot_Apocalypse.DataLayer.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Robot_Apocalypse.DataLayer
{
    public class SurvivorDataAccess : ISurvivorRepository<Survivor>
    {
        readonly SurvivorContext _survivorContext;
        public SurvivorDataAccess(SurvivorContext context)
        {
            _survivorContext = context;
        }
        public long Add(Survivor entity)
        {
            _survivorContext.Survivors.Add(entity);
            _survivorContext.SaveChanges();
            return entity.SurviverId;
        }

        public void Delete(Survivor entity)
        {
            _survivorContext.Survivors.Remove(entity);
            _survivorContext.SaveChanges();
        }

        public Survivor Get(long id)
        {
            return _survivorContext.Survivors.FirstOrDefault(e => e.SurviverId == id);
        }

        public IEnumerable<Survivor> GetAll()
        {
            return _survivorContext.Survivors.ToList();
        }

        public IEnumerable<Survivor> GetAllInfected()
        {
            return _survivorContext.Survivors.Where(x => x.ReportedBy.Count >= 3).ToList();
        }

        public IEnumerable<Survivor> GetAllNonInfected()
        {
            return _survivorContext.Survivors.Where(x => x.ReportedBy.Count < 3).ToList();

        }

        public int Infected()
        {
            return _survivorContext.Survivors.Count(x => x.ReportedBy.Count >= 3);
        }

        public int TotalSurvivors()
        {
            return _survivorContext.Survivors.Count();
        }

        public void Update(Survivor dbEntity, Survivor entity)
        {
            _survivorContext.Survivors.Update(dbEntity);
            _survivorContext.SaveChanges();
        }

    }
}
