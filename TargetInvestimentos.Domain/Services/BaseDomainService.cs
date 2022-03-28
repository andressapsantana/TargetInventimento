using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetInvestimento.Domain.Interfaces.Repositorys;

namespace TargetInvestimento.Domain.Services
{
    /// <summary>
    /// Classe genérica para implementar os métodos de regras de negócio
    /// </summary>
    public class BaseDomainService<T> : IBaseDomainService<T>
        where T : class
    {

        private readonly IBaseRepository<T> baseRepository;

        public BaseDomainService(IBaseRepository<T> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public void Create(T obj)
        {
            baseRepository.Create(obj);
        }

        public void Update(T obj)
        {
            baseRepository.Update(obj);
        }

        public void Delete(T obj)
        {
            baseRepository.Delete(obj);
        }

        public List<T> GetAll()
        {
           return baseRepository.GetAll();
        }

        public T GetById(int id)
        {
            return baseRepository.GetById(id);
        }
    }
}
