using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MechanicalDesign
{
    public abstract class MoveType
    {
        public Vehicle veh;
        public string name;
        public abstract void selectMove();

    }
    public class Generic : MoveType
    {
        public Generic(Vehicle s)
        {
            name = "Generic";
            veh = s;
        }
        public override void selectMove()
        {
        }
    }
    public class Bipedal : MoveType
    {
        public Bipedal(Vehicle s)
        {
            name = "Bipedal";
            veh = s;
        }
        public override void selectMove()
        {
            Main.mainForm.selectedVehicle.isBipedal = true;
            Main.mainForm.SectionForm.freeManCost();
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.baseArmor++; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.maxArmor++; }
            Main.mainForm.selectedVehicle.tempMove += 1;
        }
    }
    public class Quadrupedal : MoveType
    {
        public Quadrupedal(Vehicle s)
        {
            name = "Quadrupedal";
            veh = s;
        }
        public override void selectMove()
        {
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.baseArmor += 2; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.maxArmor += 2; }
        }
    }
    public class Multiped : MoveType
    {
        public Multiped(Vehicle s)
        {
            name = "Multiped";
            veh = s;
        }
        public override void selectMove()
        {
            Main.mainForm.selectedVehicle.tempMove += 2;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.baseArmor += 2; x.maxHP--; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.maxArmor += 2; x.hp--; }
        }
    }


    /// <summary>
    /// ///////////////
    public class Wheeled : MoveType
    {
        public Wheeled(Vehicle s)
        {
            name = "Wheeled";
            veh = s;
        }
        public override void selectMove()
        {
            Main.mainForm.selectedVehicle.tempMove += 2;
            Main.mainForm.selectedVehicle.tempMan = -1;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.baseArmor += 1; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.maxArmor += 1; }
        }
    }
    public class MultiWheeled : MoveType
    {
        public MultiWheeled(Vehicle s)
        {
            name = "Multi Wheeled";
            veh = s;
        }
        public override void selectMove()
        {
            Main.mainForm.selectedVehicle.tempMove += 1;
            Main.mainForm.selectedVehicle.tempMan = -1;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.baseArmor += 2; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.maxArmor += 2; }
        }
    }
    public class Track : MoveType
    {
        public Track(Vehicle s)
        {
            name = "Track";
            veh = s;
        }
        public override void selectMove()
        {
            Main.mainForm.selectedVehicle.tempMove -= 1;
            Main.mainForm.selectedVehicle.tempMan = -2;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.baseArmor += 4; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.maxArmor += 4; }
        }
    }
    public class Hover : MoveType
    {
        public Hover(Vehicle s)
        {
            name = "Hover";
            veh = s;
        }
        public override void selectMove()
        {
            Main.mainForm.selectedVehicle.tempMove += 3;

        }
    }



    public static class ExoMove
    {
        public static List<MoveType> exoMoveList = new List<MoveType>();
        public static void PopExoMove(Vehicle s)
        {
            exoMoveList.Clear();
            exoMoveList.Add(new Bipedal(s));
            exoMoveList.Add(new Quadrupedal(s));
            exoMoveList.Add(new Multiped(s));
        }
    }
    public static class GroundMove
    {
        public static List<MoveType> groundMoveList = new List<MoveType>();
        public static void PopGroundMove(Vehicle s)
        {
            groundMoveList.Clear();
            groundMoveList.Add(new Wheeled(s));
            groundMoveList.Add(new MultiWheeled(s));
            groundMoveList.Add(new Track(s));
            groundMoveList.Add(new Hover(s));
        }
    }
}
