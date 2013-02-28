using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace PaymentKiosk.About
{
    //Basic Assembly Version Information
    public static class AssemblyVersion
    {
        public static string GetAssemblyVersion()
        {
            AssemblyName assName = Assembly.GetExecutingAssembly().GetName();
            Version v = assName.Version;

            // set the version date

            DateTime compileDate = DateTime.Now;
            string compileString = compileDate.ToString("ddMMMMyy HH:mm");

            // only display the first major & minor numbers

            string version = assName.Version.Major.ToString() + "." + assName.Version.Minor.ToString();

            // start the version info
            StringBuilder sbVersionInfo = new StringBuilder();
            sbVersionInfo.Append(Application.ProductName);

#if DEBUG
            sbVersionInfo.AppendFormat(" {0} Beta -=*<DEBUG>*=- ({1})", version, compileString);
#elif RELEASE
			sbVersionInfo.AppendFormat( " {0} ({1})", version, compileString );
#else
			// unofficial
			sbVersionInfo.AppendFormat( " {0} Beta -=*<NON-DEBUG>*=- ({1})", version, compileString );
#endif

            return sbVersionInfo.ToString();
        }
    }
}
