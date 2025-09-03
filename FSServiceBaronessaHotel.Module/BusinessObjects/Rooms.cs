using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSServiceBaronessaHotel.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(DisplayName))]
    public class Rooms : BaseObject
    {
        [RuleValueComparison("RoomNumber_GreaterThanZero", DefaultContexts.Save, ValueComparisonType.GreaterThan, 0,
    CustomMessageTemplate = "Value must be greater than 0")]
        public virtual int RoomNumber { get; set; }
        
        public virtual RoomType RoomType { get; set; }
        [RuleValueComparison("PricePerNight_GreaterThanZero", DefaultContexts.Save, ValueComparisonType.GreaterThan, 0,
    CustomMessageTemplate = "Value must be greater than 0")]
        public virtual int PricePerNight { get; set; }
        public virtual bool IsAvaible { get; set; }


        [Browsable(false)]
        public string DisplayName => $"{RoomNumber} {RoomType}";
    }
}
