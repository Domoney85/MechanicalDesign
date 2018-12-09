using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MechanicalDesign
{
    public class Core
    {
        public int corCPX { get; private set; }
        public double corSize { get; private set; }
        public int corPerk { get; private set; }
        public int maxArmor { get; set; }
        public int hp { get; set; }
        public int poor { get; private set; }
        public int avg {get; private set;}
        public int exceptional { get; private set; }
        public int cuttEdge { get; private set; }
        public int addPerk { get; private set; }
        public int corCost { get; private set; }

        public Core(int cpx, double cs, int cp, int ma, int h, int p,int a, int e, int cu,int adp, int cc)
        {
            corCPX = cpx;
            corSize = cs;
            corPerk = cp;
            maxArmor = ma;
            hp = h;
            poor = p;
            avg = a;
            exceptional = e;
            cuttEdge = cu;
            addPerk = adp;
            corCost = cc;

        }
       
    }
    public class PopCore
    {
        public List<Core> CorList = new List<Core>();
        public PopCore()
        {
            CorList.Add(new Core(1, .5, 8, 3, 0,1, 4, 6, 9, 1, 15000));
            CorList.Add(new Core(1, 1, 8, 5, 1, 1,4, 6, 9, 2, 30000));
            CorList.Add(new Core(2, 2, 12, 6, 1,3, 6, 7, 10, 2, 50000));
            CorList.Add(new Core(2, 3, 20, 8, 1,3, 6, 9, 12, 3, 70000));
            CorList.Add(new Core(2, 4, 30, 10, 2,3, 7, 10, 12, 5, 90000));
            CorList.Add(new Core(2, 5, 40, 11, 2,5, 8, 11, 13, 7, 100000));
            CorList.Add(new Core(3, 6, 55, 13, 3,5, 8, 11, 13, 9, 150000));
            CorList.Add(new Core(3, 7, 70, 14, 3,6, 9, 12, 14, 10, 250000));
            CorList.Add(new Core(3, 8, 85, 16, 4, 7,10, 12, 15, 10, 350000));
            CorList.Add(new Core(3, 9, 100, 18, 4, 8,10, 12, 16, 14, 500000));
            CorList.Add(new Core(3, 10, 120, 20, 4,8, 10, 13, 16, 15, 1000000));
            CorList.Add(new Core(3, 11, 140, 22, 5, 9,11, 13, 16, 16, 2200000));
            CorList.Add(new Core(4, 12, 160, 24, 6, 9,11, 13, 16, 17, 3000000));
            CorList.Add(new Core(4, 13, 180, 24, 7,10, 12, 14, 17, 18, 3500000));
            CorList.Add(new Core(4, 14, 210, 25, 8,11, 13, 15, 18, 20, 4000000));
            CorList.Add(new Core(4, 15, 240, 26, 9, 12,14, 16, 19, 22, 4500000));
            CorList.Add(new Core(4, 16, 280, 28, 10,13, 15, 17, 20, 25, 5000000));
            CorList.Add(new Core(4, 17, 320, 30, 11,13, 15, 17, 21, 30, 6000000));
            CorList.Add(new Core(5, 18, 360, 32, 12, 13,15, 17, 21, 35, 7000000));
            CorList.Add(new Core(5, 19, 400, 34, 13,13, 16, 17, 21, 40, 8000000));
            CorList.Add(new Core(5, 20, 500, 38, 15,14, 17, 19, 22, 50, 10000000));
        }
        public void PrintCorList(ComboBox x)
        { 
            foreach (Core n in CorList)
            {
                string displayCrSize = "Core Size " + n.corSize;
                x.Items.Add(displayCrSize);
            }
        }
        public List<Core> getCoreList()
        {
            return CorList;
        }
    }
}
