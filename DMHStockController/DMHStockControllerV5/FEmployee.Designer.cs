
namespace DMHStockControllerV5
{
    partial class FEmployee
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
            this.CmdCancel = new System.Windows.Forms.Button();
            this.CmdOK = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.TxtEmployeeID = new System.Windows.Forms.TextBox();
            this.TxtFirstName = new System.Windows.Forms.TextBox();
            this.TxtLastName = new System.Windows.Forms.TextBox();
            this.TxtLoginCode = new System.Windows.Forms.TextBox();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.CboProfiles = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CmdCancel
            // 
            this.CmdCancel.Location = new System.Drawing.Point(488, 358);
            this.CmdCancel.Name = "CmdCancel";
            this.CmdCancel.Size = new System.Drawing.Size(84, 26);
            this.CmdCancel.TabIndex = 37;
            this.CmdCancel.Text = "Cancel";
            this.CmdCancel.UseVisualStyleBackColor = true;
            this.CmdCancel.Click += new System.EventHandler(this.CmdCancel_Click);
            // 
            // CmdOK
            // 
            this.CmdOK.Location = new System.Drawing.Point(398, 358);
            this.CmdOK.Name = "CmdOK";
            this.CmdOK.Size = new System.Drawing.Size(84, 26);
            this.CmdOK.TabIndex = 36;
            this.CmdOK.Text = "Save";
            this.CmdOK.UseVisualStyleBackColor = true;
            this.CmdOK.Click += new System.EventHandler(this.CmdOK_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(330, 244);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(235, 108);
            this.richTextBox1.TabIndex = 38;
            this.richTextBox1.Text = "ProfileID | Description\n---------------------------------------------\n1\t| Standar" +
    "d Users\n2\t| System Administrator\n3\t| System Manager";
            // 
            // TxtEmployeeID
            // 
            this.TxtEmployeeID.Location = new System.Drawing.Point(330, 66);
            this.TxtEmployeeID.Name = "TxtEmployeeID";
            this.TxtEmployeeID.Size = new System.Drawing.Size(112, 20);
            this.TxtEmployeeID.TabIndex = 30;
            // 
            // TxtFirstName
            // 
            this.TxtFirstName.Location = new System.Drawing.Point(330, 96);
            this.TxtFirstName.Name = "TxtFirstName";
            this.TxtFirstName.Size = new System.Drawing.Size(112, 20);
            this.TxtFirstName.TabIndex = 31;
            // 
            // TxtLastName
            // 
            this.TxtLastName.Location = new System.Drawing.Point(330, 126);
            this.TxtLastName.Name = "TxtLastName";
            this.TxtLastName.Size = new System.Drawing.Size(112, 20);
            this.TxtLastName.TabIndex = 32;
            // 
            // TxtLoginCode
            // 
            this.TxtLoginCode.Location = new System.Drawing.Point(330, 155);
            this.TxtLoginCode.Name = "TxtLoginCode";
            this.TxtLoginCode.Size = new System.Drawing.Size(112, 20);
            this.TxtLoginCode.TabIndex = 33;
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(330, 182);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '%';
            this.TxtPassword.Size = new System.Drawing.Size(112, 20);
            this.TxtPassword.TabIndex = 34;
            // 
            // CboProfiles
            // 
            this.CboProfiles.FormattingEnabled = true;
            this.CboProfiles.Items.AddRange(new object[] {
            "Standard Uers",
            "System Administrator",
            "System Manager"});
            this.CboProfiles.Location = new System.Drawing.Point(330, 212);
            this.CboProfiles.Name = "CboProfiles";
            this.CboProfiles.Size = new System.Drawing.Size(136, 21);
            this.CboProfiles.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(270, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Profile:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(245, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Password:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(236, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 41;
            this.label4.Text = "Login Code:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(240, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 42;
            this.label3.Text = "Last Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(239, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 43;
            this.label2.Text = "First Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(228, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Employee ID:";
            // 
            // FEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CmdCancel);
            this.Controls.Add(this.CmdOK);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.TxtEmployeeID);
            this.Controls.Add(this.TxtFirstName);
            this.Controls.Add(this.TxtLastName);
            this.Controls.Add(this.TxtLoginCode);
            this.Controls.Add(this.TxtPassword);
            this.Controls.Add(this.CboProfiles);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FEmployee";
            this.Text = "FEmployee";
            this.Load += new System.EventHandler(this.FEmployee_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CmdCancel;
        private System.Windows.Forms.Button CmdOK;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox TxtEmployeeID;
        private System.Windows.Forms.TextBox TxtFirstName;
        private System.Windows.Forms.TextBox TxtLastName;
        private System.Windows.Forms.TextBox TxtLoginCode;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.ComboBox CboProfiles;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}