using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using BLL.S;
using System.Data.SqlClient;
namespace 仓储后台管理系统.Controllers
{
    public class SZHController : Controller
    {
        // GET: SZH
        public ActionResult Index()
        {
            return View();
        }
        //供应商页面
        public ActionResult GongYing()
        {
            GongYingBLL bll = new GongYingBLL();
            ViewBag.gg = bll.SupplierLeixes();
            return View();
        }
        //供应商分页
        public ActionResult SelectGongYing(int pageIndex,int pageSize,string Id,string name)
        {
            GongYingBLL bll = new GongYingBLL();
            List<supplier> list = bll.Suppliers();

            var obj = from a in list
                      where a.isDel == 1
                      select new
                      {
                          supplierNum = a.supplierNum,
                          supplierName = a.supplierName,
                          phone = a.phone,
                          chuanzhen = a.chuanzhen,
                          email = a.email,
                          contacts = a.contacts,
                          address = a.address,
                          contents = a.contents,
                          supplierLeix = a.supplierLeix1.supplierLeixName
                      };
            if (!string.IsNullOrEmpty(Id))
            {
                obj = obj.Where(p=> p.supplierNum.Contains(Id));
            }
            if (!string.IsNullOrEmpty(name))
            {
                obj = obj.Where(p => p.supplierName.Contains(name));
            }
            obj = obj.OrderBy(p => p.supplierNum).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return Json(obj,JsonRequestBehavior.AllowGet);
        }

        //供应商表的总条数
        public ActionResult SelectGongYings(string Id, string name)
        {
            GongYingBLL bll = new GongYingBLL();
            List<supplier> list = bll.Suppliers();
            var obj = from a in list where a.isDel == 1 select a;
            if (!string.IsNullOrEmpty(Id))
            {
                obj = obj.Where(p => p.supplierNum.Contains(Id));
            }
            if (!string.IsNullOrEmpty(name))
            {
                obj = obj.Where(p => p.supplierName.Contains(name));
            }
            return Json(obj.Count(), JsonRequestBehavior.AllowGet);
        }
        
        //新增供应商
        public ActionResult AddGongYing(string supplierLeix,string supplierName,string phone,string chuanzhen,string email,string contacts,string address,string contents)
        {
            GongYingBLL bll = new GongYingBLL();
            List<supplier> list = bll.Suppliers();
            int shu = list.Count(); string zhang = shu.ToString();
            string supplierNum = null;
            if (zhang.Length == 1)
            {
                supplierNum = "00000" + (shu + 1);
            }
            else if(zhang.Length ==2)
            {
                supplierNum = "0000" + (shu + 1);
            }
            else if (zhang.Length == 3)
            {
                supplierNum = "000" + (shu + 1);
            }
            supplier a = new supplier();
            a.supplierNum = supplierNum;a.supplierLeix = supplierLeix;a.supplierName = supplierName;a.phone = phone; a.chuanzhen = chuanzhen;
            a.email = email;a.contacts = contacts;a.address = address;a.contents = contents;a.isDel = 1;
            bll.Add(a);
           
                return Json("新增成功！",JsonRequestBehavior.AllowGet);
           
        }

