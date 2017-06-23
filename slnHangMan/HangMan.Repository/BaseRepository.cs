using HangMan.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan.Repository
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {

        protected hangmanEntities _entities;
        protected DbSet<TEntity> _dbSet;

        public BaseRepository(hangmanEntities entities)
        {
            this._entities = entities;
            this._dbSet = _entities.Set<TEntity>();
        }


        public IEnumerable<TEntity> All
        {
            get
            {
                return _dbSet.AsEnumerable();
            }
        }

        public TEntity Delete(TEntity entity)
        {
            _dbSet.Remove(entity);

            return entity;
        }

        public TEntity FindById(object Id)
        {
            return _dbSet.Find(Id);
        }

        public TEntity Insert(TEntity entity)
        {
            _dbSet.Add(entity);

            return entity;
        }

        public TEntity Update(TEntity entity, TEntity oldEntity, out bool modified)
        {
            _entities.Entry(oldEntity).CurrentValues.SetValues(entity);
            modified = _entities.Entry(oldEntity).State == System.Data.Entity.EntityState.Modified;

            return oldEntity;
        }
    }
}
