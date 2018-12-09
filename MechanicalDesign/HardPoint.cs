using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MechanicalDesign
{
    public class HardPoint
    {
        public double ppCost=0;
        public int hpSlots;
        public double mountCost;
        public string weaponString;
        public string weaponAbrev;
        bool holdHPform = false;
        string mountType;
        Main mainForm;
        SectionProperties sectionForm;
        GroupBox hpGrpBox;
        ComboBox hpcomboBox;

        public HardPoint(string type)
        {
            mainForm = (Main)Application.OpenForms[0];
            sectionForm = mainForm.SectionForm;
            weaponString = type;
            switch (type)
            {
                case "Manipulator Arm":
                    hpSlots = 1;
                    holdHPform = true;
                    ppCost = (.5 * Math.Ceiling(mainForm.selectedSection.secChassis.chasSize));
                    weaponAbrev = "C-Arm";
                    break;
                case "Free Manipulator Arm":
                    hpSlots = 1;
                    weaponString = "Manipulator Arm";
                    holdHPform = true;
                    ppCost = 0;
                    weaponAbrev = "C-Arm";
                    break;
                case "Light HP":
                    hpSlots =1;
                    ppCost = 2;
                    weaponAbrev = "LHP";
                    break;
                case "Medium HP":
                    hpSlots = 2;
                    ppCost = 4;
                    weaponAbrev = "MHP";
                    break;
                case "Heavy HP":
                    hpSlots = 4;
                    ppCost = 8;
                    weaponAbrev = "HHP";
                    break;
                case "Ultra HP":
                    hpSlots = 8;
                    ppCost = 20;
                    weaponAbrev = "UHP";
                    break;
                default:
                    hpSlots = 0;
                    ppCost = 0;
                    break;
            }
            HPform();
            if (holdHPform) hpcomboBox.Enabled = false;
            mainForm.selectedSection.hpList.Add(this);
            mainForm.selectedSection.SetHPperkCost();
            sectionForm.spentPPLbl.Text = mainForm.selectedSection.SectionPPSpent().ToString();
            sectionForm.totalPPLbl.Text = mainForm.selectedVehicle.GetTotalUsedPP().ToString();
            PopHPTbl();
            sectionForm.upDateHPslots();


        }
        public void HPform()
        {
            string[] hpOptions = new string[] { "Fixed", "Gimbal", "Turret" };
            hpGrpBox = new GroupBox()
            {
                Size = new System.Drawing.Size(185, 51),
                BackColor = Color.FromKnownColor(KnownColor.WhiteSmoke),
                Text = weaponString
            };
            hpcomboBox = new ComboBox()
            {
                Size = new Size(107, 21),
                Location = new Point(6, 19),
            };
            hpcomboBox.Items.AddRange(hpOptions);
            hpcomboBox.Text="Fixed";
            hpcomboBox.SelectedIndexChanged += (o, i) =>
            {
                if(hpcomboBox.SelectedItem == (Object)"Fixed")
                {
                    mountCost = 0;
                    mountType = "Fixed";
                }
                else if (hpcomboBox.SelectedItem == (Object)"Gimbal")
                {
                    mountCost = .5*ppCost;
                    mountType = "Gimbal";
                }
                else if (hpcomboBox.SelectedItem == (Object)"Turret")
                {
                    mountCost = ppCost;
                    mountType = "Turret";
                }
                else
                {
                    mountCost = 0;
                }
                mainForm.selectedSection.SetHPperkCost();
                sectionForm.spentPPLbl.Text = mainForm.selectedSection.SectionPPSpent().ToString();
                sectionForm.totalPPLbl.Text = mainForm.selectedVehicle.GetTotalUsedPP().ToString();
                PopHPTbl();
            };
            Button removeHPBtn = new Button()
            {
                Font = new Font("TESLA", 8, FontStyle.Bold),
                AutoSize = false,
                Location = new Point(156,12),
                Size = new Size(23,19),
                Text = "X"
            };
            removeHPBtn.Click += (o, i) =>
            {
                RemoveHP();
            };
            hpGrpBox.Controls.Add(hpcomboBox);
            hpGrpBox.Controls.Add(removeHPBtn);
            sectionForm.hardPointLayout.Controls.Add(hpGrpBox);
            
        }
        public double GetPPTotal()
        {
            return ppCost + mountCost;
        }
        public void RemoveHP()
        {
            int index;
            sectionForm.hardPointLayout.Controls.Remove(hpGrpBox);
           index= mainForm.selectedSection.hpList.IndexOf(this);
           mainForm.selectedSection.hpList.Remove(this);
            mainForm.selectedSection.SetHPperkCost();
            sectionForm.spentPPLbl.Text = mainForm.selectedSection.SectionPPSpent().ToString();
            sectionForm.totalPPLbl.Text = mainForm.selectedVehicle.GetTotalUsedPP().ToString();
            MiscTools.remove_row(sectionForm.hardPointTbl, index+1);
            sectionForm.upDateHPslots();
        }
        public void PopHPTbl()
        {
            sectionForm.hardPointTbl.RowCount = 1;
            RowStyle temp = sectionForm.hardPointTbl.RowStyles[0];
            sectionForm.hardPointTbl.Controls.Clear();
            sectionForm.hardPointTbl.Controls.Add(new Label() { Text = "HP Type", Dock = DockStyle.Fill },0,0);
            sectionForm.hardPointTbl.Controls.Add(new Label() { Text = "     Weapon Name    ", Dock = DockStyle.Fill }, 1, 0);
            sectionForm.hardPointTbl.Controls.Add(new Label() { Text = "ACC", Dock = DockStyle.Fill}, 2, 0);
            sectionForm.hardPointTbl.Controls.Add(new Label() { Text = "DMG", Dock = DockStyle.Fill }, 3, 0);
            sectionForm.hardPointTbl.Controls.Add(new Label() { Text = "ROF", Dock = DockStyle.Fill}, 4, 0);
            sectionForm.hardPointTbl.Controls.Add(new Label() { Text = "AMMO", Dock = DockStyle.Fill }, 5, 0);
            sectionForm.hardPointTbl.Controls.Add(new Label() { Text = " RANGE ", Dock = DockStyle.Fill }, 6, 0);
            sectionForm.hardPointTbl.Controls.Add(new Label() { Text = "    Special    ", Dock = DockStyle.Fill}, 7, 0);
            int count = 1;
            List <HardPoint> mList= mainForm.selectedSection.hpList;
            foreach(HardPoint x in mList)
            {
                string hpString="";
                if (!x.holdHPform && x.mountType != null) hpString += x.mountType[0] + " ";
                hpString += x.weaponAbrev;

                Label hpTypLbl = new Label()
                {
                    Dock = DockStyle.Fill,
                    Text = hpString
                };
                sectionForm.hardPointTbl.RowCount++;
                sectionForm.hardPointTbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 20f));
                sectionForm.hardPointTbl.Controls.Add(hpTypLbl, 0,count);
                count++;

                //rowSize += 100;
            }
        }
        public void updateHP()
        {
            sectionForm.hardPointLayout.Controls.Clear();
            foreach (HardPoint x in mainForm.selectedSection.hpList)
            {
                x.HPform();
                if (!x.holdHPform) x.hpcomboBox.Enabled = false;
            }
                PopHPTbl();
        }
        public static void ClearTable(SectionProperties s)
        {
            s.hardPointLayout.Controls.Clear();
            for(int i = 0; i<= s.hardPointTbl.RowCount; i++)
            {
                MiscTools.remove_row(s.hardPointTbl, 1);
            }
        }
    }
}
