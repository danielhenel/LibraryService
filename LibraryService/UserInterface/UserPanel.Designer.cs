namespace UserInterface
{
    partial class UserPanel
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
            this.titlePanel = new System.Windows.Forms.Panel();
            this.loginButton = new System.Windows.Forms.Button();
            this.ciceroQuote = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.notificationPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.historyButton = new System.Windows.Forms.Button();
            this.followedButton = new System.Windows.Forms.Button();
            this.onLoanButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.previousButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label33 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label22 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.titlePanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // titlePanel
            // 
            this.titlePanel.BackColor = System.Drawing.Color.NavajoWhite;
            this.titlePanel.Controls.Add(this.loginButton);
            this.titlePanel.Controls.Add(this.ciceroQuote);
            this.titlePanel.Controls.Add(this.titleLabel);
            this.titlePanel.Controls.Add(this.notificationPanel);
            this.titlePanel.Location = new System.Drawing.Point(1, 1);
            this.titlePanel.Name = "titlePanel";
            this.titlePanel.Size = new System.Drawing.Size(1247, 146);
            this.titlePanel.TabIndex = 1;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(1154, 3);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(75, 60);
            this.loginButton.TabIndex = 5;
            this.loginButton.UseVisualStyleBackColor = true;
            // 
            // ciceroQuote
            // 
            this.ciceroQuote.AutoSize = true;
            this.ciceroQuote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ciceroQuote.Location = new System.Drawing.Point(229, 88);
            this.ciceroQuote.Name = "ciceroQuote";
            this.ciceroQuote.Size = new System.Drawing.Size(426, 16);
            this.ciceroQuote.TabIndex = 4;
            this.ciceroQuote.Text = "“A room without books is like a body without a soul.”, CICERO";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(11, 31);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(235, 73);
            this.titleLabel.TabIndex = 3;
            this.titleLabel.Text = "Library";
            // 
            // notificationPanel
            // 
            this.notificationPanel.Location = new System.Drawing.Point(830, 69);
            this.notificationPanel.Name = "notificationPanel";
            this.notificationPanel.Size = new System.Drawing.Size(399, 63);
            this.notificationPanel.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Tan;
            this.panel1.Controls.Add(this.historyButton);
            this.panel1.Controls.Add(this.followedButton);
            this.panel1.Controls.Add(this.onLoanButton);
            this.panel1.Location = new System.Drawing.Point(1, 153);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1247, 71);
            this.panel1.TabIndex = 2;
            // 
            // historyButton
            // 
            this.historyButton.BackColor = System.Drawing.Color.SandyBrown;
            this.historyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.historyButton.Location = new System.Drawing.Point(747, 13);
            this.historyButton.Name = "historyButton";
            this.historyButton.Size = new System.Drawing.Size(235, 45);
            this.historyButton.TabIndex = 2;
            this.historyButton.Text = "History";
            this.historyButton.UseVisualStyleBackColor = false;
            this.historyButton.Click += new System.EventHandler(this.historyButton_Click);
            // 
            // followedButton
            // 
            this.followedButton.BackColor = System.Drawing.Color.SandyBrown;
            this.followedButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.followedButton.Location = new System.Drawing.Point(506, 13);
            this.followedButton.Name = "followedButton";
            this.followedButton.Size = new System.Drawing.Size(235, 45);
            this.followedButton.TabIndex = 1;
            this.followedButton.Text = "Followed";
            this.followedButton.UseVisualStyleBackColor = false;
            this.followedButton.Click += new System.EventHandler(this.followedButton_Click);
            // 
            // onLoanButton
            // 
            this.onLoanButton.BackColor = System.Drawing.Color.OrangeRed;
            this.onLoanButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onLoanButton.Location = new System.Drawing.Point(265, 13);
            this.onLoanButton.Name = "onLoanButton";
            this.onLoanButton.Size = new System.Drawing.Size(235, 45);
            this.onLoanButton.TabIndex = 0;
            this.onLoanButton.Text = "On Loan";
            this.onLoanButton.UseVisualStyleBackColor = false;
            this.onLoanButton.Click += new System.EventHandler(this.onLoanButton_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.BackColor = System.Drawing.Color.AntiqueWhite;
            this.flowLayoutPanel2.Font = new System.Drawing.Font("Ebrima", 8.25F);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(28, 275);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(1190, 480);
            this.flowLayoutPanel2.TabIndex = 6;
            // 
            // previousButton
            // 
            this.previousButton.BackColor = System.Drawing.Color.Tan;
            this.previousButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.previousButton.Location = new System.Drawing.Point(1, 226);
            this.previousButton.Name = "previousButton";
            this.previousButton.Size = new System.Drawing.Size(24, 529);
            this.previousButton.TabIndex = 7;
            this.previousButton.Text = "<";
            this.previousButton.UseVisualStyleBackColor = false;
            this.previousButton.Click += new System.EventHandler(this.previousButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.BackColor = System.Drawing.Color.Tan;
            this.nextButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nextButton.Location = new System.Drawing.Point(1224, 226);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(24, 529);
            this.nextButton.TabIndex = 8;
            this.nextButton.Text = ">";
            this.nextButton.UseVisualStyleBackColor = false;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Tan;
            this.panel3.Controls.Add(this.endDateLabel);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.panel5);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Location = new System.Drawing.Point(28, 230);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1190, 43);
            this.panel3.TabIndex = 9;
            // 
            // endDateLabel
            // 
            this.endDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endDateLabel.Location = new System.Drawing.Point(729, 3);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(236, 36);
            this.endDateLabel.TabIndex = 4;
            this.endDateLabel.Text = "End Date";
            this.endDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label33);
            this.panel4.Location = new System.Drawing.Point(487, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(236, 36);
            this.panel4.TabIndex = 3;
            // 
            // label33
            // 
            this.label33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(0, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(236, 36);
            this.label33.TabIndex = 1;
            this.label33.Text = "Category";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label22);
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(236, 36);
            this.panel5.TabIndex = 3;
            // 
            // label22
            // 
            this.label22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(0, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(236, 36);
            this.label22.TabIndex = 0;
            this.label22.Text = "Title";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(245, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(236, 36);
            this.panel2.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(236, 36);
            this.label5.TabIndex = 1;
            this.label5.Text = "Author";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UserPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 767);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.previousButton);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.titlePanel);
            this.Name = "UserPanel";
            this.Text = "UserInterface";
            this.titlePanel.ResumeLayout(false);
            this.titlePanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel titlePanel;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label ciceroQuote;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.FlowLayoutPanel notificationPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button historyButton;
        private System.Windows.Forms.Button followedButton;
        private System.Windows.Forms.Button onLoanButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button previousButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
    }
}