        //删除供应商
        public ActionResult DeleteGongYing(string supplierNum)
        {
            GongYingBLL bll = new GongYingBLL();
            bll.delete(supplierNum);
            return Json("删除成功！",JsonRequestBehavior.AllowGet);
        }
        //全选删除供应商
        public ActionResult DeleteGongYings(string supplierNum)
        {
            GongYingBLL bll = new GongYingBLL();
            return Json(bll.delete(supplierNum), JsonRequestBehavior.AllowGet);
        }
        //修改供应商
        public ActionResult UdpateGongYing(string supplierLeix, string supplierName, string phone, string chuanzhen, string email, string contacts, string address, string contents,string supplierNum)
        {
            GongYingBLL bll = new GongYingBLL();
            List<supplier> list = bll.Suppliers();
            supplier a = new supplier();
            a.supplierNum = supplierNum; a.supplierLeix = supplierLeix; a.supplierName = supplierName; a.phone = phone; a.chuanzhen = chuanzhen;
            a.email = email; a.contacts = contacts; a.address = address; a.contents = contents; a.isDel = 1;
            bll.Udpate(a);

            return Json("修改成功！", JsonRequestBehavior.AllowGet);
        }
        //查询一个供应商
        public ActionResult SelectOneGongYing(string supplierNum) 
        {
            GongYingBLL bll = new GongYingBLL();
            List<supplier> list = bll.Suppliers();
          var  su = from a in list
                 where  a.supplierNum == supplierNum
                 select new
                 {
                     supplierNum = a.supplierNum,
                     supplierName = a.supplierName,
                     phone = a.phone,
                     chuanzhen = a.chuanzhen,
                     email = a.email,
                     contacts = a.contacts,
                     address = a.address,
                     contents = a.contents,
                     supplierLeix = a.supplierLeix
                 };
            return Json(su, JsonRequestBehavior.AllowGet);

        }
        //库位页面
        public ActionResult KeWei()
        {
            BLL.S.KeWeiBLL bll = new KeWeiBLL();
            ViewBag.gg = bll.Warehourses(); ;
            return View();
        }
        //库位管理的分页
        public ActionResult SelectKeWei(int pageIndex, int pageSize, string warehourseNum, string LocationName)
        {
            KeWeiBLL bll = new KeWeiBLL();
            List<Location> list = bll.Location();
            var obj = from p in list where p.isDel == 1 && p.warehourseNum.Contains(warehourseNum)
                      select new { LocationNum = p.LocationNum, LocationName = p.LocationName,
                          warehourseNum = p.warehourse.warehourseName,
                          barcode = p.barcode, isDisable = p.isDisable,isDefult = p.isDefult,
                          CreateTime = p.CreateTime.ToString("yyyy年MM月dd日"),
                      };
           
            if (!string.IsNullOrEmpty(LocationName))
            {
                obj = obj.Where(p => p.LocationName.Contains(LocationName));
            }
            obj = obj.OrderBy(p => p.LocationNum).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        //库位管理的总条数
        public ActionResult SelectKeWeis(string warehourseNum, string LocationName)
        {
            KeWeiBLL bll = new KeWeiBLL();
            List<Location> list = bll.Location();
            var obj = from p in list
                      where p.isDel == 1
                      select p;
            if (!string.IsNullOrEmpty(warehourseNum))
            {
                obj = obj.Where(p => p.warehourseNum.Contains(warehourseNum));
            }
            if (!string.IsNullOrEmpty(LocationName))
            {
                obj = obj.Where(p => p.LocationName.Contains(LocationName));
            }
            return Json(obj.Count(), JsonRequestBehavior.AllowGet);
        }
        //库位管理的删除
        public ActionResult DeleteKeWei(string id)
        {
            KeWeiBLL bll = new KeWeiBLL();
            bll.delete(id);
            return Json("删除成功！",JsonRequestBehavior.AllowGet);
        }
        //库位管理的总删除
        public ActionResult DeleteKeWeis(string id)
        {
            KeWeiBLL bll = new KeWeiBLL();
            return Json(bll.delete(id), JsonRequestBehavior.AllowGet);
        }

        //库位管理的新增
        public ActionResult InsertKeWei(string LocationName,string barcode,string warehourseNum,int isDefult)
        {
            KeWeiBLL bll = new KeWeiBLL();
            int shu = bll.Location().Count();
            string zhang = shu.ToString();
            string LocationNum = null;
            if (zhang.Length == 1)
            {
                LocationNum = "00000" + (shu + 1);
            }
            else if (zhang.Length == 2)
            {
                LocationNum = "0000" + (shu + 1);
            }
            else if (zhang.Length == 3)
            {
                LocationNum = "000" + (shu + 1);
            }
            Location sg = new Location();
            sg.LocationNum = LocationNum; sg.LocationName = LocationName;sg.barcode = barcode;
            sg.isDefult = isDefult;sg.isDel = 1;sg.isDisable = 1;sg.warehourseNum = warehourseNum;
            sg.CreateTime = DateTime.Now;
            bll.Add(sg);
            return Json("新增成功！", JsonRequestBehavior.AllowGet);
        }

        //查询一个供应商
        public ActionResult SelectOneKuWei(string LocationNum)
        {
            KeWeiBLL bll = new KeWeiBLL();
            List<Location> list = bll.Location();
            var obj = from p in list
                      where p.LocationNum == LocationNum
                      select new
                      {
                          LocationNum = p.LocationNum,
                          LocationName= p.LocationName,
                          isDefult = p.isDefult,
                          warehourseNum=  p.warehourseNum,
                          barcode= p.barcode
                      };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        //修改供应商
        public ActionResult UdpdateKuWei(string LocationName, string barcode, string warehourseNum, int isDefult,string LocationNum)
        {
            KeWeiBLL bll = new KeWeiBLL();
            Location sg = new Location();
            sg.LocationNum = LocationNum; sg.LocationName = LocationName; sg.barcode = barcode;
            sg.isDefult = isDefult; sg.warehourseNum = warehourseNum;
            bll.Update(sg);
            return Json("修改成功!", JsonRequestBehavior.AllowGet);
        }
        //禁用库位
        public ActionResult JingYong(string id,int shu)
        {
            KeWeiBLL bll = new KeWeiBLL();
            bll.JinYong(id,shu);
            if (shu == 0)
            {
                return Json("禁用成功！", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("解锁成功！", JsonRequestBehavior.AllowGet);
            }
        }


        //产品管理的页面
        public ActionResult Product()
        {
            ChanPinBLL bll = new ChanPinBLL();
            //库位管理
            ViewBag.Location = bll.Location().Where(p => p.isDel==1&&p.isDisable==1);
            //产品类别
            ViewBag.ProductLeixes = bll.ProductLeixes().Where(p => p.isDel==1);
            ViewBag.ProductLeixs = bll.ProductLeixes();
            //计量单位
            ViewBag.Company = bll.Company().Where(p => p.isDel == 1);
            //客户
            ViewBag.Customers = bll.Customers().Where(p => p.isDel == 1);
            //仓库管理
            ViewBag.Warehourses = bll.Warehourses();
            return View();
        }
        //产品管理分页
        public ActionResult SelectProduct(int pageIndex, int pageSize, string productName, string productLeixNum)
        {
            ChanPinBLL bll = new ChanPinBLL();
            List<product> list = bll.Product();
            var obj = from j in list
                      where j.isDel == 1 && j.productName.Contains(productName) && j.productLeixNum.Contains(productLeixNum)
                      select new {
                          productNum = j.productNum,
                          productName=j.productName,
                          productCount=j.productCount,
                          price=j.price,
                          Specifications=j.Specifications,
                          productLeixNum =j.productLeix.productLeixName,
                          CompanyNum = j.Company.CompanyName,
                          contents=j.contents};
            obj = obj.OrderBy(p => p.productNum).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        //产品总条数
        public ActionResult SelectProducts(string productName, string productLeixNum)
        {
            ChanPinBLL bll = new ChanPinBLL();
            List<product> list = bll.Product();
            var obj = from p in list
                      where p.isDel == 1
                      select p;
            if (!string.IsNullOrEmpty(productName))
            {
                obj = obj.Where(p => p.productName.Contains(productName));
            }
            if (!string.IsNullOrEmpty(productLeixNum))
            {
                obj = obj.Where(p => p.productLeixNum.Contains(productLeixNum));
            }
            return Json(obj.Count(), JsonRequestBehavior.AllowGet);
        }
        //产品删除
        public ActionResult DeleteProducts(string id)
        {
            ChanPinBLL bll = new ChanPinBLL();
            return Json(bll.delete(id), JsonRequestBehavior.AllowGet);
        }
        //产品新增
        public ActionResult InsertProduct(string productName,string Probarcode,int productCount,float price,string Specifications,string contents,string productLeixNum,string CompanyNum,string LocationNum,string customerNum)
        {
            ChanPinBLL bll = new ChanPinBLL();
            int shu = bll.Product().Count();
            string zhang = shu.ToString();
            string productNum = null;
            if (zhang.Length == 1)
            {
                productNum = "00000" + (shu + 1);
            }
            else if (zhang.Length == 2)
            {
                productNum = "0000" + (shu + 1);
            }
            else if (zhang.Length == 3)
            {
                productNum = "000" + (shu + 1);
            }
            product pro = new product();
            pro.productNum = productNum;pro.productName = productName;pro.Probarcode = Probarcode;pro.price = price;pro.productCount = productCount;pro.isDel = 1;
            pro.Specifications = Specifications; pro.contents = contents;pro.productLeixNum = productLeixNum;pro.CompanyNum = CompanyNum;pro.LocationNum = LocationNum;pro.customerNum = customerNum;
            bll.Add(pro);
            return Json("新增成功！", JsonRequestBehavior.AllowGet);
        }
        //产品的查询
        public ActionResult SelectOneProdut(string id)
        {
            ChanPinBLL bll = new ChanPinBLL();
            List<product> list = bll.Product();
            var obj = from j in list
                      where j.productNum == id
                      select new
                      {
                          productNum = j.productNum,
                          productName = j.productName,
                          productCount = j.productCount,
                          price = j.price,
                          Specifications = j.Specifications,
                          productLeixNum = j.productLeixNum,
                          CompanyNum = j.CompanyNum,
                          LocationNum = j.LocationNum,
                          customerNum = j.customerNum,
                          contents = j.contents
                      };
            List<productLeix> lists = new List<productLeix>();
            return Json(obj,JsonRequestBehavior.AllowGet);
        }
        //产品的修改
        public ActionResult UpdataProduct(string productNum, string productName, string Probarcode, int productCount, float price, string Specifications, string contents, string productLeixNum, string CompanyNum, string LocationNum, string customerNum)
        {
            ChanPinBLL bll = new ChanPinBLL();
            product pro = new product();
            pro.productNum = productNum; pro.productName = productName; pro.Probarcode = Probarcode; pro.price = price; pro.productCount = productCount; pro.isDel = 1;
            pro.Specifications = Specifications; pro.contents = contents; pro.productLeixNum = productLeixNum; pro.CompanyNum = CompanyNum; pro.LocationNum = LocationNum; pro.customerNum = customerNum;
            bll.Udpate(pro);
            return Json("修改成功！", JsonRequestBehavior.AllowGet);
        }

        //客户的页面
        public ActionResult KeHu()
        {
            return View();
        }
        //查询客户
        public ActionResult SelectKeHu(int pageIndex, int pageSize, string customerNum, string customerName)
        {
            KeHuBLL bll = new KeHuBLL();
            List<customer> list = bll.Customers();
            var obj = from p in list
                      where p.isDel == 1 && p.customerNum.Contains(customerNum) && p.customerName.Contains(customerName)
                      select new { customerNum= p.customerNum, customerName= p.customerName, phone= p.phone, chuanzhen= p.chuanzhen, createTime= p.createTime.ToString("yyyy年MM月dd日") };
            obj = obj.OrderBy(p => p.customerNum).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return Json(obj,JsonRequestBehavior.AllowGet);
        }

        //客户总条数
        public ActionResult SelectKeHus(string customerNum, string customerName)
        {
            KeHuBLL bll = new KeHuBLL();
            List<customer> list = bll.Customers();
            var obj = from p in list
                      where p.isDel == 1
                      select p;
            if (!string.IsNullOrEmpty(customerNum))
            {
                obj = obj.Where(p => p.customerNum.Contains(customerNum));
            }
            if (!string.IsNullOrEmpty(customerName))
            {
                obj = obj.Where(p => p.customerName.Contains(customerName));
            }
            return Json(obj.Count(), JsonRequestBehavior.AllowGet);
        }
        //删除客户
        public ActionResult DeleteKeHu(string customerNum)
        {
            KeHuBLL bll = new KeHuBLL();
            return Json(bll.delete(customerNum), JsonRequestBehavior.AllowGet);
        }
        //新增客户
        public ActionResult InsertKeHu(string customerName,string phone, string chuanzhen, string email, string contacts)
        {
            KeHuBLL bll = new KeHuBLL();
            int shu = bll.Customers().Count();
            string zhang = shu.ToString();
            string customerNum = null;
            if (zhang.Length == 1)
            {
                customerNum = "00000" + (shu + 1);
            }
            else if (zhang.Length == 2)
            {
                customerNum = "0000" + (shu + 1);
            }
            else if (zhang.Length == 3)
            {
                customerNum = "000" + (shu + 1);
            }
            customer cu = new customer();
            cu.customerNum = customerNum;cu.customerName = customerName;cu.phone = phone;
            cu.chuanzhen = chuanzhen;cu.email = email;cu.contents = contacts;
            cu.createTime = DateTime.Now;cu.isDel = 1;
            bll.Add(cu);
            List<customerAddressInfo> list = bll.CustomerAddressInfo();
            
                var obj = from p in list where Nullable<int>.Equals(p.customerNum, null) && p.isDel == 1 select new { AddressNum = p.AddressNum, AddressXinxi = p.AddressXinxi, contacts = p.contacts, phone = p.phone };
            foreach (var item in obj)
            {
                bll.UdpateBianHao(item.AddressNum,customerNum);
            }
              
            return Json("新增成功！", JsonRequestBehavior.AllowGet);
        }
        //新增客户地址
        public ActionResult InsertDiZhi(string AddressXinxi,string phone, string contacts,string bianhao)
        {
            KeHuBLL bll = new KeHuBLL();
            int shu = bll.CustomerAddressInfo().Count();
            string zhang = shu.ToString();
            string AddressNum = null;
            if (zhang.Length == 1)
            {
                AddressNum = "XBLY00" + (shu + 1);
            }
            else if (zhang.Length == 2)
            {
                AddressNum = "XBLY0" + (shu + 1);
            }
            else if (zhang.Length == 3)
            {
                AddressNum = "XBLY" + (shu + 1);
            }
            if (bianhao == "")
            {
                customerAddressInfo info = new customerAddressInfo();
                info.AddressNum = AddressNum; info.AddressXinxi = AddressXinxi;
                info.contacts = contacts;
                info.phone = phone; info.isDel = 1;
                bll.AddcustomerAddressInfo(info);
            }
            else
            {
                customerAddressInfo info = new customerAddressInfo();
                info.AddressNum = AddressNum; info.AddressXinxi = AddressXinxi;
                info.customerNum = bianhao; info.contacts = contacts;
                info.phone = phone; info.isDel = 1;
                bll.AddcustomerAddressInfo(info);
            }
           
            return Json("新增地址成功！",JsonRequestBehavior.AllowGet);
        }

        //查询客户地址
        public ActionResult SelectDiZhi()
        {
            KeHuBLL bll = new KeHuBLL();
            List<customerAddressInfo> list = bll.CustomerAddressInfo();
            var obj = from p in list where Nullable<int>.Equals(p.customerNum, null) && p.isDel == 1 select new { AddressNum = p.AddressNum, AddressXinxi = p.AddressXinxi, contacts = p.contacts, phone = p.phone };
            return Json(obj, JsonRequestBehavior.AllowGet);

        }
        public ActionResult SelectDiZhiUpdate(string bianhao)
        {
            KeHuBLL bll = new KeHuBLL();
            List<customerAddressInfo> list = bll.CustomerAddressInfo();
            var obj = from p in list where p.customerNum == bianhao && p.isDel == 1 select new { AddressNum = p.AddressNum, AddressXinxi = p.AddressXinxi, contacts = p.contacts, phone = p.phone };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        //删除客户地址
        public ActionResult DeleteDiZhi(string AddressNum)
        {
            KeHuBLL bll = new KeHuBLL();
            return Json(bll.deletecustomerAddressInfo(AddressNum), JsonRequestBehavior.AllowGet);
        }
        //查询一条地址数据
        public ActionResult SelectOneDiZhi(string AddressNum)
        {
            KeHuBLL bll = new KeHuBLL();
            List<customerAddressInfo> list = bll.CustomerAddressInfo();
            var obj = from p in list where p.AddressNum == AddressNum select new { AddressNum = p.AddressNum, AddressXinxi = p.AddressXinxi, contacts = p.contacts, phone = p.phone };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        //修改地址
        public ActionResult UdpateDiZhi(string AddressNum,string AddressXinxi,string contacts,string phone)
        {
            KeHuBLL bll = new KeHuBLL();
            customerAddressInfo info = new customerAddressInfo();
            info.AddressNum = AddressNum; info.AddressXinxi = AddressXinxi;
            info.contacts = contacts;
            info.phone = phone;
            bll.UdpatecustomerAddressInfo(info);
            return Json("修改地址成功！", JsonRequestBehavior.AllowGet);
        }
        //查询一条地址
        public ActionResult SelectOne(string customerNum)
        {
            KeHuBLL bll = new KeHuBLL();
            List<customer> list = bll.Customers();
            var obj = from p in list
                      where p.customerNum == customerNum
                      select new { customerNum = p.customerNum, customerName = p.customerName,
                          phone= p.phone,
                          chuanzhen= p.chuanzhen,
                          email= p.email,
                          contents= p.contents };
            return Json(obj,JsonRequestBehavior.AllowGet);
        }
        //修改客户
        public ActionResult UdpateKeHu(string bianhao,string customerName, string phone, string chuanzhen, string email, string contacts)
        {
            KeHuBLL bll = new KeHuBLL();
            customer cu = new customer();
            cu.customerNum = bianhao; cu.customerName = customerName; cu.phone = phone;
            cu.chuanzhen = chuanzhen; cu.email = email; cu.contents = contacts;
            bll.Udpate(cu);
            return Json("修改成功！",JsonRequestBehavior.AllowGet);
        }
        //产品类别页面
        public ActionResult LeiBie()
        {
            return View();
        }
        //查询产品类别
        public ActionResult SelectLeiBie(int pageIndex,int pageSize,string id,string name)
        {
            LeiBieBLL bll = new LeiBieBLL();
            List<productLeix> list = bll.productLeixes();
            var obj = from p in list
                      where p.isDel == 1 && p.productLeixNum.Contains(id) && p.productLeixName.Contains(name)
                      select new { productLeixNum = p.productLeixNum, productLeixName= p.productLeixName,
                          Founder=   p.Founder,
                          contents= p.contents, createTime= p.createTime.ToString("yyyy年MM月dd日") };
            obj = obj.OrderBy(p => p.productLeixNum).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return Json(obj,JsonRequestBehavior.AllowGet);
        }
        //查询产品类别总条数
        public ActionResult SelectLeiBies(string id, string name) 
        {
            LeiBieBLL bll = new LeiBieBLL();
            List<productLeix> list = bll.productLeixes();
            var obj = from p in list 
                      where p.isDel == 1 && p.productLeixNum.Contains(id) && p.productLeixName.Contains(name)
                      select p;
            return Json(obj.Count(),JsonRequestBehavior.AllowGet);
        }
        //删除产品类别
        public ActionResult DeleteLeiBie(string productLeixNum)
        {
            LeiBieBLL bll = new LeiBieBLL();   
            return Json(bll.delete(productLeixNum),JsonRequestBehavior.AllowGet);
        }
        //新增产品类别
        public ActionResult AddLieBie(string ProductLeixName,string contents)
        {
            LeiBieBLL bll = new LeiBieBLL();
            productLeix pro = new productLeix();
            int shu = bll.productLeixes().Count();
            string zhang = shu.ToString();
            string productLeixNum = null;
            if (zhang.Length == 1)
            {
                productLeixNum = "00000" + (shu + 1);
            }
            else if (zhang.Length == 2)
            {
                productLeixNum = "0000" + (shu + 1);
            }
            else if (zhang.Length == 3)
            {
                productLeixNum = "000" + (shu + 1);
            }
            pro.productLeixNum = productLeixNum;pro.productLeixName = ProductLeixName;pro.contents = contents;
            pro.Founder = "宋志浩";pro.isDel = 1;pro.createTime = DateTime.Now;
            bll.Add(pro);
            return Json("新增成功！",JsonRequestBehavior.AllowGet);
        }
        //查询一条产品类别
        public ActionResult SelectOneLieBie(string productLeixNum)
        {
            LeiBieBLL bll = new LeiBieBLL();
            List<productLeix> list = bll.productLeixes();
            var obj = from p in list
                      where p.productLeixNum == productLeixNum
                      select new
                      {
                          productLeixNum = p.productLeixNum,
                          productLeixName = p.productLeixName,
                          contents = p.contents
                      };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        //修改产品类别
        public ActionResult UdapteLieBie(string productLeixNum, string ProductLeixName, string contents)
        {
            LeiBieBLL bll = new LeiBieBLL();
            productLeix pro = new productLeix();
            pro.productLeixNum = productLeixNum; pro.productLeixName = ProductLeixName; pro.contents = contents;
            bll.Udpate(pro);
            return Json("修改成功！",JsonRequestBehavior.AllowGet);
        }

        //计量单位页面
        public ActionResult DanWei()
        {
            return View();
        }
        //查询计量单位
        public ActionResult SelectDanWei(int pageIndex, int pageSize, string id, string name)
        {
            DanWeiBLL bll = new DanWeiBLL();
            List<Company> list = bll.Company();
            var obj = from p in list where p.isDel == 1 && p.CompanyNum.Contains(id) && p.CompanyName.Contains(name)
                       select new { CompanyNum= p.CompanyNum, CompanyName= p.CompanyName };
            obj = obj.OrderBy(p => p.CompanyNum).Skip((pageIndex - 1) * pageSize).Take(pageSize);
            return Json(obj, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SelectDanWeis(string id, string name)
        {
            DanWeiBLL bll = new DanWeiBLL();
            List<Company> list = bll.Company();
            var obj = from p in list
                      where p.isDel == 1 && p.CompanyNum.Contains(id) && p.CompanyName.Contains(name)
                      select p;
            return Json(obj.Count(),JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteDanWei(string CompanyNum)
        {
            DanWeiBLL bll = new DanWeiBLL();
            bll.Delete(CompanyNum);
            return Json("删除成功！", JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddDanWei(string CompanyName)
        {
            DanWeiBLL bll = new DanWeiBLL();
            Company co = new Company();
            int shu = bll.Company().Count();
            string zhang = shu.ToString();
            string CompanyNum = null;
            if (zhang.Length == 1)
            {
                CompanyNum = "00" + (shu + 1);
            }
            else if (zhang.Length == 2)
            {
                CompanyNum = "0" + (shu + 1);
            }
            else if (zhang.Length == 3)
            {
                CompanyNum = (shu + 1).ToString();
            }
            co.CompanyNum = CompanyNum;co.CompanyName = CompanyName;co.isDel = 1;
            bll.Add(co);
            return Json("新增成功！",JsonRequestBehavior.AllowGet);
        }

        //查询一条产品类别
        public ActionResult SelectOneDanWei(string CompanyNum)
        {
            DanWeiBLL bll = new DanWeiBLL();
            List<Company> list = bll.Company();
            var obj = from p in list
                      where p.CompanyNum == CompanyNum
                      select new
                      {
                          CompanyNum = p.CompanyNum,
                          CompanyName = p.CompanyName
                      };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        //修改产品类别
        public ActionResult UdapteDanWei(string CompanyNum, string CompanyName)
        {
            DanWeiBLL bll = new DanWeiBLL();
            Company co = new Company();
            co.CompanyName = CompanyName; co.CompanyNum = CompanyNum;
            bll.Udapte(co);
            return Json("修改成功！", JsonRequestBehavior.AllowGet);
        }
    }
}