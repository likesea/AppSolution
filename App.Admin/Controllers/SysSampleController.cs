using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.BLL;
using App.IBLL;
using App.Models;
using App.Models.Sys;
using Microsoft.Practices.Unity;
using App.Common;
using App.Admin.Core;
namespace App.Admin.Controllers
{
    public class SysSampleController : BaseController
    {
        //
        // GET: /SysSample/
        [Dependency]
        public ISysSampleBLL m_BLL { get; set; }

        ValidationErrors errors = new ValidationErrors();
        public ActionResult Index()
        {
            //List<SysSampleModel> list = m_BLL.GetList("");
            return View();
        }
        [HttpPost]
        public JsonResult GetList(GridPager pager,string queryStr="")
        {
            List<SysSampleModel> list = m_BLL.GetList(ref pager);
            
            var json = new
            {
                total = pager.totalRows,
                rows = (from r in list
                        where r.Id.Contains(queryStr) || r.Name.Contains(queryStr)
                        select new SysSampleModel()
                        {

                            Id = r.Id,
                            Name = r.Name,
                            Age = r.Age,
                            Bir = r.Bir,
                            Photo = r.Photo,
                            Note = r.Note,
                            CreateTime = r.CreateTime,

                        }).ToArray()
            };

            return Json(json, JsonRequestBehavior.AllowGet);
        }
        #region
        [SupportFilter]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Create(SysSampleModel model)
        {
            if (m_BLL.Create(ref errors,model))
            {
                LogHandler.WriteServiceLog("Virtual User", "Id:" + model.Id + ",Name:" + model.Name, "Success", "Create", "Example");
                return Json(JsonHandler.CreateMessage(1, "Insert Success"), JsonRequestBehavior.AllowGet);
            }
            else
            {
                string ErrorCol = errors.Error;
                LogHandler.WriteServiceLog("Virtual User", "Id:" + model.Id + ",Name:" + model.Name, "Failure", "Create", "Example");
                return Json(JsonHandler.CreateMessage(0, "Insert Failure " + ErrorCol), JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
        #region 修改
        [SupportFilter]
        public ActionResult Test()
        {
            return View();
        }
        public ActionResult Edit(string id)
        {

            SysSampleModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        [HttpPost]

        public JsonResult Edit(SysSampleModel model)
        {


            if (m_BLL.Edit(model))
            {
                return Json(1, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }

        }
        #endregion

        #region 详细
        public ActionResult Details(string id)
        {
            SysSampleModel entity = m_BLL.GetById(id);
            return View(entity);
        }

        #endregion

        #region 删除
        [HttpPost]
        public JsonResult Delete(string id)
        {
            if (!string.IsNullOrWhiteSpace(id))
            {
                if (m_BLL.Delete(id))
                {
                    return Json(1, JsonRequestBehavior.AllowGet);
                }
                else
                {

                    return Json(0, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(0, JsonRequestBehavior.AllowGet);
            }


        }
        #endregion
    }
}
