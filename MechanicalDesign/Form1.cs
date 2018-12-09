using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;
//Additionally, you will frequently add one or more of these using statements:
using MongoDB.Driver.Linq;

namespace MechanicalDesign
{
    public partial class Main : Form
    {
        private Templates templateList = new Templates();
        public Vehicle selectedVehicle;
        public string vehicleType;
        public MoveType selectedMoveType;
        public Vehicle.VehicleSection selectedSection;
        private List<Vehicle> currentList;
        public PopChassis chs = new PopChassis() ;
        public PopCore crs = new PopCore();
        public int skillResult=0;
        public SectionProperties SectionForm = new SectionProperties();
        public PerkForm perkForm = new PerkForm();

        public Core selectedCore;
        public Chassis selectedChassis;
        public static Main mainForm;
        public SaveFileDialog printVehicleXml = new SaveFileDialog();
        private string connectionString;
        public MongoClient mongoClient;



        public Main()
        {
            InitializeComponent();
            mainForm = this;
            connectionString = "mongodb+srv://Cshmnymc:<Killer123$>@silcodb-0xgif.mongodb.net/test?retryWrites=true";
            mongoClient = new MongoClient(connectionString);
            var silcoDB = mongoClient.GetDatabase("SilcoStat");
        }

        public void vehicleTypeComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            templateTypeComBox.Items.Clear();
            currentList = templateList.returnTemplate((String)vehicleTypeComBox.SelectedItem);
            vehicleType = (String)vehicleTypeComBox.SelectedItem;
           
            foreach (Vehicle n in currentList)
            {
                templateTypeComBox.Items.Add(n.GetTemplateDescription());
            }
        
        }

