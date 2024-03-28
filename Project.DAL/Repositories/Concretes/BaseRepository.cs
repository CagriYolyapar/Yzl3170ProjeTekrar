using Project.DAL.ContextClasses;
using Project.DAL.Repositories.Abstracts;
using Project.ENTITIES.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Repositories.Concretes
{
    public class BaseRepository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly MyContext _db;
        public BaseRepository(MyContext db)
        {
            _db = db;
        }
        protected void Save()
        {
            _db.SaveChanges();
        }
        public void Add(T item)
        {
            _db.Set<T>().Add(item);
            Save();
        }

        public void AddRange(List<T> list)
        {
           _db.Set<T>().AddRange(list);
            Save();
        }

        public void Delete(T item)
        {
            item.Status = ENTITIES.Enums.DataStatus.Deleted;
            item.DeletedDate = DateTime.Now;
            Save();
        }

        public void DeleteRange(List<T> list)
        {
            foreach (T item in list) Delete(item);
        }

        public void Destroy(T item)
        {
            _db.Set<T>().Remove(item);
            Save();
        }

        public void DestroyRange(List<T> list)
        {
            _db.Set<T>().RemoveRange(list);
            Save();
        }

        public List<T> GetActives()
        {
            return _db.Set<T>().Where(x=>x.Status!= ENTITIES.Enums.DataStatus.Deleted).ToList();
        }

        public List<T> GetAll()
        {
            return _db.Set<T>().ToList();

        }

        public List<T> GetModifiends()
        {
            return _db.Set<T>().Where(x => x.Status == ENTITIES.Enums.DataStatus.Updated).ToList();
        }

        public List<T> GetPassives()
        {
            return _db.Set<T>().Where(x => x.Status == ENTITIES.Enums.DataStatus.Deleted).ToList();
        }
    }
}
