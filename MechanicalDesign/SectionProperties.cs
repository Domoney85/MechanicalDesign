using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MechanicalDesign
{
    public partial class SectionProperties : Form
    {
        public Main mainForm;
        public PerkForm perkForm;
        public SectionProperties()
        {
            
            InitializeComponent();
            ecmChk.CheckedChanged += new EventHandler(ecmButton_CheckedChanged);
            eccmChk.CheckedChanged += new EventHandler(eccmButton_CheckedChanged);
            ecmTrk.ValueChanged += new EventHandler(ecmButton_CheckedChanged);
            eccmTrk.ValueChanged += new EventHandler(eccmButton_CheckedChanged);

            compSysNoneRad.CheckedChanged += new EventHandler(comSys_CheckedChanged);
            comSys1Rad.CheckedChanged += new EventHandler(comSys_CheckedChanged);
            comSys2Rad.CheckedChanged += new EventHandler(comSys_CheckedChanged);
            comSys3Rad.CheckedChanged += new EventHandler(comSys_CheckedChanged);
            comSys4Rad.CheckedChanged += new EventHandler(comSys_CheckedChanged);
            comSys5Rad.CheckedChanged += new EventHandler(comSys_CheckedChanged);

            noMobRad.CheckedChanged += new EventHandler(mobAct_CheckedChanged);
            mobillityOneRad.CheckedChanged += new EventHandler(mobAct_CheckedChanged);
            mobillityTwoRad.CheckedChanged += new EventHandler(mobAct_CheckedChanged);

            pb0Rad.CheckedChanged += new EventHandler(PB_CheckedChanged);
            pb1Rad.CheckedChanged += new EventHandler(PB_CheckedChanged);
            pb2Rad.CheckedChanged += new EventHandler(PB_CheckedChanged);
            pb3Rad.CheckedChanged += new EventHandler(PB_CheckedChanged);
            pb4Rad.CheckedChanged += new EventHandler(PB_CheckedChanged);
            pb5Rad.CheckedChanged += new EventHandler(PB_CheckedChanged);

            sCoatChk.CheckedChanged += new EventHandler(StealthSystem_CheckedChanged);
            sCoatTrk.ValueChanged += new EventHandler(StealthSystem_CheckedChanged);
            hFieldChk.CheckedChanged += new EventHandler(StealthSystem_CheckedChanged);
            hFieldTrk.ValueChanged += new EventHandler(StealthSystem_CheckedChanged);

            hepColdChk.CheckedChanged += new EventHandler(ProtPerk_CheckedChanged);
            hepHeatChk.CheckedChanged += new EventHandler(ProtPerk_CheckedChanged);
            hepElecChk.CheckedChanged += new EventHandler(ProtPerk_CheckedChanged);
            hepEMPChk.CheckedChanged += new EventHandler(ProtPerk_CheckedChanged);
            armDiffChk.CheckedChanged += new EventHandler(ProtPerk_CheckedChanged);
            strongArmCmb.SelectedValueChanged += new EventHandler(ProtPerk_CheckedChanged);
            strongArmTrk.ValueChanged += new EventHandler(ProtPerk_CheckedChanged);
            armAdjustTrk.ValueChanged += new EventHandler(ProtPerk_CheckedChanged);

            installShdChk.CheckedChanged += new EventHandler(Shields_CheckedChanged);
            shieldAdjustTrk.ValueChanged += new EventHandler(Shields_CheckedChanged);
            chaffChk.CheckedChanged += new EventHandler(AmChaff_CheckedChanged);

            vp0Chk.CheckedChanged += new EventHandler(VehiclePerks_CheckedChanged);
            vp1Chk.CheckedChanged += new EventHandler(VehiclePerks_CheckedChanged);
            vp2Chk.CheckedChanged += new EventHandler(VehiclePerks_CheckedChanged);
            vp3Chk.CheckedChanged += new EventHandler(VehiclePerks_CheckedChanged);
            vp4Chk.CheckedChanged += new EventHandler(VehiclePerks_CheckedChanged);
            vp5Chk.CheckedChanged += new EventHandler(VehiclePerks_CheckedChanged);
            vp6Chk.CheckedChanged += new EventHandler(VehiclePerks_CheckedChanged);
            vp7Chk.CheckedChanged += new EventHandler(VehiclePerks_CheckedChanged);
            vp8Chk.CheckedChanged += new EventHandler(VehiclePerks_CheckedChanged);
            vp9Chk.CheckedChanged += new EventHandler(VehiclePerks_CheckedChanged);
            vp10Chk.CheckedChanged += new EventHandler(VehiclePerks_CheckedChanged);
            vp11Chk.CheckedChanged += new EventHandler(VehiclePerks_CheckedChanged);

            Vf0Chk.CheckedChanged += new EventHandler(VehicleFlaws_CheckedChanged);
            Vf1Chk.CheckedChanged += new EventHandler(VehicleFlaws_CheckedChanged);
            Vf2Chk.CheckedChanged += new EventHandler(VehicleFlaws_CheckedChanged);
            Vf3Chk.CheckedChanged += new EventHandler(VehicleFlaws_CheckedChanged);
            Vf4Chk.CheckedChanged += new EventHandler(VehicleFlaws_CheckedChanged);
            Vf5Chk.CheckedChanged += new EventHandler(VehicleFlaws_CheckedChanged);
            Vf6Chk.CheckedChanged += new EventHandler(VehicleFlaws_CheckedChanged);
            Vf7Chk.CheckedChanged += new EventHandler(VehicleFlaws_CheckedChanged);
            Vf8Chk.CheckedChanged += new EventHandler(VehicleFlaws_CheckedChanged);
            amLargeChk.CheckedChanged += new EventHandler(PC_CheckedChanged);
            amMedChk.CheckedChanged += new EventHandler(PC_CheckedChanged);
            amSmallChk.CheckedChanged += new EventHandler(PC_CheckedChanged);
        }

        private void armAdjustTrk_Scroll(object sender, EventArgs e)
        {
            perkForm.SetArmor(armAdjustTrk.Value);
            perkForm.selectedSection.armorPPSpent = armAdjustTrk.Value * perkForm.selectedSection.secChassis.chasSize;
            spentPPLbl.Text = perkForm.selectedSection.SectionPPSpent().ToString();
            totalPPLbl.Text = perkForm.selectedVehicle.GetTotalUsedPP().ToString();
            adjustArmLbl.Text = "Adjust Armor " + armAdjustTrk.Value;

        }

        private void SectionProperties_Load(object sender, EventArgs e)
        {
            mainForm = (Main)Application.OpenForms[0];
            perkForm = mainForm.perkForm;
        }
        private void CostOfComms(int distance, int quality)
        {
            int totalCost;
            int comTypCost;
            int comDistPer;
            string comTypSt;
            string comTypName = "";
            string bonusType = "";
            string result;

            if (groundComRad.Checked) { comTypCost = 1; comDistPer = 2; comTypSt = "KM"; comTypName = "Ground"; }
            else if (airComRad.Checked) { comTypCost = 1; comDistPer = 10; comTypSt = "KM"; comTypName = "Air"; }
            else if (spaceComRad.Checked) { comTypCost = 2; comDistPer = 10; comTypSt = "MM"; comTypName = "Space"; }
            else { comTypCost = 0; comDistPer = 0; comTypSt = ""; }
            perkForm.selectedSection.comType = comTypName;
            perkForm.selectedSection.comQual = quality;
            perkForm.selectedSection.comDist = distance;
            int totalQualCost;
            if (quality < 0) { totalQualCost = quality * 1; bonusType = ""; }
            else { totalQualCost = quality * (distance * comTypCost); bonusType = "+"; }
            if (distance == 0) totalQualCost = 0;

            totalCost = (distance * comTypCost) + totalQualCost;
            perkForm.selectedSection.comsCost = totalCost;
            spentPPLbl.Text = perkForm.selectedSection.SectionPPSpent().ToString();
            totalPPLbl.Text = perkForm.selectedVehicle.GetTotalUsedPP().ToString();
            result = comTypName + " Comms " + "(" + bonusType + quality + ")" + (distance * comDistPer) + " " + comTypSt;
            if (distance == 0|| perkForm.selectedSection.comType == "") result = "";
            perkForm.selectedSection.electronicSystems[0] = result;

            comRangeLbl.Text = "Comm Range: " + (distance * comDistPer) + " " + comTypSt;
            comQualLbl.Text = "Comm Quality: " + "(" + bonusType + quality + ")";
            perkForm.selectedSection.electronicSystems[0] = result;
            BuildElectricSystems();

        }
        private void CostOfSensors(int distance, int quality)
        {
            int totalCost;
            int senTypCost;
            double senDistPer;
            string senTypSt;
            string senTypName = "";
            string bonusType = "";
            string result;

            if (groundSenRad.Checked) { senTypCost = 1; senDistPer = .5; senTypSt = "KM"; senTypName = "Ground"; }
            else if (airSenRad.Checked) { senTypCost = 2; senDistPer = 3; senTypSt = "KM"; senTypName = "Air"; }
            else if (spaceSenRad.Checked) { senTypCost = 3; senDistPer = 2; senTypSt = "MM"; senTypName = "Space"; }
            else { senTypCost = 0; senDistPer = 0; senTypSt = ""; }
            perkForm.selectedSection.sensType = senTypName;
            perkForm.selectedSection.senQual = quality;
            perkForm.selectedSection.senDist = distance;
            int totalQualCost;
            if (quality < 0) { totalQualCost = quality * 1; bonusType = ""; }
            else { totalQualCost = quality * (distance * senTypCost); bonusType = "+"; }
            if (distance == 0) totalQualCost = 0;

            totalCost = (distance * senTypCost) + totalQualCost;
            perkForm.selectedSection.senCost = totalCost;
            spentPPLbl.Text = perkForm.selectedSection.SectionPPSpent().ToString();
            totalPPLbl.Text = perkForm.selectedVehicle.GetTotalUsedPP().ToString();
            result = senTypName + " Sensors " + "(" + bonusType + quality + ")" + (distance * senDistPer) + " " + senTypSt;
            if (distance == 0 || perkForm.selectedSection.sensType == "") result = "";
            perkForm.selectedSection.electronicSystems[1] = result;

            senRangeLbl.Text = "Sensor Range: " + (distance * senDistPer) + " " + senTypSt;
            senQualLbl.Text = "Sensor Quality: " + "(" + bonusType + quality + ")";
            perkForm.selectedSection.electronicSystems[1] = result;
            BuildElectricSystems();

        }
        public void BuildElectricSystems()
        {
            eSystemTable.Controls.Clear();
            foreach (string x in perkForm.selectedSection.electronicSystems)
            {
                int i = 0;
                int v = 0;

                if (x != null && x != "")
                {
                    Label eSystemLbl = new Label();
                    eSystemLbl.AutoSize = true;
                    eSystemLbl.Location = new Point(1, 1);
                    eSystemLbl.Font = new Font("Sans Serif", 6, FontStyle.Regular);
                    eSystemLbl.Text = x;
                    eSystemTable.Controls.Add(eSystemLbl, i, v);

                    if (i >= 4) { v = 1; i = 0; }
                }
            }
        }
        public void BuildMiscSystems()
        {
            mSystemTable.Controls.Clear();
            foreach (string x in perkForm.selectedSection.miscSystems)
            {
                int i = 0;
                int v = 0;

                if (x != null && x != "")
                {
                    Label mSystemLbl = new Label();
                    mSystemLbl.AutoSize = true;
                    mSystemLbl.Location = new Point(1, 1);
                    mSystemLbl.Font = new Font("Sans Serif", 6, FontStyle.Regular);
                    mSystemLbl.Text = x;
                    mSystemTable.Controls.Add(mSystemLbl, i, v);

                    if (i >= 4) { v = 1; i = 0; }
                }
            }
        }

        private void comRangeTrk_Scroll(object sender, EventArgs e)
        {
            CostOfComms(comRangeTrk.Value, comQualTrk.Value);
        }

        private void commsBonusTrk_Scroll(object sender, EventArgs e)
        {
            CostOfComms(comRangeTrk.Value, comQualTrk.Value);
        }

        private void groundComRad_CheckedChanged(object sender, EventArgs e)
        {
            CostOfComms(comRangeTrk.Value, comQualTrk.Value);
        }

        private void airComRad_CheckedChanged(object sender, EventArgs e)
        {
            CostOfComms(comRangeTrk.Value, comQualTrk.Value);
        }

        private void spaceComRad_CheckedChanged(object sender, EventArgs e)
        {
            CostOfComms(comRangeTrk.Value, comQualTrk.Value);
        }

        private void groundSenRad_CheckedChanged(object sender, EventArgs e)
        {
            CostOfSensors(senRangeTrk.Value, senQualTrk.Value);
        }

        private void airSenRad_CheckedChanged(object sender, EventArgs e)
        {
            CostOfSensors(senRangeTrk.Value, senQualTrk.Value);
        }

        private void spaceSenRad_CheckedChanged(object sender, EventArgs e)
        {
            CostOfSensors(senRangeTrk.Value, senQualTrk.Value);
        }

        private void senRangeTrk_Scroll(object sender, EventArgs e)
        {
            CostOfSensors(senRangeTrk.Value, senQualTrk.Value);
        }

        private void senQualTrk_Scroll(object sender, EventArgs e)
        {
            CostOfSensors(senRangeTrk.Value, senQualTrk.Value);
        }

        private void ecmButton_CheckedChanged(object sender, EventArgs e)
        {
            string ecmBonusType = "";
            
            string ecmText = "";
           
            
            if (ecmTrk.Value > 0) ecmBonusType = "+";
           
            if (ecmChk.Checked)
            {
                perkForm.selectedSection.ecmValue = ecmTrk.Value;
                ecmText = "ECM: " + "(" + ecmBonusType + perkForm.selectedSection.ecmValue.ToString() + ")";
                perkForm.selectedSection.ecmOvr = true;
                ecmLbl.Text = ecmText;
                perkForm.selectedSection.ecmCost = 4 + (4 * ecmTrk.Value);
            }
            else { perkForm.selectedSection.ecmCost = 0; ecmText = ""; perkForm.selectedSection.ecmOvr = false; }


            perkForm.selectedSection.electronicSystems[2] = ecmText;
            spentPPLbl.Text = perkForm.selectedSection.SectionPPSpent().ToString();
            totalPPLbl.Text = perkForm.selectedVehicle.GetTotalUsedPP().ToString();
            BuildElectricSystems();
        }
        private void eccmButton_CheckedChanged(object sender, EventArgs e)
        {
            string eccmBonusType = "";
            string eccmText = "";
            if (eccmTrk.Value > 0) eccmBonusType = "+";
            if (eccmChk.Checked)
            {
                perkForm.selectedSection.eccmValue = eccmTrk.Value;
                eccmText = "ECCM: " + "(" + eccmBonusType + perkForm.selectedSection.eccmValue.ToString() + ")";
                perkForm.selectedSection.eccmOvr = true;
                eccmLbl.Text = eccmText;
                perkForm.selectedSection.eccmCost = 4 + (4 * eccmTrk.Value);
            }
            else { perkForm.selectedSection.eccmCost = 0; eccmText = ""; perkForm.selectedSection.eccmOvr = false; }
            perkForm.selectedSection.electronicSystems[3] = eccmText;
            spentPPLbl.Text = perkForm.selectedSection.SectionPPSpent().ToString();
            totalPPLbl.Text = perkForm.selectedVehicle.GetTotalUsedPP().ToString();
            BuildElectricSystems();
        }
        private void comSys_CheckedChanged(object sender, EventArgs e)
        {
            string computerSysText = "";
            int comSysCost = 0;
            if (comSys1Rad.Checked) { comSysCost = 2; computerSysText = "Comp System Lvl 1"; }
            if (comSys2Rad.Checked) { comSysCost = 6; computerSysText = "Comp System Lvl 2"; }
            if (comSys3Rad.Checked) { comSysCost = 14; computerSysText = "Comp System Lvl 3"; }
            if (comSys4Rad.Checked) { comSysCost = 20; computerSysText = "Comp System Lvl 4"; }
            if (comSys5Rad.Checked) { comSysCost = 30; computerSysText = "Comp System Lvl 5"; }
            if (perkForm.selectedVehicle.isDrone == true) comSysCost =comSysCost/ 2;
            perkForm.selectedSection.compSysCost = comSysCost;
            perkForm.selectedSection.electronicSystems[4] = computerSysText;
            BuildElectricSystems();
            spentPPLbl.Text = perkForm.selectedSection.SectionPPSpent().ToString();
            totalPPLbl.Text = perkForm.selectedVehicle.GetTotalUsedPP().ToString();
        }
        private void AmChaff_CheckedChanged(object sender, EventArgs e)
        {
            string chaffText = "";
            int chaffCost = 0;
            if (chaffChk.Checked) { chaffCost = 6; chaffText = "AM Chaff"; }
           
            perkForm.selectedSection.chaffCost = chaffCost;
            perkForm.selectedSection.electronicSystems[5] = chaffText;
            BuildElectricSystems();
            spentPPLbl.Text = perkForm.selectedSection.SectionPPSpent().ToString();
            totalPPLbl.Text = perkForm.selectedVehicle.GetTotalUsedPP().ToString();
        }
        private void mobAct_CheckedChanged(object sender, EventArgs e)
        {
            if (mobillityOneRad.Checked) { perkForm.selectedVehicle.mobCost = (2 * (int)perkForm.selectedVehicle.tCHS); perkForm.selectedVehicle.mobillityadjust = 1; }

            else if (mobillityTwoRad.Checked) { perkForm.selectedVehicle.mobCost = (4 * (int)perkForm.selectedVehicle.tCHS); perkForm.selectedVehicle.mobillityadjust = 2; }
            else { perkForm.selectedVehicle.mobCost = 0; perkForm.selectedVehicle.mobillityadjust = 0; }
            totalPPLbl.Text = perkForm.selectedVehicle.GetTotalUsedPP().ToString();
            perkForm.SetBaseMobillity();
        }

        private void speedModTrk_Scroll(object sender, EventArgs e)
        {

            perkForm.selectedVehicle.moveAdjust = speedModTrk.Value;
            moveLbl.Text = "Move: " + perkForm.selectedVehicle.GetMove().ToString();
            perkForm.selectedVehicle.moveCost = (int)(speedModTrk.Value * perkForm.selectedVehicle.tCHS);
            totalPPLbl.Text = perkForm.selectedVehicle.GetTotalUsedPP().ToString();
            moveCountLbl.Text = speedModTrk.Value.ToString();

        }
        private void PB_CheckedChanged(object sender, EventArgs e)
        {
            string pbType = "";
            if (pb1Rad.Checked) { perkForm.selectedSection.pbCost = .5*perkForm.selectedVehicle.tCHS; pbType = "Power Boost(1)"; }
            else if (pb2Rad.Checked) { perkForm.selectedSection.pbCost = 1* perkForm.selectedVehicle.tCHS; pbType = "Power Boost(2)"; }
            else if (pb3Rad.Checked) { perkForm.selectedSection.pbCost = 2 * perkForm.selectedVehicle.tCHS; pbType = "Power Boost(3)"; }
            else if (pb4Rad.Checked) { perkForm.selectedSection.pbCost = 3 * perkForm.selectedVehicle.tCHS; pbType = "Power Boost(4)"; }
            else if (pb5Rad.Checked) { perkForm.selectedSection.pbCost = 4 * perkForm.selectedVehicle.tCHS; pbType = "Power Boost(5)"; }
            else { perkForm.selectedSection.pbCost = 0; pbType = ""; }
            perkForm.selectedSection.miscSystems[0] = pbType;
            BuildMiscSystems();
            spentPPLbl.Text = perkForm.selectedSection.SectionPPSpent().ToString();
            totalPPLbl.Text = perkForm.selectedVehicle.GetTotalUsedPP().ToString();
        }
        private void StealthSystem_CheckedChanged(object sender, EventArgs e)
        {
            string stealthCoatString = "";
            string holoFieldString = "";
            double SsystemsCost = 0;

            if (sCoatChk.Checked) { stealthCoatString = "Stealth Coating(" + sCoatTrk.Value + ")"; SsystemsCost += sCoatTrk.Value * perkForm.selectedVehicle.tCHS; }
            if (hFieldChk.Checked) { holoFieldString = "HoloField Gen(" + hFieldTrk.Value + ")"; SsystemsCost += hFieldTrk.Value * perkForm.selectedVehicle.tCHS; }
            perkForm.selectedSection.miscSystems[1] = stealthCoatString;
            perkForm.selectedSection.miscSystems[2] = holoFieldString;
            perkForm.selectedSection.sSystemCost = SsystemsCost;
            BuildMiscSystems();
            spentPPLbl.Text = perkForm.selectedSection.SectionPPSpent().ToString();
            totalPPLbl.Text = perkForm.selectedVehicle.GetTotalUsedPP().ToString();
        }
        private void ProtPerk_CheckedChanged(object sender, EventArgs e)
        {
            ProtectionPerkCalc();
        }
        private void Shields_CheckedChanged(object sender, EventArgs e)
        {
            perkForm.selectedSection.shieldPP = 0;
            shieldLbl.Text = "Shields:";
            perkForm.selectedSection.shieldCrCost = 0;
            perkForm.selectedSection.shieldValue = 0;
            if (installShdChk.Checked)
            {
                perkForm.selectedSection.shieldPP = (shieldAdjustTrk.Value +2) * perkForm.selectedSection.secChassis.chasSize;
                perkForm.selectedSection.shieldValue = (int)Math.Ceiling(perkForm.selectedSection.secCore.corSize);
                perkForm.selectedSection.shieldAdjust = shieldAdjustTrk.Value;
                int shields = perkForm.selectedSection.GetShieldTotal();
                perkForm.selectedSection.shieldCrCost = 10000 * shields;
                shieldLbl.Text = "Shields: (" + shields + ")";
            }
            shieldAdjLbl.Text = "Shields Adjustment " + shieldAdjustTrk.Value;
            costLbl.Text = "Cost: " + perkForm.selectedVehicle.GetTotalCost().ToString("N") + " Cr";
            spentPPLbl.Text = perkForm.selectedSection.SectionPPSpent().ToString();
            totalPPLbl.Text = perkForm.selectedVehicle.GetTotalUsedPP().ToString();
        }
        public void ShieldsFormSet()
        {
            if(perkForm.selectedSection.shieldValue == 0) { installShdChk.Checked = false; }
            int shields = perkForm.selectedSection.GetShieldTotal();
            shieldLbl.Text = shieldLbl.Text = "Shields: (" + shields + ")";
            shieldAdjLbl.Text = "Shields Adjustment " + perkForm.selectedSection.shieldAdjust;
            shieldAdjustTrk.Value = perkForm.selectedSection.shieldAdjust;

        }
         public void ProtPerkFormSet()
         {
            protPerksLbl.Text = "Prot Perks: ";
            List<string> protList = new List<string>();
            protList.AddRange(perkForm.selectedSection.protPerkList);
            hepColdChk.Checked = false;
            hepHeatChk.Checked = false;
            hepElecChk.Checked = false;
            hepEMPChk.Checked = false;
            armDiffChk.Checked = false;
            foreach (string n in protList)
             {
                if (n == protList[0]) protPerksLbl.Text += n; else protPerksLbl.Text += ", " + n;
                 if (n == "HEP Cold") { hepColdChk.Checked = true; }
                 if (n == "HEP Heat") { hepHeatChk.Checked = true; }
                 if (n == "HEP Electric") { hepElecChk.Checked = true; }
                 if (n == "Faraday Shield") { hepEMPChk.Checked = true; }
                 if (n == "Diffuse Armor") { armDiffChk.Checked = true; }
             }
           
            protList.Clear();
         }
        public void ElecPerkFormSet()
        {
            string comType = perkForm.selectedSection.comType;
            string senType = perkForm.selectedSection.sensType;

            comRangeTrk.Value = perkForm.selectedSection.comDist;
            comQualTrk.Value = perkForm.selectedSection.comQual;

            senRangeTrk.Value = perkForm.selectedSection.senDist;
            senQualTrk.Value = perkForm.selectedSection.senQual;

            int ecmVal = perkForm.selectedSection.ecmValue;
            int eccmVal = perkForm.selectedSection.eccmValue;

            groundComRad.Checked= false;
            airComRad.Checked = false;
            spaceComRad.Checked = false;

            groundSenRad.Checked = false;
            airSenRad.Checked = false;
            spaceSenRad.Checked = false;

            

            if (comType == "Ground") groundComRad.Checked = true;
            if (comType == "Air") airComRad.Checked = true;
            if (comType == "Space") spaceComRad.Checked = true;

            if (senType == "Ground") groundSenRad.Checked = true;
            if (senType == "Air") airSenRad.Checked = true;
            if (senType == "Space") spaceSenRad.Checked = true;

            if (perkForm.selectedSection.ecmOvr == false)
            {
                ecmChk.Checked = false;
            }
            else { ecmChk.Checked = true; perkForm.selectedSection.ecmOvr = true; }
            ecmTrk.Value = ecmVal;

            if (perkForm.selectedSection.eccmOvr == false)
            {
                eccmChk.Checked = false;
            }
            else { eccmChk.Checked = true; perkForm.selectedSection.eccmOvr = true; }
            eccmTrk.Value = eccmVal;
            ecmLbl.Text = "ECM: " + ecmVal;
            eccmLbl.Text = "ECCM: " + eccmVal;

            if(perkForm.selectedSection.chaffCost==0)
            {
                chaffChk.Checked = false;
            }
            else
            {
                chaffChk.Checked = true;
            }

        }

        private void addManHP_Click(object sender, EventArgs e)
        {
            HardPoint x = new HardPoint("Manipulator Arm");
        }

        private void addLHPBtn_Click(object sender, EventArgs e)
        {
            HardPoint x = new HardPoint("Light HP");
        }

        private void addMHPBtn_Click(object sender, EventArgs e)
        {
            HardPoint x = new HardPoint("Medium HP");
        }

        private void addHHPBtn_Click(object sender, EventArgs e)
        {
            HardPoint x = new HardPoint("Heavy HP");
        }

        private void addUHPBtn_Click(object sender, EventArgs e)
        {
            HardPoint x = new HardPoint("Ultra HP");
        }
        public void freeManCost()
        {
            addmanHPBtn.Click -= new EventHandler(addManHP_Click);
            addmanHPBtn.Click += new EventHandler(addFreeMan);
            manipLbl.Text = "Free Manipulator Arm (1 hp slot)";
        }
        public void addFreeMan(object sender, EventArgs e)
        {
            HardPoint x = new HardPoint("Free Manipulator Arm");
        }
        public void upDateHPslots()
        {
             if (perkForm.selectedSection.hpAdjust + perkForm.selectedSection.secCore.hp >= perkForm.selectedSection.GetMaxHP()) increaseHPBtn.Enabled = false; else increaseHPBtn.Enabled = true;
            if (perkForm.selectedSection.hpAdjust <= 0) decreaseHpBtn.Enabled = false; else decreaseHpBtn.Enabled = true;
            if (perkForm.selectedSection.maxHpAdj >= perkForm.selectedSection.secChassis.chasSize) increaseMaxHpBtn.Enabled = false; else increaseMaxHpBtn.Enabled = true;
            if (perkForm.selectedSection.maxHpAdj <= 0) decreaseMaxHpBtn.Enabled = false; else decreaseMaxHpBtn.Enabled = true;
            availHpLbl.Text = (perkForm.selectedSection.GetHPSlots() - perkForm.selectedSection.GetHPUsed()).ToString();
            usedHpLbl.Text = perkForm.selectedSection.GetHPUsed().ToString();
            maxHpLbl.Text = perkForm.selectedSection.GetMaxHP().ToString();
            spentPPLbl.Text = perkForm.selectedSection.SectionPPSpent().ToString();
            totalPPLbl.Text = perkForm.selectedVehicle.GetTotalUsedPP().ToString();
        }

        private void increaseHPBtn_Click(object sender, EventArgs e)
        {
            perkForm.selectedSection.hpAdjustPP += 3;
            perkForm.selectedSection.hpAdjust++;
            upDateHPslots();
            
        }

        private void decreaseHpBtn_Click(object sender, EventArgs e)
        {
            perkForm.selectedSection.hpAdjustPP -= 3;
            perkForm.selectedSection.hpAdjust--;
            upDateHPslots();
        }

        private void increaseMaxHpBtn_Click(object sender, EventArgs e)
        {
            perkForm.selectedSection.maxHpAdj ++;
            perkForm.selectedSection.hpMaxAdjPP+=4;
            upDateHPslots();
        }

        private void decreaseMaxHpBtn_Click(object sender, EventArgs e)
        {
            perkForm.selectedSection.maxHpAdj --;
            perkForm.selectedSection.hpMaxAdjPP-=4;
            upDateHPslots();
        }
        private void VehicleFlaws_CheckedChanged(object sender, EventArgs e)
        {
            vehFlawLbl.Text = "Vehicle Flaws: ";
            bool isfirst = false;
            List<VehicleFlaw> x = perkForm.selectedVehicle.flawList;
            if (Vf0Chk.Checked) x[0].isAdded = true; else x[0].isAdded = false;
            if (Vf1Chk.Checked) x[1].isAdded = true; else x[1].isAdded = false;
            if (Vf2Chk.Checked) x[2].isAdded = true; else x[2].isAdded = false;
            if (Vf3Chk.Checked) x[3].isAdded = true; else x[3].isAdded = false;
            if (Vf4Chk.Checked) x[4].isAdded = true; else x[4].isAdded = false;
            if (Vf5Chk.Checked) x[5].isAdded = true; else x[5].isAdded = false;
            if (Vf6Chk.Checked) x[6].isAdded = true; else x[6].isAdded = false;
            if (Vf7Chk.Checked) x[7].isAdded = true; else x[7].isAdded = false;
            if (Vf8Chk.Checked) x[8].isAdded = true; else x[8].isAdded = false;
            foreach (VehicleFlaw s in x)
            {
                if (!isfirst && s.isAdded)
                {
                    vehFlawLbl.Text += s.flawName;
                    isfirst = true;
                }
                else if (isfirst && s.isAdded)
                {
                    vehFlawLbl.Text += ", " + s.flawName;
                }
            }
            totalPPLbl.Text = perkForm.selectedVehicle.GetTotalUsedPP().ToString();
        }

            private void VehiclePerks_CheckedChanged(object sender, EventArgs e)
        {
            vehPerkLbl.Text = "Vehicle Perks: ";
            bool isfirst = false;
            List<VehiclePerk> x = perkForm.selectedVehicle.perkList;
            if (vp0Chk.Checked) { x[0].isAdded = true; perkForm.selectedVehicle.isSpace = true; perkForm.selectedVehicle.SetAllLs(); BuildMiscSystems(); } else { x[0].isAdded = false; perkForm.selectedVehicle.isSpace = false; perkForm.selectedVehicle.SetAllLs(); BuildMiscSystems();}
                if (vp1Chk.Checked) x[1].isAdded = true; else x[1].isAdded = false;
            if (vp2Chk.Checked) x[2].isAdded = true; else x[2].isAdded = false;
            if (vp3Chk.Checked) x[3].isAdded = true; else x[3].isAdded = false;
            if (vp4Chk.Checked) x[4].isAdded = true; else x[4].isAdded = false;
            if (vp5Chk.Checked)
            {
                x[5].isAdded = true;
                perkForm.selectedVehicle.engineMove = 2;
                moveLbl.Text = "Move: " + perkForm.selectedVehicle.GetMove();
            }
            else
            {
                x[5].isAdded = false;
                perkForm.selectedVehicle.engineMove = 0;
                moveLbl.Text = "Move: " + perkForm.selectedVehicle.GetMove();
            }
            if (vp6Chk.Checked) x[6].isAdded = true; else x[6].isAdded = false;
            if (vp7Chk.Checked) x[7].isAdded = true; else x[7].isAdded = false;
            if (vp8Chk.Checked) x[8].isAdded = true; else x[8].isAdded = false;
            if (vp9Chk.Checked) x[9].isAdded = true; else x[9].isAdded = false;
            if (vp10Chk.Checked) x[10].isAdded = true; else x[10].isAdded = false;
            if (vp11Chk.Checked) x[11].isAdded = true; else x[11].isAdded = false;
            costLbl.Text = "Cost: " + perkForm.selectedVehicle.GetTotalCost().ToString("N") + " Cr";
            foreach (VehiclePerk s in x)
            {
                if(!isfirst && s.isAdded)
                {
                    vehPerkLbl.Text += s.perkName;
                    isfirst = true;
                }
                else if(isfirst && s.isAdded)
                {
                    vehPerkLbl.Text += ", " + s.perkName;
                }
            }
            totalPPLbl.Text = perkForm.selectedVehicle.GetTotalUsedPP().ToString();
        }
            private void ProtectionPerkCalc()
        {
            List<string> x = perkForm.selectedSection.protPerkList;
            x.Clear();
            if (hepColdChk.Checked) { x.Add("HEP Cold"); }
            if (hepHeatChk.Checked) { x.Add("HEP Heat"); }
            if (hepElecChk.Checked) { x.Add("HEP Electric"); }
            if (hepEMPChk.Checked) { x.Add("Faraday Shield"); }
            if (armDiffChk.Checked) { x.Add("Diffuse Armor"); }
            protPerksLbl.Text = "Prot Perks: ";
            perkForm.selectedSection.protPPCost = 0;
            for (int con = 0; con < x.Count; con++)
            {
                if (con != 0) { protPerksLbl.Text += ", "; }
                protPerksLbl.Text += x[con];
                perkForm.selectedSection.protPPCost += Math.Ceiling(perkForm.selectedSection.secChassis.chasSize);

            }
            if (strongArmTrk.Value > 0 && strongArmCmb.SelectedItem != null)
            {
                string strArmStr = "Strong Armor " + strongArmCmb.SelectedItem.ToString() + "(" + (perkForm.selectedSection.totalArmor + strongArmTrk.Value).ToString() + ")";
                x.Add(strArmStr);
                if (x.IndexOf(strArmStr) > 0) { protPerksLbl.Text += ", "; }
                protPerksLbl.Text += strArmStr;
                strArmLbl.Text = "Strong Armor Facing " + strongArmTrk.Value;
                perkForm.selectedSection.protPPCost += (.5 * Math.Ceiling(perkForm.selectedSection.secChassis.chasSize)) * strongArmTrk.Value;
            }
            perkForm.selectedSection.protPPCost += (perkForm.selectedSection.ejectSeat * 3) + (perkForm.selectedSection.ejectPod * 6);
            
            if (perkForm.selectedSection.ejectSeat > 0)
            {
                string ejectorS = "Eject Seat (" + perkForm.selectedSection.ejectSeat + ")";
                x.Add(ejectorS);
                if (x.IndexOf(ejectorS) > 0) { protPerksLbl.Text += ", "; }
                protPerksLbl.Text += ejectorS;
            }
            if (perkForm.selectedSection.ejectPod > 0)
            {
                string ejectorP = "Eject Pod (" + perkForm.selectedSection.ejectPod + ")";
                x.Add(ejectorP);
                if (x.IndexOf(ejectorP) > 0) { protPerksLbl.Text += ", "; }
                protPerksLbl.Text += ejectorP;
            }
            spentPPLbl.Text = perkForm.selectedSection.SectionPPSpent().ToString();
            totalPPLbl.Text = perkForm.selectedVehicle.GetTotalUsedPP().ToString();
            if (perkForm.selectedSection.ejectSeat <= 0) removeSeatBtn.Enabled = false; else removeSeatBtn.Enabled = true;
            if (perkForm.selectedSection.ejectPod <= 0) removePodBtn.Enabled = false; else removePodBtn.Enabled = true;
        }

        private void addSeatBtn_Click(object sender, EventArgs e)
        {
            perkForm.selectedSection.ejectSeat++;
            ProtectionPerkCalc();
        }

        private void removeSeatBtn_Click(object sender, EventArgs e)
        {
           
            perkForm.selectedSection.ejectSeat--;
            ProtectionPerkCalc();
        }

        private void addPodBtn_Click(object sender, EventArgs e)
        {
            perkForm.selectedSection.ejectPod++;
            ProtectionPerkCalc();
        }

        private void removePodBtn_Click(object sender, EventArgs e)
        {
            perkForm.selectedSection.ejectPod--;
            ProtectionPerkCalc();
        }
        public void CompartmentSpaceAdjust()
        {
            compSpaceLbl.Text = "Compartment Space: " + perkForm.selectedSection.GetCompSize().ToString();
            maxCompSpaceLbl.Text = "Max Comp Space: " + perkForm.selectedSection.secChassis.maxCompSize.ToString();
            availCompSpaceLbl.Text = "Available Comp Space: " + (perkForm.selectedSection.GetCompSize()-perkForm.selectedSection.GetUsedCompart());
            spentPPLbl.Text = perkForm.selectedSection.SectionPPSpent().ToString();
            totalPPLbl.Text = perkForm.selectedVehicle.GetTotalUsedPP().ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((perkForm.selectedSection.secChassis.maxCompSize - perkForm.selectedSection.GetCompSize()) > 0) perkForm.selectedSection.compartAdjust++;
            CompartmentSpaceAdjust();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (perkForm.selectedSection.compartAdjust > 0) perkForm.selectedSection.compartAdjust--;
            CompartmentSpaceAdjust();
        }

        private void lsAddBtn_Click(object sender, EventArgs e)
        {
            perkForm.selectedSection.lsCount+=2;
            perkForm.selectedSection.lsCost++;
            perkForm.selectedSection.SetLsString();
            BuildMiscSystems();
            spentPPLbl.Text = perkForm.selectedSection.SectionPPSpent().ToString();
            totalPPLbl.Text = perkForm.selectedVehicle.GetTotalUsedPP().ToString();
        }

        private void lsRmbBtn_Click(object sender, EventArgs e)
        {
            if(perkForm.selectedSection.lsCost >0)
            {
                perkForm.selectedSection.lsCount -= 2;
                perkForm.selectedSection.lsCost--;
                perkForm.selectedSection.SetLsString();
                BuildMiscSystems();
                spentPPLbl.Text = perkForm.selectedSection.SectionPPSpent().ToString();
                totalPPLbl.Text = perkForm.selectedVehicle.GetTotalUsedPP().ToString();
            }
        }

        private void fireContChk_CheckedChanged(object sender, EventArgs e)
        {
            string fireCont = "";
            if (fireContChk.Checked) { fireCont = "Fire Control"; perkForm.selectedSection.fireCcost = 2; } else perkForm.selectedSection.fireCcost = 0;
            perkForm.selectedSection.miscSystems[4] = fireCont;
            BuildMiscSystems();
            spentPPLbl.Text = perkForm.selectedSection.SectionPPSpent().ToString();
            totalPPLbl.Text = perkForm.selectedVehicle.GetTotalUsedPP().ToString();

        }
        private void PC_CheckedChanged(object sender, EventArgs e)
        {
            int coreValue;
            if (amLargeChk.Checked) { coreValue = (int)(Math.Round(perkForm.selectedSection.sectionPP * .6)); perkForm.selectedSection.pcCost = 10000000; }
            else if (amMedChk.Checked) {coreValue = (int)(Math.Round(perkForm.selectedSection.sectionPP * .4)); perkForm.selectedSection.pcCost = 4000000; }
            else if (amSmallChk.Checked) {coreValue = (int)(Math.Round(perkForm.selectedSection.sectionPP * .2)); perkForm.selectedSection.pcCost = 1000000; }
            else {coreValue = (int)(Math.Round(perkForm.selectedSection.sectionPP * 0));perkForm.selectedSection.pcCost = 0; }
            perkForm.selectedSection.AdjustMaxPP(coreValue);
            TotPerkPointLbl.Text = "Total Perk Points: " + perkForm.selectedVehicle.totalPP.ToString();
            costLbl.Text = "Cost: " + perkForm.selectedVehicle.GetTotalCost().ToString("N") + " Cr";
        }

        private void VehNameLbl_Click(object sender, EventArgs e)
        {

        }

        private void moveLbl_TextChanged(object sender, EventArgs e)
        {
            depRangeLbl.Text = "Dep Range: " + perkForm.selectedVehicle.bpTotal;
        }

    }

}
