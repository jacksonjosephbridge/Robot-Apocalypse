using System.Collections.Generic;

namespace Robot_Apocalypse.Abstractions
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        long Add(TEntity entity);
        void Update(TEntity dbEntity, TEntity entity);
    }
}
