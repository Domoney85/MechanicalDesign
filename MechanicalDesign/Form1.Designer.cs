namespace MechanicalDesign
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.vehicleTypeComBox = new System.Windows.Forms.ComboBox();
            this.templateTypeComBox = new System.Windows.Forms.ComboBox();
            this.buildButton = new System.Windows.Forms.Button();
            this.creatorLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.vehName = new System.Windows.Forms.TextBox();
            this.moveTypeCmb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.moveTypeLbl = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printVehicleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openVehicleViewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vehicleWeaponsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // vehicleTypeComBox
            // 
            this.vehicleTypeComBox.BackColor = System.Drawing.SystemColors.Menu;
            this.vehicleTypeComBox.ForeColor = System.Drawing.SystemColors.WindowText;
            this.vehicleTypeComBox.FormattingEnabled = true;
            this.vehicleTypeComBox.Items.AddRange(new object[] {
            "Walker",
            "Ground",
            "Aero/Space"});
            this.vehicleTypeComBox.Location = new System.Drawing.Point(249, 69);
            this.vehicleTypeComBox.Margin = new System.Windows.Forms.Padding(4);
            this.vehicleTypeComBox.Name = "vehicleTypeComBox";
            this.vehicleTypeComBox.Size = new System.Drawing.Size(217, 24);
            this.vehicleTypeComBox.TabIndex = 0;
            this.vehicleTypeComBox.SelectedIndexChanged += new System.EventHandler(this.vehicleTypeComBox_SelectedIndexChanged);
            // 
            // templateTypeComBox
            // 
            this.templateTypeComBox.BackColor = System.Drawing.SystemColors.Menu;
            this.templateTypeComBox.FormattingEnabled = true;
            this.templateTypeComBox.Location = new System.Drawing.Point(249, 102);
            this.templateTypeComBox.Margin = new System.Windows.Forms.Padding(4);
            this.templateTypeComBox.Name = "templateTypeComBox";
            this.templateTypeComBox.Size = new System.Drawing.Size(217, 24);
            this.templateTypeComBox.TabIndex = 1;
            this.templateTypeComBox.SelectedIndexChanged += new System.EventHandler(this.templateTypeComBox_SelectedIndexChanged);
            // 
            // buildButton
            // 
            this.buildButton.Location = new System.Drawing.Point(285, 169);
            this.buildButton.Margin = new System.Windows.Forms.Padding(4);
            this.buildButton.Name = "buildButton";
            this.buildButton.Size = new System.Drawing.Size(127, 28);
            this.buildButton.TabIndex = 3;
            this.buildButton.Text = "Build Sections";
            this.buildButton.UseVisualStyleBackColor = true;
            this.buildButton.Click += new System.EventHandler(this.buildButton_Click);
            // 
            // creatorLayout
            // 
            this.creatorLayout.AutoScroll = true;
            this.creatorLayout.Location = new System.Drawing.Point(28, 226);
            this.creatorLayout.Margin = new System.Windows.Forms.Padding(4);
            this.creatorLayout.Name = "creatorLayout";
            this.creatorLayout.Size = new System.Drawing.Size(685, 348);
            this.creatorLayout.TabIndex = 4;
            // 
            // vehName
            // 
            this.vehName.Location = new System.Drawing.Point(249, 37);
            this.vehName.Margin = new System.Windows.Forms.Padding(4);
            this.vehName.Name = "vehName";
            this.vehName.Size = new System.Drawing.Size(268, 22);
            this.vehName.TabIndex = 5;
            this.vehName.Text = "Enter Vehicle Name";
            this.vehName.TextChanged += new System.EventHandler(this.vehName_TextChanged);
            // 
            // moveTypeCmb
            // 
            this.moveTypeCmb.BackColor = System.Drawing.SystemColors.Menu;
            this.moveTypeCmb.FormattingEnabled = true;
            this.moveTypeCmb.Location = new System.Drawing.Point(249, 135);
            this.moveTypeCmb.Margin = new System.Windows.Forms.Padding(4);
            this.moveTypeCmb.Name = "moveTypeCmb";
            this.moveTypeCmb.Size = new System.Drawing.Size(217, 24);
            this.moveTypeCmb.TabIndex = 6;
            this.moveTypeCmb.Visible = false;
            this.moveTypeCmb.SelectedIndexChanged += new System.EventHandler(this.moveTypeCmb_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Enter Vehicle Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 73);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Select Vehicle Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(160, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Select Vehicle Template";
            // 
            // moveTypeLbl
            // 
            this.moveTypeLbl.AutoSize = true;
            this.moveTypeLbl.Location = new System.Drawing.Point(57, 145);
            this.moveTypeLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.moveTypeLbl.Name = "moveTypeLbl";
            this.moveTypeLbl.Size = new System.Drawing.Size(152, 17);
            this.moveTypeLbl.TabIndex = 10;
            this.moveTypeLbl.Text = "Select Movement Type";
            this.moveTypeLbl.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.menuToolStripMenuItem,
            this.updateToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(745, 28);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.openToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.clearToolStripMenuItem.Text = "Clear";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printVehicleToolStripMenuItem,
            this.openVehicleViewToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.menuToolStripMenuItem.Text = "Vehicle";
            // 
            // printVehicleToolStripMenuItem
            // 
            this.printVehicleToolStripMenuItem.Name = "printVehicleToolStripMenuItem";
            this.printVehicleToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.printVehicleToolStripMenuItem.Text = "Print Vehicle View";
            this.printVehicleToolStripMenuItem.Click += new System.EventHandler(this.printVehicleToolStripMenuItem_Click);
            // 
            // openVehicleViewToolStripMenuItem
            // 
            this.openVehicleViewToolStripMenuItem.Name = "openVehicleViewToolStripMenuItem";
            this.openVehicleViewToolStripMenuItem.Size = new System.Drawing.Size(216, 26);
            this.openVehicleViewToolStripMenuItem.Text = "Open Vehicle View";
            this.openVehicleViewToolStripMenuItem.Click += new System.EventHandler(this.openVehicleViewToolStripMenuItem_Click);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vehicleWeaponsToolStripMenuItem});
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.updateToolStripMenuItem.Text = "Update";
            // 
            // vehicleWeaponsToolStripMenuItem
            // 
            this.vehicleWeaponsToolStripMenuItem.Name = "vehicleWeaponsToolStripMenuItem";
            this.vehicleWeaponsToolStripMenuItem.Size = new System.Drawing.Size(196, 26);
            this.vehicleWeaponsToolStripMenuItem.Text = "Vehicle Weapons";
            this.vehicleWeaponsToolStripMenuItem.Click += new System.EventHandler(this.vehicleWeaponsToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 678);
            this.Controls.Add(this.moveTypeLbl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.moveTypeCmb);
            this.Controls.Add(this.vehName);
            this.Controls.Add(this.creatorLayout);
            this.Controls.Add(this.buildButton);
            this.Controls.Add(this.templateTypeComBox);
            this.Controls.Add(this.vehicleTypeComBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox vehicleTypeComBox;
        private System.Windows.Forms.ComboBox templateTypeComBox;
        private System.Windows.Forms.Button buildButton;
        private System.Windows.Forms.FlowLayoutPanel creatorLayout;
        public System.Windows.Forms.ComboBox moveTypeCmb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label moveTypeLbl;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printVehicleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openVehicleViewToolStripMenuItem;
        public System.Windows.Forms.TextBox vehName;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vehicleWeaponsToolStripMenuItem;
    }
}

