using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer
{
    interface Ioperations<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(int id);
        T Add(T obj);
        bool Update(T obj);
        bool Remove(int id); 
        int Count(); 
    }
}
