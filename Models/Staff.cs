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
    
    public partial class Staff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Staff()
        {
            this.LossReport = new HashSet<LossReport>();
            this.outWarehourse = new HashSet<outWarehourse>();
            this.putWarehourse = new HashSet<putWarehourse>();
            this.transfer = new HashSet<transfer>();
        }
    
        public string ygNumber { get; set; }
        public string LoginName { get; set; }
        public string loginPwd { get; set; }
        public string ygName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public Nullable<int> LoginNum { get; set; }
        public string BmNum { get; set; }
        public string ZwNum { get; set; }
        public Nullable<System.DateTime> CreateTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public Nullable<int> isDel { get; set; }
    
        public virtual department department { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LossReport> LossReport { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<outWarehourse> outWarehourse { get; set; }
        public virtual position position { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<putWarehourse> putWarehourse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<transfer> transfer { get; set; }
    }
}
