using DevExpress.CodeParser;
using DevExpress.XtraReports.UI;
using FSServiceBaronessaHotel.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSServiceBaronessaHotel.Module.Reports
{
    public class BookingReport : XtraReport
    {
        public BookingReport(Guests guest, IQueryable<Booking> bookings) 
        {
            var headerBand = new ReportHeaderBand { HeightF = 100f };
            this.Bands.Add(headerBand);

            var firstNameLabel = new XRLabel
            {
                Text = $"Имя: {guest.FirstName}",
                LocationF = new PointF(0, 0),
                WidthF = 300
            };
            var lastNameLabel = new XRLabel
            {
                Text = $"Фамилия: {guest.LastName}",
                LocationF = new PointF(0, 20),
                WidthF = 300
            };
            var phoneLabel = new XRLabel
            {
                Text = $"Телефон: {guest.Phone}",
                LocationF = new PointF(0, 40),
                WidthF = 300
            };
            var passportLabel = new XRLabel
            {
                Text = $"Паспорт: {guest.PassportNumber}",
                LocationF = new PointF(0, 60),
                WidthF = 300
            };

            headerBand.Controls.AddRange(new XRControl[] { firstNameLabel, lastNameLabel, phoneLabel, passportLabel });

            var detailBand = new DetailBand { HeightF = 25f };
            this.Bands.Add(detailBand);

            var table = new XRTable { WidthF = 700f, Borders = DevExpress.XtraPrinting.BorderSide.All };
            var headerRow = new XRTableRow();

            headerRow.Cells.Add(new XRTableCell { Text = "Комната" });
            headerRow.Cells.Add(new XRTableCell { Text = "Тип комнаты" });
            headerRow.Cells.Add(new XRTableCell { Text = "Заселение" });
            headerRow.Cells.Add(new XRTableCell { Text = "Выселение" });
            headerRow.Cells.Add(new XRTableCell { Text = "Итог" });
            headerRow.Cells.Add(new XRTableCell { Text = "Статус" });

            table.Rows.Add(headerRow);

            foreach (var booking in bookings)
            {
                var row = new XRTableRow();
                row.Cells.Add(new XRTableCell { Text = booking.Room.RoomNumber.ToString() });
                row.Cells.Add(new XRTableCell { Text = booking.Room.RoomType.Name });
                row.Cells.Add(new XRTableCell { Text = booking.CheckInDate.ToString("dd.MM.yyyy") });
                row.Cells.Add(new XRTableCell { Text = booking.CheckOutDate.ToString("dd.MM.yyyy") });
                row.Cells.Add(new XRTableCell { Text = booking.TotalAmount.ToString("C0") });
                row.Cells.Add(new XRTableCell { Text = booking.Status.ToString() });

                table.Rows.Add(row);
            }

            detailBand.Controls.Add(table);

        }
    }
}
