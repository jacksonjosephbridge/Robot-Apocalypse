using Robot_Apocalypse.Abstractions;
using Robot_Apocalypse.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Robot_Apocalypse.DataLayer
{
    public class ContaminationReportDataAccess : IDataRepository<ContaminationReport>
    {
        readonly SurvivorContext _survivorContext;
        public ContaminationReportDataAccess(SurvivorContext context)
        {
            _survivorContext = context;
        }
        public long Add(ContaminationReport entity)
        {
            var isAlreadyREported = _survivorContext.ContaminationReports.Any(x => x.ReporterId == entity.ReporterId && x.SurvivorId == entity.SurvivorId);
            if (!isAlreadyREported)
            {
                _survivorContext.ContaminationReports.Add(entity);
                _survivorContext.SaveChanges();
                return entity.contaminationReportId;
            }
            return 0;
        }

        public ContaminationReport Get(long id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ContaminationReport> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(ContaminationReport dbEntity, ContaminationReport entity)
        {
            throw new NotImplementedException();
        }
    }
}
