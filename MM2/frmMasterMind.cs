using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Collections.Generic;

namespace MasterMindWin
{
	public class frmMasterMind : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components = null ;
        public static int mychois=10;

        private Bitmap OffScreenBitmap;
		private Graphics gOffScreen; 

		Color DarkColor = Color.Navy;
		Brush DarkBrush;
		Pen DarkPen;
		Pen BlackPen = new Pen(Color.Black);
		Font MyFont = new Font("Verdana",8,FontStyle.Bold);
		
		Image[] PegImages;
		Image PegHole;
		Image ResultPegHole;
		Image ResultBlackPeg;
		Image ResultWhitePeg;

		Color[] PelleteColors = new Color[] {Color.Red, Color.DarkBlue, Color.Brown, Color.Black, Color.Green, Color.Magenta, Color.Yellow, Color.SkyBlue};
		                 
		Point StartPoint = new Point(15,36);
		int border = 2;
		int boxWidth = 24;
        
		Rectangle[,] Boxes =  new Rectangle[mychois, 4];
        Rectangle[,] ResultBoxes = new Rectangle[mychois, 4];
        Rectangle[] ResultTrays = new Rectangle[mychois];
        Rectangle[] ColorPellete ;
		Rectangle[] MasterBoxes = new Rectangle[4]; 

		Rectangle ColorPelleteTray;
		Rectangle Ok;        
		Rectangle Rb;
		
		Point mPosition = new Point(0,0);
		bool PegPicking = false;
        static byte klr = 8;
       
		Board myBoard = new Board(klr); //с 8 фишками играем по умолчанию
                           
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem mnuGame;
		private System.Windows.Forms.MenuItem mnuNew;
		private System.Windows.Forms.MenuItem mnuShowPegs;
		private System.Windows.Forms.MenuItem mnuOptions;
		private System.Windows.Forms.MenuItem mnuOption6;
		private System.Windows.Forms.MenuItem mnuOption7;
		private System.Windows.Forms.StatusBar statusBar;
        private MenuItem menuItem1;
        private MenuItem menuItem2;
        private MenuItem str10;
        private MenuItem str9;
        private MenuItem str8;
        private MenuItem str7;
        private MenuItem str6;
        private MenuItem str5;
        private MenuItem str11;
        private MenuItem str12;
        private MenuItem str13;
        private MenuItem str14;
        private MenuItem str15;
        private MenuItem menuItem3;
        private System.Windows.Forms.MenuItem mnuOption8;

