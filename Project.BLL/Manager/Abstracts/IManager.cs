using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Manager.Abstracts
{
    public interface IManager<T> where T : class
    {
        //List Commands

        List<T> GetAll();
        List<T> GetActives();

        List<T> GetPassives();

        List<T> GetModifiends();

        //Modify Commands

        void Add(T item);
        void AddRange(List<T> list);
        void Delete(T item);
        void DeleteRange(List<T> list);
        string Destroy(T item);
        void DestroyRange(List<T> list);

        //Linq Commands

        List<T> Where(Expression<Func<T, bool>> exp);


    }
}
