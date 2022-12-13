namespace DLWMS.WinForms.IspitIB180084
{
    partial class frmStudentSlikeIB180084
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
            this.label1 = new System.Windows.Forms.Label();
            this.pbSlikaGore = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtOpis = new System.Windows.Forms.TextBox();
            this.btnDodajSliku = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblOpis = new System.Windows.Forms.Label();
            this.lblDatum = new System.Windows.Forms.Label();
            this.btnDesno = new System.Windows.Forms.Button();
            this.btnLijevo = new System.Windows.Forms.Button();
            this.pbSlikaDole = new System.Windows.Forms.PictureBox();
            this.lblBrSlike = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlikaGore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlikaDole)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Slika:";
            // 
            // pbSlikaGore
            // 
            this.pbSlikaGore.Location = new System.Drawing.Point(16, 30);
            this.pbSlikaGore.Name = "pbSlikaGore";
            this.pbSlikaGore.Size = new System.Drawing.Size(104, 128);
            this.pbSlikaGore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSlikaGore.TabIndex = 1;
            this.pbSlikaGore.TabStop = false;
            this.pbSlikaGore.DoubleClick += new System.EventHandler(this.pbSlikaGore_DoubleClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Opis:";
            // 
            // txtOpis
            // 
            this.txtOpis.Location = new System.Drawing.Point(156, 30);
            this.txtOpis.Multiline = true;
            this.txtOpis.Name = "txtOpis";
            this.txtOpis.Size = new System.Drawing.Size(271, 86);
            this.txtOpis.TabIndex = 3;
            // 
            // btnDodajSliku
            // 
            this.btnDodajSliku.Location = new System.Drawing.Point(352, 135);
            this.btnDodajSliku.Name = "btnDodajSliku";
            this.btnDodajSliku.Size = new System.Drawing.Size(75, 23);
            this.btnDodajSliku.TabIndex = 4;
            this.btnDodajSliku.Text = "Dodaj sliku";
            this.btnDodajSliku.UseVisualStyleBackColor = true;
            this.btnDodajSliku.Click += new System.EventHandler(this.btnDodajSliku_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblOpis);
            this.groupBox1.Controls.Add(this.lblDatum);
            this.groupBox1.Controls.Add(this.btnDesno);
            this.groupBox1.Controls.Add(this.btnLijevo);
            this.groupBox1.Controls.Add(this.pbSlikaDole);
            this.groupBox1.Controls.Add(this.lblBrSlike);
            this.groupBox1.Location = new System.Drawing.Point(16, 173);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 343);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pregled slika";
            // 
            // lblOpis
            // 
            this.lblOpis.AutoSize = true;
            this.lblOpis.Location = new System.Drawing.Point(173, 307);
            this.lblOpis.Name = "lblOpis";
            this.lblOpis.Size = new System.Drawing.Size(28, 13);
            this.lblOpis.TabIndex = 5;
            this.lblOpis.Text = "Opis";
            // 
            // lblDatum
            // 
            this.lblDatum.AutoSize = true;
            this.lblDatum.Location = new System.Drawing.Point(170, 275);
            this.lblDatum.Name = "lblDatum";
            this.lblDatum.Size = new System.Drawing.Size(38, 13);
            this.lblDatum.TabIndex = 4;
            this.lblDatum.Text = "Datum";
            // 
            // btnDesno
            // 
            this.btnDesno.Location = new System.Drawing.Point(290, 147);
            this.btnDesno.Name = "btnDesno";
            this.btnDesno.Size = new System.Drawing.Size(75, 23);
            this.btnDesno.TabIndex = 3;
            this.btnDesno.Text = "==>";
            this.btnDesno.UseVisualStyleBackColor = true;
            this.btnDesno.Click += new System.EventHandler(this.btnDesno_Click);
            // 
            // btnLijevo
            // 
            this.btnLijevo.Location = new System.Drawing.Point(29, 147);
            this.btnLijevo.Name = "btnLijevo";
            this.btnLijevo.Size = new System.Drawing.Size(75, 23);
            this.btnLijevo.TabIndex = 2;
            this.btnLijevo.Text = "<==";
            this.btnLijevo.UseVisualStyleBackColor = true;
            this.btnLijevo.Click += new System.EventHandler(this.btnLijevo_Click);
            // 
            // pbSlikaDole
            // 
            this.pbSlikaDole.Location = new System.Drawing.Point(129, 67);
            this.pbSlikaDole.Name = "pbSlikaDole";
            this.pbSlikaDole.Size = new System.Drawing.Size(135, 191);
            this.pbSlikaDole.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbSlikaDole.TabIndex = 1;
            this.pbSlikaDole.TabStop = false;
            // 
            // lblBrSlike
            // 
            this.lblBrSlike.AutoSize = true;
            this.lblBrSlike.Location = new System.Drawing.Point(170, 27);
            this.lblBrSlike.Name = "lblBrSlike";
            this.lblBrSlike.Size = new System.Drawing.Size(49, 13);
            this.lblBrSlike.TabIndex = 0;
            this.lblBrSlike.Text = "Broj slike";
            // 
            // frmStudentSlikeIB180084
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 528);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDodajSliku);
            this.Controls.Add(this.txtOpis);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pbSlikaGore);
            this.Controls.Add(this.label1);
            this.Name = "frmStudentSlikeIB180084";
            this.Text = "StudentSlikeIB180084";
            ((System.ComponentModel.ISupportInitialize)(this.pbSlikaGore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSlikaDole)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbSlikaGore;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblOpis;
        private System.Windows.Forms.Label lblDatum;
        private System.Windows.Forms.Button btnDesno;
        private System.Windows.Forms.Button btnLijevo;
        private System.Windows.Forms.PictureBox pbSlikaDole;
        private System.Windows.Forms.Label lblBrSlike;
        private System.Windows.Forms.Button btnDodajSliku;
        private System.Windows.Forms.TextBox txtOpis;
        private System.Windows.Forms.Label label2;
    }
}