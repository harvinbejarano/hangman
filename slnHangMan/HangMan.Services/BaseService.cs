using AutoMapper;
using HangMan.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan.Services
{
    public abstract class BaseService<TDTO, TEntity> : IService<TDTO> where TDTO : class where TEntity : class
    {
        protected IRepository<TEntity> _repository;
        protected IUnitOfWork _unitOfWork;

        public BaseService(IUnitOfWork unitOfWork, IRepository<TEntity> repository)
        {
            this._unitOfWork = unitOfWork;
            this._repository = repository;
        }

        public void Create(TDTO dto)
        {
            TEntity entity = Mapper.Map<TEntity>(dto);
            entity = _repository.Insert(entity);
            _unitOfWork.Commit();
        }

        public void Delete(object id)
        {
            TEntity entity = _repository.FindById(id);
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public TDTO FindById(object Id)
        {
            return Mapper.Map<TDTO>(_repository.FindById(Id));
        }

        public IEnumerable<TDTO> GetAll()
        {
            List<TEntity> list;
            list = _repository.All.ToList();

            return list.Select(data => Mapper.Map<TDTO>(data));
        }

        public void Update(object id, TDTO dto)
        {
            TEntity entity = Mapper.Map<TEntity>(dto);
            TEntity oldEntity = _repository.FindById(id);
            bool changed = false;
            entity = _repository.Update(entity, oldEntity, out changed);
            _unitOfWork.Commit();
        }
    }
}
