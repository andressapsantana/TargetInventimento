using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetInvestimento.Domain.Interfaces.Repositorys
{
    public interface IBaseRepository<T> where T : class
    {
        void Create(T obj);
        void Update(T obj);
        void Delete(T obj);

        List<T> GetAll();
        T GetById(int id);
    }
}
