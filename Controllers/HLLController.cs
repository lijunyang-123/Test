using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 仓储后台管理系统.Controllers
{
    public class HLLController : Controller
    {
        //库存清单视图
        public ActionResult Index()
        {
            return View();
        }
        //库存清单分页
        public ActionResult Page(int pageIndex, int pagesize)
        {
            return Json(BLL.H.LocationManager.Page(pageIndex, pagesize), JsonRequestBehavior.AllowGet);
        }
        //库存清单总条数
        public ActionResult getRow()
        {
            return Json(BLL.H.LocationManager.GetRow(), JsonRequestBehavior.AllowGet);
        }
        //库存清单根据条件查询
        public ActionResult queryid(int pageIndex, int pagesize, string warehourseNum, string productNum, string Probarcode, string productName, string warehourseName)
        {
            return Json(BLL.H.LocationManager.queryid(pageIndex, pagesize, warehourseNum, productNum, Probarcode, productName, warehourseName), JsonRequestBehavior.AllowGet);
        }
        //下拉框
        public ActionResult Show()
        {
            return Json(BLL.H.LocationManager.Show(), JsonRequestBehavior.AllowGet);
        }




        //货品统计视图
        public ActionResult Index1()
        {
            return View();
        }
        //货品统计分页
        public ActionResult Page1(int pageIndex, int pagesize)
        {
            return Json(BLL.H.CountManager.Page(pageIndex, pagesize), JsonRequestBehavior.AllowGet);
        }
        //货品统计总条数
        public ActionResult getRow1()
        {
            return Json(BLL.H.CountManager.GetRow(), JsonRequestBehavior.AllowGet);
        }
        //货品统计根据条件查询
        public ActionResult queryid1(int pageIndex, int pagesize, string productNum, string Probarcode, string productName)
        {
            return Json(BLL.H.CountManager.queryid(pageIndex, pagesize, productNum, Probarcode, productName), JsonRequestBehavior.AllowGet);
        }





        //出入库报表
        public ActionResult Index2()
        {
            return View();
        }
        //出入库分页
        public ActionResult Page2(int pageIndex, int pagesize)
        {
            return Json(BLL.H.OutinManager.Page(pageIndex, pagesize), JsonRequestBehavior.AllowGet);
        }
        //出入库总条数
        public ActionResult getRow2()
        {
            return Json(BLL.H.OutinManager.GetRow(), JsonRequestBehavior.AllowGet);
        }
        //产品入库排行
        public ActionResult Put(int pageIndex, int PageSize)
        {
            return Json(BLL.H.OutinManager.Put(pageIndex, PageSize), JsonRequestBehavior.AllowGet);
        }
        //产品出库排行
        public ActionResult Out(int pageIndex, int PageSize)
        {
            return Json(BLL.H.OutinManager.Out(pageIndex, PageSize), JsonRequestBehavior.AllowGet);
        }





        //入库报表
        public ActionResult Index3()
        {
            return View();
        }
        //入库分页
        public ActionResult Page3(int pageIndex, int pagesize)
        {
            return Json(BLL.H.PutManager.Page(pageIndex, pagesize), JsonRequestBehavior.AllowGet);
        }
        //入库总条数
        public ActionResult getRow3()
        {
            return Json(BLL.H.PutManager.GetRow(), JsonRequestBehavior.AllowGet);
        }
        //入库报表
        public ActionResult Put1(int pageIndex, int PageSize)
        {
            return Json(BLL.H.PutManager.Put(pageIndex, PageSize), JsonRequestBehavior.AllowGet);
        }
        //根据入库单号查询
        public ActionResult GetById(string receiptNum)
        {
            return Json(BLL.H.PutManager.GetById(receiptNum), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Hu(int pageIndex, int PageSize)
        {
            return Json(BLL.H.PutManager.Hu(pageIndex, PageSize), JsonRequestBehavior.AllowGet);
        }




        //出库报表
        public ActionResult Index4()
        {
            return View();
        }
        //出库分页
        public ActionResult Page4(int pageIndex, int pagesize)
        {
            return Json(BLL.H.OutManager.Page(pageIndex, pagesize), JsonRequestBehavior.AllowGet);
        }
        //出库总条数
        public ActionResult getRow4()
        {
            return Json(BLL.H.OutManager.GetRow(), JsonRequestBehavior.AllowGet);
        }
        //出库报表
        public ActionResult Put2(int pageIndex, int PageSize)
        {
            return Json(BLL.H.OutManager.Put(pageIndex, PageSize), JsonRequestBehavior.AllowGet);
        }
        //根据入库单号查询
        public ActionResult GetById1(string OutboundNum)
        {
            return Json(BLL.H.OutManager.GetById(OutboundNum), JsonRequestBehavior.AllowGet);
        }

    }
}