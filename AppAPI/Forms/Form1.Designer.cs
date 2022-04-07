namespace AppAPI
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelTem = new System.Windows.Forms.Label();
            this.labelViento = new System.Windows.Forms.Label();
            this.labelPresion = new System.Windows.Forms.Label();
            this.labelDetalles = new System.Windows.Forms.Label();
            this.labelCondicion = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Nicaragua",
            "Costa Rica",
            "México",
            "Estados Unidos",
            "España",
            "Japón",
            "Australia"});
            this.comboBox1.Location = new System.Drawing.Point(99, 39);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 23);
            this.comboBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Location = new System.Drawing.Point(249, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Consultar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(379, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(186, 142);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(26, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "Condicion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(26, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Detalles";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(349, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Velocidad del Viento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(30, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ciudad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(26, 215);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 15);
            this.label7.TabIndex = 10;
            this.label7.Text = "Temperatura";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(349, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 15);
            this.label8.TabIndex = 11;
            this.label8.Text = "Presión";
            // 
            // labelTem
            // 
            this.labelTem.AutoSize = true;
            this.labelTem.BackColor = System.Drawing.Color.Transparent;
            this.labelTem.Location = new System.Drawing.Point(105, 215);
            this.labelTem.Name = "labelTem";
            this.labelTem.Size = new System.Drawing.Size(29, 15);
            this.labelTem.TabIndex = 13;
            this.labelTem.Text = "N/A";
            // 
            // labelViento
            // 
            this.labelViento.AutoSize = true;
            this.labelViento.BackColor = System.Drawing.Color.Transparent;
            this.labelViento.Location = new System.Drawing.Point(469, 171);
            this.labelViento.Name = "labelViento";
            this.labelViento.Size = new System.Drawing.Size(29, 15);
            this.labelViento.TabIndex = 14;
            this.labelViento.Text = "N/A";
            // 
            // labelPresion
            // 
            this.labelPresion.AutoSize = true;
            this.labelPresion.BackColor = System.Drawing.Color.Transparent;
            this.labelPresion.Location = new System.Drawing.Point(401, 215);
            this.labelPresion.Name = "labelPresion";
            this.labelPresion.Size = new System.Drawing.Size(29, 15);
            this.labelPresion.TabIndex = 15;
            this.labelPresion.Text = "N/A";
            // 
            // labelDetalles
            // 
            this.labelDetalles.AutoSize = true;
            this.labelDetalles.BackColor = System.Drawing.Color.Transparent;
            this.labelDetalles.Location = new System.Drawing.Point(98, 171);
            this.labelDetalles.Name = "labelDetalles";
            this.labelDetalles.Size = new System.Drawing.Size(29, 15);
            this.labelDetalles.TabIndex = 16;
            this.labelDetalles.Text = "N/A";
            // 
            // labelCondicion
            // 
            this.labelCondicion.AutoSize = true;
            this.labelCondicion.BackColor = System.Drawing.Color.Transparent;
            this.labelCondicion.Location = new System.Drawing.Point(94, 119);
            this.labelCondicion.Name = "labelCondicion";
            this.labelCondicion.Size = new System.Drawing.Size(29, 15);
            this.labelCondicion.TabIndex = 17;
            this.labelCondicion.Text = "N/A";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AppAPI.Properties.Resources.wallpaperbetter;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(621, 420);
            this.Controls.Add(this.labelCondicion);
            this.Controls.Add(this.labelDetalles);
            this.Controls.Add(this.labelPresion);
            this.Controls.Add(this.labelViento);
            this.Controls.Add(this.labelTem);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Icon = global::AppAPI.Properties.Resources.API;
            this.Name = "Form1";
            this.Text = "API";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelTem;
        private System.Windows.Forms.Label labelViento;
        private System.Windows.Forms.Label labelPresion;
        private System.Windows.Forms.Label labelDetalles;
        private System.Windows.Forms.Label labelCondicion;
    }
}
