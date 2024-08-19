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

		public const string VERSION = "DOTRMap v1.0.0";

		public const string BUILT = "19-08-2024";

		public const int SLUSSIZE = 0x21EBD8;

		public const int ISOSIZE = 0x7DEE8000;

		public const int SLUSOFFSET = 0x1D575C;

		public const int ISOOFFSET = 0x29EF5C;

		//Each map is 49 bytes long, and there are 46 maps. Total length of data we're interested in loading is 2254 bytes.
		public const int MAPSSIZE = 0x8CE;

		public static void SetDoubleBuffered(Control c)
		{
			PropertyInfo pi = typeof(Control).GetProperty("DoubleBuffered",
			BindingFlags.NonPublic | BindingFlags.Instance);
			pi.SetValue(c, true, null);
		}

	}
}
