using System;
using System.Drawing;

namespace DOTRMap
{
	/// <summary>
	/// Summary description for Palette.
	/// </summary>
	public class Palette
	{
		private Tile[] tiles;
		private Terrain selected;
		public Palette()
		{
			selected = 0;
			tiles = new Tile[10];
			tiles[0] = new Tile(Terrain.FOREST);
			tiles[1] = new Tile(Terrain.WASTELAND);
			tiles[2] = new Tile(Terrain.MOUNTAIN);
			tiles[3] = new Tile(Terrain.MEADOW);
			tiles[4] = new Tile(Terrain.SEA);
			tiles[5] = new Tile(Terrain.DARK);
			tiles[6] = new Tile(Terrain.TOON);
			tiles[7] = new Tile(Terrain.NORMAL);
			tiles[8] = new Tile(Terrain.LABYRINTH);
			tiles[9] = new Tile(Terrain.CRUSH);
		}

		public void Draw(Graphics g, int startx, int starty)
		{
			int x = startx;
			int y = starty;
			for(int i = 0; i < tiles.Length; i++)
			{
				if((i > 0) && (i%2 == 0))
				{
					x = startx;
					y += Constants.TILESIZE;
				}
				tiles[i].SetRect(x, y);
				tiles[i].Draw(g);
				x += Constants.TILESIZE;
			}
		}

		public int GetTilesLength()
		{
			return tiles.Length;
		}

		public void SetTileHovered(int tilenum, bool state)
		{
			if (tilenum > tiles.Length - 1)
			{
				tiles[tiles.Length - 1].SetHovered(state);
			}
			else if (tilenum < 0)
			{
				tiles[0].SetHovered(state);
			}
			else
			{
				tiles[tilenum].SetHovered(state);
			}
		}

		public Tile GetTile(int tilenum)
		{
			if (tilenum > tiles.Length - 1)
			{
				return tiles[tiles.Length - 1];
			}
			else if (tilenum < 0)
			{
				return tiles[0];
			}
			else
			{
				return tiles[tilenum];
			}
		}

		public void SetSelected(int s)
		{
			selected = tiles[s].GetTerrain();
		}

		public Terrain GetSelected()
		{
			return selected;
		}
	}
}
