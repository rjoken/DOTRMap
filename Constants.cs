using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace DOTRMap
{
	public static class Constants
	{
		public const int TILESIZE = 32;

		//this is manual the revision number is just the number of days i've worked on it
		public const string VERSION = "DOTRMap v0.3.6_02";

		public const string BUILT = "21-09-2020";

		public const int SLUSSIZE = 0x21EBD8;

		public static void SetDoubleBuffered(Control c)
		{
			PropertyInfo pi = typeof(Control).GetProperty("DoubleBuffered",
				BindingFlags.NonPublic | BindingFlags.Instance);
			pi.SetValue(c, true, null);
		}

	}
}
