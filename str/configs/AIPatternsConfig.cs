using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lizzard.str.configs
{
    public class AIPatternsConfig
    {
        //3 in row

        private int[,] _pattern_0 = new int[1, 4] { { 2, 3, 1, 1 } };
        private int[,] _pattern_1 = new int[1, 4] { { 1, 1, 3, 2 } };

        private int[,] _pattern_2 = new int[4, 1] { { 2 },
                                                    { 3 },
                                                    { 1 },
                                                    { 1 } };

        private int[,] _pattern_3 = new int[4, 1] { { 1 },
                                                    { 1 },
                                                    { 3 },
                                                    { 2 } };

        private int[,] _pattern_4 = new int[2, 3] { { 2, 0, 0 },
                                                    { 3, 1, 1 } };

        private int[,] _pattern_5 = new int[2, 3] { { 3, 1, 1 },
                                                    { 2, 0, 0 } };

        private int[,] _pattern_6 = new int[2, 3] { { 0, 0, 2 },
                                                    { 1, 1, 3 } };

        private int[,] _pattern_7 = new int[2, 3] { { 1, 1, 3 }, 
                                                    { 0, 0, 2 } };

        private int[,] _pattern_8 = new int[3, 2] { { 2, 3 },
                                                    { 0, 1 },
                                                    { 0, 1 } };

        private int[,] _pattern_9 = new int[3, 2] { { 2, 3 },
                                                    { 1, 0 },
                                                    { 1, 0 } };

        private int[,] _pattern_10 = new int[3, 2] {{ 1, 0 },
                                                    { 1, 0 },
                                                    { 3, 2 } };

        private int[,] _pattern_11 = new int[3, 2] {{ 0, 1 },
                                                    { 0, 1 },
                                                    { 2, 3 } };

        private int[,] _pattern_12 = new int[3, 2] {{ 1, 0 },
                                                    { 3, 2 },
                                                    { 1, 0 } };

        private int[,] _pattern_13 = new int[3, 2] {{ 0, 1 },
                                                    { 2, 3 },
                                                    { 0, 1 } };

        private int[,] _pattern_14 = new int[2, 3] {{ 1, 3, 1 },
                                                    { 0, 2, 0 }};

        private int[,] _pattern_15 = new int[2, 3] {{ 0, 2, 0 },
                                                    { 1, 3, 1 }};

        //4 in row

        private int[,] _pattern_16 = new int[2, 4] {{0, 2, 0, 0},
                                                    {1, 3, 1, 1}};

        private int[,] _pattern_17 = new int[2, 4] {{1, 3, 1, 1},
                                                    {0, 2, 0, 0}};
    
        private int[,] _pattern_18 = new int[4, 2] {{0, 1},
                                                    {2, 3},
                                                    {0, 1},
                                                    {0, 1}};

        private int[,] _pattern_19 = new int[4, 2] {{1, 0},
                                                    {3, 2},
                                                    {1, 0},
                                                    {1, 0}};

        private int[,] _pattern_20 = new int[2, 4] {{0, 0, 2, 0},
                                                    {1, 1, 3, 1}};

        private int[,] _pattern_21 = new int[2, 4] {{1, 1, 3, 1},
                                                    {0, 0, 2, 0}};

        private int[,] _pattern_22 = new int[4, 2] {{0, 1},
                                                    {0, 1},
                                                    {2, 3},
                                                    {0, 1}};

        private int[,] _pattern_23 = new int[4, 2] {{1, 0},
                                                    {1, 0},
                                                    {3, 2},
                                                    {1, 0}};

        //5 in row

        private int[,] _pattern_24 = new int[2, 5] {{1, 1, 3, 1, 1},
                                                    {0, 0, 2, 0, 0}};

        private int[,] _pattern_25 = new int[2, 5] {{0, 0, 2, 0, 0},
                                                    {1, 1, 3, 1, 1}};

        private int[,] _pattern_26 = new int[5, 2] {{0, 1},
                                                    {0, 1},
                                                    {2, 3},
                                                    {0, 1},
                                                    {0, 1}};

        private int[,] _pattern_27 = new int[5, 2] {{1, 0},
                                                    {1, 0},
                                                    {3, 2},
                                                    {1, 0},
                                                    {1, 0}};

        //5 in L

        private int[,] _pattern_28 = new int[4, 3] {{2, 0, 0},
                                                    {3, 1, 1},
                                                    {1, 0, 0},
                                                    {1, 0, 0}};

        private int[,] _pattern_29 = new int[4, 3] {{0, 0, 2},
                                                    {1, 1, 3},
                                                    {0, 0, 1},
                                                    {0, 0, 1}};

        private int[,] _pattern_30 = new int[4, 3] {{0, 0, 1},
                                                    {0, 0, 1},
                                                    {1, 1, 3},
                                                    {0, 0, 2}};

        private int[,] _pattern_31 = new int[4, 3] {{1, 0, 0},
                                                    {1, 0, 0},
                                                    {3, 1, 1},
                                                    {2, 0, 0}};

        private int[,] _pattern_32 = new int[3, 4] {{2, 3, 1, 1},
                                                    {0, 1, 0, 0},
                                                    {0, 1, 0, 0}};

        private int[,] _pattern_33 = new int[3, 4] {{1, 1, 3, 2},
                                                    {0, 0, 1, 0},
                                                    {0, 0, 1, 0}};

        private int[,] _pattern_34 = new int[3, 4] {{0, 1, 0, 0},
                                                    {0, 1, 0, 0},
                                                    {2, 3, 1, 1}};

        private int[,] _pattern_35 = new int[3, 4] {{0, 0, 1, 0},
                                                    {0, 0, 1, 0},
                                                    {1, 1, 3, 2}};

        //5 in T

       private int[,] _pattern_36 = new int[4, 3] { {0, 2, 0},
                                                    {1, 3, 1},
                                                    {0, 1, 0},
                                                    {0, 1, 0}};

       private int[,] _pattern_37 = new int[4, 3] { {0, 1, 0},
                                                    {0, 1, 0},
                                                    {1, 3, 1},
                                                    {0, 2, 0}};

       private int[,] _pattern_38 = new int[3, 4] { {0, 1, 0, 0},
                                                    {2, 3, 1, 1},
                                                    {0, 1, 0, 0}};

        private int[,] _pattern_39= new int[3, 4] { {0, 0, 1, 0},
                                                    {1, 1, 3, 2},
                                                    {0, 0, 1, 0}};

        //6 in T

       private int[,] _pattern_40 = new int[4, 4] { {0, 2, 0, 0},
                                                    {1, 3, 1, 1},
                                                    {0, 1, 0, 0},
                                                    {0, 1, 0, 0}};

       private int[,] _pattern_41 = new int[4, 4] { {0, 0, 2, 0},
                                                    {1, 1, 3, 1},
                                                    {0, 0, 1, 0},
                                                    {0, 0, 1, 0}};

       private int[,] _pattern_42 = new int[4, 4] { {0, 1, 0, 0},
                                                    {2, 3, 1, 1},
                                                    {0, 1, 0, 0},
                                                    {0, 1, 0, 0}};

       private int[,] _pattern_43 = new int[4, 4] { {0, 1, 0, 0},
                                                    {0, 1, 0, 0},
                                                    {2, 3, 1, 1},
                                                    {0, 1, 0, 0}};

       private int[,] _pattern_44 = new int[4, 4] { {0, 1, 0, 0},
                                                    {0, 1, 0, 0},
                                                    {1, 3, 1, 1},
                                                    {0, 2, 0, 0}};

       private int[,] _pattern_45 = new int[4, 4] { {0, 0, 1, 0},
                                                    {0, 0, 1, 0},
                                                    {1, 1, 3, 1},
                                                    {0, 0, 2, 0}};

       private int[,] _pattern_46 = new int[4, 4] { {0, 0, 1, 0},
                                                    {1, 1, 3, 2},
                                                    {0, 0, 1, 0},
                                                    {0, 0, 1, 0}};

       private int[,] _pattern_47 = new int[4, 4] { {0, 0, 1, 0},
                                                    {0, 0, 1, 0},
                                                    {1, 1, 3, 2},
                                                    {0, 0, 1, 0}};

        //7 in T

       private int[,] _pattern_48 = new int[4, 5] { {0, 0, 2, 0, 0},
                                                    {1, 1, 3, 1, 1},
                                                    {0, 0, 1, 0, 0},
                                                    {0, 0, 1, 0, 0}};

       private int[,] _pattern_49 = new int[4, 5] { {0, 0, 1, 0, 0},
                                                    {0, 0, 1, 0, 0},
                                                    {1, 1, 3, 1, 1},
                                                    {0, 0, 2, 0, 0}};

       private int[,] _pattern_50 = new int[5, 4] { {0, 1, 0, 0},
                                                    {0, 1, 0, 0},
                                                    {2, 3, 1, 1},
                                                    {0, 1, 0, 0},
                                                    {0, 1, 0, 0}};

       private int[,] _pattern_51 = new int[5, 4] { {0, 0, 1, 0},
                                                    {0, 0, 1, 0},
                                                    {1, 1, 3, 2},
                                                    {0, 0, 1, 0},
                                                    {0, 0, 1, 0}};

        public List<int[,]> patternList;

        public AIPatternsConfig()
        {
            patternList = new List<int[,]>();
            patternList.Add(_pattern_0);
            patternList.Add(_pattern_1);
            patternList.Add(_pattern_2);
            patternList.Add(_pattern_3);
            patternList.Add(_pattern_4);
            patternList.Add(_pattern_5);
            patternList.Add(_pattern_6);
            patternList.Add(_pattern_7);
            patternList.Add(_pattern_8);
            patternList.Add(_pattern_9);
            patternList.Add(_pattern_10);
            patternList.Add(_pattern_11);
            patternList.Add(_pattern_12);
            patternList.Add(_pattern_13);
            patternList.Add(_pattern_14);
            patternList.Add(_pattern_15);
            patternList.Add(_pattern_16);
            patternList.Add(_pattern_17);
            patternList.Add(_pattern_18);
            patternList.Add(_pattern_19);
            patternList.Add(_pattern_20);
            patternList.Add(_pattern_21);
            patternList.Add(_pattern_22);
            patternList.Add(_pattern_23);
            patternList.Add(_pattern_24);
            patternList.Add(_pattern_25);
            patternList.Add(_pattern_26);
            patternList.Add(_pattern_27);
            patternList.Add(_pattern_28);
            patternList.Add(_pattern_29);
            patternList.Add(_pattern_30);
            patternList.Add(_pattern_31);
            patternList.Add(_pattern_32);
            patternList.Add(_pattern_33);
            patternList.Add(_pattern_34);
            patternList.Add(_pattern_35);
            patternList.Add(_pattern_36);
            patternList.Add(_pattern_37);
            patternList.Add(_pattern_38);
            patternList.Add(_pattern_39);
            patternList.Add(_pattern_40);
            patternList.Add(_pattern_41);
            patternList.Add(_pattern_42);
            patternList.Add(_pattern_43);
            patternList.Add(_pattern_44);
            patternList.Add(_pattern_45);
            patternList.Add(_pattern_46);
            patternList.Add(_pattern_47);
            patternList.Add(_pattern_48);
            patternList.Add(_pattern_49);
            patternList.Add(_pattern_50);
            patternList.Add(_pattern_51);
        }
    }
}
