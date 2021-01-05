using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace DAL.S
{
    public  class GongYing
    {
        CKSJKEntities ck = new CKSJKEntities();
        /*
         * 查询供应商
         */
        public List<supplier> Suppliers()
        {
            return ck.supplier.ToList();
        }
    }
}
