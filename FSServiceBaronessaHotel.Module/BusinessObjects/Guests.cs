using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl.EF;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSServiceBaronessaHotel.Module.BusinessObjects
{
    [DefaultClassOptions]
    [DefaultProperty(nameof(DisplayName))]
    public class Guests : BaseObject
    {

        [RuleRequiredField("RuleRequiredField for Guests.FirstName", DefaultContexts.Save,
      "A First Name must be specified")]
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public virtual string Phone {  get; set; }
        public virtual string Email {  get; set; }

        [RuleRequiredField("RuleRequiredField for Guests.PassportNumber", DefaultContexts.Save,
      "A Passport Number must be specified")]
        public virtual string PassportNumber {  get; set; }

        [VisibleInListView(false)]
        [VisibleInDetailView(false)]
        [VisibleInLookupListView(true)]
        [ReadOnly(true)]
        public string DisplayName => $"{FirstName} {LastName}";
    }
}
