using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.DC;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using FSServiceBaronessaHotel.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FSServiceBaronessaHotel.Module.Controllers
{
    public partial class BookingListViewController : ObjectViewController<ListView, Booking>
    {
        public BookingListViewController()
        {
            var totalAmountByMonthAction = new ParametrizedAction(this, "TotalAmountByMonth", DevExpress.Persistent.Base.PredefinedCategory.Filters, typeof(DateTime))
            {
                Caption = "Получить итог за весь месяц",
                ImageName = "BO_Opportunity"
            };
            totalAmountByMonthAction.Execute += TotalAmountAction_Execute;
        }

        private void TotalAmountAction_Execute(object sender, ParametrizedActionExecuteEventArgs e)
        {
            int sumTotal = 0;
            using (IObjectSpace os = Application.CreateObjectSpace(typeof(Booking))) {
                var all = os.GetObjects<Booking>();
                foreach (Booking booking in all)
                {
                    if (booking.CheckInDate.Month == ((DateTime)e.ParameterCurrentValue).Month &&
                        booking.CheckInDate.Year == ((DateTime)e.ParameterCurrentValue).Year)
                        sumTotal += booking.TotalAmount;
                }
            }
            MessageOptions options = new MessageOptions();
            options.Duration = 2000;
            options.Message = string.Format("В этом месяце {0}!", sumTotal);
            options.Type = InformationType.Success;
            options.Web.Position = InformationPosition.Right;
            options.Win.Caption = "Успешно";
            options.Win.Type = WinMessageType.Toast;
            Application.ShowViewStrategy.ShowMessage(options);
        }
    }
}

