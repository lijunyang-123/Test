using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL;
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
        //分页
        public ActionResult fenye(int pageIndex,int pagesize){
            return Json(BLL.L.RuluManager.fenye(pageIndex,pagesize),JsonRequestBehavior.AllowGet);
        }
        //总条数
        public ActionResult getRow(){
            return Json(BLL.L.RuluManager.GetRow(),JsonRequestBehavior.AllowGet);
        }
        //根据条件查询
        public ActionResult queryid(int pageIndex, int pagesize,string id, DateTime kstime, DateTime jstime){
            return Json(BLL.L.RuluManager.queryid(pageIndex, pagesize,id,kstime,jstime),JsonRequestBehavior.AllowGet);
        }
    }
}