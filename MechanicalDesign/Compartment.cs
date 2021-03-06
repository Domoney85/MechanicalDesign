﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MechanicalDesign
{
    public abstract class Compartment
    {
        internal string name;
        internal int space;
        internal double ppCost;
        internal int count=0;
        internal int ls=0;


        public void AddCompButton()
        {
            Button compBtn = new Button
            {
                Name = this.name,
                Font = new Font("Sans Serif", 6, FontStyle.Regular),
                Size = new Size(100,30),
                Text = this.name
            };
            compBtn.Click += new EventHandler(compBtn_Click);
            PerkForm.sectionForm.compartmentLayout.Controls.Add(compBtn);
        }
        private void compBtn_Click(object sender, EventArgs e)
        {
            count++;
            addButtons();
            PerkForm.sectionForm.CompartmentSpaceAdjust();
            Main.mainForm.selectedVehicle.SetAllLs();
            PerkForm.sectionForm.BuildMiscSystems();
        }
        private void addComp_Click(object sender, EventArgs e)
        {
            Button thisBut = (Button)sender;
            foreach(Compartment x in PerkForm.mainForm.selectedSection.compList)
            {
                if(thisBut.Name == x.name) x.count--;
            }
            addButtons();
            PerkForm.sectionForm.CompartmentSpaceAdjust();
            Main.mainForm.selectedVehicle.SetAllLs();
            PerkForm.sectionForm.BuildMiscSystems();
        }
        public void addButtons()
        {
            PerkForm.sectionForm.sectionCompLayout.Controls.Clear();
            foreach (Compartment x in PerkForm.mainForm.selectedSection.compList)
            {
                if(x.count>0)
                {
                    string compName = x.name;
                    if (x.count > 1) compName = "(" + x.count + ")" + x.name;

                    Button removeBtn = new Button
                    {
                        Name = x.name,
                        Text = compName,
                        AutoSize = true,
                        Font = new Font("Sans Serif", 6, FontStyle.Regular)
                };
                    PerkForm.sectionForm.sectionCompLayout.Controls.Add(removeBtn);
                    removeBtn.Click += new EventHandler(addComp_Click);
                }
            }
            PerkForm.sectionForm.spentPPLbl.Text = PerkForm.mainForm.selectedSection.SectionPPSpent().ToString();
            PerkForm.sectionForm.totalPPLbl.Text = PerkForm.mainForm.selectedVehicle.GetTotalUsedPP().ToString();

        }
    }
    public class Cockpit : Compartment
    {
        public Cockpit(){name = "Cockpit";space = 2;ppCost = 2;}
    }
    public class FCockpit : Compartment
    {
        public FCockpit() { name = "(Free)Cockpit"; space = 2; ppCost = 0; count = 1; }
    }
    public class FDriver : Compartment
    {
        public FDriver() { name = "(Free)Driver Seat"; space = 2; ppCost = 0; count = 1; }
    }
    public class Accommodations : Compartment
    {
        public Accommodations(){name = "Accomodations";space = 6;ppCost = 1;}
    }
    public class SoldierAccommodations : Compartment
    {
        public SoldierAccommodations(){name = "Soldier Accommodations"; space = 6; ppCost = 1;}
    }
    public class LuxAccommodations : Compartment
    {
        public LuxAccommodations(){name = "Luxury Accommodations"; space = 12; ppCost = 2;}
    }
    public class DiningFacility : Compartment
    {
        public DiningFacility(){ name = "Dining Facility"; space = 12; ppCost = 2;}
    }
    public class SocialLounge : Compartment
    {
        public SocialLounge(){name = "Social Lounge"; space = 16; ppCost = 3;}
    }
    public class GrandSocialLounge: Compartment
    {
        public GrandSocialLounge(){name = "Social Lounge w/ Wetbar"; space = 20; ppCost = 5;}
    }
    public class ControlBridge : Compartment
    {
        public ControlBridge(){name = "Control Bridge"; space = 10;  ppCost = 4;}
    }
    public class FControlBridge : Compartment
    {
        public FControlBridge() { name = "(Free)Control Bridge"; space = 10; ppCost = 0; count = 1; }
    }
    public class EWarControls : Compartment
    {
        public EWarControls() { name = "E-Warfare Controls"; space = 2; ppCost = 2; }
    }
    public class ExposedGunHatch : Compartment
    {
        public ExposedGunHatch() { name = "Exposed Gun Hatch"; space = 3; ppCost = 3; }
    }
    public class GunHatch : Compartment
    {
        public GunHatch() { name = "Gun Hatch"; space = 4; ppCost = 5; }
    }
    public class HPGunHatch : Compartment
    {
        public HPGunHatch() { name = "Hardpoint Gun Hatch"; space = 4; ppCost = 2; }
    }
    public class PilotControl : Compartment
    {
        public PilotControl() { name = "Pilots Controls"; space = 1; ppCost = 2; }
    }
    public class Laboratory : Compartment
    {
        public Laboratory() { name = "Laboratory"; space = 16; ppCost = 10; }
    }
    public class Medical : Compartment
    {
        public Medical() { name = "Medical Bay"; space = 12; ppCost = 4; }
    }
    public class EMedical : Compartment
    {
        public EMedical() { name = "Enh. Medical Bay"; space = 18; ppCost = 12; }
    }
    public class Engineering : Compartment
    {
        public Engineering() { name = "Engineering Bay"; space = 15; ppCost = 15; }
    }
    public class ExternalClamp : Compartment
    {
        public ExternalClamp() { name = "External Clamp"; space = 2; ppCost = 0; }
    }
    public class ExternalHatch : Compartment
    {
        public ExternalHatch() { name = "External Con Hatch"; space = 2; ppCost = 2; }
    }
    public class CrewSeat : Compartment
    {
        public CrewSeat() { name = "Crew Transport Seat"; space = 1; ppCost = 0; }
    }
    public class AirLock : Compartment
    {
        public AirLock() { name = "Air Lock"; space = 1; ppCost = 1; }
    }
    public class LSLarge : Compartment
    {
        public LSLarge() { name = "LS Large Cann"; space = 10; ppCost = 2;ls = 40; }
    }
    public class LSMed : Compartment
    {
        public LSMed() { name = "LS Med Cann"; space = 5; ppCost = 2; ls = 20; }
    }
    public class LSSmall : Compartment
    {
        public LSSmall() { name = "LS Small Cann"; space = 2; ppCost = 2; ls = 10; }
    }
    public class CompartmentList
    {
        List<Compartment> CompList = new List<Compartment>();

        public CompartmentList()
        {
            CompList = new List<Compartment>
            {
                new Cockpit(),
                new Accommodations(),
                new SoldierAccommodations(),
                new LuxAccommodations(),
                new DiningFacility(),
                new SocialLounge(),
                new GrandSocialLounge(),
                new ControlBridge(),
                new EWarControls(),
                new ExposedGunHatch(),
                new GunHatch(),
                new HPGunHatch(),
                new PilotControl(),
                new Laboratory(),
                new Medical(),
                new EMedical(),
                new Engineering(),
                new ExternalClamp(),
                new ExternalHatch(),
                new CrewSeat(),
                new AirLock(),
                new LSLarge(),
                new LSMed(),
                new LSSmall()
            
            };
            
        }
        public List<Compartment> GetCompList()
        {
            return CompList;
        }
    }
}
