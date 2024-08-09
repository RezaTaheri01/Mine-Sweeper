using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MineSwepper.MineSwepperCodes
{
    class Cells
    {
       //Hard 100 Mine
       //Medium 40 Mine
       //Easy 10 Mine
       public  int i, j;
       public  Rectangle Rect;
       public Rectangle MineRect;
       public bool IsMine;
       public bool flag;
       public bool IsClick=false;
       public int MineCounter;
       //public int SoilCount;
       public int MineCount;
    }
}
