using System;
using Lizzard.ComponentPattern;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Lizzard.str.model;
using Lizzard.str.view;
using Lizzard;

namespace Lizzard.str
{
    class GameScreen : Sprite
    {
        //private float step = 0.01f;
        private BoardModel _boardModel;
        private FightModel _fightModel;
        private AIBoardModel _aiModel;

        private BoardView _boardView;
        private FightView _fightView;
        private BattleView _battleView;

        static public GameScreen instance;

        public void init()
        {
            instance = this;
            _boardModel = new BoardModel();
            _aiModel = new AIBoardModel(_boardModel);
            _fightModel = new FightModel(_boardModel, _aiModel);
            

            _boardView = new BoardView(_boardModel, _aiModel);
            _battleView = new BattleView(_fightModel);


            float _boardViewWidth = (Configuration.ITEM_ORIGINAL_SIZE + Configuration.ITEMS_DISTANCE) * Configuration.BOARD_SCALE * BoardModel.width;
            _boardView.x = (float)(Configuration.WINDOWS_WIDTH - _boardViewWidth) *0.5f;
            _boardView.y = 150;

            _fightView = new FightView(_fightModel, _boardViewWidth + _boardView.x);
            _battleView.x = (float)(Configuration.WINDOWS_WIDTH - _battleView.sizeX) * 0.5f;
            _battleView.y = 20;


            addChild(_fightView);
            addChild(_boardView);
            addChild(_battleView);

            _boardModel.init();
            _fightModel.init();
        }

        private void onClick(Event e)
        {
            Debug.WriteLine("Game Screen");
        }
    }
}
