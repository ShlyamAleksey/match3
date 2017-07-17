using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lizzard.ComponentPattern;
using Lizzard.str.model;
using Lizzard.str.events;
using System.Diagnostics;
using Lizzard.str.configs;

namespace Lizzard.str.view
{
    public class BattleView : Sprite
    {
        private Sprite advantage;
        private Sprite flags;
        private Sprite upperBar;

        private float middlePosition;
        
        public BattleView(FightModel fightModel)
        {
            flags = new Sprite("monsters", "flags");
            addChild(flags);

            upperBar = new Sprite("monsters", "upperBar");
            addChild(upperBar);

            sizeX = upperBar.width;
            upperBar.y = flags.height - upperBar.height + 8;
            flags.x = (upperBar.width - flags.width) / 2;

            advantage = new Sprite("monsters", "swords");
            addChild(advantage);

            middlePosition = (upperBar.width - advantage.width) * 0.5f;

            advantage.y = upperBar.y - (advantage.height - upperBar.height) * 0.5f;
            advantage.x = middlePosition;

            fightModel.addEventListener(FightEvent.CHANGE_VS, updateAdvantage);
        }

        private void updateAdvantage(Event e)
        {
            Tween tween = new Tween();

                Debug.WriteLine(e.data);
                float pos = (CharactersConfig.VS_COUNT + (int)e.data) * middlePosition / CharactersConfig.VS_COUNT;

                if (pos < 0) pos = 0;
                if (pos > middlePosition * 2) pos = middlePosition * 2;
                tween.add("x", pos);
                tween.start(advantage, 20);

            
        }
    }
}
