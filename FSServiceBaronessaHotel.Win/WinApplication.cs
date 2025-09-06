using System.ComponentModel;
using System.Data.Common;
using DevExpress.EntityFrameworkCore.Security;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ApplicationBuilder;
using DevExpress.ExpressApp.EFCore;
using DevExpress.ExpressApp.Security;
using DevExpress.ExpressApp.Security.ClientServer;
using DevExpress.ExpressApp.Updating;
using DevExpress.ExpressApp.Win;
using DevExpress.ExpressApp.Win.Utils;
using DevExpress.XtraMap.Drawing.DirectD3D9;
using FSServiceBaronessaHotel.Module;
using FSServiceBaronessaHotel.Module.BusinessObjects;
using Microsoft.EntityFrameworkCore;

namespace FSServiceBaronessaHotel.Win
{
    // For more typical usage scenarios, be sure to check out https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.Win.WinApplication._members
    public class FSServiceBaronessaHotelWindowsFormsApplication : WinApplication
    {
        public FSServiceBaronessaHotelWindowsFormsApplication()
        {
            SplashScreen = new DXSplashScreen(typeof(XafSplashScreen), new DefaultOverlayFormOptions());
            ApplicationName = "FSServiceBaronessaHotel";
            CheckCompatibilityType = DevExpress.ExpressApp.CheckCompatibilityType.DatabaseSchema;
            UseOldTemplates = false;
            DatabaseVersionMismatch += FSServiceBaronessaHotelWindowsFormsApplication_DatabaseVersionMismatch;
            CustomizeLanguagesList += FSServiceBaronessaHotelWindowsFormsApplication_CustomizeLanguagesList;
        }
        void FSServiceBaronessaHotelWindowsFormsApplication_CustomizeLanguagesList(object sender, CustomizeLanguagesListEventArgs e)
        {
            e.Languages.Clear();   // Сбросим список, чтоб не мешал
            e.Languages.Add("en-US");
            e.Languages.Add("ru-RU");
        }
        void FSServiceBaronessaHotelWindowsFormsApplication_DatabaseVersionMismatch(object sender, DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs e)
        {
#if EASYTEST
            e.Updater.Update();
            e.Handled = true;
#else
            if (System.Diagnostics.Debugger.IsAttached)
            {
                e.Updater.Update();
                e.Handled = true;
            }
            else
            {
                string message = "The application cannot connect to the specified database, " +
                    "because the database doesn't exist, its version is older " +
                    "than that of the application or its schema does not match " +
                    "the ORM data model structure. To avoid this error, use one " +
                    "of the solutions from the https://www.devexpress.com/kb=T367835 KB Article.";

                if (e.CompatibilityError != null && e.CompatibilityError.Exception != null)
                {
                    message += "\r\n\r\nInner exception: " + e.CompatibilityError.Exception.Message;
                }
                throw new InvalidOperationException(message);
            }
#endif
        }
    }
}
