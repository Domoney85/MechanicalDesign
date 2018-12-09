using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MechanicalDesign
{
    class TemplateTypes
    {
    }
    public class WalkerDrone : Vehicle
    {
        public WalkerDrone()
        {
            templateName = "Walker Drone";
            maxSections = 1;
            sizeMin = .5;
            sizeMax = 2;
        }
        public override void TempBonusses()
        {
            isDrone = true;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.maxHP++; x.compSize = 0; x.maxCompSize = 0; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.hp++; }
        }
    }
    class ScoutExo : Vehicle
    {
        public ScoutExo()
        {
            templateName = "Scout Exo";
            maxSections = 1;
            sizeMin = 3;
            sizeMax = 4;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.compartmentCode = 1;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.maxHP++; x.baseArmor += 2; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.hp++; x.maxArmor += 2; }
            Main.mainForm.selectedVehicle.tempMove = 1;
        }
    }
    class BattleExo : Vehicle
    {
        public BattleExo()
        {
            templateName = "Battle Exo";
            maxSections = 1;
            sizeMin = 5;
            sizeMax = 7;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.compartmentCode = 1;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.maxHP++; x.baseArmor += 4; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.hp++; x.maxArmor += 4; }
        }
    }
    class HeavyExo: Vehicle
    {
        public HeavyExo()
        {
            templateName = "Heavy Exo";
            maxSections = 1;
            sizeMin = 8;
            sizeMax = 9;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.compartmentCode = 1;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.maxHP++; x.baseArmor += 6; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.hp++; x.maxArmor += 6; }

        }
    }
    class Titan : Vehicle
    {
        public Titan()
        {
            templateName = "Titan";
            maxSections = 1;
            sizeMin = 10;
            sizeMax = 10;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.compartmentCode = 1;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.maxHP++; x.baseArmor += 8; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.hp++; x.maxArmor += 8; }

        }
    }
    //////////////////////////////////////////Ground Types//////////////////////////////////
    class GroundDrone : Vehicle
    {
        public GroundDrone()
        {
            templateName = "Ground Drone";
            maxSections = 1;
            sizeMin = .5;
            sizeMax = 2;
        }
        public override void TempBonusses()
        {
            isDrone = true;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.baseArmor+=2;  }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.maxArmor+=2; }
            Main.mainForm.selectedVehicle.tempMove = 1;
        }
    }
    class Bike : Vehicle
    {
        public Bike()
        {
            templateName = "Bike";
            maxSections = 1;
            sizeMin = 1;
            sizeMax = 2;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.compartmentCode = 2;
            Main.mainForm.selectedVehicle.isBike = true;
            Main.mainForm.selectedVehicle.tempMove = 1;
        }
    }
    class CCBike : Vehicle
    {
        public CCBike()
        {
            templateName = "Closed Cabin Bike";
            maxSections = 1;
            sizeMin = 2;
            sizeMax = 3;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.compartmentCode = 2;
            Main.mainForm.selectedVehicle.isCBike = true;
        }
    }
    class Speeder : Vehicle
    {
        public Speeder()
        {
            templateName = "Speeder";
            maxSections = 1;
            sizeMin = 3;
            sizeMax = 4;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.compartmentCode = 2;
            Main.mainForm.selectedVehicle.tempMove = 2;
        }
    }
    class Transport : Vehicle
    {
        public Transport()
        {
            templateName = "Transport";
            maxSections = 1;
            sizeMin = 4;
            sizeMax = 6;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.compartmentCode = 2;
            Main.mainForm.selectedVehicle.tempMove = -1;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.baseArmor += 4; x.compSize = x.maxCompSize; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.maxArmor += 4; }
        }
    }
    class Tank : Vehicle
    {
        public Tank()
        {
            templateName = "Tank";
            maxSections = 1;
            sizeMin = 6;
            sizeMax = 7;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.compartmentCode = 2;
            Main.mainForm.selectedVehicle.tempMove = -2;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.baseArmor += 6; x.maxHP++; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.maxArmor += 6;x.hp++; }
        }
    }
    class HTransport : Vehicle
    {
        public HTransport()
        {

            templateName = "Heavy Transport";
            maxSections = 1;
            sizeMin = 7;
            sizeMax = 8;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.compartmentCode = 2;
            Main.mainForm.selectedVehicle.tempMove = -2;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.baseArmor += 5; x.compSize = x.maxCompSize; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.maxArmor += 5; }
        }
    }
    class HTank : Vehicle
    {
        public HTank()
        {
            templateName = "Heavy Tank";
            maxSections = 1;
            sizeMin = 8;
            sizeMax = 8;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.compartmentCode = 2;
            Main.mainForm.selectedVehicle.tempMove = -4;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.baseArmor += 8; x.maxHP+=2; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.maxArmor += 8; x.hp+=2; }
        }
    }
    class MBase : Vehicle
    {
        public MBase()
        {
            templateName = "Mobile Base";
            maxSections = 1;
            sizeMin = 9;
            sizeMax = 10;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.compartmentCode = 3;
            Main.mainForm.selectedVehicle.tempMove = -4;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.baseArmor += 10; x.compSize = x.maxCompSize; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.maxArmor += 10; }
        }
    }
    class GTank : Vehicle
    {
        public GTank()
        {
            templateName = "Goliath Tank";
            maxSections = 1;
            sizeMin = 9;
            sizeMax = 10;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.compartmentCode = 2;
            Main.mainForm.selectedVehicle.tempMove = -4;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.baseArmor += 12; x.maxHP += 4; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.maxArmor += 12; x.hp += 4; }
        }
    }
    //////////////////////////////////////Fliers////////////////////////////////////////////
    class DroneFlier : Vehicle
    {
        public DroneFlier()
        {
            templateName = "Drone Flier";
            maxSections = 1;
            sizeMin = .5;
            sizeMax = 2;
        }
        public override void TempBonusses()
        {

            isDrone = true;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.baseArmor++; x.compSize = 0; x.maxCompSize = 0; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.maxArmor++; }
        }
    }
    class Scout : Vehicle
    {
        public Scout()
        {
            templateName = "Scout";
            maxSections = 1;
            sizeMin = 3;
            sizeMax = 5;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.compartmentCode = 1;
            Main.mainForm.selectedVehicle.isScout = true;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.maxHP--; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.hp--; }
        }
    }
    class Fighter : Vehicle
    {
        public Fighter()
        {
            templateName = "Fighter";
            maxSections = 1;
            sizeMin = 5;
            sizeMax = 7;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.isFighter = true;
            Main.mainForm.selectedVehicle.compartmentCode = 1;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.baseArmor++; x.compSize =(int)( x.compSize * .5); x.maxCompSize =(int)(x.maxCompSize * .5); }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.maxArmor++; }
        }
    }
    class Cargo : Vehicle
    {
        public Cargo()
        {
            templateName = "Cargo";
            maxSections = 1;
            sizeMin = 7;
            sizeMax = 10;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.compartmentCode = 1;
            Main.mainForm.selectedVehicle.isCargo = true;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.maxHP-=2; x.maxCompSize = (int)(x.maxCompSize * 1.20);  x.compSize = x.maxCompSize;  }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.hp-=2; }

        }
    }
    class Dropship : Vehicle
    {
        public Dropship()
        {
            templateName = "Dropship";
            maxSections = 1;
            sizeMin = 7;
            sizeMax = 10;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.compartmentCode = 1;
            Main.mainForm.selectedVehicle.isDropship = true;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            {x.compSize = x.maxCompSize; }
        }
    }
    class HCargo : Vehicle
    {
        public HCargo()
        {
            templateName = "Heavy Cargo";
            maxSections = 2;
            sizeMin = 11;
            sizeMax = 20;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.compartmentCode = 1;
            Main.mainForm.selectedVehicle.fixedmaneuver = -3;
            Main.mainForm.selectedVehicle.isCargo = true;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.maxCompSize = (int)(x.maxCompSize * 1.20); x.compSize = x.maxCompSize; }

        }
    }
    class HDropship : Vehicle
    {
        public HDropship()
        {
            templateName = "Heavy Dropship";
            maxSections = 2;
            sizeMin = 11;
            sizeMax = 20;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.compartmentCode = 1;
            Main.mainForm.selectedVehicle.isDropship = true;
            Main.mainForm.selectedVehicle.fixedmaneuver = -3;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            {x.compSize = x.maxCompSize; }
        }
    }
    class Corvette : Vehicle
    {
        public Corvette()
        {
            templateName = "Corvette";
            maxSections = 3;
            sizeMin = 20;
            sizeMax = 30;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.compartmentCode = 3;
            Main.mainForm.selectedVehicle.isCapital = true;
            Main.mainForm.selectedVehicle.fixedmaneuver = -3;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.baseArmor += 2; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.maxArmor += 2; }
        }
    }
    class LCruiser : Vehicle
    {
        public LCruiser()
        {
            templateName = "Light Cruiser";
            maxSections = 4;
            sizeMin = 31;
            sizeMax = 40;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.compartmentCode = 3;
            Main.mainForm.selectedVehicle.isCapital = true;
            Main.mainForm.selectedVehicle.fixedmaneuver = -4;
            Main.mainForm.selectedVehicle.tempShield = 2;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.baseArmor += 4; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.maxArmor += 4; }
        }
    }
    class Cruiser : Vehicle
    {
        public Cruiser()
        {
            templateName = "Cruiser";
            maxSections = 5;
            sizeMin = 41;
            sizeMax = 50;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.compartmentCode = 3;
            Main.mainForm.selectedVehicle.isCapital = true;
            Main.mainForm.selectedVehicle.fixedmaneuver = -5;
            Main.mainForm.selectedVehicle.tempShield = 3;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.baseArmor += 6; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.maxArmor += 6; }
        }
    }
    class Carrier : Vehicle
    {
        public Carrier()
        {
            templateName = "Carrier";
            maxSections = 6;
            sizeMin = 51;
            sizeMax = 70;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.compartmentCode = 3;
            Main.mainForm.selectedVehicle.isCapital = true;
            Main.mainForm.selectedVehicle.fixedmaneuver = -5;
            Main.mainForm.selectedVehicle.tempShield = 4;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.baseArmor += 6; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.maxArmor += 6; }
        }
    }
    class Battleship : Vehicle
    {
        public Battleship()
        {
            templateName = "Battleship";
            maxSections = 10;
            sizeMin = 71;
            sizeMax = 100;
        }
        public override void TempBonusses()
        {
            Main.mainForm.selectedVehicle.compartmentCode = 3;
            Main.mainForm.selectedVehicle.isCapital = true;
            Main.mainForm.selectedVehicle.fixedmaneuver = -5;
            Main.mainForm.selectedVehicle.tempShield = 5;
            foreach (Chassis x in Main.mainForm.chs.ChasList)
            { x.baseArmor += 10; x.compSize += 20; x.maxCompSize += 20; }
            foreach (Core x in Main.mainForm.crs.CorList)
            { x.maxArmor += 10; }
        }
    }
}
