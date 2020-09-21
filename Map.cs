using System;
using System.Drawing;
using System.Windows.Forms;

namespace DOTRMap
{
	/// <summary>
	/// Summary description for Map.
	/// </summary>
	public class Map
	{
		private Tile[] tiles;
		public Map()
		{
			// creates a blank map of all NORMAL
			tiles = new Tile[49];
			for(int i = 0; i < tiles.Length; i++)
			{
				tiles[i] = new Tile();
			}
		}

		public Map(byte[] arr)
        {
			// loads a map from a byte array.
			tiles = new Tile[49];
			for(int i = 0; i < tiles.Length; i++)
            {
				try
				{
					tiles[i] = new Tile((Terrain)arr[i]);
				}
				catch
                {
					MessageBox.Show("The map you loaded was corrupt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

		// get the length of the tiles array
		public int GetTilesLength()
		{
			return tiles.Length;
		}

		// set a tile hovered for effects when drawing
		public void SetTileHovered(int tilenum, bool state)
		{
			if(tilenum > tiles.Length - 1)
			{
				tiles[tiles.Length - 1].SetHovered(state);
			}
			else if(tilenum < 0)
			{
				tiles[0].SetHovered(state);
			}
			else
			{
				tiles[tilenum].SetHovered(state);
			}
		}

		// get a tile given its index in the array
		public Tile GetTile(int tilenum)
		{
			if(tilenum > tiles.Length - 1)
			{
				return tiles[tiles.Length - 1];
			}
			else if(tilenum < 0)
			{
				return tiles[0];
			}
			else
			{
				return tiles[tilenum];
			}
		}

		// set a tile as a specific terrain given tile number and terrain type
		public void SetTile(int tilenum, Terrain t)
        {
			if (tilenum > tiles.Length - 1)
			{
				tiles[tiles.Length - 1].SetTerrain(t);
			}
			else if (tilenum < 0)
			{
				tiles[0].SetTerrain(t);
			}
			else
			{
				tiles[tilenum].SetTerrain(t);
			}
		}

		// draw map as 7x7 via byte array
		public void Draw(Graphics g, int startx, int starty)
		{
			int x = startx;
			int y = starty;
			for(int i = 0; i < tiles.Length; i++)
			{
				// if divisible by 7, go to new row
				if((i > 0) && (i%7 == 0))
				{
					x = startx;
					y += Constants.TILESIZE;
				}
				tiles[i].SetRect(x, y);
				tiles[i].Draw(g);
				x += Constants.TILESIZE;
			}
		}
	}
}
