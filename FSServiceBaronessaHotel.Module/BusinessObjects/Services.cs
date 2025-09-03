using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSServiceBaronessaHotel.Module.BusinessObjects
{
    [DefaultClassOptions]
    public class Services : BaseObject
    {
        public virtual string Name { get; set; }
        [RuleValueComparison("Price_GreaterThanZero", DefaultContexts.Save, ValueComparisonType.GreaterThan, 0,
        CustomMessageTemplate = "Value must be greater than 0")]
        public virtual int Price {  get; set; }
    }
}