        public void templateTypeComBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedVehicle = currentList[templateTypeComBox.SelectedIndex];
            if (vehicleType == "Walker")
            {
                ExoMove.PopExoMove(selectedVehicle);
                moveTypeCmb.Visible = true;
                moveTypeLbl.Visible = true;
                moveTypeCmb.Items.Clear();
                foreach (MoveType n in ExoMove.exoMoveList)
                {
                    moveTypeCmb.Items.Add(n.name);
                }
            }
            else if (vehicleType == "Ground")
            {
                GroundMove.PopGroundMove(selectedVehicle);
                moveTypeCmb.Visible = true;
                moveTypeLbl.Visible = true;
                moveTypeCmb.Items.Clear();
                foreach (MoveType n in GroundMove.groundMoveList)
                {
                    moveTypeCmb.Items.Add(n.name);
                }
            }
            else
            {
                moveTypeCmb.Visible = false;
                moveTypeLbl.Visible = false;
                selectedMoveType = new Generic(selectedVehicle);
            }

        }

     

        public void buildButton_Click(object sender, EventArgs e)
        {
            selectedVehicle.PopSections();
            creatorLayout.Controls.Clear();
            selectedVehicle.TempBonusses();
            selectedMoveType.selectMove();
            foreach (Vehicle.VehicleSection currentSection in selectedVehicle.sectionList)
            {
                Label baseSpeed = new Label
                {
                    Text = "Base Speed",
                    Location = new Point(89, 85),
                    Font = new Font(Font, FontStyle.Regular),
                    AutoSize = true
                };
                Label totalCost = new Label
                {
                    Text = "Base Cost",
                    Location = new Point(89, 100),
                    Font = new Font(Font, FontStyle.Regular),
                    AutoSize = true
                };
                /////////////// CHASSIS LABELS /////////////////////////
                Label baseArmor = new Label
                {
                    Location = new Point(4,23),
                    Font = new Font(Font, FontStyle.Regular),
                    Margin = new Padding(0),
                    Padding = new Padding(0),
                    AutoSize = true
                };
                Label baseMan = new Label
                {
                    Location = new Point(4, 36),
                    Font = new Font(Font, FontStyle.Regular),
                    Margin = new Padding(0),
                    Padding = new Padding(0),
                    AutoSize = true
                };
                Label maxHP = new Label
                {
                    Location = new Point(4, 49),
                    Font = new Font(Font, FontStyle.Regular),
                    Margin = new Padding(0),
                    Padding = new Padding(0),
                    AutoSize = true
                };
                Label compMax = new Label
                {
                    Location = new Point(4, 62),
                    Font = new Font(Font, FontStyle.Regular),
                    Margin = new Padding(0),
                    Padding = new Padding(0),
                    AutoSize = true
                };
                Label chasCost = new Label
                {
                    Location = new Point(4, 75),
                    Font = new Font(Font, FontStyle.Regular),
                    Margin = new Padding(0),
                    Padding = new Padding(0),
                    AutoSize = true
                };

                //////////////////////////CORE LABELS////////////////

                Label perkPoints = new Label
                {
                    Location = new Point(4, 23),
                    Font = new Font(Font, FontStyle.Regular),
                    Margin = new Padding(0),
                    Padding = new Padding(0),
                    AutoSize = true
                };
                Label maxArmor = new Label
                {
                    Location = new Point(4, 36),
                    Font = new Font(Font, FontStyle.Regular),
                    Margin = new Padding(0),
                    Padding = new Padding(0),
                    AutoSize = true
                };
                Label hpSlots = new Label
                {
                    Location = new Point(4, 49),
                    Font = new Font(Font, FontStyle.Regular),
                    Margin = new Padding(0),
                    Padding = new Padding(0),
                    AutoSize = true
                };
                Label crCost = new Label
                {
                    Location = new Point(4, 62),
                    Font = new Font(Font, FontStyle.Regular),
                    Margin = new Padding(0),
                    Padding = new Padding(0),
                    AutoSize = true
                };

                ////////////////CPX PANEL/////////////////////
                Label pilCPX = new Label
                {
                    Location = new Point(1, 4),
                    Font = new Font(Font, FontStyle.Regular),
                    Margin = new Padding(0),
                    Padding = new Padding(0),
                    AutoSize = true
                };
                Label mechCPX = new Label
                {
                    Location = new Point(64, 4),
                    Font = new Font(Font, FontStyle.Regular),
                    Margin = new Padding(0),
                    Padding = new Padding(0),
                    AutoSize = true
                };
                ComboBox chasBox = new ComboBox();
                chasBox.Location = new Point(51, 25);
                chs.PrintChasList(chasBox, selectedVehicle);
                chasBox.SelectedIndexChanged += (o, i) =>
                {
                    //selectedChassis = chs.ChasList[chasBox.SelectedIndex];
                    foreach (Chassis c in chs.ChasList)
                    {
                        if (c.chasName == chasBox.SelectedItem.ToString())
                        {
                            currentSection.secChassis = c;
                            selectedChassis = c;
                        }
                    }
                    baseArmor.Text = "Base Armor: " + currentSection.secChassis.baseArmor.ToString();
                    baseMan.Text = "Base Mnv: " + currentSection.secChassis.baseMan.ToString();
                    maxHP.Text = "Max HP: " + currentSection.secChassis.maxHP.ToString();
                    compMax.Text = "Comp/Max: " + currentSection.secChassis.compSize.ToString() + "/ " + currentSection.secChassis.maxCompSize.ToString() + "M^2";
                    chasCost.Text = "Cost: " + currentSection.secChassis.chasCost.ToString("n0") + " Cr";
                    if (currentSection.secCore != null)
                    {
                        mechCPX.Text = "Mech CPX: " + mechCPXTest().ToString();
                        baseSpeed.Text = "Base Speed: " + baseSpeedTest().ToString();
                        totalCost.Text = "Base Cost: " + (currentSection.secChassis.chasCost + currentSection.secCore.corCost).ToString("n0") + " Cr";
                    }
                };
                /////////SECTION GROUP BOX////////////////////
                GroupBox sectionGrpBox = new GroupBox
                {
                    Size = new Size(505, 120),
                    Text = currentSection.sectionName,
                    Name = currentSection.sectionName,
                    //default color
                    BackColor = Color.FromKnownColor(KnownColor.Control)
            };
                sectionGrpBox.MouseClick += (o, i) =>
                {
                    if (chasBox.Enabled == false)
                    {
                        selectedSection = currentSection;

                        // foreach (Vehicle.VehicleSection n in selectedVehicle.sectionList)
                        // {
                        // if (n.sectionName == sectionGrpBox.Name)
                        // {
                        //  selectedSection = n;
                        // }
                        //}
                        perkForm.UpdateForm(selectedVehicle, selectedSection);
                        SectionForm.testLabelName.Text = selectedSection.sectionName;
                        foreach (GroupBox n in creatorLayout.Controls)
                        {
                            if (n.Name == selectedSection.sectionName)
                            {
                                n.BackColor = Color.FromKnownColor(KnownColor.DarkGray);
                            }
                            else if (n.BackColor == Color.FromKnownColor(KnownColor.White) || n.BackColor == Color.FromKnownColor(KnownColor.DarkGray))
                            {
                                n.BackColor = Color.FromKnownColor(KnownColor.White);
                            }
                            else
                            {
                                //default color
                                n.BackColor = Color.FromKnownColor(KnownColor.Control);
                            }
                        }
                    }
                };
                Button removeSection = new Button
                {
                    Text = "X",
                    Size = new Size(20,20),
                    Location = new Point(480,10)

                };
                removeSection.MouseClick += (o, i) =>
                {
                    int x = selectedVehicle.sectionList.IndexOf(currentSection);
                    creatorLayout.Controls.RemoveAt(x);
                };
                
                ComboBox corBox = new ComboBox();
                corBox.Location = new Point(51, 52);
                crs.PrintCorList(corBox);
                corBox.SelectedIndexChanged += (o, i) =>
                {
                    selectedCore =crs.CorList[corBox.SelectedIndex];
                    currentSection.secCore = crs.CorList[corBox.SelectedIndex];
                    perkPoints.Text = "Perk Points: " + currentSection.secCore.corPerk.ToString();
                    maxArmor.Text = "Max Armor: " + currentSection.secCore.maxArmor.ToString();
                    hpSlots.Text = "HP Slots: " + currentSection.secCore.hp.ToString();
                    crCost.Text = "Cost: " + currentSection.secCore.corCost.ToString("n0") + " Cr";
                    pilCPX.Text = "Pilot CPX: " + currentSection.secCore.corCPX.ToString();
                    if (currentSection.secChassis != null)
                    {
                        mechCPX.Text = "Mech CPX: " + mechCPXTest().ToString();
                        baseSpeed.Text = "Base Speed: " + baseSpeedTest().ToString();
                        totalCost.Text = "Base Cost: " + (currentSection.secChassis.chasCost + currentSection.secCore.corCost).ToString("n0") + " Cr";
                    }
                };

                /////////////////BUILD SECTION BUTTON////////////////////////////////////

                Button buildSectionButton = new Button
                {
                    Location = new Point(6, 94),
                    Text = "Build"
                };
                buildSectionButton.MouseClick += (o, i) =>
                {
                    currentSection.isBuilt = true;
                    chasBox.Enabled = false;
                    corBox.Enabled = false;
                    //////////////////Input Box///////////////////////TEMP
                    string input = Microsoft.VisualBasic.Interaction.InputBox("Enter Mechanical Design Roll \n"+ QuallityString(),
                       "Design Roll",
                       "Enter Integer Roll Result " ,
                       0,
                       0);
                    if (int.TryParse(input, out skillResult))

                    //skillResult = int.Parse(input);
                    /////////////////End Input Box//////////////////TEMP
                    try 
                    {
                        SectionForm.Show();
                    }
                    catch 
                    {
                        throw;
                    }
                    selectedSection = currentSection;
                    selectedSection.CalcSectionPP(skillResult);
                    selectedSection.isBuilt = true;
                    selectedVehicle.SetPilotCPX(selectedSection.secCore.corCPX);
                    selectedVehicle.SetMechCPX((int)mechCPXTest());
                    SectionForm.testLabelName.Text = selectedSection.sectionName;
                    

                    perkForm.UpdateForm(selectedVehicle, selectedSection);
                    foreach (GroupBox n in creatorLayout.Controls)
                    {
                        if (n.Name == selectedSection.sectionName)
                        {
                            n.BackColor = Color.FromKnownColor(KnownColor.DarkGray);
                        }
                        else if(n.BackColor== Color.FromKnownColor(KnownColor.White)|| n.BackColor == Color.FromKnownColor(KnownColor.DarkGray))
                        {
                            n.BackColor = Color.FromKnownColor(KnownColor.White);
                        }
                        else
                        {
                            //default color
                            n.BackColor = Color.FromKnownColor(KnownColor.Control);
                        }
                    }


                };
                Panel chasPanel = new Panel
                {
                    Location = new Point(200, 10),
                    Size = new Size(129, 90)
                };

                Panel corPanel = new Panel
                {
                    Location = new Point(338, 10),
                    Size = new Size(141, 79)
                };

                Panel cpxPanel = new Panel
                {
                    Location = new Point(338, 84),
                    Size = new Size(141, 25)
                };

                sectionGrpBox.Controls.Add(chasBox);
                sectionGrpBox.Controls.Add(corBox);
                sectionGrpBox.Controls.Add(chasPanel);
                sectionGrpBox.Controls.Add(corPanel);
                sectionGrpBox.Controls.Add(cpxPanel);
                sectionGrpBox.Controls.Add(buildSectionButton);
                sectionGrpBox.Controls.Add(baseSpeed);
                sectionGrpBox.Controls.Add(totalCost);
                sectionGrpBox.Controls.Add(removeSection);
                creatorLayout.Controls.Add(sectionGrpBox);


                Label chasInfo = new Label
                {
                    Text = "Chassis Info",
                    Location = new Point(20, 6),
                    Font = new Font(Font, FontStyle.Bold),
                    AutoSize = true
                };
                Label corInfo = new Label
                {
                    Text = "Core Info",
                    Location = new Point(20, 6),
                    Font = new Font(Font, FontStyle.Bold),
                    AutoSize = true
                };


                chasPanel.Controls.Add(chasInfo);
                chasPanel.Controls.Add(baseArmor);
                chasPanel.Controls.Add(baseMan);
                chasPanel.Controls.Add(maxHP);
                chasPanel.Controls.Add(compMax);
                chasPanel.Controls.Add(chasCost);

                corPanel.Controls.Add(corInfo);
                corPanel.Controls.Add(perkPoints);
                corPanel.Controls.Add(maxArmor);
                corPanel.Controls.Add(hpSlots);
                corPanel.Controls.Add(crCost);

                cpxPanel.Controls.Add(pilCPX);
                cpxPanel.Controls.Add(mechCPX);
                

            }

        }
        public double mechCPXTest()
        {
            double mechCPX;
            if (selectedCore.corSize > selectedChassis.chasSize)
            {
                mechCPX = selectedCore.corCPX + (selectedCore.corSize - selectedChassis.chasSize);
            }
            else
                mechCPX = selectedCore.corCPX;
            return mechCPX;
        }
        public double baseSpeedTest()
        {
            double baseSpeed;
            baseSpeed = selectedCore.corSize+(selectedCore.corSize - selectedChassis.chasSize);
            return baseSpeed;
        }
        public Vehicle.VehicleSection GetVehicleSection()
        {
            return selectedSection;
        }
        public Main GetMain()
        {
            return this;
        }
        public SectionProperties GetSP()
        {
            return SectionForm;
        }
        public string QuallityString()
        {
            string result = "Poor Quality:" + selectedCore.poor.ToString() + " - " + (selectedCore.avg - 1)+ Environment.NewLine ;
            result += "Average Quality: " + selectedCore.avg + " - " + (selectedCore.exceptional)+Environment.NewLine;
            result += "Exceptional Quality: " + (selectedCore.exceptional + 1) + " - " + selectedCore.cuttEdge+ Environment.NewLine; 
            result+= "Cutting Edge" + selectedCore.cuttEdge + "+";
            return result;
        }

        private void vehName_TextChanged(object sender, EventArgs e)
        {
            SectionForm.VehNameLbl.Text = vehName.Text;
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void moveTypeCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (vehicleType == "Walker") selectedMoveType = ExoMove.exoMoveList[moveTypeCmb.SelectedIndex];
            if (vehicleType == "Ground") selectedMoveType = GroundMove.groundMoveList[moveTypeCmb.SelectedIndex];
        }

        private void printVehicleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printVehicleXml.Filter = "XML File|*.xml";
            XmlSerializer serial = new XmlSerializer(typeof(VehiclePrint));
            VehiclePrint tempPrint = new VehiclePrint();
            printVehicleXml.InitialDirectory = (Environment.CurrentDirectory + "\\VehiclePrints" );
                
            //+printVehicleXml.OpenFile()
            if (vehName.Text != "Enter Vehicle Name" && vehName.Text != "")
            {
                printVehicleXml.ShowDialog();
                if (printVehicleXml.FileName != "")
                {
                    using (FileStream NewSave = new FileStream(printVehicleXml.FileName, FileMode.Create, FileAccess.Write))
                    {
                        serial.Serialize(NewSave, tempPrint);
                        MessageBox.Show("Save Complete");
                    }
                }
                else MessageBox.Show("No Save File Name");
            }
            else MessageBox.Show("Enter A Name First");
            //
        }
    }
    [Serializable]
    public class VehiclePrint
    {
        ///////////////Variables for Serialization//////////////////
        public string vehicleName;
        public string templateName;
        public double totalSize;
        public int maneuver;
        public int move;
        public int bp;
        public static int sectionIndex;
        public List<SectionPrint> sectionPrintList = new List<SectionPrint>();

        public VehiclePrint()
        {
            Vehicle v = Main.mainForm.selectedVehicle;
            ///////////////Variables for Serialization//////////////////
            templateName = v.templateName;
            totalSize = v.tCHS;
            vehicleName = Main.mainForm.vehName.Text;
            maneuver = v.GetFinalMan();
            move = v.GetMove();
            bp = v.bpTotal;

            //////////////Print Sections for Serialization/////////////
            for(int i = 0; i< v.actualSections; i++)
            {
                sectionIndex = i;
                if (v.sectionList[i] != null & v.sectionList[i].secCore != null)
                {
                    SectionPrint x = new SectionPrint();
                    sectionPrintList.Add(x);
                }
            }
        }
        public class SectionPrint
        {
            public String sectionName;
            public double armor;
            public int shields;
            public List<string> eSystems = new List<string>();
            public List<string> mSystems = new List<string>();
            public List<string> protPerks = new List<string>();

            public SectionPrint()
            {
                Vehicle.VehicleSection s = Main.mainForm.selectedVehicle.sectionList[sectionIndex];
                sectionName = s.sectionName;
                armor = s.secChassis.baseArmor + s.armorAdjust;
                shields = s.GetShieldTotal();
                eSystems.AddRange(s.electronicSystems);
                mSystems.AddRange(s.miscSystems);
                protPerks.AddRange(s.protPerkList);

            }
        }
    }
}
