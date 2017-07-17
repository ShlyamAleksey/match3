using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Lizzard.Common;

namespace Lizzard.str.model
{
    public class ChooseData
    {
        public SimplePoint position;
        public bool choose;
    }

    public class BoardModel : EventDispatcher
    {
        public int TOTAL_ITEMS = 5;

        static public int width = 6;
        static public int height = 8;

		public List<PieceModel> destroyList = new List<PieceModel>();

        public PieceModel[,] boardData = new PieceModel[width, height];

		public SimplePoint chooseFirst;
		public SimplePoint chooseSecond;

        public bool successSwaping = false;

        public BoardModel()
        {
        }

        virtual public void init()
        {
            createBoard();
            //console();

            dispatchEvent(new Event(GameEvent.UPDATE_BOARD));
        }

        //Создаем поле
        virtual public void createBoard()
		{
			destroyList = new List<PieceModel>();
            boardData = new PieceModel[width, height];
            Random rnd = new Random();
            PieceModel piece;

			for (int i = 0; i < width; i++) 
			{
				for (int j = 0; j < height; j++) 
				{
					piece = new PieceModel();
                    piece.position = new SimplePoint(i, j);
                    piece.assets = new ItemView();
					piece.type = rnd.Next(0, TOTAL_ITEMS);
                    boardData[i, j] = piece;
                }
            }

            lookForMatches(true);
			if ( destroyList.Count != 0 )
			{
                createBoard();
				return;
			}

            chooseFirst = null; chooseSecond = null;
            //console();
            successSwaping = false;
            dispatchEvent(new Event(GameEvent.CREATE_BOARD));
		}

        //Возвращаем массив всех найденных линий 
        public void lookForMatches(bool onCreate = false)
		{
            List<PieceModel> match;
            // Поиск горизонтальных линий    
            for (int row = 0; row < height; row++)
			{     
				for(int col = 0; col < width - 1; col++)
				{
                    match = getMatchHoriz(col, row);
					
					if (match.Count > 2)
					{
						for (int i = 0; i < match.Count; i++) destroyList.Add(match[i]);
						col += match.Count - 1;
					}
                }    
			}  
			
			// Поиск вертикальных линий    
			for(int col = 0; col < width; col++)
			{     
				for (int row = 0; row < height - 1; row++)
				{      
					 match = getMatchVert(col, row); 
					 
					 if (match.Count > 2)
					 {
						 for (int k = 0; k < match.Count; k++) 
						 {
							 destroyList.Add(match[k]);
						 }
						 row += match.Count - 1;      
					 } 
				}    
			}

            if (onCreate)
            {
                successSwaping = false;
            }

            if (chooseSecond != null && destroyList.Count == 0)
			{
                swapPiece();
				if(chooseFirst != null)
				{
                    onChoose(chooseFirst, false);
                    chooseFirst = null;

                }			
				if(chooseSecond != null)
				{
                    onChoose(chooseSecond, false);
                    chooseSecond = null;
                }

                successSwaping = false;
            }

            if (!onCreate && destroyList.Count != 0)
            {
                successSwaping = true;
            }

            if (destroyList.Count == 0)
            {
                dispatchEvent(new Event(GameEvent.COMPLETE_TURN));
                return;
            }
           
            if (!onCreate) sendDestroy();

        }

        public void sendDestroy()
        {
            dispatchEvent(new Event(GameEvent.DESTROY));
        }

        // Поиск горизонтальных линий из заданной точки   
        public List<PieceModel> getMatchHoriz(int col, int row)
        {    
			List<PieceModel> match = new List<PieceModel>();   
			match.Add(boardData[col, row]);
			for(int i = 1; col + i < width; i++)
			{
				if (boardData[col, row].type == boardData[col + i, row].type) match.Add(boardData[col + i, row]);
				else return match;           
			}    
			return match;  
		}

        // Поиск вертикальных линий из заданной точки   
        public List<PieceModel> getMatchVert(int col, int row)
		{
            List<PieceModel> match = new List<PieceModel>();   
			match.Add(boardData[col, row]);  
			for(int i = 1; row + i < height; i++)
			{     
				if (boardData[col, row].type == boardData[col, row + i].type) match.Add(boardData[col, row + i]);
				else return match;           
			}    
			return match;
		}

