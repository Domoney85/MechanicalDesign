using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalDesign
{
    public class VehiclePerk
    {
        public string perkName;
        public bool isAdded;
        public double perkCost;
        public VehiclePerk(String n, double c)
        {
            perkName = n;
            isAdded = false;
            perkCost = c;
        }
        public static void PopPerkList(Vehicle s)
        {
            s.perkList.Clear();
            s.perkList.Add(new VehiclePerk("Space Ready", s.tCHS));//0
            s.perkList.Add(new VehiclePerk("Improved Towing", s.tCHS));//1
            s.perkList.Add(new VehiclePerk("Intuitive Controls", s.tCHS));//2
            s.perkList.Add(new VehiclePerk("PSI Controller", s.tCHS));//3
            s.perkList.Add(new VehiclePerk("Battering Ram", s.tCHS));//4

            s.perkList.Add(new VehiclePerk("HY Pulse Engine", 0));//5
            s.perkList.Add(new VehiclePerk("RF Engine", 0));//6

            s.perkList.Add(new VehiclePerk("Accel Protect +1", 2));//7
            s.perkList.Add(new VehiclePerk("Accel Protect +2", 5));//8
            s.perkList.Add(new VehiclePerk("Accel Protect +3", 10));//9
            s.perkList.Add(new VehiclePerk("Accel Protect +4", 15));//10
            s.perkList.Add(new VehiclePerk("Accel Protect +4", 20));//11
        }
    }
    public class VehicleFlaw
    {
        public string flawName;
        public bool isAdded;
        public double flawCost;
        public VehicleFlaw(String n, double c)
        {
            flawName = n;
            isAdded = false;
            flawCost = c;
        }
        public static void PopFlawList(Vehicle s)
        {
            s.flawList.Clear();
            if(s.isBike) s.flawList.Add(new VehicleFlaw("Exposed Crew Comp", (0)));//0
            else
            s.flawList.Add(new VehicleFlaw ("Exposed Crew Comp", -1*(.5*s.tCHS)));//0
            s.flawList.Add(new VehicleFlaw("Compact Crew Comp", -1 * (.5 * s.tCHS)));//1
            s.flawList.Add(new VehicleFlaw("Difficulty to Mod", -1 * (.5 * s.tCHS)));//2
            s.flawList.Add(new VehicleFlaw("Loud Engine", -1 * (2)));//3
            s.flawList.Add(new VehicleFlaw("Power Issues", -1 * (s.tCHS)));//4
            s.flawList.Add(new VehicleFlaw("Cannot Glide", -1 * (.5*s.tCHS)));//5
            s.flawList.Add(new VehicleFlaw("Poor Towing", -1 * (s.tCHS)));//6
            s.flawList.Add(new VehicleFlaw("Problem Prone", -1 * (s.tCHS)));//7
            s.flawList.Add(new VehicleFlaw("No Re-entry Systems", -1 * (.5 * s.tCHS)));//8
        }

    }

}
