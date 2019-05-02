﻿using AccountExpress.Interfaces;
using AccountExpress.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountExpress.Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        private readonly IRepository<TEntity> _repository;

        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public void Delete(int id)
        {
            _repository.Remove(_repository.GetById(id));
        }

        public TEntity Get(int id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return _repository.GetAll();
        }

        public TEntity Post(TEntity obj)
        {
            return _repository.Add(obj);
        }

        public TEntity Put(TEntity obj)
        {
            return _repository.Update(obj);
        }
    }
}