        //	удаление одинаковых фигур
        virtual public void destroy()
		{
            PieceModel piece;
			for (int i = 0; i < destroyList.Count; i++) 
			{
				piece = destroyList[i];
				boardData[(int)piece.position.X, (int)piece.position.Y] = null;         
			}
		    dispatchEvent(new Event(GameEvent.SCORE, destroyList.Count));
        }

        //падение фигур после события удаления
        public void fall()
		{
            List<PieceModel> colmnListMatch = new List<PieceModel>();
			int emptyCount = 0;
            PieceModel piece;
            Random rnd = new Random();

			for (int i = 0 ; i < width ; i++) 
			{
				for (int j = 0; j < height; j++) 
				{
					if (boardData[i, j] != null) colmnListMatch.Add(boardData[i, j]);
				}

                emptyCount = height - colmnListMatch.Count;
				
				for (int k = 0; k < emptyCount; k++) 
				{
					piece = new PieceModel();
                    piece.assets = new ItemView();
					piece.type = rnd.Next(0, TOTAL_ITEMS);
                    colmnListMatch.Insert(0, piece);
				}

                for (int c = 0; c < height; c++)
                {
                    boardData[i, c] = colmnListMatch[c];
                }

                colmnListMatch = new List<PieceModel>();
                emptyCount = 0;
				
				for (int m = 0; m < height; m++)
				{
                    boardData[i, m].position = new SimplePoint(i, m);		
				}
			}

            dispatchEvent(new Event(GameEvent.FALL));
			destroyList = new List<PieceModel>();
            chooseFirst = null; chooseSecond = null;
		}

        //Меняем местами ячейки
        public void swapPiece()
		{
            PieceModel tempPiece = boardData[(int)chooseFirst.X, (int)chooseFirst.Y];

            boardData[(int)chooseFirst.X, (int)chooseFirst.Y] = boardData[(int)chooseSecond.X, (int)chooseSecond.Y];
            boardData[(int)chooseSecond.X, (int)chooseSecond.Y] = tempPiece;

            boardData[(int)chooseFirst.X, (int)chooseFirst.Y].position = VectorUtils.cloneVector(chooseFirst);    
            boardData[(int)chooseSecond.X, (int)chooseSecond.Y].position = VectorUtils.cloneVector(chooseSecond);

            dispatchEvent(new Event(GameEvent.SWAP_PIECE));
		}

        private void onChoose(SimplePoint position, bool choose)
		{
            ChooseData data = new ChooseData();
            data.position = position;
            data.choose = choose;
            dispatchEvent( new Event(GameEvent.CHOOSE, data));
		}

        //Выбираем ячейки
        public void selectPiece(SimplePoint position)
		{	
			if(chooseFirst == null) 
			{
				chooseFirst = VectorUtils.cloneVector(position);
                chooseSecond = null;
                onChoose(chooseFirst, true);
            }
			else checkSwap(position);
			
			if(chooseSecond != null) 
			{
                swapPiece();
                onChoose(chooseFirst, false);
            }
		}

        //Проверяем соседние ячейки
        private void checkSwap(SimplePoint position)
		{
			if( (Math.Abs(chooseFirst.X - position.X) == 1 &&  chooseFirst.Y == position.Y) ||
				(Math.Abs(chooseFirst.Y - position.Y) == 1 &&  chooseFirst.X == position.X))
			{
				chooseSecond = VectorUtils.cloneVector(position);
                onChoose(chooseFirst, false);
             }
			else if(chooseFirst.X == position.X && chooseFirst.Y == position.Y)
			{
                chooseFirst = null;
                onChoose(position, false);
            }
			else
			{
                onChoose(chooseFirst, false);
                chooseFirst = position.clone();
                onChoose(chooseFirst, true);
			}
		}

        private void createBoardData()
        {
            Random rnd = new Random();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    boardData[i, j] = new PieceModel();
                    boardData[i, j].type = rnd.Next(0, TOTAL_ITEMS);
                }
            }
        }

        protected void console()
        {
            string str = "";

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    str += Convert.ToString(boardData[j, i].type) + " ";
                }
                Debug.WriteLine(str);
                str = "";
            }
            Debug.WriteLine("______________________");
        }
    }
}
