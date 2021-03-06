using System;
using System.Collections.Generic;

namespace StudentMongoDB
{
    public interface IGenericRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T GetById(string id);
        T Insert(T record);
        T Delete(string id);
        T Update(T record, string id);
    }
}