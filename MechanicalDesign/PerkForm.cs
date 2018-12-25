using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MechanicalDesign
{
    public class PerkForm
    {

        public Vehicle selectedVehicle;
        public Vehicle.VehicleSection selectedSection;

        public double chasSize=0;
        public double corSize=0;
        public double tCHS=0;
        public int totalSpeed=0;
        public double maxPP=0;
        public double ppSpent=0;

        public static Main mainForm;
        public static SectionProperties sectionForm;

        


        public void UpdateForm(Vehicle v, Vehicle.VehicleSection s)
        {
            mainForm = (Main)Application.OpenForms[0];
            sectionForm = mainForm.SectionForm;
            selectedVehicle = v;
            selectedSection = s;
            if (mainForm.vehicleType == "Aero/Space") sectionForm.Vf8Chk.Enabled = true;
            chasSize = s.secChassis.chasSize;
            corSize = s.secCore.corSize;

            sectionForm.buildQualLbl.Text = "Build Quality " + s.quality + " (" + s.buildRoll + ")";
            sectionForm.pCPXLbl.Text = "CPX(" +selectedVehicle.pilotCPX+ ")";
            sectionForm.mCPXLbl.Text = "MCPX(" + selectedVehicle.mechCPX + ")";
            v.setTCHS();
            v.SetTotalPP();
            tCHS = v.tCHS;
            VehiclePerk.PopPerkList(v);
            VehicleFlaw.PopFlawList(v);
            //
            sectionForm.upDateHPslots();
            sectionForm.TotPerkPointLbl.Text = "Total Perk Points: "+v.totalPP.ToString();
            sectionForm.TempDescLbl.Text = tempLblBuilder();
            sectionForm.spentPPLbl.Text = selectedSection.SectionPPSpent().ToString();
            sectionForm.totalPPLbl.Text = selectedVehicle.GetTotalUsedPP().ToString();
            sectionForm.pwrCrLbl.Text = "Power Core: "+selectedSection.secCore.corSize.ToString();

            HardPoint.updateHP();

            VehicleCheck();
            SetArmor();
            sectionForm.armAdjustTrk.Value = selectedSection.armorAdjust;

            SetBaseMobillity();
            

            sectionForm.ElecPerkFormSet();

            sectionForm.moveLbl.Text = "Move: " + selectedVehicle.GetMove();
            sectionForm.costLbl.Text = "Cost: " + selectedVehicle.GetTotalCost().ToString("N") + " Cr";
           
             sectionForm.ShieldsFormSet();
            sectionForm.ProtPerkFormSet();
            selectedSection.PopSecCompList();
            sectionForm.CompartmentSpaceAdjust();
            sectionForm.compartmentLayout.Controls.Clear();
            sectionForm.sectionCompLayout.Controls.Clear();
            foreach (Compartment x in selectedSection.compList)
            {
                x.AddCompButton();
                x.addButtons();
            }
            sectionForm.BuildElectricSystems();
            sectionForm.BuildMiscSystems();


        }
        public String tempLblBuilder()
        {
            String templateDesc = "Size: ("+tCHS+") "+selectedVehicle.templateName;
            return templateDesc;
        }
        public void SetArmor(int x)
        {
            
            selectedSection.armorAdjust = x;
            selectedSection.totalArmor = (int)selectedSection.secChassis.baseArmor + selectedSection.armorAdjust;
            sectionForm.ArmorLbl.Text = "Armor: " + selectedSection.totalArmor.ToString();
        }
        public void SetArmor()
        {
            selectedSection.totalArmor = (int)selectedSection.secChassis.baseArmor + selectedSection.armorAdjust;
            sectionForm.ArmorLbl.Text = "Armor: " + selectedSection.totalArmor.ToString();
        }
        public void SetBaseMobillity()
        {
            if (selectedVehicle.fixedmaneuver == 0) selectedVehicle.maneuver = selectedSection.secChassis.baseMan;
            else selectedVehicle.maneuver = selectedVehicle.fixedmaneuver;
            sectionForm.manLbl.Text="Maneuver: "+selectedVehicle.GetFinalMan().ToString();
        }
        public void VehicleCheck()
        {
            if (selectedVehicle.isBike)
            {
                sectionForm.Vf0Chk.Checked = true;
                sectionForm.Vf0Chk.Enabled = false;
                sectionForm.mobillityOneRad.Checked = true;
                sectionForm.noMobRad.Enabled = false;
                selectedVehicle.tempPPadj = -1 * (2 * selectedVehicle.tCHS);
            }
            if (selectedVehicle.isCBike)
            {
                sectionForm.mobillityOneRad.Checked = true;
                sectionForm.noMobRad.Enabled = false;
                selectedVehicle.tempPPadj = -1 * (2 * selectedVehicle.tCHS);
            }
            if (selectedVehicle.isScout)
            {
                sectionForm.sCoatChk.Checked = true;
                sectionForm.sCoatChk.Enabled = false;
                sectionForm.mobillityOneRad.Checked = true;
                sectionForm.noMobRad.Enabled = false;
                selectedVehicle.tempPPadj = -1 * (3 * selectedVehicle.tCHS);
            }
            if (selectedVehicle.isFighter)
            {
                sectionForm.mobillityOneRad.Checked = true;
                sectionForm.noMobRad.Enabled = false;
                selectedVehicle.tempPPadj = -1 * (2 * selectedVehicle.tCHS);
            }
            if(selectedVehicle.isCargo)
            {
                sectionForm.vp0Chk.Checked = true;
                sectionForm.vp0Chk.Enabled = false;
                selectedVehicle.tempPPadj = -1 * (selectedVehicle.tCHS);
            }
            if (selectedVehicle.isDropship)
            {
                sectionForm.vp0Chk.Checked = true;
                sectionForm.vp0Chk.Enabled = false;
                sectionForm.noAccBtn.Enabled = false;
                sectionForm.vp7Chk.Enabled = false;
                sectionForm.vp8Chk.Checked = true;
                selectedVehicle.tempPPadj = -1 * (selectedVehicle.tCHS + 5);
            }
            if (selectedVehicle.isCapital)
            {
                sectionForm.vp0Chk.Checked = true;
                sectionForm.vp0Chk.Enabled = false;
                sectionForm.vp8Chk.Checked = true;
                selectedVehicle.tempPPadj = -1 * (selectedVehicle.tCHS *.5);
            }













     
        }
    }
}
