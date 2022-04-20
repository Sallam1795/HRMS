using System.Collections.Generic;
using System.Linq;
using test.Models;

namespace test.Data.Repository
{
    public class ArchievRepository : IArchievRepository
    {
        ApplicationDbContext applicationDbContext;
        public ArchievRepository(ApplicationDbContext applicationDb)
        {
            applicationDbContext = applicationDb;
        }
        public List<Archiev> GetAll()
        {
            List<Archiev> archiveList = applicationDbContext.Archievs.ToList();
            return archiveList;
        }
        public Archiev GetById(int id)
        {
            Archiev archiev = applicationDbContext.Archievs.FirstOrDefault(x => x.Id == id);
            return archiev;
        }

        public int Insert(Archiev archiev)
        {
            applicationDbContext.Archievs.Add(archiev);
            int archivee = applicationDbContext.SaveChanges();
            return archivee;
        }
        public int Update(int id, Archiev archiev)
        {
            Archiev oldArchiev = applicationDbContext.Archievs.FirstOrDefault(s => s.Id == id);
            oldArchiev.Id = archiev.Id;
            oldArchiev.AbsentArch = archiev.AbsentArch;
            oldArchiev.AttendanceArch = archiev.AttendanceArch;
            oldArchiev.OverTimeArch = archiev.OverTimeArch;
            oldArchiev.DiscountTimeArch = archiev.DiscountTimeArch;
            oldArchiev.Date = archiev.Date;
            oldArchiev.Salary = archiev.Salary;
            int UpdateArchiev = applicationDbContext.SaveChanges();
            return UpdateArchiev;
        }
        public int Delete(int id)
        {
            Archiev deleteArchiev = applicationDbContext.Archievs.FirstOrDefault(s => s.Id == id);
            applicationDbContext.Archievs.Remove(deleteArchiev);
            int deleteeArchiev = applicationDbContext.SaveChanges();
            return deleteeArchiev;
        }
    }
}
