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
        public VehWeapon VehicleWeapon;
        public bool holdHPform = false;
        string mountType;
        public string hpString;
        int inCount;
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
            hpString = weaponAbrev;
            PopHPTbl();
            sectionForm.upDateHPslots();


        }
        public HardPoint()
        {

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
                if (!holdHPform && mountType != null) hpString = mountType[0] + " " + weaponAbrev;
                else hpString = weaponAbrev;
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
            //MiscTools.remove_row(sectionForm.hardPointTbl, index+1);
            sectionForm.upDateHPslots();
            PopHPTbl();
        }
        public void PopHPTbl()
        {
            sectionForm.hardPointTbl.RowCount = 1;
            RowStyle temp = sectionForm.hardPointTbl.RowStyles[0];
            sectionForm.hardPointTbl.Controls.Clear();
            sectionForm.hardPointTbl.Controls.Add(new Label() { Text = "HP Type", Dock = DockStyle.Fill, Font = new Font("Arial",7, FontStyle.Bold) },0,0);
            sectionForm.hardPointTbl.Controls.Add(new Label() { Text = "     Weapon Name    ", Dock = DockStyle.Fill, Font = new Font("Arial", 7, FontStyle.Bold) }, 1, 0);
            sectionForm.hardPointTbl.Controls.Add(new Label() { Text = "ACC", Dock = DockStyle.Fill, Font = new Font("Arial", 7, FontStyle.Bold) }, 2, 0);
            sectionForm.hardPointTbl.Controls.Add(new Label() { Text = "DMG", Dock = DockStyle.Fill, Font = new Font("Arial", 7, FontStyle.Bold) }, 3, 0);
            sectionForm.hardPointTbl.Controls.Add(new Label() { Text = "ROF", Dock = DockStyle.Fill, Font = new Font("Arial", 7, FontStyle.Bold) }, 4, 0);
            sectionForm.hardPointTbl.Controls.Add(new Label() { Text = "AMMO", Dock = DockStyle.Fill, Font = new Font("Arial", 7, FontStyle.Bold) }, 5, 0);
            sectionForm.hardPointTbl.Controls.Add(new Label() { Text = " RANGE ", Dock = DockStyle.Fill, Font = new Font("Arial", 7, FontStyle.Bold) }, 6, 0);
            sectionForm.hardPointTbl.Controls.Add(new Label() { Text = "    Special    ", Dock = DockStyle.Fill, Font = new Font("Arial", 7, FontStyle.Bold) }, 7, 0);
            int count = 1;
            List <HardPoint> mList= mainForm.selectedSection.hpList;
            foreach(HardPoint x in mList)
            {
                x.inCount = count;
                //  hpString="";
               // if (!x.holdHPform && x.mountType != null) hpString = x.mountType[0] + " "+x.weaponAbrev;
               // else x.hpString =x.weaponAbrev;
                ///////////Add new Object here
                rowCreation row = new rowCreation(x, count);


                //if ((VehWeapon)weaponSelect.SelectedItem != x.VehicleWeapon)
                //forcing for now                
                count++;
                
               
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
        
       
        // Create new object that does all perhaps
    }
    public class rowCreation
    {
        Main mainForm;
        SectionProperties sectionForm;
        ComboBox weaponSelect;
        HardPoint inHp;
        Label[] controls = new Label[6];
        public int col;
        public rowCreation(HardPoint ih,int c)
        {
            mainForm = (Main)Application.OpenForms[0];
            sectionForm = mainForm.SectionForm;
            col = c;
            inHp = ih;
            Label hpTypLbl = new Label()
            {
                Dock = DockStyle.Fill,
                Text = inHp.hpString
            };
            weaponSelect = new ComboBox()
            {
                Dock = DockStyle.Fill,
                DisplayMember = "Text",
                ValueMember = "Value"
            };
            weaponSelect.Items.Add(new { Text = Main.availWeapList[0].Name, Value = Main.availWeapList[0]});
            foreach (VehWeapon v in Main.availWeapList)
            {
                if(inHp.weaponAbrev ==v.HPTYPE)
                weaponSelect.Items.Add(new { Text = v.Name, Value = v});
            }
            if (inHp.VehicleWeapon != null)
            {
                weaponSelect.SelectedItem = inHp.VehicleWeapon;
                weaponSelect.Text = inHp.VehicleWeapon.Name;
            }

            else
                weaponSelect.SelectedItem = weaponSelect.Items[0];
            weaponSelect.SelectedIndexChanged += new EventHandler(VehWeapon_Selection);
            sectionForm.hardPointTbl.RowCount++;
            sectionForm.hardPointTbl.RowStyles.Add(new RowStyle(SizeType.Absolute, 25f));
            sectionForm.hardPointTbl.Controls.Add(hpTypLbl, 0, col);
            if (inHp.holdHPform)
            {
                inHp.VehicleWeapon = new VehWeapon(inHp.weaponString, "", "", "", "", "", "", "", "", "", 0, 0);
                sectionForm.hardPointTbl.Controls.Add(new Label()
                {
                    Dock = DockStyle.Fill,
                    Text = inHp.weaponString
                });
            }
            else
            {
                sectionForm.hardPointTbl.Controls.Add(weaponSelect, 1, col);
            }
            for(int i = 0; i < controls.Length;i++)
            {
                controls[i] = new Label()
                {
                    Dock = DockStyle.Fill,
                    Text = "",
                    Font = new Font("Arial", 7, FontStyle.Regular)
                };
            }

            sectionForm.hardPointTbl.Controls.Add(controls[0], 2, col);
            sectionForm.hardPointTbl.Controls.Add(controls[1], 3, col);
            sectionForm.hardPointTbl.Controls.Add(controls[2], 4, col);
            sectionForm.hardPointTbl.Controls.Add(controls[3], 5, col);
            sectionForm.hardPointTbl.Controls.Add(controls[4], 6, col);
            sectionForm.hardPointTbl.Controls.Add(controls[5], 7, col);

            if (inHp.VehicleWeapon != null)
            {
                controls[0].Text = inHp.VehicleWeapon.ACC;
                controls[1].Text = inHp.VehicleWeapon.DMG;
                controls[2].Text = inHp.VehicleWeapon.ROF;
                controls[3].Text = inHp.VehicleWeapon.AMMO + " / " + inHp.VehicleWeapon.AMMO_TYPE;
                controls[4].Text = inHp.VehicleWeapon.Range;
                controls[5].Text = inHp.VehicleWeapon.Special;
                
            }
            void VehWeapon_Selection(object sender, EventArgs e)
            {

                inHp.VehicleWeapon = (weaponSelect.SelectedItem as dynamic).Value;
                    sectionForm.costLbl.Text = "Cost: " + mainForm.selectedVehicle.GetTotalCost().ToString("N") + " Cr";
                    controls[0].Text = inHp.VehicleWeapon.ACC;
                    controls[1].Text = inHp.VehicleWeapon.DMG;
                    controls[2].Text = inHp.VehicleWeapon.ROF;
                    controls[3].Text = inHp.VehicleWeapon.AMMO+ " / " + inHp.VehicleWeapon.AMMO_TYPE;
                    controls[4].Text = inHp.VehicleWeapon.Range;
                    controls[5].Text = inHp.VehicleWeapon.Special;
                    //inHp.PopHPTbl();
            }
        }
    }
}
