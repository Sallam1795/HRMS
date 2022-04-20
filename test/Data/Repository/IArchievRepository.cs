using System.Collections.Generic;
using test.Models;

namespace test.Data.Repository
{
    public interface IArchievRepository
    {
        int Delete(int id);
        List<Archiev> GetAll();
        Archiev GetById(int id);
        int Insert(Archiev archiev);
        int Update(int id, Archiev archiev);
    }
}