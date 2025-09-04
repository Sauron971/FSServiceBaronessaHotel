using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.Persistent.Base;
using DevExpress.Utils.CommonDialogs.Internal;
using FSServiceBaronessaHotel.Module.BusinessObjects;
using FSServiceBaronessaHotel.Module.Reports;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DialogResult = System.Windows.Forms.DialogResult;

namespace FSServiceBaronessaHotel.Module.Controllers
{
    public class GuestListViewController : ObjectViewController<ListView, Guests>
    {
        public GuestListViewController()
        {
            var exportBookings = new SimpleAction(this, "ExportGuestBookings", PredefinedCategory.Reports)
            {
                Caption = "Сформировать отчет",
                ImageName = "Shopping_CashVoucher"
            };
            exportBookings.Execute += ExportWordReport;
        }

        private void ExportWordReport(object sender, SimpleActionExecuteEventArgs e)
        {
            var guest = e.SelectedObjects[0] as Guests;
            if (guest == null) return;

            using (var os = Application.CreateObjectSpace(typeof(Booking)))
            {
                var bookings = os.GetObjects<Booking>().Where(b => b.Guest.ID == guest.ID).ToList();
                if (!bookings.Any())
                {
                    MessageBox.Show("У этого гостя нет бронирований.", "Внимание");
                    return;
                }

                var report = new BookingReport(guest, bookings.AsQueryable());

                using (var dialog = new SaveFileDialog())
                {
                    dialog.Filter = "Word Document|*.docx";
                    dialog.FileName = $"GuestBooking_{guest.FirstName}_{guest.LastName}.docx";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        var path = dialog.FileName;
                        report.ExportToDocx(path);

                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                        {
                            FileName = path,
                            UseShellExecute = true
                        });
                    }

                    MessageOptions options = new MessageOptions();
                    options.Duration = 2000;
                    options.Message = string.Format("Отчет сохранен на пути: {0}!", dialog.FileName);
                    options.Type = InformationType.Success;
                    options.Web.Position = InformationPosition.Right;
                    options.Win.Caption = "Успешно";
                    options.Win.Type = WinMessageType.Toast;
                    Application.ShowViewStrategy.ShowMessage(options);
                }
            }
        }
    }
}
