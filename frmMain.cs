using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;


namespace DOTRMap
{
	public enum Terrain 
	{
		FOREST = 0x00,
		WASTELAND = 0x01,
		MOUNTAIN = 0x02,
		MEADOW = 0x03,
		SEA = 0x04,
		DARK = 0x05,
		TOON = 0x06,
		NORMAL = 0x07,
		LABYRINTH = 0x08,
		CRUSH = 0x09
	};

	public class frmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu menuMenu;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuHelp;
		private System.Windows.Forms.MenuItem menuFileOpen;
		private System.Windows.Forms.TabControl tabctrlMain;
		private System.Windows.Forms.TabPage tabInjector;
		private System.Windows.Forms.TabPage tabEditor;
		private System.Windows.Forms.MenuItem menuOpenSlus;
		private System.Windows.Forms.MenuItem menuOpenMap;
		private System.Windows.Forms.MenuItem menuFileSave;
		private System.Windows.Forms.MenuItem menuSaveSlus;
		private System.Windows.Forms.MenuItem menuSaveMap;
		private System.Windows.Forms.MenuItem menuFileExit;
		private System.Windows.Forms.ListBox lbxMaps;
		private System.Windows.Forms.Label lblSlus;
		private System.Windows.Forms.GroupBox gbxStatus;
		private System.Windows.Forms.Button btnExport;
		private System.Windows.Forms.Button btnLoad;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.GroupBox gbxPalette;
		private System.Windows.Forms.GroupBox gbxSelected;
		private System.Windows.Forms.Timer tmrRefresh;
        private System.Windows.Forms.Panel pnlPalette;

        private byte[] fileSlus;
		private Map loadedMap;
        private Panel pnlSelected;
        private Panel pnlEditor;
        private Label lblRR;
        private Label lblWR;
        private Button btnInject;
        private Palette palette;
        private Button btnReload;
        private MenuItem menuHelpAbout;
        private String slusPath;

		public frmMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			loadedMap = new Map();
			palette = new Palette();
			tmrRefresh.Interval = 1000 / 60;
			tmrRefresh.Enabled = true;

