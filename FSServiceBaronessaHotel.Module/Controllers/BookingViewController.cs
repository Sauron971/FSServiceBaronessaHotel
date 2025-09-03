using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using FSServiceBaronessaHotel.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSServiceBaronessaHotel.Module.Controllers
{
    public class BookingViewController : ObjectViewController<DetailView, Booking>
    {
        public BookingViewController()
        {
            var calcAction = new SimpleAction(this, "CalculateTotalAmount", DevExpress.Persistent.Base.PredefinedCategory.View)
            {
                Caption = "Пересчитать сумму",
                ImageName = "Action_Refresh"

            };
            calcAction.Execute += CalcAction_Execute;
        }

        private void CalcAction_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            foreach (Booking booking in e.SelectedObjects)
            {
                booking.RecalculateTotal();
            }
            ObjectSpace.CommitChanges();
        }
    }
}
