using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{   //generic constraint kısıtlama
    //class:referans tip
    // T IEntity veya IEntity den iplemente olan bir şey olabilir.(ref tip)
    //new() : new'lenebilir olmalı.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);
        T Get(Expression<Func<T, bool>> filter);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
               
    }

}
