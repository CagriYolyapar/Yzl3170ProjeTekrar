using Project.BLL.Manager.Abstracts;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Project.BLL.Manager.Concretes
{
    public class BaseManager<T> : IManager<T> where T : class , IEntity
    {
        protected readonly IRepository<T> _repository;

        public BaseManager(IRepository<T> repository)
        {
            _repository = repository; 
        }

        public void Add(T item)
        {
            //Todo : implement busines logic here
            _repository.Add(item);
        }

        public void AddRange(List<T> list)
        {
            _repository.AddRange(list);
        }

        public void Delete(T item)
        {
            _repository.Delete(item);
        }

        public void DeleteRange(List<T> list)
        {
            _repository.DestroyRange(list);
        }

        public string Destroy(T item)
        {
            if (item.Status == ENTITIES.Enums.DataStatus.Deleted)
            {
                _repository.Destroy(item);
                return "Silme İşlemi Başarılı";
            }
            return $"Lütfen {item.ID} ID li veriyi önce pasife çekin";
        }

        public void DestroyRange(List<T> list)
        {
            _repository.DestroyRange(list);
        }

        public List<T> GetActives()
        {
           return _repository.GetActives();
        }

        public List<T> GetAll()
        {
            return _repository.GetAll();
        }

        public List<T> GetModifiends()
        {
            return _repository.GetModifiends();
        }

        public List<T> GetPassives()
        {
            return _repository.GetPassives();
        }

        public List<T> Where(Expression<Func<T, bool>> exp)
        {
            return _repository.Where(exp);
        }
    }
}
