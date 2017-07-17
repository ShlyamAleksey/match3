using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lizzard.str
{
    class GameEvent
    {
        static public String UPDATE_BOARD = "UPDATE_BOARD";
        static public String CREATE_BOARD = "CREATE_BOARD";
        static public String DESTROY = "DESTROY";
        static public String COMPLETE_TURN = "COMPLETE_TURN";
        static public String SWAP_PIECE = "SWAP_PIECE";
        static public String CHOOSE = "CHOOSE";
        static public String FALL = "FALL";
        static public String SCORE = "SCORE";
    }
}
