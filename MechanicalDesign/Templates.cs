using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MechanicalDesign
{
    class Templates
    {
        List<Vehicle> exoList = new List<Vehicle>();
        List<Vehicle> groundList = new List<Vehicle>();
        List<Vehicle> aeroList = new List<Vehicle>();
        public Templates()
        {
            exoList.Add(new WalkerDrone());
            exoList.Add(new ScoutExo ());
            exoList.Add(new BattleExo ());
            exoList.Add(new HeavyExo ());
            exoList.Add(new Titan());

            groundList.Add(new GroundDrone());
            groundList.Add(new Bike());
            groundList.Add(new CCBike());
            groundList.Add(new Speeder());
            groundList.Add(new Transport());
            groundList.Add(new Tank());
            groundList.Add(new HTransport());
            groundList.Add(new HTank());
            groundList.Add(new MBase());
            groundList.Add(new GTank());

            aeroList.Add(new DroneFlier());
            aeroList.Add(new Scout());
            aeroList.Add(new Fighter());
            aeroList.Add(new Cargo());
            aeroList.Add(new Dropship());
            aeroList.Add(new HCargo());
            aeroList.Add(new HDropship());
            aeroList.Add(new Corvette());
            aeroList.Add(new LCruiser());
            aeroList.Add(new Cruiser());
            aeroList.Add(new Carrier());
            aeroList.Add(new Battleship());
        }
        public List<Vehicle> returnTemplate(String n)
        {
            List<Vehicle> template;
            switch (n)
            {
                case "Walker":
                    template = exoList;
                    break;
                case "Ground":
                    template = groundList;
                    break;
                case "Aero/Space":
                    template = aeroList;
                    break;
                default:
                    template = exoList;
                    break;
            }
            return template;
        }
    }
     public abstract class Vehicle
    {
        public int compartmentCode;
        public bool compAdded = false;
        public String templateName;
        public int maxSections { get; set; }
        public double sizeMin, sizeMax;
        public List<VehicleSection> sectionList = new List<VehicleSection>();
        public int actualSections;
        public double tCHS;
        public double totalPP;
        public double tempPPadj;
        public int bpTotal;
        public int crCost;
        public int pilotCPX;
        public int mechCPX;
        public int maneuver;
        public int tempMan;
        public int fixedmaneuver=0;
        public bool mobillity1=false;
        public bool mobillity2=false;
        public int mobillityadjust;
        public int mobCost;
        public List<VehiclePerk> perkList = new List<VehiclePerk>();
        public List<VehicleFlaw> flawList = new List<VehicleFlaw>();
        internal List<Compartment> compList = new List<Compartment>();
        public int move;
        public int moveAdjust;
        public int engineMove;
        public int tempMove=0;
        public int tempShield;
        //moveCost is the PP cost for movement adjustment
        public int moveCost;
        public double vehiclePP;
        /// ////////////////Template Bonus section
        public bool isSpace = false;
        public bool isDrone=false;
        public bool isBike = false;
        public bool isCBike = false;
        public bool isScout = false;
        public bool isFighter = false;
        public bool isCargo = false;
        public bool isDropship = false;
        public bool isCapital = false;

        public bool isBipedal = false;

        public void PopSections()
        {
            actualSections = maxSections;
            for (int i = 0; i < maxSections; i++)
            {
                String nameBuilder;
                if (maxSections > 1)
                {
                    nameBuilder = "Section " + (i + 1);
                }
                else
                {
                    nameBuilder = "Main Section";
                }
                sectionList.Insert(i, new VehicleSection(nameBuilder, this));
            }
        }

        public abstract void TempBonusses();

        public int SetMechCPX(int x)
        {
            if (x > mechCPX) mechCPX = x;
            return mechCPX;
        }
        public int SetPilotCPX(int x)
        {
            if (x > pilotCPX) pilotCPX = x;
            return pilotCPX;
        }
        public void setTCHS()
        {
            tCHS = 0;
            
            foreach(VehicleSection n in sectionList)
            {
                if (n != null & n.secChassis != null)
                {
                    if (n.secChassis.chasSize > 0)
                    {
                        tCHS += n.secChassis.chasSize;
                    }
                }
            }
        }
        public double getTCRS()
        {
            double tcrs = 0;

            foreach (VehicleSection n in sectionList)
            {
                if (n != null & n.secCore != null)
                {
                    if (n.secCore.corSize > 0)
                    {
                        tcrs += n.secCore.corSize;
                    }
                }
            }
            return tcrs;
        }
        public void SetTotalPP()
        {
            totalPP = 0;
            foreach (VehicleSection n in sectionList)
            {
                if (n != null & n.secCore != null)
                {
                    totalPP += n.sectionPP+n.corePP;
                }
            }
        }
        public double GetTotalUsedPP()
        {
            vehiclePP = mobCost+moveCost+GetVehPerkPP()+GetVehFlawPP()+tempPPadj; //add to this
            double collectedPP=0;
            foreach (VehicleSection n in sectionList)
            {
                if (n != null & n.secCore != null)
                {
                    collectedPP += n.ppSpent;
                }
            }
            double result = vehiclePP + collectedPP;
            return result; 
        }
        private double GetVehPerkPP()
        {
            double vehPP=0;
            foreach(VehiclePerk v in perkList)
            {
                if (v.isAdded == true) vehPP += v.perkCost;
            }
            return vehPP;
        }
        private double GetVehFlawPP()
        {
            double vehPP = 0;
            foreach (VehicleFlaw v in flawList)
            {
                if (v.isAdded == true) vehPP += v.flawCost;
            }
            return vehPP;
        }
        public String GetTemplateDescription()
        {
            String descBuilder = templateName;
            String sizeClean;
            if (sizeMax > sizeMin) sizeClean = " - " + sizeMax;
            else
                sizeClean = "";
            descBuilder += ": Size (" + sizeMin + sizeClean + ")";
            return descBuilder;
        }
        public int GetFinalMan()
        {
            int man;
            man = maneuver + mobillityadjust+tempMan;
            return man;
        }
        public void SetAllLs()
        {
            foreach(Vehicle.VehicleSection x in sectionList)
            {
                if (x != null & x.secCore != null)
                {
                    x.SetLsString();
                }
            }
        }
        public int GetMove()
        {
            int moveAdd=0;  
            int listCount=0;
            foreach(VehicleSection n in sectionList)
            {
                if (n.isBuilt == true)
                {
                    moveAdd += (int)(n.secCore.corSize + n.secCore.corSize - n.secChassis.chasSize);
                    listCount++;
                }   
            }
            bpTotal = (int)(tCHS / getTCRS() * 500 * getTCRS());
            move = moveAdd / listCount;
            return move + moveAdjust+engineMove+tempMove;
        }
        public int GetTotalCost()
        {
            crCost = 0;
            foreach(VehicleSection n in sectionList)
            {
                if (n.isBuilt) { crCost += n.SectionCr(); }
            }
            crCost += (int)(totalPP * 2000.00);
            if (perkList[5].isAdded) crCost = (int)(crCost * 1.20);
            if (perkList[6].isAdded) crCost = (int)(crCost * .8);
            return crCost;
        }
        public class VehicleSection
        {
            public Vehicle parentVeh;
            public Chassis secChassis;
            public Core secCore;
            public double sectionPP;
            public double corePP;
            public double ppSpent;
            public String sectionName;
            public int buildRoll;
            public String quality;
            public CompartmentList alphaList = new CompartmentList();
            public int armor;
            public int armorAdjust;
            public int armorTrackPos;
            public int totalArmor;
            public double armorPPSpent;
            public double protPPCost;
            public int ejectSeat;
            public int ejectPod;
            public List<string> protPerkList = new List<string>();
            public int lsCount = 0;
            public int lsCost = 0;
            public int shieldValue;
            public int shieldAdjust;
            public int totalShields;
            public double shieldPP;

            public int sectionCrCost;
            public int shieldCrCost;
            public int pcCost;
            public List<HardPoint> hpList = new List<HardPoint>();
            public List<Compartment> compList = new List<Compartment>();
            public int compartAdjust = 0;
            public int hpAdjust;
            public int maxHpAdj;
            public double hpCostPP;
            public double hpAdjustPP;
            public double hpMaxAdjPP;

            public string[] electronicSystems = new string[6];
            //[0] = comms
            //[1] = sensors
            //[2]=ecm
            //[3]=eccm
            //[4]=Computer Systems
            //[5]= Anti Missile Chaff
            public double comsCost;
            public double senCost;
            public double ecmCost=0;
            public double eccmCost=0;
            public int ecmValue;
            public bool ecmOvr=false;
            public bool eccmOvr = false;
            public int eccmValue;
            public double chaffCost;
            public double compSysCost;
            public string sensType;
            public string comType;
            public int comQual=0;
            public int senQual=0;
            public int comDist=0;
            public int senDist=0;

            public string[] miscSystems = new string[6];

            //[0] Power Booster
            //[1] Stealth Coating
            //[2] HoloField
            //[3] LS System
            //[4] Fire Cont
            public double pbCost;
            public double sSystemCost;
            public double fireCcost;


            public bool isBuilt;

            public VehicleSection(String n, Vehicle v)
            {
                parentVeh = v;
                sectionName = n;
                
            }
            public void PopSecCompList()
            {
                compList = alphaList.GetCompList();
                if (parentVeh.compartmentCode == 1 && parentVeh.compAdded == false) { parentVeh.compAdded = true; parentVeh.sectionList[0].compList.Add(new FCockpit()); }
                if (parentVeh.compartmentCode == 2 && parentVeh.compAdded == false) { parentVeh.compAdded = true; parentVeh.sectionList[0].compList.Add(new FDriver()); }
                if (parentVeh.compartmentCode == 3 && parentVeh.compAdded == false) { parentVeh.compAdded = true; parentVeh.sectionList[0].compList.Add(new FControlBridge()); }
            }
            public void CalcSectionPP(int rollResult)
            {
                buildRoll = rollResult;
                if(rollResult> secCore.poor && rollResult < secCore.avg)
                {
                    quality = "Poor";
                    sectionPP = secCore.corPerk - secCore.addPerk;
                }
                else if (rollResult >= secCore.avg && rollResult <= secCore.exceptional)
                {
                    quality = "Average";
                    sectionPP = secCore.corPerk;
                }
                else if (rollResult >secCore.exceptional && rollResult <=secCore.cuttEdge )
                {
                    quality = "Exceptional";
                    sectionPP = secCore.corPerk + secCore.addPerk;
                }
                else if(rollResult > secCore.cuttEdge)
                {
                    quality = "Cutting Edge";
                    sectionPP = secCore.corPerk + secCore.addPerk+ ((rollResult - secCore.cuttEdge)*secCore.addPerk);
                }
                else
                {
                    sectionPP = 0;
                    quality = "Failure";
                }
            }
            public double SectionPPSpent()
            {
                ppSpent = (armorPPSpent)+(comsCost+senCost+ecmCost+eccmCost+compSysCost+chaffCost)+(pbCost+sSystemCost+lsCost+fireCcost)+(protPPCost+shieldPP)+ (hpCostPP+hpAdjustPP+hpMaxAdjPP)+ GetCompartmentPP()+compartAdjust;
                return ppSpent;
            }
            public void SetLsString()
            {
                string lsString = "";
                int totalLs=0;
                if (parentVeh.isSpace) totalLs += (int)secCore.corSize;
                totalLs += lsCount;
                if (totalLs > 0) lsString = "Life Support BP("+totalLs+")";
                miscSystems[3] = lsString;

            }
            public int SectionCr()
            {
                sectionCrCost = (int)(secChassis.chasCost+shieldCrCost+pcCost);
                return sectionCrCost;
            }
            public int GetShieldTotal()
            {
                totalShields = shieldValue + shieldAdjust+parentVeh.tempShield;
                return totalShields;
            }
            public void SetHPperkCost()
            {
                hpCostPP=0;
                foreach(HardPoint x in hpList)
                {
                    hpCostPP += x.GetPPTotal();
                }
            }
            public int GetHPSlots()
            {
                int hpSlots = hpAdjust + secCore.hp;
                return hpSlots;
            }
            public int GetHPUsed()
            {
                int hpUsed=0;
                foreach(HardPoint x in hpList)
                {
                    hpUsed += x.hpSlots;
                }
                return hpUsed;
            }
            public int GetMaxHP()
            {
                int maxHP = maxHpAdj + secChassis.maxHP;
                return maxHP;
            }
            public double GetCompartmentPP()
            {
                double secComPP=0;
                foreach(Compartment x in compList)
                {
                    secComPP += (x.ppCost * x.count);
                }
                return secComPP;
            }
            public int GetCompSize()
            {
                int result = secChassis.compSize + (compartAdjust*2);
                return result;
            }
            public int GetUsedCompart()
            {
                int result=0;
                foreach(Compartment x in compList)
                {
                    result += (x.space * x.count);
                }
                return result;
            }
            public void AdjustMaxPP(int x)
            {
                corePP = x;
                parentVeh.SetTotalPP();
            }
        }
    }
}
