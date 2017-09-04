using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lizzard.ComponentPattern;
using Lizzard.str.model;
using Lizzard.str.events;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Lizzard.str.view
{
    public class FightView : Sprite
    {
        private CharacterView _enemyView;
        private CharacterView _playerView;
        private FightModel _model;

        private float _boardDistance;
        private int _currentLevel = 0;


        public FightView(FightModel model, float boardDistance)
        {           
            _boardDistance = boardDistance;
            addEnemy(_currentLevel);

            _playerView = new CharacterView(11);
            addChild(_playerView);

            _model = model;

            _model.addEventListener(FightEvent.UPDATE_ENEMY, updateEnemyHealth);
            _model.addEventListener(FightEvent.UPDATE_PLAYER, updatePlayerHealth);
            _model.addEventListener(FightEvent.UPDATE_LEVEL, updateLevel);
        }

        private void updateEnemyHealth(Event e)
        {
            _enemyView.updateHealth((float)e.data);
        }

        private void updatePlayerHealth(Event e)
        {
            _playerView.updateHealth((float)e.data);
        }

        private void addEnemy(int level)
        {
            _currentLevel = level;
           
            if (_enemyView != null)
            {
                _enemyView.showVanishAnimation(onDesapearComplete);
            } else
            {
                onDesapearComplete();
            }
        }

        private void onDesapearComplete()
        {
           if(_enemyView != null) removeChild(_enemyView);
            _enemyView = new CharacterView(_currentLevel);
            addChild(_enemyView);

            _enemyView.x = _boardDistance + 10;

            System.Diagnostics.Debug.WriteLine(this.children.Count);
        }

        private void updateLevel(Event e)
        {
            addEnemy((int)e.data);
        }
    }
}
