using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //generic constraint
    //class referans tip olablir demek
    //IEntity olabilir veya IEntity implemente eden bir nesne olabilir
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {

        List<T> GetAll(Expression<Func<T, bool>> filter=null);
        //Tek bir dosya getirmek için aşağıdakini yazmak gerekiyor
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        
    }
}
