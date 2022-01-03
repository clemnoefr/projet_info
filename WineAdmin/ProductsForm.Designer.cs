namespace WineAdmin
{
    partial class ProductsForm
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
            this.components = new System.ComponentModel.Container();
            this.WhiteButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RosedButton = new System.Windows.Forms.Button();
            this.Red = new System.Windows.Forms.Button();
            this.ChampagneButton = new System.Windows.Forms.Button();
            this.SparklingButton = new System.Windows.Forms.Button();
            this.CategoryName = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Reference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MiseEnBouteille = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Origine = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantitee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // WhiteButton
            // 
            this.WhiteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(12)))), ((int)(((byte)(40)))));
            this.WhiteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.WhiteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.WhiteButton.ForeColor = System.Drawing.Color.White;
            this.WhiteButton.Location = new System.Drawing.Point(101, 0);
            this.WhiteButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WhiteButton.Name = "WhiteButton";
            this.WhiteButton.Size = new System.Drawing.Size(203, 109);
            this.WhiteButton.TabIndex = 0;
            this.WhiteButton.Text = "Blanc";
            this.WhiteButton.UseVisualStyleBackColor = false;
            this.WhiteButton.Click += new System.EventHandler(this.WhiteButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::WineAdmin.Properties.Resources.WINE;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(102, 109);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // RosedButton
            // 
            this.RosedButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(12)))), ((int)(((byte)(40)))));
            this.RosedButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.RosedButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.RosedButton.ForeColor = System.Drawing.Color.White;
            this.RosedButton.Location = new System.Drawing.Point(301, 0);
            this.RosedButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.RosedButton.Name = "RosedButton";
            this.RosedButton.Size = new System.Drawing.Size(203, 109);
            this.RosedButton.TabIndex = 2;
            this.RosedButton.Text = "Rosé";
            this.RosedButton.UseVisualStyleBackColor = false;
            this.RosedButton.Click += new System.EventHandler(this.RosedButton_Click);
            // 
            // Red
            // 
            this.Red.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(12)))), ((int)(((byte)(40)))));
            this.Red.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Red.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Red.ForeColor = System.Drawing.Color.White;
            this.Red.Location = new System.Drawing.Point(501, 0);
            this.Red.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Red.Name = "Red";
            this.Red.Size = new System.Drawing.Size(203, 109);
            this.Red.TabIndex = 3;
            this.Red.Text = "Rouge";
            this.Red.UseVisualStyleBackColor = false;
            this.Red.Click += new System.EventHandler(this.Red_Click);
            // 
            // ChampagneButton
            // 
            this.ChampagneButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(12)))), ((int)(((byte)(40)))));
            this.ChampagneButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ChampagneButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ChampagneButton.ForeColor = System.Drawing.Color.White;
            this.ChampagneButton.Location = new System.Drawing.Point(701, 0);
            this.ChampagneButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ChampagneButton.Name = "ChampagneButton";
            this.ChampagneButton.Size = new System.Drawing.Size(203, 109);
            this.ChampagneButton.TabIndex = 4;
            this.ChampagneButton.Text = "Champagne";
            this.ChampagneButton.UseVisualStyleBackColor = false;
            this.ChampagneButton.Click += new System.EventHandler(this.ChampagneButton_Click);
            // 
            // SparklingButton
            // 
            this.SparklingButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(12)))), ((int)(((byte)(40)))));
            this.SparklingButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SparklingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SparklingButton.ForeColor = System.Drawing.Color.White;
            this.SparklingButton.Location = new System.Drawing.Point(901, 0);
            this.SparklingButton.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.SparklingButton.Name = "SparklingButton";
            this.SparklingButton.Size = new System.Drawing.Size(203, 109);
            this.SparklingButton.TabIndex = 5;
            this.SparklingButton.Text = "Bio";
            this.SparklingButton.UseVisualStyleBackColor = false;
            this.SparklingButton.Click += new System.EventHandler(this.SparklingButton_Click);
            // 
            // CategoryName
            // 
            this.CategoryName.AutoSize = true;
            this.CategoryName.Font = new System.Drawing.Font("Reem Kufi", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CategoryName.Location = new System.Drawing.Point(501, 127);
            this.CategoryName.Name = "CategoryName";
            this.CategoryName.Size = new System.Drawing.Size(144, 84);
            this.CategoryName.TabIndex = 6;
            this.CategoryName.Text = "Blanc";
            this.CategoryName.Click += new System.EventHandler(this.CategoryName_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nom,
            this.Description,
            this.Reference,
            this.MiseEnBouteille,
            this.Origine,
            this.Quantitee});
            this.dataGridView1.Location = new System.Drawing.Point(17, 220);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1069, 487);
            this.dataGridView1.TabIndex = 7;
            // 
            // Nom
            // 
            this.Nom.HeaderText = "Nom";
            this.Nom.MinimumWidth = 6;
            this.Nom.Name = "Nom";
            this.Nom.Width = 125;
            // 
            // Description
            // 
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            this.Description.Width = 125;
            // 
            // Reference
            // 
            this.Reference.HeaderText = "Réference";
            this.Reference.MinimumWidth = 6;
            this.Reference.Name = "Reference";
            this.Reference.Width = 125;
            // 
            // MiseEnBouteille
            // 
            this.MiseEnBouteille.HeaderText = "Mise En Bouteille";
            this.MiseEnBouteille.MinimumWidth = 6;
            this.MiseEnBouteille.Name = "MiseEnBouteille";
            this.MiseEnBouteille.Width = 125;
            // 
            // Origine
            // 
            this.Origine.HeaderText = "Origine";
            this.Origine.MinimumWidth = 6;
            this.Origine.Name = "Origine";
            this.Origine.Width = 125;
            // 
            // Quantitee
            // 
            this.Quantitee.HeaderText = "Quantitée";
            this.Quantitee.MinimumWidth = 6;
            this.Quantitee.Name = "Quantitee";
            this.Quantitee.Width = 125;
            // 
            // productBindingSource
            // 
            this.productBindingSource.DataSource = typeof(WineBiblio.Business.Product);
            // 
            // ProductsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1099, 723);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.CategoryName);
            this.Controls.Add(this.SparklingButton);
            this.Controls.Add(this.ChampagneButton);
            this.Controls.Add(this.Red);
            this.Controls.Add(this.RosedButton);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.WhiteButton);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ProductsForm";
            this.Text = "ProductsForm";
            this.Load += new System.EventHandler(this.ProductsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.productBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button WhiteButton;
        private PictureBox pictureBox1;
        private Button RosedButton;
        private Button Red;
        private Button ChampagneButton;
        private Button SparklingButton;
        private Label CategoryName;
        private DataGridView dataGridView1;
        private BindingSource productBindingSource;
        private DataGridViewTextBoxColumn Nom;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn Reference;
        private DataGridViewTextBoxColumn MiseEnBouteille;
        private DataGridViewTextBoxColumn Origine;
        private DataGridViewTextBoxColumn Quantitee;
    }
}