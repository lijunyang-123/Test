//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class supplier
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public supplier()
        {
            this.putWarehourse = new HashSet<putWarehourse>();
        }
    
        public string supplierNum { get; set; }
        public string supplierLeix { get; set; }
        public string supplierName { get; set; }
        public string phone { get; set; }
        public string chuanzhen { get; set; }
        public string email { get; set; }
        public string contacts { get; set; }
        public string address { get; set; }
        public string contents { get; set; }
        public int isDel { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<putWarehourse> putWarehourse { get; set; }
        public virtual supplierLeix supplierLeix1 { get; set; }
    }
}
