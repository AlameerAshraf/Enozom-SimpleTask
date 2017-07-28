using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using DataAccessLayer;


namespace BusinessAccessLayer
{
    public class DataRepository<C, T> : Ioperations<T>
        where T : class
        where C : AppDbContext, new()
    {

        private C _Data = new C();

        public C _pdata
        {
            get { return _Data; }
            set { _Data = value; }
        }


        public T Add(T obj)
        {
            T ret = null; 
            _Data.Set<T>().Add(obj);
            if(_Data.SaveChanges() > 0 )
            {
                ret = obj; 
            }
            return ret;  
        }

        public int Count()
        {
            return _Data.Set<T>().Count(); 
        }

        public IQueryable<T> GetAll()
        {
            return _Data.Set<T>(); 
        }

        public T GetById(int id)
        {
            return _Data.Set<T>().Find(id); 
        }

        public bool Remove(int id)
        {
            bool ret = false;
            T obj =  _Data.Set<T>().Find(id);
            _Data.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
            if(_Data.SaveChanges() > 0)
            {
                ret = true; 
            }
            return ret; 
        }

        public bool Update(T obj)
        {
            bool ret = false;
            _Data.Entry(obj).State = System.Data.Entity.EntityState.Modified; 
            if (_Data.SaveChanges() > 0)
            {
                ret = true; 
            }
            return ret; 
        }
    }
}
