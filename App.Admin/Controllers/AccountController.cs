﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using App.Models.Sys;
using App.IBLL;
using Microsoft.Practices.Unity;
using App.Common;
using App.Models;
using YmNets.Common;
namespace App.Admin.Controllers
{
    public class AccountController : BaseController
    {
        //
        // GET: /Account/
        [Dependency]
        public IAccountBLL accountBLL { get; set; }
        public ViewResult Index()
        {
            return View();
        }
        public JsonResult Login(string UserName,string Password,string Code)
        {
            if (Session["Code"] == null)
                return Json(JsonHandler.CreateMessage(0, "请重新刷新验证码"), JsonRequestBehavior.AllowGet);

            if (Session["Code"].ToString().ToLower() != Code.ToLower())
                return Json(JsonHandler.CreateMessage(0, "验证码错误"), JsonRequestBehavior.AllowGet);
            SysUser user = accountBLL.Login(UserName, ValueConvert.MD5(Password));
            if (user == null)
            {
                return Json(JsonHandler.CreateMessage(0, "用户名或密码错误"), JsonRequestBehavior.AllowGet);
            }
            else if (!Convert.ToBoolean(user.State))//被禁用
            {
                return Json(JsonHandler.CreateMessage(0, "账户被系统禁用"), JsonRequestBehavior.AllowGet);
            }
            AccountModel account = new AccountModel();
            account.Id = user.Id;
            account.TrueName = user.TrueName;
            Session["Account"] = account;

            return Json(JsonHandler.CreateMessage(1, ""), JsonRequestBehavior.AllowGet);
        }

    }
}
