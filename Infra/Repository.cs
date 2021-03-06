using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Infra
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        public void Add(T entity)
        {
            using (var db = new SeuVizinhoContext())
            {
                db.Add<T>(entity);
                db.SaveChanges();
            }
        }

        public T Get(Func<T, bool> predicate)
        {
            using (var db = new SeuVizinhoContext())
            {
                return db.Set<T>().FirstOrDefault(predicate);
            }
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate)
        {
            using (var db = new SeuVizinhoContext())
            {
                return db.Set<T>().Where(predicate).ToArray();
            }
        }        

        public T Get(Guid id)
        {
            using (var db = new SeuVizinhoContext())
            {
                return db.Set<T>().SingleOrDefault(x => x.Id == id);
            }
        }

        public void Modify(T entity)
        {
            using (var db = new SeuVizinhoContext())
            {
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Remove(T entity)
        {
            using (var db = new SeuVizinhoContext())
            {
                db.Entry(entity).State = EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
