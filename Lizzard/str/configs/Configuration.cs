using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lizzard.str
{
    public class Configuration
    {
        public const string EASY = "easy";
        public const string MEDIUM = "medium";
        public const string HARD = "hard";
        public const string CHEAT = "cheat";

        static public string DIFFICULT = EASY;

        static public int WINDOWS_WIDTH = 1050;
        static public int WINDOWS_HEIGHT = 700;

        static public int ITEM_ORIGINAL_SIZE = 202;
        static public int ITEMS_DISTANCE = 5;

        static public float BOARD_SCALE = 0.3f;
    }
}
