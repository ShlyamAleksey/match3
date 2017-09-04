using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lizzard.str.events;
using Lizzard.Common;

namespace Lizzard.str.model
{
    public class FightModel : EventDispatcher
    {
        private CharacterModel _enemy;
        private CharacterModel _player;

        private BoardModel _boardModel;
        private AIBoardModel _aiModel;
        private CharactersConfig _characterConfig;
        private Character _currentMonster;
        private int _level;
        private Timer _timer;
        private int _vs = 0;

        public FightModel(BoardModel boardModel, AIBoardModel aiModel)
        {
            _boardModel = boardModel;
            _aiModel = aiModel;

            _level = 0;
            _characterConfig = new CharactersConfig();
            _currentMonster = _characterConfig.characters[_level];

            _enemy = new CharacterModel();
            _player = new CharacterModel();

            _enemy.addEventListener(CharacterEvent.UPDATE_HEALTH, updateEnemy);
            _player.addEventListener(CharacterEvent.UPDATE_HEALTH, updatePlayer);
            
            _boardModel.addEventListener(GameEvent.SCORE, hit);

            _timer = new Timer(_characterConfig.tickTime);
            //_timer.addEventListener(TimerEvent.TIMER, addEnemyEnergy);
        }

        private void hit(Event e)
        {
            _vs = _aiModel.isAITurn ? _vs - (int)e.data : _vs + (int)e.data;
            //dispatchEvent(new Event(FightEvent.CHANGE_VS, _vs));

            if (_vs >= CharactersConfig.VS_COUNT)
            {
                _enemy.hit(_characterConfig.playerPower);
                _vs = 0;
               // dispatchEvent(new Event(FightEvent.CHANGE_VS, _vs));
            }
            if (_vs <= -CharactersConfig.VS_COUNT)
            {
                _player.hit(_currentMonster.power);
                _vs = 0;
               // dispatchEvent(new Event(FightEvent.CHANGE_VS, _vs));
            }

            dispatchEvent(new Event(FightEvent.CHANGE_VS, _vs));
        }

        private void hitPlayer()
        {
            _enemy.energy.statusValue = 0;
            _timer.start();
            _player.hit(_currentMonster.power);
        }

        private void addEnemyEnergy(Event e)
        {
            _enemy.addEnergy(_characterConfig.energyPerTick);
            if (_enemy.energy.statusValue >= _characterConfig.totalEnemyEnergy)
            {
                _timer.stop();
                hitPlayer();
            }
        }

        private void updatePlayer(Event e)
        {
            float playerHealth = (e.data as CharacterEvent).value;
            dispatchEvent(new Event(FightEvent.UPDATE_PLAYER, playerHealth / _characterConfig.playerHealth));
        }

        private void updateEnemy(Event e)
        {
            float enemyHealth = (e.data as CharacterEvent).value;
            
            dispatchEvent(new Event(FightEvent.UPDATE_ENEMY, enemyHealth / _currentMonster.health));
            if (enemyHealth <= 0)
            {
                _level++;
                if(_level > 10)
                {
                    Debug.WriteLine("GAME COMPLETE!!!");
                    return;
                }
                _currentMonster = _characterConfig.characters[_level];
                initEnemy();

                dispatchEvent(new Event(FightEvent.UPDATE_LEVEL, _level));
            }
           // Debug.WriteLine("Enemy health: " + enemyHealth / _currentMonster.health);
        }

        public void init()
        {
            initPlayer();
            initEnemy();
        }

        public void initPlayer()
        {
            _player.init(10, _characterConfig.playerHealth);
        }

        public void initEnemy()
        {
            _enemy.init(_currentMonster.power, _currentMonster.health);
            _timer.start();
        }
    }
}
