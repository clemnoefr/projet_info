namespace WineAdmin
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.SeeProductsButton = new System.Windows.Forms.Button();
            this.OrderButton = new System.Windows.Forms.Button();
            this.connectionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WineAdmin.Properties.Resources.WINE;
            this.pictureBox1.Location = new System.Drawing.Point(43, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(500, 500);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ConnectButton.FlatAppearance.BorderSize = 0;
            this.ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ConnectButton.Font = new System.Drawing.Font("Reem Kufi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ConnectButton.Location = new System.Drawing.Point(549, 94);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(258, 47);
            this.ConnectButton.TabIndex = 1;
            this.ConnectButton.Text = "Connexion";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // SeeProductsButton
            // 
            this.SeeProductsButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SeeProductsButton.FlatAppearance.BorderSize = 0;
            this.SeeProductsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SeeProductsButton.Font = new System.Drawing.Font("Reem Kufi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SeeProductsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(12)))), ((int)(((byte)(40)))));
            this.SeeProductsButton.Location = new System.Drawing.Point(602, 224);
            this.SeeProductsButton.Name = "SeeProductsButton";
            this.SeeProductsButton.Size = new System.Drawing.Size(258, 47);
            this.SeeProductsButton.TabIndex = 2;
            this.SeeProductsButton.Text = "Voir les produits";
            this.SeeProductsButton.UseVisualStyleBackColor = true;
            this.SeeProductsButton.Click += new System.EventHandler(this.SeeProductsButton_Click);
            // 
            // OrderButton
            // 
            this.OrderButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.OrderButton.FlatAppearance.BorderSize = 0;
            this.OrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OrderButton.Font = new System.Drawing.Font("Reem Kufi", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OrderButton.Location = new System.Drawing.Point(632, 333);
            this.OrderButton.Name = "OrderButton";
            this.OrderButton.Size = new System.Drawing.Size(258, 47);
            this.OrderButton.TabIndex = 3;
            this.OrderButton.Text = "Commander";
            this.OrderButton.UseVisualStyleBackColor = true;
            // 
            // connectionLabel
            // 
            this.connectionLabel.AutoSize = true;
            this.connectionLabel.Location = new System.Drawing.Point(3, 3);
            this.connectionLabel.Name = "connectionLabel";
            this.connectionLabel.Size = new System.Drawing.Size(127, 15);
            this.connectionLabel.TabIndex = 4;
            this.connectionLabel.Text = "Connecté en tant que: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(962, 542);
            this.Controls.Add(this.connectionLabel);
            this.Controls.Add(this.OrderButton);
            this.Controls.Add(this.SeeProductsButton);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Button ConnectButton;
        private Button SeeProductsButton;
        private Button OrderButton;
        private Label connectionLabel;
    }
}