using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusinessAccessLayer.Manager
{
   public class StoreManager : DataRepository<AppDbContext , Store>
    {
        public IQueryable<Store> GetData()
        {
            return new StoreManager().GetAll(); 
        }

        public Store Insert(Store Obj)
        {
            return new StoreManager().Add(Obj); 
        }

        public bool Edit (Store Obj)
        {
            return new StoreManager().Update(Obj);
        }

        public bool Delete (int id)
        {
            return new StoreManager().Remove(id); 
        }

        public Store GetStore(int id)
        {
            return new StoreManager().GetById(id); 
        }
    }
}
