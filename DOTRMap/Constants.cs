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
		public const string VERSION = "DOTRMap v0.3.9";

		public const string BUILT = "02-01-2021";

		public const int SLUSSIZE = 0x21EBD8;

		public const int ISOSIZE = 0x7DEE8000;

		public const int SLUSOFFSET = 0x1D575C;

		public const int ISOOFFSET = 0x29EF5C;

		public static void SetDoubleBuffered(Control c)
		{
			PropertyInfo pi = typeof(Control).GetProperty("DoubleBuffered",
				BindingFlags.NonPublic | BindingFlags.Instance);
			pi.SetValue(c, true, null);
		}

	}
}
