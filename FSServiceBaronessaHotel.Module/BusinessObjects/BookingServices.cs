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
    public class BookingServices : BaseObject
    {
        [RuleRequiredField("RuleRequiredField for BookingServices.Booking", DefaultContexts.Save,
        "A booking must be specified")]
        public virtual Booking Booking { get; set; }

        [RuleRequiredField("RuleRequiredField for BookingServices.Service", DefaultContexts.Save,
        "A service must be specified")]
        public virtual Services Service { get; set; }
        public virtual int Quantity { get; set; }
    }
}
