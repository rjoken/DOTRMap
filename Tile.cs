using System;
using System.IO;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace DOTRMap
{
	/// <summary>
	/// Summary description for Tile.
	/// </summary>
	public class Tile
	{
		private Terrain terrain;
		private Rectangle rect;
		private Bitmap img;
		private bool hovered;

		// default tile constructor creates NORMAL tiles
		public Tile()
		{
			terrain = Terrain.NORMAL;
			rect = new Rectangle(0, 0, Constants.TILESIZE, Constants.TILESIZE);
			hovered = false;
			img = new Bitmap(Assembly.GetEntryAssembly().
				GetManifestResourceStream("DOTRMap.Resources." + terrain.ToString() + ".PNG"));
		}

		// create a tile with a specific terrain
		public Tile(Terrain t)
		{
			terrain = t;
			rect = new Rectangle(0, 0, Constants.TILESIZE, Constants.TILESIZE);
			hovered = false;
			img = new Bitmap(Assembly.GetEntryAssembly().
				GetManifestResourceStream("DOTRMap.Resources." + terrain.ToString() + ".PNG"));
		}

		// draw a tile with specific handling for hovered tiles given a rectangle previously determined
		public void Draw(Graphics g)
		{
			g.DrawImage(img, rect);
			if(hovered)
			{
				g.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.White)), rect);
			}
		}

		// draw a tile with a given rectangle
		public void Draw(Graphics g, Rectangle r)
        {
			g.DrawImage(img, r);
			if (hovered)
			{
				g.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.White)), rect);
			}
		}

		// encapsulation crap
		public Rectangle GetRect()
		{
			return rect;
		}

		public Terrain GetTerrain()
        {
			return terrain;
        }

		//return the terrain as its byte equivalent (useful!!)
		public byte GetTerrainAsByte()
        {
			return (byte)terrain;
        }

		// change the terrain of the tile
		public void SetTerrain(Terrain t)
        {
			img = new Bitmap(Assembly.GetEntryAssembly().
				GetManifestResourceStream("DOTRMap.Resources." + terrain.ToString() + ".PNG"));
			terrain = t;
        }

		// i'm lazy and i use this to reposition the tiles on a grid through the map class etc.
		public void SetRect(int x, int y)
		{
			rect.X = x;
			rect.Y = y;
		}

		public void SetHovered(bool b)
		{
			hovered = b;
		}
	}
}
