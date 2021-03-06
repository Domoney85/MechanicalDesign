﻿using System;
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
using System.Threading;

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
        private static string connectionString;
        public static MongoClient mongoClient;
        public static IMongoDatabase silcoDB;
        public  static IMongoCollection<VehWeapon> vehWeapons;
        public static List<VehWeapon> availWeapList = new List<VehWeapon>();
        
        



        public Main()
        {
            InitializeComponent();
            mainForm = this;
            try { xmlVehWeapons(); }
            catch (Exception)
            {
                connectionString = "mongodb+srv://Cshmnymc:Killer123$@silcodb-0xgif.mongodb.net/test?retryWrites=true";
                mongoClient = new MongoClient(connectionString);
                silcoDB = mongoClient.GetDatabase("SilcoStat");
                vehWeapons = silcoDB.GetCollection<VehWeapon>("VehWeapons");
                MessageBox.Show("Local Data missing or corupted, attempting data Retrieval");
                var finish = MainAsync();
                MessageBox.Show("Loading Weapons");
                Thread.Sleep(1000);
                GrabVehWeaponDB();
            }
            

        }
        private void xmlVehWeapons()
        {
            XmlSerializer read = new XmlSerializer(typeof(List<VehWeapon>));
            using (FileStream wepXml = new FileStream(Environment.CurrentDirectory + "\\VehicleWeapons\\" + "Weapons.xml", FileMode.Open, FileAccess.Read))
            {
                availWeapList = read.Deserialize(wepXml) as List<VehWeapon>;
            }
        }
        static async Task MainAsync()
        {

            var collection = silcoDB.GetCollection<BsonDocument>("VehWeapons");

            using (IAsyncCursor<BsonDocument> cursor = await collection.FindAsync(new BsonDocument()))
            {
                while (await cursor.MoveNextAsync())
                {
                    IEnumerable<BsonDocument> batch = cursor.Current;
                    availWeapList.Clear();
                    foreach (BsonDocument x in batch)
                    {

                        VehWeapon nWeapon = new VehWeapon(ret(x, 1), ret(x, 2), ret(x, 3), ret(x, 4), ret(x, 5), ret(x, 6), ret(x, 7), ret(x, 8),ret(x,9), ret(x, 10), (Int32)x.GetValue(11), (Int32)x.GetValue(12));
                        availWeapList.Add(nWeapon);
                        //VehWeapon x = new VehWeapon();
                       // MessageBox.Show(nWeapon.name + " " + nWeapon.range);
                    }
                }
            }
            String ret(BsonDocument doc ,int input) { String r = doc.GetValue(input).ToString(); return r; }
            
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
                        ComboBox thisBox = (ComboBox)o;
                        foreach (Control x in thisBox.Parent.Controls)
                        {
                            if (x.Text == "Build") ;
                            {
                                x.Enabled = true;
                            }
                        }
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
                        ComboBox thisBox = (ComboBox)o;
                        foreach(Control x in thisBox.Parent.Controls)
                        {
                            if (x.Text == "Build");
                            {
                                x.Enabled = true;
                            }
                        }
                    }
                };

                /////////////////BUILD SECTION BUTTON////////////////////////////////////

                Button buildSectionButton = new Button
                {
                    Location = new Point(6, 94),
                    Text = "Build",
                    Enabled = false
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
                    {
                        SectionForm.Show();
                        selectedSection = currentSection;
                        selectedSection.CalcSectionPP(skillResult);
                        selectedSection.isBuilt = true;
                        selectedVehicle.SetPilotCPX(selectedSection.secCore.corCPX);
                        selectedVehicle.SetMechCPX((int)mechCPXTest());
                        SectionForm.testLabelName.Text = selectedSection.sectionName;
                        perkForm.UpdateForm(selectedVehicle, selectedSection);
                        
                        //skillResult = int.Parse(input);
                        /////////////////End Input Box//////////////////TEMP
                        if (selectedVehicle.tCHS >= selectedVehicle.sizeMin)   
                        {
                            try
                            {
                                SectionForm.Show();
                            }
                            catch
                            {
                                throw;
                            }
                        }
                        else
                        {
                            SectionForm.Hide();
                        }
                    }
                    
                    

                   
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
        private void GrabVehWeaponDB()
        {
            XmlSerializer serial = new XmlSerializer(typeof(List<VehWeapon>));
           
            using (FileStream NewSave = new FileStream(Environment.CurrentDirectory + "\\VehicleWeapons\\"+"Weapons.xml", FileMode.Create, FileAccess.Write))
            {
                serial.Serialize(NewSave, availWeapList);
            }

        }

        private void vehicleWeaponsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                connectionString = "mongodb+srv://Cshmnymc:Killer123$@silcodb-0xgif.mongodb.net/test?retryWrites=true";
                mongoClient = new MongoClient(connectionString);
                silcoDB = mongoClient.GetDatabase("SilcoStat");
                vehWeapons = silcoDB.GetCollection<VehWeapon>("VehWeapons");
            }
            catch (Exception)
            {
                MessageBox.Show(" Cannot Connect to DB: Using Local Storage");
            }
            try
            {
                var finish = MainAsync();
                MessageBox.Show("Loading Weapons");
                Thread.Sleep(1000);
                GrabVehWeaponDB();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            
        }

        private void openVehicleViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog openView = new SaveFileDialog();
            openView.Filter = "XML File|*.xml";
            openView.InitialDirectory = (Environment.CurrentDirectory + "\\VehiclePrints");
            openView.ShowDialog();
            if (openView.FileName != "")
            {
                
                using (FileStream openVeh = new FileStream(openView.FileName, FileMode.Open, FileAccess.Read))
                {
                    File.Copy(openView.FileName, (Environment.CurrentDirectory + "\\VehViewer"+"\\SelectedView.xml"), true);
 
                }
            }
            else MessageBox.Show("No Save File Name");
            //File.Copy(filePath, newPath, true);
            System.Diagnostics.Process.Start(Environment.CurrentDirectory + "\\VehViewer\\" + "\\VehicleView.html");
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
        public int pilotCPX;
        public int mechCPX;
        public int crCost;
        public string buildQual;
        public string moveType;

        public List<SerPerk> perkList = new List<SerPerk>();
        public List<SerFlaw> flawList = new List<SerFlaw>();
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
            crCost = v.crCost;
            pilotCPX = v.pilotCPX;
            mechCPX = v.mechCPX;
            buildQual = Main.mainForm.SectionForm.buildQualLbl.Text;
            moveType = Main.mainForm.selectedMoveType.name;
            
           foreach (VehiclePerk s in v.perkList)
            {
               
                if (s.isAdded) perkList.Add(new SerPerk {perkString = s.perkName });
                
           }
            foreach (VehicleFlaw s in v.flawList)
            {
                if (s.isAdded) flawList.Add(new SerFlaw { flawString = s.flawName });
            }
            //////////////Print Sections for Serialization/////////////
            for (int i = 0; i< v.actualSections; i++)
            {
                sectionIndex = i;
                if (v.sectionList[i] != null & v.sectionList[i].secCore != null)
                {
                    SectionPrint x = new SectionPrint();
                    sectionPrintList.Add(x);
                }
            }
        }
        public class SerPerk{ public string perkString;}
        public class SerFlaw { public string flawString; }
        public class SectionPrint
        {
            public String sectionName;
            public double armor;
            public int shields;
            public double crs;
            public double chs;
            public List<SerEsystem> eSystems = new List<SerEsystem>();
            public List<SerMsystem> mSystems = new List<SerMsystem>();
            public List<SerProt> protPerks = new List<SerProt>();
            public List<HardPoint> hPoints = new List<HardPoint>();
            public List<SerCompart> compList = new List<SerCompart>();

            public SectionPrint()
            {
                Vehicle.VehicleSection s = Main.mainForm.selectedVehicle.sectionList[sectionIndex];
                sectionName = s.sectionName;
                armor = s.secChassis.baseArmor + s.armorAdjust;
                shields = s.GetShieldTotal();
                hPoints.AddRange(s.hpList);
                crs = s.secCore.corSize;
                chs = s.secChassis.chasSize;
                
                foreach(string x in s.electronicSystems)
                {
                    if (x != null)
                     eSystems.Add(new SerEsystem { eSysString = x }); 
                }
                foreach (string x in s.miscSystems)
                {
                    if (x != null)
                        mSystems.Add(new SerMsystem { mSysString = x });
                }
                foreach (string x in s.protPerkList)
                {
                    if (x != null)
                        protPerks.Add(new SerProt { protString = x });
                }
                foreach (Compartment x in s.compList)
                {
                    if (x.count > 0)
                    {
                        if (x.count < 2)
                            compList.Add(new SerCompart { comp = x.name });
                        else
                            compList.Add(new SerCompart { comp = x.name + "(" + x.count + ")" });
                    }
   
                }
            }
        }
        public class SerEsystem { public string eSysString; }
        public class SerMsystem { public string mSysString; }
        public class SerProt { public string protString; }
        public class SerCompart { public string comp; }

    }
 
}
