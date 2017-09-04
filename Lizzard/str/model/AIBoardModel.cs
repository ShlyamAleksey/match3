using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lizzard.Common;
using Lizzard.str.configs;
using System.Diagnostics;

namespace Lizzard.str.model
{
    public class AIBoardModel : BoardModel
    {
        private BoardModel _boardModel;
        public bool isAITurn { get; private set; } = false;

        private  AIPatternsConfig _config = new AIPatternsConfig();

        private int lastCombination = 0;
        private SimplePoint[] bestPattern;

        public AIBoardModel(BoardModel boardModel)
        {
            _boardModel = boardModel;
        }

        public override void createBoard()
        {
            destroyList = new List<PieceModel>();
            boardData = new PieceModel[width, height];
            PieceModel piece;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    piece = new PieceModel();
                    piece.position = new SimplePoint(i, j);
                    piece.type = _boardModel.boardData[i, j].type;
                    boardData[i, j] = piece;
                }
            }               
        }

        override public void init()
        {
            createBoard();     
            _boardModel.addEventListener(GameEvent.COMPLETE_TURN, completeTurn);
        }

        public void findPossibleSwap()
        {
            bestPattern = null;
            lastCombination = 0;
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    for (int p = 0; p < _config.patternList.Count; p++)
                    {
                        checkHoriz(boardData[j, i], _config.patternList[p], p );
                    }
                }
            }

            if (_boardModel.successSwaping) isAITurn = !isAITurn;

            if (bestPattern == null)
            {
                _boardModel.removeEventListener(GameEvent.COMPLETE_TURN, completeTurn);
                _boardModel.init();
            }
            else
            {
                if (isAITurn)
                {
                    Debug.WriteLine("Pattern: " + lastCombination);
                    _boardModel.selectPiece(bestPattern[0].revert());
                    _boardModel.selectPiece(bestPattern[1].revert());
                }
            }
        }

        protected void completeTurn(Event e)
        {
            createBoard();
            findPossibleSwap();
        }

        private void checkHoriz(PieceModel piece, int[,] pattern, int id)
        {
            int pW = pattern.GetLength(1);
            int pH = pattern.GetLength(0);

            int type = piece.type;
            bool firstMatch = true;

            int dX = 0;
            int dY = 0;

            string str = "";
            SimplePoint[] comb = new SimplePoint[2]; ;

            for (int i = 0; i < pH; i++)
            {
                for (int j = 0; j < pW; j++)
                {
                    if (pattern[i, j] == 2) comb[0] = new SimplePoint(i, j);
                    if (pattern[i, j] == 3) comb[1] = new SimplePoint(i, j);

                    if (pattern[i, j] == 1 || pattern[i, j] == 2)
                    {
                        if (firstMatch)
                        {
                            dX = (int)piece.position.X - j;
                            dY = (int)piece.position.Y - i;
                            firstMatch = false;
                            str += type + " ";
                        }
                        else
                        {
                            if (dX + j >= 0 && dX + j < BoardModel.width && dY + i >= 0 && dY + i < BoardModel.height)
                            {
                                if(type != _boardModel.boardData[dX + j, dY + i].type) return;
                                str += _boardModel.boardData[dX + j, dY + i].type + " ";
                            } else return;
                        }
                    } 
                }
            }

            comb[0].X = comb[0].X + dY; comb[0].Y = comb[0].Y + dX;
            comb[1].X = comb[1].X + dY; comb[1].Y = comb[1].Y + dX;

            if(lastCombination < id)
            {
                bestPattern = comb;
                lastCombination = id;
            }
        }
    }
}
