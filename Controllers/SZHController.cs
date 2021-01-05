using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL.S;
namespace 仓储后台管理系统.Controllers
{
    public class SZHController : Controller
    {
        // GET: SZH
        public ActionResult Index()
        {
            return View();
        }
        //库位页面
        public ActionResult KeWei()
        {
            BLL.S.KeWeiBLL bll = new KeWeiBLL();
            ViewBag.gg = bll.Warehourses(); ;
            return View();
        }
        //供应商页面
        public ActionResult GongYing()
        {
            return View();
        }
      
    }
}