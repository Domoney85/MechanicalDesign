using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MechanicalDesign
{
    public class Chassis
    {
        public String chasName;
        public double chasSize{ get; private set; }
        public double baseArmor { get; set; }
        public int baseMan { get; private set; }
        public int maxHP { get; set; }
        public int maxCompSize { get; set; }
        public int compSize { get; set; }
        public double chasCost { get; private set; }

        public Chassis(double chs, double bsa, int bm, int mhp, int mcs, int cs,double c)
        {
            this.chasSize = chs;
            this.baseArmor = bsa;
            this.baseMan = bm;
            this.maxHP = mhp;
            this.maxCompSize = mcs;
            this.compSize = cs;
            this.chasCost = c;

           chasName= "Chassis Size " + chasSize;
        }
       
    }
    public class PopChassis
    {
        public List<Chassis> ChasList = new List<Chassis>();

        public PopChassis()
        {
            // Size, BaseArmor, Base Maneuver, Max HP, Max compartment, Compartment, cost
            /*Size 1/2*/
            ChasList.Add(new Chassis(.5, 1, 0, 2, 0, 0, 10000));
            /*Size 1*/
            ChasList.Add(new Chassis(1, 2, -1, 2, 1, 1, 20000));
            /*Size 2*/
            ChasList.Add(new Chassis(2, 4, -2, 2, 2, 1, 30000));
            /*Size 3*/
            ChasList.Add(new Chassis(3, 5, -2, 3, 6, 2, 40000));
            /*Size 4*/
            ChasList.Add(new Chassis(4, 6, -2, 4, 8, 4, 50000));
            /*Size 5*/
            ChasList.Add(new Chassis(5, 7, -3, 5, 10, 5, 60000));
            /*Size 6*/
            ChasList.Add(new Chassis(6, 8, -3, 6, 20, 10, 70000));
            /*Size 7*/
            ChasList.Add(new Chassis(7, 9, -3, 7, 40, 20, 100000));
            /*Size 8*/
            ChasList.Add(new Chassis(8, 10, -3, 8, 50, 30, 200000));
            /*Size 9*/
            ChasList.Add(new Chassis(9, 11, -3, 9, 60, 40, 500000));
            /*Size 10*/
            ChasList.Add(new Chassis(10, 13, -3, 10, 80, 50, 1000000));
            /*Size 11*/
            ChasList.Add(new Chassis(11, 14, -4, 11, 120, 60, 1200000));
            /*Size 12*/
            ChasList.Add(new Chassis(12, 15, -4, 12, 140, 70, 1400000));
            /*Size 13*/
            ChasList.Add(new Chassis(13, 17, -4, 13, 160, 80, 2000000));
            /*Size 14*/
            ChasList.Add(new Chassis(14, 18, -4, 13, 180, 100, 2300000));
            /*Size 15*/
            ChasList.Add(new Chassis(15, 19, -4, 14, 200, 120, 2600000));
            /*Size 16*/
            ChasList.Add(new Chassis(16, 20, -4, 14, 220, 140, 3000000));
            /*Size 17*/
            ChasList.Add(new Chassis(17, 21, -4, 14, 240, 160, 3300000));
            /*Size 18*/
            ChasList.Add(new Chassis(18, 22, -4, 15, 270, 190, 3900000));
            /*Size 19*/
            ChasList.Add(new Chassis(19, 23, -4, 15, 300, 210, 4200000));
            /*Size 20*/
            ChasList.Add(new Chassis(20, 24, -5, 16, 360, 280, 5000000));
        }

        public void PrintChasList(ComboBox x, Vehicle v )
        {
            foreach (Chassis n in ChasList)
            {
                if ((n.chasSize >= v.sizeMin && n.chasSize <= v.sizeMax)||v.sizeMin>10)
                {
                    x.Items.Add(n.chasName);
                }
            }
        }
        public List<Chassis> getChasList()
        {
            return ChasList; 
        }
    }
}
