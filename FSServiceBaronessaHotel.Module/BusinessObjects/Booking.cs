using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSServiceBaronessaHotel.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(DisplayName))]
    public class Booking : BaseObject
    {
        [RuleRequiredField("RuleRequiredField for Booking.Guest", DefaultContexts.Save,
        "A guest must be specified")]
        public virtual Guests Guest { get; set; }
        [RuleRequiredField("RuleRequiredField for Booking.Room", DefaultContexts.Save,
        "A Room must be specified")]
        public virtual Rooms Room { get; set; }
        public virtual DateTime CheckInDate { get; set; }
        public virtual DateTime CheckOutDate { get; set; }
        public virtual int TotalAmount { get; set; }
        public virtual BookingStatus Status { get; set; }

        public virtual ObservableCollection<BookingServices> Services { get; }
        = new ObservableCollection<BookingServices>();


        [Browsable(false)]
        public string DisplayName => $"{Guest} {Room}";

        public void RecalculateTotal()
        {
            if (Room != null)
            {
                var days = (CheckOutDate - CheckInDate).Days;
                TotalAmount = Math.Max(0, days * Room.PricePerNight);
            }
            else
            {
                TotalAmount = 0;
            }
        }

    }
    public enum BookingStatus
    {
        Active = 1,
        Cancelled = 2,
        Completed = 3
    }
}
