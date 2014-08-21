﻿using System;
using System.Web.Configuration;
using App.Models;
using System.IO;
using System.Text;
using App.Common;
using App.IDAL;
using App.IDAL;
using Microsoft.Practices.Unity;
namespace App.BLL
{
    /// <summary>
    /// 写入一个异常错误
    /// </summary>
    /// <param name="ex">异常</param>
    public class ExceptionHandler
    {
        public static void WriteException(Exception ex)
        {
            try
            {
                using(DBContainer db = new DBContainer())
                {
                    SysException model = new SysException()
                    {
                        Id = ResultHelper.NewId,
                        HelpLink = ex.HelpLink,
                        Message = ex.Message,
                        Source = ex.Source,
                        StackTrace = ex.StackTrace,
                        TargetSite = ex.TargetSite.ToString(),
                        Data = ex.Data.ToString(),
                        CreateTime = ResultHelper.NowTime
                    };
                    db.SysException.Add(model);
                    db.SaveChanges();
                }
                
            }
            catch(Exception ep)
            {
                try
                {
                    string path = @"~/exceptionLog.txt";
                    string txtPath = System.Web.HttpContext.Current.Server.MapPath(path);
                    using(StreamWriter sw = new StreamWriter(txtPath,true,Encoding.Default))
                    {
                        sw.WriteLine((ex.Message + "|" + ex.StackTrace + "|" + ep.Message + "|"
                            + DateTime.Now.ToString()).ToString());
                        sw.Dispose();
                        sw.Close();
                    }
                    return;
                }
                catch { return; }
            }
        }
    }
}
