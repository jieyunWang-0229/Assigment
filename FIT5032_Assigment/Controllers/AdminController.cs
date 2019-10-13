using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FIT5032_Assigment.Models;
using FIT5032_Assigment.Repository;
using Newtonsoft.Json;

namespace FIT5032_Assigment.Controllers
{
    public class AdminController : Controller
    {

        private Model1 db = new Model1();
        // GET: Admin
        public GenericUnitofWork _unitOfWork = new GenericUnitofWork();
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Categories()
        {

            List<Category> allcategories = _unitOfWork.GetRepositoryInstance<Category>().GetAllRecordsIQueryable().ToList();
            return View(allcategories);

        }

        public ActionResult AddCategory()
        {
            return UpdateCategory(0);

        }

        public ActionResult UpdateCategory(int categoryId)
        {
            Categorydetail cd;
                if (categoryId !=null)
            {
                cd = JsonConvert.DeserializeObject<Categorydetail>(JsonConvert.SerializeObject(_unitOfWork.GetRepositoryInstance<Category>().GetFirstorDefault(categoryId)));
            }
            else
            {
                cd = new Categorydetail();
            }
            return View("UpdateCategory", cd);

        }



    }
}
