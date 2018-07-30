//--------------------------------------------------------------------------
// Name Of File : frmMasterMind                                             
// Last Change  : 13th May 2002                                             
// Written by   : Jigar Desai                                               
// email        : jigar@urvitech.com, desaijm@hotmail.com                   
//--------------------------------------------------------------------------
// this file encapsulates userinterface for game mastermind,                
//--------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace MasterMindWin
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMasterMind : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components = null ;

		// OffScreen BitMap and Graphics            
		private Bitmap OffScreenBitmap;
		private Graphics gOffScreen; 
		//------------------------------------------
		
		// Colors Brushes and Pens for application  
		Color DarkColor = Color.Navy;
		Brush DarkBrush;
		Pen DarkPen;
		Pen BlackPen = new Pen(Color.Black);
		Font MyFont = new Font("Verdana",8,FontStyle.Bold);
		
		// Array of Images for Pegs
		Image[] PegImages;
		// Image for Peg Hole.
		Image PegHole;
		// Image For ResultPeg hole.
		Image ResultPegHole;
		//Image for Result Black Peg.
		Image ResultBlackPeg;
		// Image For Result White Peg.
		Image ResultWhitePeg;

		Color[] PelleteColors = new Color[] {Color.Red,Color.DarkBlue,
												Color.Brown,Color.Black,
												Color.Green,Color.Magenta,
												Color.Yellow,Color.SkyBlue };
		
		//------------------------------------------
		
		// Points and Rectangle                     
		Point StartPoint = new Point(15,36);
		int border = 2;
		int boxWidth = 24;

		// Defines position and size each element of board  
		Rectangle[,] Boxes =  new Rectangle[10,4];
		
		// defines Position and size of each result element
		Rectangle[,] ResultBoxes = new Rectangle[10,4];

		// defines position of each set of result for one row.
		Rectangle[] ResultTrays = new Rectangle[10];

		// defines Position and size of each Pegs available.
		Rectangle[] ColorPellete ;

		// defines position of Hidden master row            
		Rectangle[] MasterBoxes = new Rectangle[4]; 
		
		// Outer rectangle on ColorPellete or Pegs.   
		Rectangle ColorPelleteTray;

		// Position Of Ok button which player uses to validate row.
		Rectangle Ok;

		// outer rectangle for board.
		Rectangle Rb;
		
		// Mouse position while Draging.
		Point mPosition = new Point(0,0);

		//------------------------------------------
		
		// true if user is draging peg to board.
		bool PegPicking = false;
		


		// create new instance of board with 8 pegs.
		Board myBoard = new Board(8);


		//  Menus For Application                             
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem mnuGame;
		private System.Windows.Forms.MenuItem mnuNew;
		private System.Windows.Forms.MenuItem mnuShowPegs;
		private System.Windows.Forms.MenuItem mnuOptions;
		private System.Windows.Forms.MenuItem mnuOption6;
		private System.Windows.Forms.MenuItem mnuOption7;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.MenuItem mnuOption8;
		//----------------------------------------------------

		public frmMasterMind()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mnuGame = new System.Windows.Forms.MenuItem();
            this.mnuNew = new System.Windows.Forms.MenuItem();
            this.mnuShowPegs = new System.Windows.Forms.MenuItem();
            this.mnuOptions = new System.Windows.Forms.MenuItem();
            this.mnuOption6 = new System.Windows.Forms.MenuItem();
            this.mnuOption7 = new System.Windows.Forms.MenuItem();
            this.mnuOption8 = new System.Windows.Forms.MenuItem();
            this.statusBar = new System.Windows.Forms.StatusBar();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuGame,
            this.mnuOptions});
            // 
            // mnuGame
            // 
            this.mnuGame.Index = 0;
            this.mnuGame.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuNew,
            this.mnuShowPegs});
            this.mnuGame.Text = "Game";
            // 
            // mnuNew
            // 
            this.mnuNew.Index = 0;
            this.mnuNew.Text = "New";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // mnuShowPegs
            // 
            this.mnuShowPegs.Index = 1;
            this.mnuShowPegs.Text = "Show Pegs";
            this.mnuShowPegs.Click += new System.EventHandler(this.mnuShowPegs_Click);
            // 
            // mnuOptions
            // 
            this.mnuOptions.Index = 1;
            this.mnuOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuOption6,
            this.mnuOption7,
            this.mnuOption8});
            this.mnuOptions.Text = "Options";
            // 
            // mnuOption6
            // 
            this.mnuOption6.Index = 0;
            this.mnuOption6.Text = "6 Pegs";
            this.mnuOption6.Click += new System.EventHandler(this.mnuOptions_Click);
            // 
            // mnuOption7
            // 
            this.mnuOption7.Index = 1;
            this.mnuOption7.Text = "7 Pegs";
            this.mnuOption7.Click += new System.EventHandler(this.mnuOptions_Click);
            // 
            // mnuOption8
            // 
            this.mnuOption8.Index = 2;
            this.mnuOption8.Text = "8 Pegs";
            this.mnuOption8.Click += new System.EventHandler(this.mnuOptions_Click);
            // 
            // statusBar
            // 
            this.statusBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.statusBar.Location = new System.Drawing.Point(0, 290);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(234, 25);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "Start with first row.";
            // 
            // frmMasterMind
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(234, 315);
            this.Controls.Add(this.statusBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.Name = "frmMasterMind";
            this.Text = "MasterMind";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		static void Main() 
		{
			Application.Run(new frmMasterMind());
		}

		protected override void OnPaint(PaintEventArgs e) 
		{
			// ------------------------------------------------
			// Get Graphics Object from EventArgs              
			// ------------------------------------------------
			Graphics g = e.Graphics;

			// ------------------------------------------------
			// if User is Draging peg no need to reDraw Image  
			// ------------------------------------------------
			if (PegPicking == false)
			{
				CreateOffScreenImage();
			}
			
			// ------------------------------------------------
			// Draw OffScreen Image to Screen                  
			// ------------------------------------------------
			g.DrawImage(this.OffScreenBitmap,0,0,new Rectangle(0,0,this.Width,this.Height),GraphicsUnit.Pixel);
			
			// ------------------------------------------------
			// If Player is Currently Draging Peg Draw Peg at  
			// tip of Mouse to Show Effect of Draging          
			// ------------------------------------------------
			if (this.PegPicking == true)
			{
				
				// I am using Direct drawing instead of using Imageof peg    
				// because I can not find suitable method to make background 
				// of Image transperent                                      
				
				// set AntiAlias on   
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias ;
				DrawingUtility.DrawPeg(ref g,new Rectangle(this.mPosition.X -7,this.mPosition.Y -7,this.boxWidth-6,this.boxWidth-6),this.PelleteColors[myBoard.SelectedPeg]);
				// Set AntiAlias off  
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
			}
			
		
		}
		protected override void OnPaintBackground(PaintEventArgs e)
		{
			// Empty To avoid Flickring due do background Drawing.
		}

		
		
		protected override void OnMouseMove(MouseEventArgs e)
		{
			
			//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			// this Code will handle Visual effect of Draging peg  
			// from pellete from Tray to Board                     
			//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			
			// ----------------------------------------------------
			// Do only if Mouse was down on one of the Color Pegs  
			// and is Still down (So draging ).                    
			// ----------------------------------------------------
			if (PegPicking )
			{
				// -------------------------------------------------
				// Make sure that Screen is not refreshing on every 
				// mouse movement we are doing showing only when    
				// mouse has move substantialy ( 5 pix in this case)
				// -------------------------------------------------
				if (e.X > mPosition.X + 5 || e.X < mPosition.X -5 || e.Y > mPosition.Y +5|| e.Y <mPosition.Y -5)
				{
					// change Position to current mouse Position   
					this.mPosition = new Point(e.X,e.Y);
					// Repaint to Show Effect                      
					this.Invalidate();
				}
			}
		}
		

		protected override void OnMouseUp(MouseEventArgs e)
		{
			// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			// this code will handle droping peg on board  if Player was   
			// draging peg from tray and Click on Ok While current Row is  
            // filled                                                      
			// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			
			
			// ------------------------------------------------------------
			// Stop Draging if its on                                      
			// ------------------------------------------------------------
			PegPicking = false;
			
			// ------------------------------------------------------------
			//  Inserting Pegs but only is Game is Active                  
			// ------------------------------------------------------------
			if (myBoard.Status == GameStatus.Active)
			{
				for(int j=0; j<4;j++)
				{
					// Allow insert only in Active Row.       
					if (DrawingUtility.isPointinRectangle(new Point(e.X,e.Y),Boxes[myBoard.ActiveRowNo,j])==true)
					{	
						myBoard.Rows[myBoard.ActiveRowNo][j] = (byte)(myBoard.SelectedPeg + 1);
						break;
					}	
				}
			}

			// ------------------------------------------------------------
			// Check For Ok button Click                                   
			// ------------------------------------------------------------
			if (DrawingUtility.isPointinRectangle(new Point(e.X,e.Y),Ok)==true)
			{	
				myBoard.test();
			}
			

			
			// ---------------------------------------------------------
			// Insert messages in to status bar as required             
			// ---------------------------------------------------------
			if (myBoard.Status == GameStatus.Active)
			{
				if (myBoard.ActiveRowIsComplite)
				{
					statusBar.Text = "Press Ok to validate result";
				}
				else
				{
					statusBar.Text = "Fill active row";
				}
			}
			else if (myBoard.Status == GameStatus.Won)
			{
				statusBar.Text = "You Won, play new!";
			}
			else if (myBoard.Status == GameStatus.Lost)
			{
				statusBar.Text = "You lost, play new!";
			}
			
			// ---------------------------------------------------
			// Repaint Screen to show changes in game             
			// ---------------------------------------------------
			Invalidate();
			
		}


		protected override void OnMouseDown(MouseEventArgs e)
		{
			// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			// This Code will give a start for Draging Peg from Tray  
			// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
			
			
			// -------------------------------------------------------
			// loop through all Pegs to find Where Mouse was down     
			// -------------------------------------------------------
			for(int i=0;i<ColorPellete.Length;i++)
			{
				if (DrawingUtility.isPointinRectangle(new Point(e.X,e.Y),ColorPellete[i])==true)
				{	
					// Make that peg selected peg       
					myBoard.SelectedPeg = (byte)i;
					// make flag PegPicking true        
					this.PegPicking = true;
					break;
				}
			}
		}



		private void Form1_Load(object sender, System.EventArgs e)
		{

			//   Create Offscreen Bitmap with width and height  
			//   equal to that of Form                          
			OffScreenBitmap = new Bitmap(this.Width,this.Height);
			gOffScreen = Graphics.FromImage(OffScreenBitmap);
			
			//  Create Brushes                                  
			DarkBrush =  new SolidBrush(DarkColor);
			DarkPen = new Pen(DarkColor);
			
			// this rectangle is for outerborder of game Board  
			Rb = new Rectangle(StartPoint.X,StartPoint.Y -boxWidth - border,boxWidth*5 + border*2,boxWidth*11 + border*2);
			
			// loop to create Rectangles for mastermind Board   
			// and Result boxes                                 
			for(int i=0;i<10;i++)
			{
				ResultTrays[i]  = new Rectangle(StartPoint.X + border + 4*boxWidth+1,StartPoint.Y + i*boxWidth +1,boxWidth-2,boxWidth-2);
				for(int j=0; j<4;j++)
				{
					Boxes[i,j] = new Rectangle(StartPoint.X + border + j*boxWidth,StartPoint.Y + i*boxWidth ,boxWidth,boxWidth);
				}
				ResultBoxes[i,0] = new Rectangle(StartPoint.X + border + 4*boxWidth +1,StartPoint.Y + i*boxWidth +1,boxWidth/2,boxWidth/2);
				ResultBoxes[i,1] = new Rectangle(StartPoint.X + border + 4*boxWidth -1+ boxWidth/2 ,StartPoint.Y + i*boxWidth +1,boxWidth/2,boxWidth/2);
				ResultBoxes[i,2] = new Rectangle(StartPoint.X + border + 4*boxWidth +1,StartPoint.Y + i*boxWidth + boxWidth/2-1,boxWidth/2,boxWidth/2);
				ResultBoxes[i,3] = new Rectangle(StartPoint.X + border + 4*boxWidth -1+ boxWidth/2,StartPoint.Y + i*boxWidth + boxWidth/2 -1,boxWidth/2,boxWidth/2);
			}

			ColorPelleteTray = new Rectangle(StartPoint.X + 6*boxWidth,StartPoint.Y ,boxWidth*2+ border*2,boxWidth*4+ border*2);
			ColorPellete = GetPelleteRectangles((byte)(myBoard.pegs.Value.Length+1),new Point(ColorPelleteTray.X ,ColorPelleteTray.Y));
			
			
			// We will create Seperate Images for all objects used in game 
			// this will speeden up drawing Process at run time            
			PegImages = CreatePegImages((byte)(myBoard.pegs.Value.Length +1));
			PegHole = this.CreatePegHoleImage();
			ResultPegHole = this.CreateResultPegHole();
			ResultBlackPeg = this.CreateResultPeg(Color.Black);
			ResultWhitePeg = this.CreateResultPeg(Color.White);


			for(int i=0;i<4;i++)
			{
				MasterBoxes[i] = new Rectangle(StartPoint.X + border + i*boxWidth,StartPoint.Y - boxWidth ,boxWidth,boxWidth);
			}
			Ok = new Rectangle(StartPoint.X + border + 4*boxWidth,StartPoint.Y + myBoard.ActiveRowNo*boxWidth ,boxWidth,boxWidth);
			
		}


		// ------------------------------------------------------------
		// Starts New Game if User has won or Lost Current Game        
		// ------------------------------------------------------------
		private void mnuNew_Click(object sender, System.EventArgs e)
		{
			// ----------------------------------------------------- 
			// Starts New Game                                       
			// ------------------------------------------------------
			myBoard.StartNew();


			// ------------------------------------------------------
			// repaints Screen to show effect                        
			// ------------------------------------------------------
			Invalidate();
		}

		
		// --------------------------------------------------------------
		// Open Master with out Complition of game                       
		// Player Will end Game                                          
		// --------------------------------------------------------------
		private void mnuShowPegs_Click(object sender, System.EventArgs e)
		{
			// ends Current game
			myBoard.EndGame();
			// repaints Screen to show effect
			Invalidate();
		}
		


		private Rectangle[] GetPelleteRectangles(byte b, Point p)
		{
			Rectangle[] r = new Rectangle[b];
			for (int i=1;i<b+1;i++)
			{
				if (decimal.Remainder(i,2) == 1)
				{
                    decimal myval = (i - 1) / 2;
					r[i-1] = new Rectangle(p.X + border ,(int)(p.Y + border + Math.Floor(myval) * boxWidth),boxWidth, boxWidth);
				}
				else
				{
                    r[i - 1] = new Rectangle(p.X + border + boxWidth, (int)(p.Y + border + ((i - 1) / 2) * boxWidth), boxWidth, boxWidth);
				}

			}
			return r;
		}
		
		
		private void mnuOptions_Click(object sender, System.EventArgs e)
		{
			// Get Context of MenuItem which was Clicked
			MenuItem mnuItem = (MenuItem)sender;
			
			if (mnuItem.Text == "6 Pegs")
			{
				myBoard = new Board(6);
				this.ColorPelleteTray.Height = this.boxWidth*3 + border*2;
				
			}
			else if (mnuItem.Text == "7 Pegs")
			{
				myBoard = new Board(7);
				this.ColorPelleteTray.Height = this.boxWidth*4 + border*2;
			}
			else if (mnuItem.Text == "8 Pegs")
			{
				myBoard = new Board(8);
				this.ColorPelleteTray.Height = this.boxWidth*4 + border*2;
			}

			// new Position of ColorPegs as per nos of Colors
			ColorPellete = GetPelleteRectangles(
				(byte)(myBoard.pegs.Value.Length+1),
				new Point(ColorPelleteTray.X,
				ColorPelleteTray.Y));
			// repaint to show new Option                    
			Invalidate();
		}		
		
		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		// Creates Array of Images for all pegs                 
		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Image[] CreatePegImages(byte pelleteSize)
		{
			Image[] PegImages = new Image[pelleteSize +1];

			for(int i=0;i<pelleteSize;i++)
			{
				PegImages[i] = new Bitmap(this.boxWidth-5,this.boxWidth-5);
				Graphics g = Graphics.FromImage(PegImages[i]);
				g.Clear(this.BackColor);
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
				DrawingUtility.DrawPeg(ref g,new Rectangle(0,0,boxWidth-6,boxWidth-6),PelleteColors[i]);
				g.Dispose();
			}
			return PegImages;

		
		}

		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		// Creates Image for Peg hole for                       
		//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Image CreatePegHoleImage()
		{
			Image img;
			img = new Bitmap(this.boxWidth-6,this.boxWidth-6);
			Graphics g = Graphics.FromImage(img);
			g.Clear(this.BackColor);
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			g.FillEllipse(new SolidBrush(Color.Gray),new Rectangle(4,4,boxWidth-14,boxWidth-14));
			DrawingUtility.DrawInsetCircle(ref g,new Rectangle(4,4,boxWidth-14,boxWidth-14),new Pen(this.BackColor));
			return img;
		}
		// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		// Creates Image for Result Hole            
		// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Image CreateResultPegHole()
		{
			Image img;
			int RbWidth = this.ResultBoxes[0,0].Width;
			
			img = new Bitmap(RbWidth,RbWidth);
			Graphics g = Graphics.FromImage(img);
			g.Clear(this.BackColor);
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			g.FillEllipse(new SolidBrush(Color.Gray),new Rectangle(3,3,RbWidth-6,RbWidth-6));
			DrawingUtility.DrawInsetCircle(ref g,new Rectangle(3,3,RbWidth-6,RbWidth-6),new Pen(this.BackColor));
			
			
			return img;

		}

		// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		// Creates Result Peg White and Black        
		// ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
		private Image CreateResultPeg(Color c)
		{
			Image img;
			int RbWidth = this.ResultBoxes[0,0].Width;
			
			img = new Bitmap(RbWidth-2,RbWidth-2);
			Graphics g = Graphics.FromImage(img);

			g.Clear(this.BackColor);
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			
			if (c.B == 0) 
			{
				DrawingUtility.DrawPeg(ref g,new Rectangle(1,1,RbWidth-4,RbWidth-4),Color.Black);
			}
			else
			{
				DrawingUtility.DrawPeg(ref g,new Rectangle(1,1,RbWidth-4,RbWidth-4),Color.FromArgb(102,102,102));
			}
			g.Dispose();

			return img;
			
		}
		private void CreateOffScreenImage()
		{
			gOffScreen.Clear(this.BackColor);
			// Outer rectangle of game Board                
			gOffScreen.DrawRectangle(DarkPen,Rb);
			// Vertical line dividing Rows and Result Space 
			gOffScreen.DrawLine(DarkPen,StartPoint.X + 4*boxWidth + border,StartPoint.Y,StartPoint.X + 4*boxWidth + border,StartPoint.Y+ 10*boxWidth);
	
			for(int i=0;i<10;i++)
			{
				// Draw Horizontal lines through rows     
				gOffScreen.DrawLine(DarkPen,Boxes[1,0].X,Boxes[i,0].Y ,Boxes[1,0].X + Boxes[1,0].Width*5,Boxes[i,0].Y );

				for(int j=0; j<4;j++)
				{
					
					//  -------------------------------------   
					// Draw Result Peg Holes                    
					//  -------------------------------------   
					if (myBoard.ActiveRowNo != i && myBoard.Results[i][j] == 0)
					{
						gOffScreen.DrawImage(ResultPegHole,ResultBoxes[i,j].X ,ResultBoxes[i,j].Y);
					}
					else if (myBoard.ActiveRowIsComplite == false || myBoard.Status != GameStatus.Active )
					{
						gOffScreen.DrawImage(ResultPegHole,ResultBoxes[i,j].X ,ResultBoxes[i,j].Y);
					}
					
					//  -------------------------------------  
					// Draw Pegs if Filled or show Peg Hole    
					//  -------------------------------------  
					if(myBoard.Rows[i][j] != 0)
					{
						gOffScreen.DrawImage(this.PegImages[myBoard.Rows[i][j]-1],Boxes[i,j].X +3,Boxes[i,j].Y +3);
					}
					else
					{
						gOffScreen.DrawImage(this.PegHole,Boxes[i,j].X +3,Boxes[i,j].Y +3);
					}
				}
			}


			//  --------------------------------------------------------
			// pegs drawing on Peg Tray                                 
			//  --------------------------------------------------------
			gOffScreen.DrawRectangle(DarkPen,ColorPelleteTray);
			for (int i=0; i<ColorPellete.Length; i++)
			{
				gOffScreen.DrawImage(this.PegImages[i],ColorPellete[i].X +3,ColorPellete[i].Y +3);
			}
			//  ------------------------------------------------------- 
			//  draw master Which is Hiding Colors                      
			//  --------------------------------------------------------
			Rectangle rm = new Rectangle(MasterBoxes[0].X +2,MasterBoxes[0].Y +2,MasterBoxes[0].Width*4 -4,MasterBoxes[0].Height-4);
			if (myBoard.Status == GameStatus.Active)
			{
				gOffScreen.DrawString("MasterMind",this.MyFont,this.DarkBrush,MasterBoxes[0].X +5,MasterBoxes[0].Y+3);
			}
			else
			{
				for (int i=0; i<4; i++)
				{
					gOffScreen.DrawImage(this.PegImages[myBoard.master.Row[i]-1],MasterBoxes[i].X +3,MasterBoxes[i].Y +3);
				}
			}
			//  ------------------------------------------------------- 
			//  draw results  with White and Black Pegs                 
			//  ------------------------------------------------------- 
			for(int i=0; i<=myBoard.ActiveRowNo;i++)
			{
				for(int j=0;j<4;j++)
				{
					Rectangle ResultCircle = new Rectangle(ResultBoxes[i,j].X +2,ResultBoxes[i,j].Y +2,ResultBoxes[i,j].Width-4,ResultBoxes[i,j].Height-4); 
					if (myBoard.Results[i][j] !=0)
					{
						if (myBoard.Results[i][j] ==1)
						{
							gOffScreen.DrawImage(this.ResultBlackPeg ,ResultBoxes[i,j].X +1,ResultBoxes[i,j].Y +1);
						}
						else
						{
							gOffScreen.DrawImage(this.ResultWhitePeg ,ResultBoxes[i,j].X +1,ResultBoxes[i,j].Y +1);
						}
					}	
				}
				
			}
			
			//  ------------------------------------------------------- 
			// Drawing Of Ok Button                                     
			//  ------------------------------------------------------- 
			if (myBoard.Status == GameStatus.Active)
			{
				if (myBoard.ActiveRowIsComplite)
				{
					Ok.Y = StartPoint.Y + myBoard.ActiveRowNo*boxWidth ;
					DrawingUtility.DrawRaisedString(ref gOffScreen,"Ok",Ok,this.BackColor,MyFont);
				}
			}
		
		}
		
	}
}
