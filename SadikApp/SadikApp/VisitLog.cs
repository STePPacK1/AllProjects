//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SadikApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class VisitLog
    {
        public int ID { get; set; }
        public int PupilID { get; set; }
        public System.DateTime Date { get; set; }
        public string ArirvalTime { get; set; }
        public string DepartureTime { get; set; }
        public int PresenceStatusID { get; set; }
        public Nullable<int> ReasonForAdsenceID { get; set; }
        public bool Deleted { get; set; }
    
        public virtual PresenceStatus PresenceStatus { get; set; }
        public virtual Pupil Pupil { get; set; }
        public virtual ReasonForAbsence ReasonForAbsence { get; set; }
    }
}
