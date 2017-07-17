using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using Lizzard.ComponentPattern;
using Lizzard.str.model;
using Microsoft.Xna.Framework;
using Lizzard.Common;

namespace Lizzard.str
{
    public class BoardView : Sprite
    {
        private BoardModel _model;
        private AIBoardModel _aiModel;
        private AnimationView animationManager;

        public BoardView(BoardModel model, AIBoardModel aiModel)
        {
            _model = model;
            _aiModel = aiModel;
            addListeners();
            animationManager = new AnimationView(_model);
        }

        private void addListeners()
        {
			_model.addEventListener(GameEvent.CREATE_BOARD, drawBoard);
			_model.addEventListener(GameEvent.CHOOSE, onChoose);
			_model.addEventListener(GameEvent.SWAP_PIECE, swapPiece);
            _model.addEventListener(GameEvent.DESTROY, onDestroy);
            _model.addEventListener(GameEvent.FALL, onFall);
        }

        private void drawBoard(Event e)
        {
            clearBoard();
        }

        private void addAllItems()
        {
            scaleX = scaleY = Configuration.BOARD_SCALE;

            for (int i = 0; i < BoardModel.width; i++)
            {
                for (int j = 0; j < BoardModel.height; j++)
                {
                    ItemView item = _model.boardData[i, j].assets;
                    item.state = _model.boardData[i, j].type;

                    item.x = (item.width + Configuration.ITEMS_DISTANCE) * i;
                    item.y = (item.height + Configuration.ITEMS_DISTANCE) * j;
                    this.addChild(item);
                    item.addEventListener(MouseEvent.CLICK, choosePiece);
                }
            }

            _aiModel.init();
        }

        private void clearBoard()
        {
            Tween tween = new Tween();
            tween.add("alpha", 0);
            tween.start(this, 25, removeAllItems);         
        }

        private void showBoard()
        {
            Tween tween = new Tween();
            tween.add("alpha", 1f);
            tween.start(this, 25, _aiModel.findPossibleSwap);
        }

        private void removeAllItems()
        {
            while (this.children.Count > 0)
            {
                removeChild(this.children[0]);
            }
            addAllItems();
            showBoard();
        }

        protected void swapPiece(Event у)
		{
            GameActiveStatus.deactive();

            SimplePoint pt1 = VectorUtils.cloneVector(_model.chooseFirst);
            SimplePoint pt2 = VectorUtils.cloneVector(_model.chooseSecond);
			
			ItemView piece1 = _model.boardData[(int)pt1.X, (int)pt1.Y].assets;
			ItemView piece2 = _model.boardData[(int)pt2.X, (int)pt2.Y].assets;

			Tween tween = new Tween();
			tween.add("x", (int) pt1.X * (piece1.width + Configuration.ITEMS_DISTANCE));
			tween.add("y", (int) pt1.Y * (piece1.height + Configuration.ITEMS_DISTANCE));
			tween.start(piece1, 25);

			tween = new Tween();
			tween.add("x", (int)pt2.X * (piece1.width + Configuration.ITEMS_DISTANCE));
			tween.add("y", (int)pt2.Y * (piece1.height + Configuration.ITEMS_DISTANCE));
			tween.start(piece2, 25, onComplete);
		}

        protected void onDestroy(Event e)
		{
            GameActiveStatus.deactive();

            SimplePoint pt;
		    Tween tween;

            for (int i = 0; i < _model.destroyList.Count; i++)
            {
                pt = _model.destroyList[i].position.clone();
                _model.destroyList[i] = _model.boardData[(int)pt.X, (int)pt.Y];

                if (_model.destroyList[i].assets.parent != null)
                {
                    tween = new Tween();
                    tween.add("alpha", 0);
                    tween.start(_model.destroyList[i].assets, 25);

                    _model.destroyList[i].assets.removeEventListener(MouseEvent.CLICK, choosePiece);
                }
            }

            tween = new Tween();
            tween.start(this, 25, onDestroyAnimation);
		}

        private void removeDestroyedAssets()
        {
            for (int i = 0; i < _model.destroyList.Count; i++)
            {
                _model.destroyList[i].assets.parent.removeChild(_model.destroyList[i].assets);
            }
        }

        private void onFall(Event e)
		{
            GameActiveStatus.deactive();

            PieceModel piece;
			int count = 0;
            Tween tween;

            for (int i = 0; i < BoardModel.width; i++) 
			{
				for (int j = BoardModel.height - 1; j >= 0; j--) 
				{
					piece = _model.boardData[i, j];
					if(piece.assets.parent == null)
					{
						count++;
						piece.assets.state = _model.boardData[i, j].type;
						piece.assets.x = (_model.boardData[i, j].assets.width + Configuration.ITEMS_DISTANCE) * i;
                        piece.assets.y = -count * (_model.boardData[i, j].assets.height + Configuration.ITEMS_DISTANCE);
                        piece.assets.addEventListener(MouseEvent.CLICK, choosePiece);
						piece.assets.selected.visible = false;
                        addChild(piece.assets);
                    }

                    tween = new Tween();
                    tween.add("y", (int)piece.position.Y * (piece.assets.height + Configuration.ITEMS_DISTANCE));
                    tween.start(piece.assets, 25);
                }	
				count = 0;
			}

            tween = new Tween();
            tween.start(this, 25, onComplete);
		}

        private void onDestroyAnimation()
		{
            removeDestroyedAssets();
            animationManager.completeDestroyPiece();
        }

        private void onComplete()
		{
            GameActiveStatus.active();
            animationManager.completeMovingPiece();
		}

        private void choosePiece(Event e)
		{		
			ItemView piece = e.currentTarget as ItemView;
            SimplePoint pt = new SimplePoint((Int32)(piece.x/(piece.width + Configuration.ITEMS_DISTANCE)), (Int32)(piece.y/(piece.height + Configuration.ITEMS_DISTANCE)));
			_model.selectPiece( pt );
			//Debug.WriteLine(pt.X.ToString() + " " +  pt.Y.ToString());
		}

		private void onChoose(Event e)
		{
            SimplePoint pt = VectorUtils.cloneVector((e.data as ChooseData).position);
			_model.boardData[(int) pt.X, (int) pt.Y].assets.selected.visible = (e.data as ChooseData).choose;
		}

        private void hideItem(Event e)
        {
            (e.currentTarget as ItemView).visible = false;
        }
    }
}
