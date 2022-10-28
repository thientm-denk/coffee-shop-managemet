namespace WinFormsApp1.Employee
{
    partial class frmEmployeeOpen
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
            this.label1 = new System.Windows.Forms.Label();
            this.textMoney = new System.Windows.Forms.TextBox();
            this.LogoutButton = new System.Windows.Forms.Button();
            this.StartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(35, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Money in Cashbox before working:";
            // 
            // textMoney
            // 
            this.textMoney.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textMoney.Location = new System.Drawing.Point(356, 50);
            this.textMoney.Name = "textMoney";
            this.textMoney.Size = new System.Drawing.Size(260, 34);
            this.textMoney.TabIndex = 1;
            // 
            // LogoutButton
            // 
            this.LogoutButton.Location = new System.Drawing.Point(506, 111);
            this.LogoutButton.Name = "LogoutButton";
            this.LogoutButton.Size = new System.Drawing.Size(110, 36);
            this.LogoutButton.TabIndex = 2;
            this.LogoutButton.Text = "Log out";
            this.LogoutButton.UseVisualStyleBackColor = true;
            this.LogoutButton.Click += new System.EventHandler(this.LogoutButton_Click);
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(356, 111);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(110, 36);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // frmEmployeeOpen
            // 
            this.AcceptButton = this.StartButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 159);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.LogoutButton);
            this.Controls.Add(this.textMoney);
            this.Controls.Add(this.label1);
            this.Name = "frmEmployeeOpen";
            this.Text = "Cashbox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textMoney;
        private Button LogoutButton;
        private Button StartButton;
    }
}