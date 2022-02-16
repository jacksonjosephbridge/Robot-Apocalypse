using Robot_Apocalypse.Abstractions;
using Robot_Apocalypse.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Robot_Apocalypse.DataLayer
{
    public class LocationDataAccess : IDataRepository<Location>
    {
        readonly SurvivorContext _survivorContext;
        public LocationDataAccess(SurvivorContext context)
        {
            _survivorContext = context;
        }
        public long Add(Location entity)
        {
            throw new NotImplementedException();
        }

        public Location Get(long id)
        {
            return _survivorContext.Locations.FirstOrDefault(e => e.SurvivorId == id);
        }

        public IEnumerable<Location> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Location entity, Location location)
        {
            entity.Latitude = location.Latitude;
            entity.Longitude = location.Longitude;

            _survivorContext.SaveChanges();
        }
    }
}