			#region setstyle
			Constants.SetDoubleBuffered(pnlPalette);
            Constants.SetDoubleBuffered(pnlSelected);
            Constants.SetDoubleBuffered(pnlEditor);
			this.UpdateStyles();
			#endregion
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.menuMenu = new System.Windows.Forms.MainMenu(this.components);
            this.menuFile = new System.Windows.Forms.MenuItem();
            this.menuFileOpen = new System.Windows.Forms.MenuItem();
            this.menuOpenSlus = new System.Windows.Forms.MenuItem();
            this.menuOpenMap = new System.Windows.Forms.MenuItem();
            this.menuFileSave = new System.Windows.Forms.MenuItem();
            this.menuSaveSlus = new System.Windows.Forms.MenuItem();
            this.menuSaveMap = new System.Windows.Forms.MenuItem();
            this.menuFileExit = new System.Windows.Forms.MenuItem();
            this.menuHelp = new System.Windows.Forms.MenuItem();
            this.menuHelpAbout = new System.Windows.Forms.MenuItem();
            this.tabctrlMain = new System.Windows.Forms.TabControl();
            this.tabInjector = new System.Windows.Forms.TabPage();
            this.btnReload = new System.Windows.Forms.Button();
            this.btnInject = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblSlus = new System.Windows.Forms.Label();
            this.gbxStatus = new System.Windows.Forms.GroupBox();
            this.lbxMaps = new System.Windows.Forms.ListBox();
            this.tabEditor = new System.Windows.Forms.TabPage();
            this.lblRR = new System.Windows.Forms.Label();
            this.lblWR = new System.Windows.Forms.Label();
            this.pnlEditor = new System.Windows.Forms.Panel();
            this.gbxPalette = new System.Windows.Forms.GroupBox();
            this.pnlPalette = new System.Windows.Forms.Panel();
            this.gbxSelected = new System.Windows.Forms.GroupBox();
            this.pnlSelected = new System.Windows.Forms.Panel();
            this.tmrRefresh = new System.Windows.Forms.Timer(this.components);
            this.tabctrlMain.SuspendLayout();
            this.tabInjector.SuspendLayout();
            this.tabEditor.SuspendLayout();
            this.gbxPalette.SuspendLayout();
            this.gbxSelected.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMenu
            // 
            this.menuMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFile,
            this.menuHelp});
            // 
            // menuFile
            // 
            this.menuFile.Index = 0;
            this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuFileOpen,
            this.menuFileSave,
            this.menuFileExit});
            this.menuFile.Text = "File";
            // 
            // menuFileOpen
            // 
            this.menuFileOpen.Index = 0;
            this.menuFileOpen.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuOpenSlus,
            this.menuOpenMap});
            this.menuFileOpen.Text = "Open...";
            // 
            // menuOpenSlus
            // 
            this.menuOpenSlus.Index = 0;
            this.menuOpenSlus.Text = "SLUS";
            this.menuOpenSlus.Click += new System.EventHandler(this.menuOpenSlus_Click);
            // 
            // menuOpenMap
            // 
            this.menuOpenMap.Index = 1;
            this.menuOpenMap.Text = "Map";
            this.menuOpenMap.Click += new System.EventHandler(this.menuOpenMap_Click);
            // 
            // menuFileSave
            // 
            this.menuFileSave.Index = 1;
            this.menuFileSave.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuSaveSlus,
            this.menuSaveMap});
            this.menuFileSave.Text = "Save...";
            // 
            // menuSaveSlus
            // 
            this.menuSaveSlus.Enabled = false;
            this.menuSaveSlus.Index = 0;
            this.menuSaveSlus.Text = "SLUS";
            this.menuSaveSlus.Click += new System.EventHandler(this.menuSaveSlus_Click);
            // 
            // menuSaveMap
            // 
            this.menuSaveMap.Index = 1;
            this.menuSaveMap.Text = "Map";
            this.menuSaveMap.Click += new System.EventHandler(this.menuSaveMap_Click);
            // 
            // menuFileExit
            // 
            this.menuFileExit.Index = 2;
            this.menuFileExit.Text = "Exit";
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.Index = 1;
            this.menuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuHelpAbout});
            this.menuHelp.Text = "Help";
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Index = 0;
            this.menuHelpAbout.Text = "About";
            this.menuHelpAbout.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // tabctrlMain
            // 
            this.tabctrlMain.Controls.Add(this.tabInjector);
            this.tabctrlMain.Controls.Add(this.tabEditor);
            this.tabctrlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabctrlMain.Location = new System.Drawing.Point(0, 0);
            this.tabctrlMain.Name = "tabctrlMain";
            this.tabctrlMain.SelectedIndex = 0;
            this.tabctrlMain.Size = new System.Drawing.Size(392, 353);
            this.tabctrlMain.TabIndex = 0;
            // 
            // tabInjector
            // 
            this.tabInjector.Controls.Add(this.btnReload);
            this.tabInjector.Controls.Add(this.btnInject);
            this.tabInjector.Controls.Add(this.btnLoad);
            this.tabInjector.Controls.Add(this.btnExport);
            this.tabInjector.Controls.Add(this.lblSlus);
            this.tabInjector.Controls.Add(this.gbxStatus);
            this.tabInjector.Controls.Add(this.lbxMaps);
            this.tabInjector.Location = new System.Drawing.Point(4, 22);
            this.tabInjector.Name = "tabInjector";
            this.tabInjector.Size = new System.Drawing.Size(384, 327);
            this.tabInjector.TabIndex = 0;
            this.tabInjector.Text = "Injector";
            // 
            // btnReload
            // 
            this.btnReload.Enabled = false;
            this.btnReload.Location = new System.Drawing.Point(208, 163);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(168, 23);
            this.btnReload.TabIndex = 6;
            this.btnReload.Text = "Reload SLUS";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // btnInject
            // 
            this.btnInject.Enabled = false;
            this.btnInject.Location = new System.Drawing.Point(208, 133);
            this.btnInject.Name = "btnInject";
            this.btnInject.Size = new System.Drawing.Size(168, 23);
            this.btnInject.TabIndex = 5;
            this.btnInject.Text = "Inject Map";
            this.btnInject.Click += new System.EventHandler(this.btnInject_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Enabled = false;
            this.btnLoad.Location = new System.Drawing.Point(208, 104);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(168, 23);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Load Selected";
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnExport
            // 
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(208, 72);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(168, 23);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblSlus
            // 
            this.lblSlus.Location = new System.Drawing.Point(216, 24);
            this.lblSlus.Name = "lblSlus";
            this.lblSlus.Size = new System.Drawing.Size(152, 32);
            this.lblSlus.TabIndex = 1;
            this.lblSlus.Text = "SLUS not loaded";
            // 
            // gbxStatus
            // 
            this.gbxStatus.Location = new System.Drawing.Point(208, 8);
            this.gbxStatus.Name = "gbxStatus";
            this.gbxStatus.Size = new System.Drawing.Size(168, 56);
            this.gbxStatus.TabIndex = 2;
            this.gbxStatus.TabStop = false;
            this.gbxStatus.Text = "Status";
            // 
            // lbxMaps
            // 
            this.lbxMaps.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbxMaps.Enabled = false;
            this.lbxMaps.Items.AddRange(new object[] {
            "Tutorial",
            "Seto",
            "Weevil",
            "Rex",
            "Keith",
            "Ishtar",
            "Necromancer",
            "Darkness-ruler",
            "Labyrinth-ruler",
            "Pegasus",
            "Richard",
            "Tea",
            "Tristan",
            "Mai",
            "Mako",
            "Joey",
            "Shadi",
            "Jasper",
            "Bakura",
            "Yugi",
            "Skull Knight",
            "Chakra",
            "Default Map 00",
            "Default Map 01",
            "Default Map 02",
            "Default Map 03",
            "Default Map 04",
            "Default Map 05",
            "Default Map 06",
            "Default Map 07",
            "Default Map 08",
            "Default Map 09",
            "Default Map 10",
            "Default Map 11",
            "Default Map 12",
            "Default Map 13",
            "Default Map 14",
            "Default Map 15",
            "Default Map 16",
            "Default Map 17",
            "Default Map 18",
            "Default Map 19",
            "Default Map 20",
            "Default Map 21",
            "Default Map 22",
            "Default Map 23"});
            this.lbxMaps.Location = new System.Drawing.Point(0, 0);
            this.lbxMaps.Name = "lbxMaps";
            this.lbxMaps.Size = new System.Drawing.Size(200, 327);
            this.lbxMaps.TabIndex = 0;
            // 
            // tabEditor
            // 
            this.tabEditor.Controls.Add(this.lblRR);
            this.tabEditor.Controls.Add(this.lblWR);
            this.tabEditor.Controls.Add(this.pnlEditor);
            this.tabEditor.Controls.Add(this.gbxPalette);
            this.tabEditor.Controls.Add(this.gbxSelected);
            this.tabEditor.Location = new System.Drawing.Point(4, 22);
            this.tabEditor.Name = "tabEditor";
            this.tabEditor.Size = new System.Drawing.Size(384, 327);
            this.tabEditor.TabIndex = 1;
            this.tabEditor.Text = "Editor";
            // 
            // lblRR
            // 
            this.lblRR.AutoSize = true;
            this.lblRR.Location = new System.Drawing.Point(227, 255);
            this.lblRR.Name = "lblRR";
            this.lblRR.Size = new System.Drawing.Size(27, 13);
            this.lblRR.TabIndex = 4;
            this.lblRR.Text = "Red";
            // 
            // lblWR
            // 
            this.lblWR.AutoSize = true;
            this.lblWR.Location = new System.Drawing.Point(224, 10);
            this.lblWR.Name = "lblWR";
            this.lblWR.Size = new System.Drawing.Size(35, 13);
            this.lblWR.TabIndex = 3;
            this.lblWR.Text = "White";
            // 
            // pnlEditor
            // 
            this.pnlEditor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlEditor.CausesValidation = false;
            this.pnlEditor.Location = new System.Drawing.Point(127, 28);
            this.pnlEditor.Name = "pnlEditor";
            this.pnlEditor.Size = new System.Drawing.Size(224, 224);
            this.pnlEditor.TabIndex = 2;
            this.pnlEditor.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlEditor_Paint);
            this.pnlEditor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlEditor_MouseDown);
            this.pnlEditor.MouseLeave += new System.EventHandler(this.pnlEditor_MouseLeave);
            this.pnlEditor.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlEditor_MouseMove);
            this.pnlEditor.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnlEditor_MouseDown);
            // 
            // gbxPalette
            // 
            this.gbxPalette.Controls.Add(this.pnlPalette);
            this.gbxPalette.Location = new System.Drawing.Point(8, 8);
            this.gbxPalette.Name = "gbxPalette";
            this.gbxPalette.Size = new System.Drawing.Size(86, 192);
            this.gbxPalette.TabIndex = 0;
            this.gbxPalette.TabStop = false;
            this.gbxPalette.Text = "Palette";
            // 
            // pnlPalette
            // 
            this.pnlPalette.Location = new System.Drawing.Point(6, 11);
            this.pnlPalette.Name = "pnlPalette";
            this.pnlPalette.Size = new System.Drawing.Size(72, 175);
            this.pnlPalette.TabIndex = 0;
            this.pnlPalette.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPalette_Paint);
            this.pnlPalette.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlPalette_MouseDown);
            this.pnlPalette.MouseLeave += new System.EventHandler(this.pnlPalette_MouseLeave);
            this.pnlPalette.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlPalette_MouseMove);
            // 
            // gbxSelected
            // 
            this.gbxSelected.Controls.Add(this.pnlSelected);
            this.gbxSelected.Location = new System.Drawing.Point(8, 216);
            this.gbxSelected.Name = "gbxSelected";
            this.gbxSelected.Size = new System.Drawing.Size(86, 86);
            this.gbxSelected.TabIndex = 1;
            this.gbxSelected.TabStop = false;
            this.gbxSelected.Text = "Selected";
            // 
            // pnlSelected
            // 
            this.pnlSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSelected.Location = new System.Drawing.Point(11, 16);
            this.pnlSelected.Name = "pnlSelected";
            this.pnlSelected.Size = new System.Drawing.Size(64, 64);
            this.pnlSelected.TabIndex = 0;
            this.pnlSelected.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlSelected_Paint);
            // 
            // tmrRefresh
            // 
            this.tmrRefresh.Tick += new System.EventHandler(this.tmrRefresh_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(392, 353);
            this.Controls.Add(this.tabctrlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Menu = this.menuMenu;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.tabctrlMain.ResumeLayout(false);
            this.tabInjector.ResumeLayout(false);
            this.tabEditor.ResumeLayout(false);
            this.tabEditor.PerformLayout();
            this.gbxPalette.ResumeLayout(false);
            this.gbxSelected.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.Run(new frmMain());
		}

        private void SaveSlus(String path, byte[] memorySlus)
        {
            File.WriteAllBytes(path, memorySlus);
        }

        private byte[] OpenSlus(String path, byte[] memorySlus)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                memorySlus = new byte[fs.Length];
                int bytesToRead = (int)fs.Length;
                int bytesRead = 0;
                while (bytesToRead > 0)
                {
                    int b = fs.Read(memorySlus, bytesRead, bytesToRead);
                    if (b == 0)
                    {
                        break;
                    }

                    bytesRead += b;
                    bytesToRead -= b;
                }
            }

            return memorySlus;
        }

		private void menuFileExit_Click(object sender, System.EventArgs e)
		{
			Environment.Exit(1);
		}

		private void frmMain_Load(object sender, System.EventArgs e)
		{
            this.Icon = new Icon(Assembly.GetExecutingAssembly().GetManifestResourceStream("DOTRMap.Resources.ROSE.ICO"));
            this.Text = Constants.VERSION;
			loadedMap = new Map();
		}

		private void menuOpenSlus_Click(object sender, System.EventArgs e)
		{
			slusPath = string.Empty;
			using (OpenFileDialog ofd = new OpenFileDialog())
			{
				ofd.Filter = "SLUS files (SLUS_205.15)|SLUS_205.15";
				ofd.FilterIndex = 2;
				ofd.RestoreDirectory = true;

				if (ofd.ShowDialog() == DialogResult.OK)
				{
					try
					{
                        slusPath = ofd.FileName;
                        fileSlus = OpenSlus(slusPath, fileSlus);

                        //TODO: advanced offset editing if file size is unexpected, along with a warning. For now, just deny opening the file
                        if (fileSlus.Length != Constants.SLUSSIZE)
                        {
                            throw new Exception("The SLUS provided was corrupt!");
                        }
						lblSlus.Text = "SLUS loaded\n" + fileSlus.Length.ToString() + " bytes.";

                        //enable all SLUS related buttons
                        menuSaveSlus.Enabled = true;
                        lbxMaps.Enabled = true;
                        btnLoad.Enabled = true;
                        btnExport.Enabled = true;
                        btnInject.Enabled = true;
                        btnReload.Enabled = true;
                        lbxMaps.SelectedIndex = 0;
					}
					catch (Exception ex)
					{
                        MessageBox.Show("SLUS could not be loaded. " + ex.ToString(), "Error", MessageBoxButtons.OK);
					}
				}
			}
		}

        // called at 60 frames per second..
        private void pnlEditor_Paint(object sender, PaintEventArgs e)
        {
            loadedMap.Draw(e.Graphics, 0, 0);
        }

        private void pnlPalette_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
            // i cant get this centred nicely
			palette.Draw(e.Graphics, 6, 8);
		}

        private void pnlSelected_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = new Rectangle(0, 0, pnlSelected.Size.Width, pnlSelected.Size.Height);
            Tile selected = new Tile(palette.GetSelected());
            selected.Draw(e.Graphics, r);
        }

        // 60 fps timer
        private void tmrRefresh_Tick(object sender, System.EventArgs e)
		{
			pnlPalette.Invalidate();
            pnlSelected.Invalidate();
			pnlEditor.Invalidate();
		}

        // when mouse moves over the editor, catch the tile the mouse intersects with and set it hovered 
        // for visual effect
		private void pnlEditor_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
            Rectangle mousePoint = new Rectangle(e.X, e.Y, 1, 1);
			//iterate through map
			for (int i = 0; i < loadedMap.GetTilesLength(); i++)
			{
				if (loadedMap.GetTile(i).GetRect().IntersectsWith(mousePoint))
				{
					loadedMap.SetTileHovered(i, true);
				}
				else
				{
					loadedMap.SetTileHovered(i, false);
				}
			}
		}

        // when clicking within the editor, set the hovered tile to whatever is selected via palette
        private void pnlEditor_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Rectangle mousePoint = new Rectangle(e.X, e.Y, 1, 1);
                //iterate through map
                for (int i = 0; i < loadedMap.GetTilesLength(); i++)
                {
                    if (loadedMap.GetTile(i).GetRect().IntersectsWith(mousePoint))
                    {
                        loadedMap.SetTile(i, palette.GetSelected());
                    }
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                //fill entire map
                for (int i = 0; i < loadedMap.GetTilesLength(); i++)
                {
                    loadedMap.SetTile(i, palette.GetSelected());
                }
            }
        }

        // reset hover status of all tiles when mouse leaves editor
        private void pnlEditor_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i < loadedMap.GetTilesLength(); i++)
            {
                loadedMap.SetTileHovered(i, false);
            }
        }

        // same logic as editor
        private void pnlPalette_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Rectangle mousePoint = new Rectangle(e.X, e.Y, 1, 1);
			//iterate through palette
			for (int i = 0; i < palette.GetTilesLength(); i++)
			{
				if (palette.GetTile(i).GetRect().IntersectsWith(mousePoint))
				{
					palette.SetTileHovered(i, true);
				}
				else
				{
					palette.SetTileHovered(i, false);
				}
			}
		}

        private void pnlPalette_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                Rectangle mousePoint = new Rectangle(e.X, e.Y, 1, 1);
                //iterate through palette
                for (int i = 0; i < palette.GetTilesLength(); i++)
                {
                    if (palette.GetTile(i).GetRect().IntersectsWith(mousePoint))
                    {
                        palette.SetSelected(i);
                    }
                }

            }
        }

        private void pnlPalette_MouseLeave(object sender, EventArgs e)
        {
            for (int i = 0; i < palette.GetTilesLength(); i++)
            {
                palette.SetTileHovered(i, false);
            }
        }

        // save 'loadedMap' as dor file (just straight up bytes)
        private void menuSaveMap_Click(object sender, EventArgs e)
        {
            using(SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "dor Map Files (*.dor)|*.dor";
                sfd.FilterIndex = 1;
                sfd.RestoreDirectory = true;
                if(sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        byte[] fileMap = new byte[49];
                        for (int i = 0; i < loadedMap.GetTilesLength(); i++)
                        {
                            fileMap[i] = loadedMap.GetTile(i).GetTerrainAsByte();
                        }
                        File.WriteAllBytes(sfd.FileName, fileMap);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Could not save map file. " + ex.ToString(), "Error", MessageBoxButtons.OK);
                    }
                }
            }
        }

        // open map from saved dor file
        private void menuOpenMap_Click(object sender, EventArgs e)
        {
            using(OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "dor Map Files (*.dor)|*.dor";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;
                if(sender == btnExport)
                {
                    ofd.FileName = lbxMaps.SelectedItem.ToString() + ".dor";
                }
                if(ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    try
                    {
                        byte[] fileMap;
                        using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                        {
                            if (fs.Length != 49)
                            {
                                throw new Exception("File size is invalid.");
                            }
                            else
                            {
                                fileMap = new byte[fs.Length];

                                int bytesToRead = (int)fs.Length;
                                int bytesRead = 0;
                                while (bytesToRead > 0)
                                {
                                    int b = fs.Read(fileMap, bytesRead, bytesToRead);
                                    if (b == 0)
                                    {
                                        break;
                                    }

                                    bytesRead += b;
                                    bytesToRead -= b;
                                }
                                loadedMap = new Map(fileMap);
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Could not load map file. " + ex.Message + " Perhaps the map you provided is corrupt?", "Error", MessageBoxButtons.OK);
                    }
                }
            }
        }

        // load a map from the SLUS in memory given the selected index of lbxMaps
        private void btnLoad_Click(object sender, EventArgs e)
        {
            int mapOffset = 0x1D575C;
            mapOffset += lbxMaps.SelectedIndex * 0x31;
            byte[] slusMap = new byte[49];
            for(int i = 0; i < slusMap.Length; i++)
            {
                slusMap[i] = fileSlus[mapOffset + i];
            }
            loadedMap = new Map(slusMap);
            tabctrlMain.SelectedTab = tabEditor;
        }

        // export map from SLUS to dor file
        private void btnExport_Click(object sender, EventArgs e)
        {
            int mapOffset = 0x1D575C;
            mapOffset += lbxMaps.SelectedIndex * 0x31;
            byte[] slusMap = new byte[49];
            for (int i = 0; i < slusMap.Length; i++)
            {
                slusMap[i] = fileSlus[mapOffset + i];
            }
            loadedMap = new Map(slusMap);
            //dirty
            menuSaveMap_Click(sender, e);
            loadedMap = new Map();
        }

        // inject the map currently loaded as "loadedMap" into the SLUS based on selected index of lbxMaps
        private void btnInject_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("This will insert the map currently being edited into the specified slot. Would you like to continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if(result1 == DialogResult.Yes)
            {
                int mapOffset = 0x1D575C;
                mapOffset += lbxMaps.SelectedIndex * 0x31;
                for(int i = 0; i < loadedMap.GetTilesLength(); i++)
                {
                    fileSlus[mapOffset + i] = loadedMap.GetTile(i).GetTerrainAsByte();
                }

                DialogResult result2 = MessageBox.Show("The map was written to memory. Would you like to save the changes to the SLUS now?", "Success", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(result2 == DialogResult.Yes)
                {
                    SaveSlus(slusPath, fileSlus);
                }

            }

        }

        // save the SLUS file to disk from fileSlus
        private void menuSaveSlus_Click(object sender, EventArgs e)
        {
            SaveSlus(slusPath, fileSlus);
        }

        // reload SLUS from disk
        private void btnReload_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("You will lose all unsaved changes. Continue?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result1 == DialogResult.Yes)
            {
                fileSlus = OpenSlus(slusPath, fileSlus);
            }
        }

        // About DOTRMap
        private void menuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Constants.VERSION + " built " + Constants.BUILT + " by thots.\nSpecial thanks: GenericMadScientist", "About DOTRMap", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
