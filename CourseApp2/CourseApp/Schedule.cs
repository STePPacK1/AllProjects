//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CourseApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Schedule
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Schedule()
        {
            this.ScheduleStudent = new HashSet<ScheduleStudent>();
        }
    
        public int Id { get; set; }
        public int Course { get; set; }
        public int Teacher { get; set; }
        public int DayOfWeek { get; set; }
        public System.DateTime Time { get; set; }
        public bool Deleted { get; set; }
    
        public virtual Course Course1 { get; set; }
        public virtual DayOfWeek DayOfWeek1 { get; set; }
        public virtual Teacher Teacher1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScheduleStudent> ScheduleStudent { get; set; }
    }
}
