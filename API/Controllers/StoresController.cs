using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using BusinessAccessLayer.Manager;
using DataAccessLayer.Models;



namespace API.Controllers
{
    public class StoresController : ApiController
    {
        StoreManager _StoreManager = new StoreManager(); 


        [System.Web.Http.HttpPost]
        public int InsertNewStore (Store Obj)
        {
            int Ack = 0;
            var ResultObject = _StoreManager.Insert(Obj);
            return ( Ack =  ResultObject != null ? 1 : 0);  
        }


        [System.Web.Http.HttpGet]
        public int DeleteEixtedObject(int id)
        {
            int Ack = 0;
            var ResultData = _StoreManager.Delete(id);
            return (Ack = ResultData != false ? 1 : 0);
        }



        [System.Web.Http.HttpPost]
        public int UpdateEixtedObject(Store Obj)
        {
            int Ack = 0;
            var ResultData = _StoreManager.Edit(Obj);
            return (Ack = ResultData != false ? 1 : 0);
        }



        [System.Web.Http.HttpGet]
        public Store GetStoreData(int id)
        {
            return _StoreManager.GetStore(id);
        }



        [System.Web.Http.HttpGet]
        public IQueryable<Store> GetAllStoresData()
        {
            return _StoreManager.GetData(); 
        }


    }
}