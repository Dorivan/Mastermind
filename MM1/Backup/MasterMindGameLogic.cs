//--------------------------------------------------------------------------
// Name Of File : MasterMindGameLogic                                       
// Classes      : Result, Master, Pegs, Board and Enum GameStatus           
// Last Change  : 13th May 2002                                             
// Written by   : Jigar Desai                                               
// email        : jigar@urvitech.com, desaijm@hotmail.com                   
//--------------------------------------------------------------------------
// this file encapsulates logic for game mastermind, you will need to       
// create GUI to make complite game.                                        
//--------------------------------------------------------------------------

using System;

namespace MasterMindWin
{
	/// <summary>
	/// Describes matches for particular row.
	/// </summary>
	public class Result
	{
		/// <summary>
		/// Empty = 0, ExactMatch = 1 , CrossMatch=2
		/// </summary>
		public byte[] Row = new byte[] {0,0,0,0}; 
	}
	/// <summary>
	/// Describes Master Row for game.
	/// </summary>
	public class Master
	{
		
		/// <summary>
		/// Array of byte which describes content of
		/// master.
		/// 0 = Empty.
		/// 1-8 = Different Color Pegs value comes from peg class.
		/// </summary>
		public byte[] Row = {0,0,0,0} ;

		/// <summary>
		/// Sets Random content to Master Row.
		/// </summary>
		/// <param name="p">Instance of pegs Class</param>
		public void SetMaster(Pegs p)
		{
			Random r = new Random();
			for (int i = 0; i < 4; i++)
			{
				Row[i] = (byte)(r.Next(p.Value.Length +1) + 1);
			}
		}
 
	}



	/// <summary>
	/// Describes Game Status 
	/// </summary>
	public enum GameStatus 
	{
		/// <summary>
		/// Active: Game Currently Active.
		/// </summary>
		Active = 1,
		/// <summary>
		/// Won: Game Won by Player.
		/// </summary>
		Won    = 2,
		/// <summary>
		/// Lost: Game is Lost by Player.
		/// </summary>
		Lost   = 3
	}


	/// <summary>
	/// Hold Data or number of pegs that are 
	/// available for user to insert in Row.
	/// </summary>
	public class Pegs
	{
		/// <summary>
		/// Creates new instance of class 
		/// </summary>
		/// <param name="Length">no of elements required</param>
		public Pegs(byte Length)
		{
			Value = new byte[Length-1];

			for (int i=0 ;i<Value.Length; i++)
			{
				Value[i] = (byte)(i + 1);
			}
		}
		/// <summary>
		/// Value of each element in Pegs.
		/// starts with 1.
		/// </summary>
		public byte[] Value;
	}



	/// <summary>
	/// This class EnCaps Logic of game.
	/// </summary>
	public class Board
	{
		
		/// <summary>
		/// Holds Data for Each row of Board.
		/// </summary>
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
		};

		/// <summary>
		/// Holds Data for result of each Row.
		/// </summary>
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
		};

		/// <summary>
		/// Consructor to create new instance of Board.
		/// </summary>
		/// <param name="b">No of color Pegs</param>
		public Board(byte b)
		{
			pegs = new Pegs(b);
			master.SetMaster(pegs);
		}

		/// <summary>
		/// Master Which Hides set pegs.
		/// </summary>
		public Master master = new Master();

		/// <summary>
		/// Color Pegs which are inserted in Rows
		/// </summary>
		public Pegs pegs;

		/// <summary>
		/// Peg Which user has selected to put in Row.
		/// required to be kept in memory to perform 
		/// draging operation.
		/// </summary>
		public byte SelectedPeg = 255;

		/// <summary>
		/// Game Status Set to active as default.
		/// </summary>
		public GameStatus Status = GameStatus.Active;

		/// <summary>
		/// Active Row No Where player will first drop pegs
		/// </summary>
		private byte _ActiveRowNo =0;

		/// <summary>
		/// Tests for Setting result.
		/// </summary>
		public void test()
		{
			
			//--------------------------------------------------------------
			// Perform only if Current row is filled complitely  by player  
			//--------------------------------------------------------------
			if (ActiveRowIsComplite)
			{
				Result r = CheckActiveRow();
				Results[_ActiveRowNo] = r.Row;

				// ---------------------------------------------------------
				// Continue Game is player has not reached to end of Rows,  
				// if he is in last row end the game.                       
				// ---------------------------------------------------------

				if (_ActiveRowNo<9)
				{	
					// increment if not won
					if (r.Row[0]!=1 || r.Row[1]!=1 || r.Row[2]!=1 || r.Row[3]!=1)
					{
						_ActiveRowNo += 1;
					}
				}
				else 
				{
					Status = GameStatus.Lost;
				}

				// ---------------------------------------------------------
				// Check if User has won game if yes then set Status to Won 
				// ---------------------------------------------------------
				if (r.Row[0]==1 && r.Row[1]==1 && r.Row[2]==1 && r.Row[3]==1  )
				{
					Status = GameStatus.Won;	
				}
			}
			
		}

		/// <summary>
		/// Gets Avtive Row no on whis player is playing.
		/// </summary>
		public byte ActiveRowNo
		{
			get{return _ActiveRowNo;}
		}


		/// <summary>
		/// Starts New game
		/// </summary>
		public void StartNew()
		{
			// sets Ramdom pegs in to Master.
			master.SetMaster(pegs);

			// Removes all values from Rows and result by setting 
			// values to 0;
			for(int i=0;i<10;i++)
			{
				for(int j=0;j<4;j++)
				{
					Rows[i][j] = 0;
					Results[i][j] = 0;
				}
			}
			// Set game status to Active.
			Status = GameStatus.Active;

			// make active row first.
			_ActiveRowNo = 0;
		}



		/// <summary>
		/// End Current game can be used to show hidden pegs 
		/// to player.
		/// </summary>
		public void EndGame()
		{
			Status = GameStatus.Lost;
		}



		/// <summary>
		/// Checks If player has filled Active row.
		/// </summary>
		public bool ActiveRowIsComplite
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

		
		
		/// <summary>
		/// Checks Result for active row
		/// </summary>
		/// <returns>Result object</returns>
		public Result CheckActiveRow()
		{
			//Create result object to return      
			Result r = new Result();

			// keeps data for full match          
			byte fullmatch = 0;

			// keeps data for Cross match         
			byte crossmatch = 0;

			//----------------------------------------------------------
			//------ Logic for Testing ---------------------------------
			//----------------------------------------------------------

			byte[] flagsMaster = new byte[]{0,0,0,0};
			byte[] flagsRow = new byte[]{0,0,0,0};
			//  full match testing  
			for (int i=0; i<4; i++)
			{
				if (master.Row[i] == Rows[_ActiveRowNo][i])
				{
					fullmatch++;
					flagsMaster[i] = 1;
					flagsRow[i] = 1;
				}
			}

			// cross match        
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
			// ----------testing logic ends ---------------------------
			
			// insert fullmatch in to result       
			for(int i=0;i<fullmatch;i++)
			{
				r.Row[i] = 1;
			}

			// insert crossmatch in to result      
			for(int i=fullmatch;i<fullmatch+crossmatch;i++)
			{
				r.Row[i] = 2;
			}

			// return result
			return r;
		}
	}
}
