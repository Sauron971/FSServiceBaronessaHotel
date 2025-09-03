using DevExpress.ExpressApp.DC;
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
    [DefaultProperty(nameof(Name))]
    public class RoomType : BaseObject
    {
        [RuleRequiredField("RuleRequiredField for RoomType.Name", DefaultContexts.Save,
        "A name room type must be specified")]
        public virtual string Name { get; set; }

        [FieldSize(int.MaxValue)]
        public virtual string Description { get; set; }

        public virtual int MaxOccupancy { get; set; }

    }
}