		public frmMasterMind()
		{
			InitializeComponent();
        }
		protected override void Dispose( bool disposing ) //закрытие программы
		{
			if( disposing )
			{
				if (components != null) 
					components.Dispose();
			}
			base.Dispose( disposing );
		}
		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mnuGame = new System.Windows.Forms.MenuItem();
            this.mnuNew = new System.Windows.Forms.MenuItem();
            this.mnuShowPegs = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.mnuOptions = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.str15 = new System.Windows.Forms.MenuItem();
            this.str14 = new System.Windows.Forms.MenuItem();
            this.str13 = new System.Windows.Forms.MenuItem();
            this.str12 = new System.Windows.Forms.MenuItem();
            this.str11 = new System.Windows.Forms.MenuItem();
            this.str10 = new System.Windows.Forms.MenuItem();
            this.str9 = new System.Windows.Forms.MenuItem();
            this.str8 = new System.Windows.Forms.MenuItem();
            this.str7 = new System.Windows.Forms.MenuItem();
            this.str6 = new System.Windows.Forms.MenuItem();
            this.str5 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
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
            this.mnuShowPegs,
            this.menuItem1});
            this.mnuGame.Text = "Игра";
            // 
            // mnuNew
            // 
            this.mnuNew.Index = 0;
            this.mnuNew.Text = "Новая";
            this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
            // 
            // mnuShowPegs
            // 
            this.mnuShowPegs.Index = 1;
            this.mnuShowPegs.Text = "Показать фишки";
            this.mnuShowPegs.Click += new System.EventHandler(this.mnuShowPegs_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.Text = "Помощь";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // mnuOptions
            // 
            this.mnuOptions.Index = 1;
            this.mnuOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2,
            this.menuItem3});
            this.mnuOptions.Text = "Опции";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.str15,
            this.str14,
            this.str13,
            this.str12,
            this.str11,
            this.str10,
            this.str9,
            this.str8,
            this.str7,
            this.str6,
            this.str5});
            this.menuItem2.Text = "Количество строк";
            // 
            // str15
            // 
            this.str15.Index = 0;
            this.str15.Text = "15";
            this.str15.Click += new System.EventHandler(this.str15_Click);
            // 
            // str14
            // 
            this.str14.Index = 1;
            this.str14.Text = "14";
            this.str14.Click += new System.EventHandler(this.str14_Click);
            // 
            // str13
            // 
            this.str13.Index = 2;
            this.str13.Text = "13";
            this.str13.Click += new System.EventHandler(this.str13_Click);
            // 
            // str12
            // 
            this.str12.Index = 3;
            this.str12.Text = "12";
            this.str12.Click += new System.EventHandler(this.str12_Click);
            // 
            // str11
            // 
            this.str11.Index = 4;
            this.str11.Text = "11";
            this.str11.Click += new System.EventHandler(this.str11_Click);
            // 
            // str10
            // 
            this.str10.Checked = true;
            this.str10.Index = 5;
            this.str10.Text = "10";
            this.str10.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // str9
            // 
            this.str9.Index = 6;
            this.str9.Text = "9";
            this.str9.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // str8
            // 
            this.str8.Index = 7;
            this.str8.Text = "8";
            this.str8.Click += new System.EventHandler(this.str8_Click);
            // 
            // str7
            // 
            this.str7.Index = 8;
            this.str7.Text = "7";
            this.str7.Click += new System.EventHandler(this.str7_Click);
            // 
            // str6
            // 
            this.str6.Index = 9;
            this.str6.Text = "6";
            this.str6.Click += new System.EventHandler(this.str6_Click);
            // 
            // str5
            // 
            this.str5.Index = 10;
            this.str5.Text = "5";
            this.str5.Click += new System.EventHandler(this.str5_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 1;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuOption6,
            this.mnuOption7,
            this.mnuOption8});
            this.menuItem3.Text = "Фишки";
            // 
            // mnuOption6
            // 
            this.mnuOption6.Index = 0;
            this.mnuOption6.Text = "6 фишек";
            this.mnuOption6.Click += new System.EventHandler(this.mnuOptions_Click);
            // 
            // mnuOption7
            // 
            this.mnuOption7.Index = 1;
            this.mnuOption7.Text = "7 фишек";
            this.mnuOption7.Click += new System.EventHandler(this.mnuOptions_Click);
            // 
            // mnuOption8
            // 
            this.mnuOption8.Index = 2;
            this.mnuOption8.Text = "8 фишек";
            this.mnuOption8.Click += new System.EventHandler(this.mnuOptions_Click);
            // 
            // statusBar
            // 
            this.statusBar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.statusBar.Location = new System.Drawing.Point(0, 652);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(238, 22);
            this.statusBar.TabIndex = 0;
            this.statusBar.Text = "Начнем с первой строки";
            // 
            // frmMasterMind
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.Violet;
            this.ClientSize = new System.Drawing.Size(238, 674);
            this.Controls.Add(this.statusBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Menu = this.mainMenu1;
            this.Name = "frmMasterMind";
            this.Text = "Мастер майнд";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

		}
		#endregion
        
		static void Main() 
		{
			Application.Run(new frmMasterMind());

		}

		protected override void OnPaint(PaintEventArgs e) //Приведение поля в нормальный вид и его прорисовка
		{
			Graphics g = e.Graphics;
			if (PegPicking == false)
				CreateOffScreenImage();

			g.DrawImage(this.OffScreenBitmap,0,0,new Rectangle(0,0,this.Width,this.Height),GraphicsUnit.Pixel);
			
			if (this.PegPicking == true)
			{
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias ;
				DrawingUtility.DrawPeg(ref g,new Rectangle(this.mPosition.X -7,this.mPosition.Y -7,this.boxWidth-6,this.boxWidth-6),this.PelleteColors[myBoard.SelectedPeg]);
				g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
			}
			
		
		}
		protected override void OnPaintBackground(PaintEventArgs e)
		{}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (PegPicking )
			{
				if (e.X > mPosition.X + 5 || e.X < mPosition.X -5 || e.Y > mPosition.Y +5|| e.Y <mPosition.Y -5)
				{  
					this.mPosition = new Point(e.X,e.Y);               
					this.Invalidate();
				}
			}
		}
		protected override void OnMouseUp(MouseEventArgs e)
		{
			PegPicking = false;
			if (myBoard.Status == GameStatus.Active)
			{
				for(int j=0; j<4;j++)
				{      
					if (DrawingUtility.isPointinRectangle(new Point(e.X,e.Y),Boxes[myBoard.ActiveRowNo,j])==true)
					{
                        myBoard.Rowss[myBoard.ActiveRowNo][j] = (byte)(myBoard.SelectedPeg + 1);
						break;
					}	
				}
			}
			if (DrawingUtility.isPointinRectangle(new Point(e.X,e.Y),Ok)==true)
				myBoard.test(mychois);

			if (myBoard.Status == GameStatus.Active)
			{
				if (myBoard.ActiveRowIsComplite)
					statusBar.Text = "Нажмите ОК чтоб подтвердить результат";			
				else
					statusBar.Text = "Заполнить строку";
			}

			else if (myBoard.Status == GameStatus.Won)
				    statusBar.Text = "Поздравляем!Вы угадали комбинацию!";	
            		
			else if (myBoard.Status == GameStatus.Lost)
				    statusBar.Text = "Ничего страшного, попробуй еще раз!";			
			Invalidate();
			
		}
        protected override void OnMouseDown(MouseEventArgs e)
		{
			for(int i=0;i<ColorPellete.Length-1;i++)
			{
				if (DrawingUtility.isPointinRectangle(new Point(e.X,e.Y),ColorPellete[i])==true)
				{	    
					myBoard.SelectedPeg = (byte)i;   
					this.PegPicking = true;
					break;
				}
			}
		}
        private void Form1_Load(object sender, System.EventArgs e)  //загрузка игрового поля
		{
            OffScreenBitmap = new Bitmap(this.Width,this.Height);
			gOffScreen = Graphics.FromImage(OffScreenBitmap);
			              
			DarkBrush =  new SolidBrush(DarkColor);
			DarkPen = new Pen(DarkColor);

            if (str5.Checked == true)
            {
                Rb = new Rectangle(StartPoint.X, StartPoint.Y - boxWidth - border, boxWidth * 5 + border * 2, 29 * mychois + 1);
                this.Size = new Size(254, 245);
            }
            else if (str6.Checked == true)
            {
                Rb = new Rectangle(StartPoint.X, StartPoint.Y - boxWidth - border, boxWidth * 5 + border * 2, 28 * mychois + 2);
                this.Size = new Size(254, 270);
            }
            else if (str7.Checked == true)
            {
                Rb = new Rectangle(StartPoint.X, StartPoint.Y - boxWidth - border, boxWidth * 5 + border * 2, 28 * mychois);//ограничение поля
                this.Size = new Size(254, 295);
            }
            else if (str8.Checked == true || str9.Checked == true)
            {
                Rb = new Rectangle(StartPoint.X, StartPoint.Y - boxWidth - border, boxWidth * 5 + border * 2, 27 * mychois + 2);
                this.Size=new Size(254, 347);
            }//ограничение поля             
            else if (str10.Checked == true)
            {
                Rb = new Rectangle(StartPoint.X, StartPoint.Y - boxWidth - border, boxWidth * 5 + border * 2, 27 * mychois - 2);
                this.Size= new Size(254, 370);
            }
            else if (str11.Checked == true)
            {
                Rb = new Rectangle(StartPoint.X, StartPoint.Y - boxWidth - border, boxWidth * 5 + border * 2, 26 * mychois + 4);
                this.Size = new Size(254, 393);
            }
            else if (str12.Checked ==true)
            {
                Rb = new Rectangle(StartPoint.X, StartPoint.Y - boxWidth - border, boxWidth * 5 + border * 2, 26 * mychois +2);
                this.Size = new Size(254, 415);
            }
            else if (str13.Checked==true)
            {
                Rb = new Rectangle(StartPoint.X, StartPoint.Y - boxWidth - border, boxWidth * 5 + border * 2, 26 * mychois);
                this.Size = new Size(254,   440);
            }
            else if (str14.Checked==true)
            {
                Rb = new Rectangle(StartPoint.X, StartPoint.Y - boxWidth - border, boxWidth * 5 + border * 2, 26 * mychois-2);
                this.Size = new Size(254, 465);
            }
            else if (str15.Checked==true)
            {
                Rb = new Rectangle(StartPoint.X, StartPoint.Y - boxWidth - border, boxWidth * 5 + border * 2, 26 * mychois - 4);
                this.Size = new Size(254, 490);
            }

            if (str8.Checked == true)
                this.Size = new Size(254, 320);

            for (int i=0;i< mychois; i++)
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

			ColorPelleteTray = new Rectangle(StartPoint.X + 6*boxWidth,StartPoint.Y ,boxWidth*2+ border*2,boxWidth*4+ border*2);//позиция цветных шариков
			ColorPellete = GetPelleteRectangles((byte)(myBoard.pegs.Values.Count),new Point(ColorPelleteTray.X ,ColorPelleteTray.Y));
			
		    PegImages = CreatePegImages((byte)(myBoard.pegs.Values.Count+1));
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
		private void mnuNew_Click(object sender, System.EventArgs e)//для создания новой игры
		{
			myBoard.StartNew(mychois);
			Invalidate();
		}
		private void mnuShowPegs_Click(object sender, System.EventArgs e)//для показа комбинации фишек и конец игры
		{
			myBoard.EndGame();
			Invalidate();
		}
		private Rectangle[] GetPelleteRectangles(byte b, Point p) //получение поля в котором будут
		{                                                       //фишки для выбора комбинации
			Rectangle[] r = new Rectangle[b];

			for (int i=1;i<b+1;i++)
			{
				if (decimal.Remainder(i,2) == 1)
				{
                    decimal myval = (i - 1) / 2;
					r[i-1] = new Rectangle(p.X + border ,(int)(p.Y + border + Math.Floor(myval) * boxWidth),boxWidth, boxWidth);//расположение фишек которые выбирает пользователь
				}
				else
                    r[i - 1] = new Rectangle(p.X + border + boxWidth, (int)(p.Y + border + ((i - 1) / 2) * boxWidth), boxWidth, boxWidth);//расположение фишек которые выбирает пользователь
            }
			return r;
		}		
		private void mnuOptions_Click(object sender, System.EventArgs e)    //меню программы
		{
			MenuItem mnuItem = (MenuItem)sender;
			
			if (mnuItem.Text == "6 фишек")
			{
                klr = 6;
				myBoard = new Board(klr);
				this.ColorPelleteTray.Height = this.boxWidth*3 + border*2;				
			}
			else if (mnuItem.Text == "7 фишек")
			{
                klr = 7;
                myBoard = new Board(klr);
				this.ColorPelleteTray.Height = this.boxWidth*4 + border*2;
			}
			else if (mnuItem.Text == "8 фишек")
			{
                klr = 8;
                myBoard = new Board(klr);
				this.ColorPelleteTray.Height = this.boxWidth*4 + border*2;
			}

			ColorPellete =  GetPelleteRectangles((byte)(myBoard.pegs.Values.Count),
                            new Point(ColorPelleteTray.X, ColorPelleteTray.Y));      
			    Invalidate();
		}		
		private Image[] CreatePegImages(byte pelleteSize)   //создание изображения фишек
		 {
			Image[] PegImages = new Image[pelleteSize-1];

			for(int i=0;i<pelleteSize-1;i++)
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
		private Image CreatePegHoleImage() //создание изображения для "дырочек"
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
		private Image CreateResultPegHole() //объединение методов для прорисовки "дырочки" 
        {                                   //и вывод конечного изображения
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
		private Image CreateResultPeg(Color c) //изображение получившейся комбинации
		{
			Image img;
			int RbWidth = this.ResultBoxes[0,0].Width;
			
			img = new Bitmap(RbWidth-2,RbWidth-2);
			Graphics g = Graphics.FromImage(img);

			g.Clear(this.BackColor);
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			
			if (c.B == 0) 			
				DrawingUtility.DrawPeg(ref g,new Rectangle(1,1,
                               RbWidth-4,RbWidth-4),Color.Black);//если угадали позицию и цвет
			else
				DrawingUtility.DrawPeg(ref g,new Rectangle(1,1,RbWidth-4,
                               RbWidth-4),Color.FromArgb(102,102,102));//если угадали лишь цвет
			g.Dispose();

			return img;			
		}
		private void CreateOffScreenImage()//формирвоание игрового поля
		{
            gOffScreen.Clear(this.BackColor);            
			gOffScreen.DrawRectangle(DarkPen,Rb);
			gOffScreen.DrawLine(DarkPen,StartPoint.X + 4*boxWidth + border,StartPoint.Y,
                                StartPoint.X + 4*boxWidth + border,StartPoint.Y+ mychois* boxWidth);

            if (mychois > 10)
            {
                for (int k = 10; k < mychois; k++)
                {
                    myBoard.Resultss.Add(new List<byte>() { 0, 0, 0, 0 });
                    myBoard.Rowss.Add(new List<byte>() { 0, 0, 0, 0 });
                }
            }

            for (int i=0;i< mychois; i++)//!!!
			{
				gOffScreen.DrawLine(DarkPen,Boxes[1,0].X,Boxes[i,0].Y ,Boxes[1,0].X + Boxes[1,0].Width*5,Boxes[i,0].Y );
            
                    for (int j = 0; j < 4; j++)
                    {
                        if (myBoard.ActiveRowNo != i && myBoard.Resultss[i][j] == 0)
                            gOffScreen.DrawImage(ResultPegHole, ResultBoxes[i, j].X, ResultBoxes[i, j].Y);
                                                
                        else if (myBoard.ActiveRowIsComplite == false || myBoard.Status != GameStatus.Active)
                            gOffScreen.DrawImage(ResultPegHole, ResultBoxes[i, j].X, ResultBoxes[i, j].Y);
                        
                        if (myBoard.Rowss[i][j] != 0)
                            gOffScreen.DrawImage(this.PegImages[myBoard.Rowss[i][j] - 1], 
                                                      Boxes[i, j].X + 3, Boxes[i, j].Y + 3);
                        else
                            gOffScreen.DrawImage(this.PegHole, Boxes[i, j].X + 3, Boxes[i, j].Y + 3);                       
                    }                
			}
			gOffScreen.DrawRectangle(DarkPen,ColorPelleteTray);
            if (this.PegImages.Length != ColorPellete.Length)
                PegImages = CreatePegImages((byte)(myBoard.pegs.Values.Count + 1));
            
			for (int i=0; i<ColorPellete.Length; i++)			
				gOffScreen.DrawImage(this.PegImages[i],ColorPellete[i].X +3,ColorPellete[i].Y +3);
			
			Rectangle rm = new Rectangle(MasterBoxes[0].X +2,MasterBoxes[0].Y +2,
                                         MasterBoxes[0].Width*4 -4,MasterBoxes[0].Height-4);
			if (myBoard.Status == GameStatus.Active)			
				gOffScreen.DrawString("Мастер майнд",this.MyFont,this.DarkBrush,MasterBoxes[0].X +5,MasterBoxes[0].Y+3);			
			else
			{
				for (int i=0; i<4; i++)				
					gOffScreen.DrawImage(this.PegImages[myBoard.master.Rows[i]-1],MasterBoxes[i].X +3,MasterBoxes[i].Y +3);
			}

			for(int i=0; i<=myBoard.ActiveRowNo;i++)
			{
				for(int j=0;j<4;j++)
				{
					Rectangle ResultCircle = new Rectangle(ResultBoxes[i,j].X +2,ResultBoxes[i,j].Y +2,
                                                           ResultBoxes[i,j].Width-4,ResultBoxes[i,j].Height-4); 
					if (myBoard.Resultss[i][j] !=0)
					{
						if (myBoard.Resultss[i][j] ==1)						
							gOffScreen.DrawImage(this.ResultBlackPeg ,ResultBoxes[i,j].X +1,ResultBoxes[i,j].Y +1);						
						else						
							gOffScreen.DrawImage(this.ResultWhitePeg ,ResultBoxes[i,j].X +1,ResultBoxes[i,j].Y +1);						
					}	
				}				
			}

			if (myBoard.Status == GameStatus.Active)
			{
				if (myBoard.ActiveRowIsComplite)
				{
					Ok.Y = StartPoint.Y + myBoard.ActiveRowNo*boxWidth ;
					DrawingUtility.DrawRaisedString(ref gOffScreen,"Ok",Ok,this.BackColor,MyFont);
				}
			}		
		}
        private void menuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Суть данноый игры: необходимо угадать комбинацию, загаданную компьютером. В этом вам поможет маленькое поле, состоящее из четырех точек возле строки. Если в этом поле вы увидели, как появился черный или серый цвет, то это уже половина успеха! Серый - означает, что вы угадали с местом, но не угадали с положением в комбинации. Черный - угадали место и комбинацию одного из шариков. Удачи!", "Помощь");
        }
        public Board tre (object sender, EventArgs e)   //обобщенный метод для кнопок, в котором
        {                                               //мы выполняем подготовку поля и редактируем его размерность
            Boxes = new Rectangle[mychois, 4];
            ResultBoxes = new Rectangle[mychois, 4];
            ResultTrays = new Rectangle[mychois];

            myBoard = new Board(mychois, klr);
            Form1_Load(sender, e);
            CreateOffScreenImage();
            Invalidate();

            return myBoard;
        }
        private void menuItem3_Click(object sender, EventArgs e) //кнопка для изменения размерности на : 10 строк 
        {
                str5.Checked = false;
                str6.Checked = false;
                str7.Checked = false;
                str8.Checked = false;
                str9.Checked = false;
                str10.Checked = true;
                str11.Checked = false;
                str12.Checked = false;
                str13.Checked = false;
                str14.Checked = false;
                str15.Checked = false;
                mychois = 10;
                tre(sender, e);
        }
        private void menuItem4_Click(object sender, EventArgs e)
        {
            str9.Checked = true;
            str5.Checked = false;
            str6.Checked = false;
            str7.Checked = false;
            str8.Checked = false;
            str10.Checked = false;
            str11.Checked = false;
            str12.Checked = false;
            str13.Checked = false;
            str14.Checked = false;
            str15.Checked = false;
            mychois = 9;
            tre(sender, e);
        }//кнопка для изменения размерности на : 9 строк 
        private void str8_Click(object sender, EventArgs e)
        {
            str5.Checked = false;
            str6.Checked = false;
            str7.Checked = false;
            str8.Checked = true;
            str9.Checked = false;
            str10.Checked = false;
            str11.Checked = false;
            str12.Checked = false;
            str13.Checked = false;
            str14.Checked = false;
            str15.Checked = false;
            mychois =8;
            tre(sender, e);
        }//кнопка для изменения размерности на : 8 строк 
        private void str7_Click(object sender, EventArgs e)
        {
            str5.Checked = false;
            str6.Checked = false;
            str7.Checked = true;
            str8.Checked = false;
            str9.Checked = false;
            str10.Checked = false;
            str11.Checked = false;
            str12.Checked = false;
            str13.Checked = false;
            str14.Checked = false;
            str15.Checked = false;
            mychois =7;
            tre(sender, e);
        }//кнопка для изменения размерности на : 7 строк 
        private void str6_Click(object sender, EventArgs e)
        {
            str5.Checked = false;
            str6.Checked = true;
            str7.Checked = false;
            str8.Checked = false;
            str9.Checked = false;
            str10.Checked = false;
            str11.Checked = false;
            str12.Checked = false;
            str13.Checked = false;
            str14.Checked = false;
            str15.Checked = false;
            mychois =6;
            tre(sender, e);
        }//кнопка для изменения размерности на : 6 строк 
        private void str5_Click(object sender, EventArgs e)
        {
            str5.Checked = true;
            str6.Checked = false;
            str7.Checked = false;
            str8.Checked = false;
            str9.Checked = false;
            str10.Checked = false;
            str11.Checked = false;
            str12.Checked = false;
            str13.Checked = false;
            str14.Checked = false;
            str15.Checked = false;
            mychois =5;
            tre(sender, e);
        }//кнопка для изменения размерности на : 5 строк 
        private void str15_Click(object sender, EventArgs e)
        {
            str5.Checked = false;
            str6.Checked = false;
            str7.Checked = false;
            str8.Checked = false;
            str9.Checked = false;
            str10.Checked = false;
            str11.Checked = false;
            str12.Checked = false;
            str13.Checked = false;
            str14.Checked = false;
            str15.Checked = true;
            mychois =15;
            tre(sender, e);
        }//кнопка для изменения размерности на : 15 строк 
        private void str14_Click(object sender, EventArgs e)
        {
            str5.Checked = false;
            str6.Checked = false;
            str7.Checked = false;
            str8.Checked = false;
            str9.Checked = false;
            str10.Checked = false;
            str11.Checked = false;
            str12.Checked = false;
            str13.Checked = false;
            str14.Checked = true;
            str15.Checked = false;
            mychois =14;
            tre(sender, e);
        }//кнопка для изменения размерности на : 14 строк 
        private void str13_Click(object sender, EventArgs e)
        {
            str5.Checked = false;
            str6.Checked = false;
            str7.Checked = false;
            str8.Checked = false;
            str9.Checked = false;
            str10.Checked = false;
            str11.Checked = false;
            str12.Checked = false;
            str13.Checked = true;
            str14.Checked = false;
            str15.Checked = false;
            mychois =13;
            tre(sender, e);
        }//кнопка для изменения размерности на : 13 строк 
        private void str12_Click(object sender, EventArgs e)
        {
            str5.Checked = false;
            str6.Checked = false;
            str7.Checked = false;
            str8.Checked = false;
            str9.Checked = false;
            str10.Checked = false;
            str11.Checked = false;
            str12.Checked = true;
            str13.Checked = false;
            str14.Checked = false;
            str15.Checked = false;
            mychois =12;
            tre(sender, e);
        }//кнопка для изменения размерности на : 12 строк 
        private void str11_Click(object sender, EventArgs e)
        {            
            str5.Checked = false;
            str6.Checked = false;
            str7.Checked = false;
            str8.Checked = false;
            str9.Checked = false;
            str10.Checked = false;
            str11.Checked = true;
            str12.Checked = false;
            str13.Checked = false;
            str14.Checked = false;
            str15.Checked = false;
            mychois =11;
            tre(sender, e);
        }//кнопка для изменения размерности на : 11 строк
    }
}
