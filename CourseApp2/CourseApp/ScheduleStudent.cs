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
    
    public partial class ScheduleStudent
    {
        public int Id { get; set; }
        public int Student { get; set; }
        public int Schedule { get; set; }
        public bool Deleted { get; set; }
    
        public virtual Schedule Schedule1 { get; set; }
        public virtual Student Student1 { get; set; }
    }
}
