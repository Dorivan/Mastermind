using System;

namespace MasterMindWin
{
	public class Result 
	{
		public byte[] Row = new byte[] {0,0,0,0}; //��� ������� ������������� ������
	}
	public class Master
	{
        public byte[] Row = {0,0,0,0} ;
		public void SetMaster(Pegs p)//��������� ����������, ������� ������ ������� ������������
		{
			Random r = new Random();
			for (int i = 0; i < 4; i++)
			{
				Row[i] = (byte)(r.Next(p.Value.Length +1) + 1);
			}
		}
 
	}
	public enum GameStatus 
	{
		Active = 1,
		Won    = 2,
		Lost   = 3
	}

    
	public class Pegs
	{
		public Pegs(byte Length)
		{
			Value = new byte[Length-1];

			for (int i=0 ;i<Value.Length; i++)
			{
				Value[i] = (byte)(i + 1);
			}
		}
		public byte[] Value;
	}
	public class Board
	{
		
		public byte[][] Rows = {
								   new byte[] {0,0,0,0},
								   new byte[] {0,0,0,0},
								   new byte[] {0,0,0,0},
								   new byte[] {0,0,0,0},
								   new byte[] {0,0,0,0},
								   new byte[] {0,0,0,0},
								   new byte[] {0,0,0,0},
								   new byte[] {0,0,0,0},
								   new byte[] {0,0,0,0},
								   new byte[] {0,0,0,0},
		};//��������� ������� �����, ��� ����� ��������� ����
        
		public byte[][] Results = {
									  new byte[] {0,0,0,0},
									  new byte[] {0,0,0,0},
									  new byte[] {0,0,0,0},
									  new byte[] {0,0,0,0},
									  new byte[] {0,0,0,0},
									  new byte[] {0,0,0,0},
									  new byte[] {0,0,0,0},
									  new byte[] {0,0,0,0},
									  new byte[] {0,0,0,0},
									  new byte[] {0,0,0,0},
		};//��������� �����, ���� ����� ������������ ��������� ����� ����
        
		public Board(byte b) //�������� ���������� �����, � �������� ����� ������ ������������
		{                    //� ������� ���� � ����
			pegs = new Pegs(b);
			master.SetMaster(pegs);
		}
        
		public Master master = new Master();        
		public Pegs pegs;        
		public byte SelectedPeg = 255;        
		public GameStatus Status = GameStatus.Active;        
		private byte _ActiveRowNo =0;        
		public void test()
		{
			if (ActiveRowIsComplite)
			{
				Result r = CheckActiveRow();
				Results[_ActiveRowNo] = r.Row;

		
				if (_ActiveRowNo<9)
				{	
					if (r.Row[0]!=1 || r.Row[1]!=1 || r.Row[2]!=1 || r.Row[3]!=1)
					{
						_ActiveRowNo += 1;
					}
				}
				else 
				{
					Status = GameStatus.Lost;
				}
               //���������, ���� ������������ �������, �� ������ ����������
				if (r.Row[0]==1 && r.Row[1]==1 && r.Row[2]==1 && r.Row[3]==1  )
				{
					Status = GameStatus.Won;	
				}
			}
			
		}

		public byte ActiveRowNo
		{
			get{return _ActiveRowNo;}
		}
		public void StartNew()//����������� ��� ����������� ������ ���
        {                       //������ ����� ����
			master.SetMaster(pegs); //����� ���������� �����
            
			for(int i=0;i<10;i++)       //��������� �������� ����
			{
				for(int j=0;j<4;j++)
				{
					Rows[i][j] = 0;
					Results[i][j] = 0;
				}
			}
			Status = GameStatus.Active; //����� ������� ����
			_ActiveRowNo = 0;
		}
		public void EndGame()   //��������� ����
		{
			Status = GameStatus.Lost;
		}
		public bool ActiveRowIsComplite //�������� �� ����������� ������
		{
			get
			{
				bool flag = true;
				for (int i=0;i<4;i++)
				{
					if(Rows[_ActiveRowNo][i] == 0)
					{
						flag =false;
					}
				}
				return flag;
			}
		}
		public Result CheckActiveRow()  //�������� ���������� ���������� �� ������������
		{
			Result r = new Result();    
			byte fullmatch = 0;         //���������� ��� ������������� "������� ���������" 
			byte crossmatch = 0;        //��������� ��� ������������� ��������� �� �����

			byte[] flagsMaster = new byte[]{0,0,0,0};
			byte[] flagsRow = new byte[]{0,0,0,0};
			for (int i=0; i<4; i++)
			{
				if (master.Row[i] == Rows[_ActiveRowNo][i])
				{
					fullmatch++;
					flagsMaster[i] = 1;
					flagsRow[i] = 1;
				}
			}
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if ((i != j) && (flagsMaster[i] != 1) && (flagsRow[j] != 1))
					{
						if (master.Row[i] == Rows[_ActiveRowNo][j])
						{
							crossmatch++;
							flagsMaster[i] = 1;
							flagsRow[j] = 1;
							break;
						}
					}
				}
			}  
			for(int i=0;i<fullmatch;i++)
			{
				r.Row[i] = 1;
			}   
			for(int i=fullmatch;i<fullmatch+crossmatch;i++)
			{
				r.Row[i] = 2;
			}
			return r;
		}
	}
}
