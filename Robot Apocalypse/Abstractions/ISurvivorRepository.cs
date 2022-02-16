using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Robot_Apocalypse.Abstractions
{
    public interface ISurvivorRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        long Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
        IEnumerable<TEntity> GetAllInfected();
        IEnumerable<TEntity> GetAllNonInfected();
        int Infected();

        int TotalSurvivors();
    }
}
