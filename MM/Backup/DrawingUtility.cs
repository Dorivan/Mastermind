using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MasterMindWin
{
	/// <summary>
	/// Utility Class That help Drawing.
	/// </summary>
	public class DrawingUtility
	{
		
		public static void DrawPeg(ref Graphics g,Rectangle r, Color c)
		{
			GraphicsPath path = new GraphicsPath();
			path.AddEllipse(r);

			// Create a path gradient brush based on the elliptical path.
			PathGradientBrush pthGrBrush = new PathGradientBrush(path);
			pthGrBrush.SurroundColors = new Color[] {c};
			// Set the center color to White.
			pthGrBrush.CenterColor = Color.White;
			pthGrBrush.CenterPoint = new Point(r.X + r.Width/3,r.Y + r.Height/3);
			
			// Use the path gradient brush to fill the ellipse. 
			g.FillPath(pthGrBrush, path);
			g.DrawEllipse(new Pen(c),r);
		}
		public static void DrawRaisedString(ref Graphics g,string s,Rectangle r,Color c, Font f)
		{
			Color c1 = getDarkColor(c,50);
			Color c2 = getLightColor(c,50);
			StringFormat sf = new StringFormat();
			sf.Alignment = StringAlignment.Center ;
			sf.LineAlignment = StringAlignment.Center ;
			g.DrawString(s,f,new SolidBrush(c2),r,sf);
			g.DrawString(s,f,new SolidBrush(c1),new Rectangle(r.X+1,r.Y+1,r.Width,r.Height),sf);
		}

		public static void DrawInsetCircle(ref Graphics g,Rectangle r,Pen p)
		{
			Pen p1 = new Pen(getDarkColor(p.Color,50));
			Pen p2 = new Pen(getLightColor(p.Color,50));
			for(int i=0;i<p.Width;i++)
			{
				Rectangle r1 = new Rectangle(r.X +i,r.Y +i,r.Width-i*2,r.Height-i*2);
				g.DrawArc(p2,r1,-45,180);
				g.DrawArc(p1,r1,135,180);
			}
		}

		public static Color getDarkColor(Color c,byte d)
		{
			byte r = 0 ;
			byte g = 0;
			byte b = 0 ;

			if (c.R > d) r = (byte)(c.R - d);
			if (c.G > d) g = (byte)(c.G - d);
			if (c.B > d) b = (byte)(c.B - d);

			Color c1 = Color.FromArgb(r,g,b);
			return c1;
		}
		public static Color getLightColor(Color c,byte d)
		{
			byte r = 255 ;
			byte g = 255 ;
			byte b = 255 ;

			if (c.R + d < 255) r = (byte)(c.R + d);
			if (c.G + d < 255) g = (byte)(c.G + d);
			if (c.B + d < 255) b = (byte)(c.B + d);

			Color c2 = Color.FromArgb(r,g,b);
			return c2;
		}
			
		
		/// <summary>
		/// Method which checks is particular point is in rectangle
		/// </summary>
		/// <param name="p">Point to be Chaecked</param>
		/// <param name="r">Rectangle</param>
		/// <returns>true is Point is in rectangle, else false</returns>
		public static bool isPointinRectangle(Point p ,Rectangle r)
		{
			bool flag = false;
			if (p.X > r.X && p.X < r.X + r.Width && p.Y > r.Y && p.Y < r.Y + r.Height)
			{
				flag = true;
			}
			return flag;

		}
	}
}
