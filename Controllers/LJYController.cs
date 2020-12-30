using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 仓储后台管理系统.Controllers
{
    public class LJYController : Controller
    {
        // GET: LJY
        public ActionResult Index()
        {
            return View();
        }
        //返回首页视图
        public ActionResult Main()
        {
            return View();
        }
        //返回入库视图
        public ActionResult Ruku()
        {
            return View();
        }
    }
}