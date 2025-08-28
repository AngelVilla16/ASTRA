namespace Astra
{
    partial class Form7
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPeso = new System.Windows.Forms.TextBox();
            this.txtAltura = new System.Windows.Forms.TextBox();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtAlergias = new System.Windows.Forms.TextBox();
            this.txtPadecimientos = new System.Windows.Forms.TextBox();
            this.txtEdadPrevio = new System.Windows.Forms.TextBox();
            this.txtAlturaPrevia = new System.Windows.Forms.TextBox();
            this.txtPesoPrevio = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtAlergiasPrevio = new System.Windows.Forms.TextBox();
            this.txtPadecimientosPrevios = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.txtPadecimientosPrevios);
            this.panel1.Controls.Add(this.txtAlergiasPrevio);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtPesoPrevio);
            this.panel1.Controls.Add(this.txtAlturaPrevia);
            this.panel1.Controls.Add(this.txtEdadPrevio);
            this.panel1.Controls.Add(this.txtPadecimientos);
            this.panel1.Controls.Add(this.txtAlergias);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnConfirmar);
            this.panel1.Controls.Add(this.txtPaciente);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtPeso);
            this.panel1.Controls.Add(this.txtAltura);
            this.panel1.Controls.Add(this.txtEdad);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 33);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1076, 686);
            this.panel1.TabIndex = 0;
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirmar.BackgroundImage = global::Astra.Properties.Resources.Confirmar_pacietne;
            this.btnConfirmar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.Location = new System.Drawing.Point(410, 359);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(176, 165);
            this.btnConfirmar.TabIndex = 8;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            this.btnConfirmar.Click += new System.EventHandler(this.btnConfirmar_Click);
            // 
            // txtPaciente
            // 
            this.txtPaciente.BackColor = System.Drawing.SystemColors.ControlText;
            this.txtPaciente.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtPaciente.Location = new System.Drawing.Point(123, 23);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.ReadOnly = true;
            this.txtPaciente.Size = new System.Drawing.Size(160, 29);
            this.txtPaciente.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 22);
            this.label4.TabIndex = 6;
            this.label4.Text = "Paciente";
            // 
            // txtPeso
            // 
            this.txtPeso.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtPeso.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtPeso.Location = new System.Drawing.Point(52, 282);
            this.txtPeso.Name = "txtPeso";
            this.txtPeso.Size = new System.Drawing.Size(100, 29);
            this.txtPeso.TabIndex = 5;
            // 
            // txtAltura
            // 
            this.txtAltura.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtAltura.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtAltura.Location = new System.Drawing.Point(52, 198);
            this.txtAltura.Name = "txtAltura";
            this.txtAltura.Size = new System.Drawing.Size(100, 29);
            this.txtAltura.TabIndex = 4;
            // 
            // txtEdad
            // 
            this.txtEdad.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtEdad.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.txtEdad.Location = new System.Drawing.Point(52, 111);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(100, 29);
            this.txtEdad.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Peso (Kilogramos)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Altura (Metros)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Edad";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.btnCerrar);
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1076, 37);
            this.panel2.TabIndex = 1;
            this.panel2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
            this.panel2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
            this.panel2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Transparent;
            this.btnCerrar.BackgroundImage = global::Astra.Properties.Resources.Cerrar;
            this.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCerrar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCerrar.Location = new System.Drawing.Point(1030, 3);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(43, 33);
            this.btnCerrar.TabIndex = 0;
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(679, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 28);
            this.label5.TabIndex = 9;
            this.label5.Text = "Datos previos";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(540, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 22);
            this.label6.TabIndex = 10;
            this.label6.Text = "Edad";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(670, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(114, 22);
            this.label7.TabIndex = 11;
            this.label7.Text = "Altura (Metros)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(870, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(132, 22);
            this.label8.TabIndex = 12;
            this.label8.Text = "Peso (Kilogramos)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(200, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 22);
            this.label9.TabIndex = 13;
            this.label9.Text = "Alergias";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(200, 156);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(107, 22);
            this.label10.TabIndex = 14;
            this.label10.Text = "Padecimientos";
            // 
            // txtAlergias
            // 
            this.txtAlergias.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtAlergias.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtAlergias.Location = new System.Drawing.Point(183, 111);
            this.txtAlergias.Name = "txtAlergias";
            this.txtAlergias.Size = new System.Drawing.Size(124, 29);
            this.txtAlergias.TabIndex = 15;
            // 
            // txtPadecimientos
            // 
            this.txtPadecimientos.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtPadecimientos.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtPadecimientos.Location = new System.Drawing.Point(183, 198);
            this.txtPadecimientos.Name = "txtPadecimientos";
            this.txtPadecimientos.Size = new System.Drawing.Size(124, 29);
            this.txtPadecimientos.TabIndex = 16;
            // 
            // txtEdadPrevio
            // 
            this.txtEdadPrevio.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtEdadPrevio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtEdadPrevio.Location = new System.Drawing.Point(513, 111);
            this.txtEdadPrevio.Name = "txtEdadPrevio";
            this.txtEdadPrevio.ReadOnly = true;
            this.txtEdadPrevio.Size = new System.Drawing.Size(100, 29);
            this.txtEdadPrevio.TabIndex = 17;
            // 
            // txtAlturaPrevia
            // 
            this.txtAlturaPrevia.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtAlturaPrevia.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtAlturaPrevia.Location = new System.Drawing.Point(674, 111);
            this.txtAlturaPrevia.Name = "txtAlturaPrevia";
            this.txtAlturaPrevia.ReadOnly = true;
            this.txtAlturaPrevia.Size = new System.Drawing.Size(100, 29);
            this.txtAlturaPrevia.TabIndex = 18;
            // 
            // txtPesoPrevio
            // 
            this.txtPesoPrevio.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtPesoPrevio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtPesoPrevio.Location = new System.Drawing.Point(874, 111);
            this.txtPesoPrevio.Name = "txtPesoPrevio";
            this.txtPesoPrevio.ReadOnly = true;
            this.txtPesoPrevio.Size = new System.Drawing.Size(128, 29);
            this.txtPesoPrevio.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(528, 156);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 22);
            this.label11.TabIndex = 20;
            this.label11.Text = "Alergias";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(674, 156);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 22);
            this.label12.TabIndex = 21;
            this.label12.Text = "Padecimientos";
            // 
            // txtAlergiasPrevio
            // 
            this.txtAlergiasPrevio.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtAlergiasPrevio.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtAlergiasPrevio.Location = new System.Drawing.Point(484, 198);
            this.txtAlergiasPrevio.Name = "txtAlergiasPrevio";
            this.txtAlergiasPrevio.ReadOnly = true;
            this.txtAlergiasPrevio.Size = new System.Drawing.Size(142, 29);
            this.txtAlergiasPrevio.TabIndex = 22;
            // 
            // txtPadecimientosPrevios
            // 
            this.txtPadecimientosPrevios.BackColor = System.Drawing.SystemColors.MenuText;
            this.txtPadecimientosPrevios.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtPadecimientosPrevios.Location = new System.Drawing.Point(652, 198);
            this.txtPadecimientosPrevios.Name = "txtPadecimientosPrevios";
            this.txtPadecimientosPrevios.ReadOnly = true;
            this.txtPadecimientosPrevios.Size = new System.Drawing.Size(147, 29);
            this.txtPadecimientosPrevios.TabIndex = 23;
            // 
            // Form7
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImage = global::Astra.Properties.Resources.Fondo_2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1072, 718);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form7";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form7_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPeso;
        private System.Windows.Forms.TextBox txtAltura;
        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAlturaPrevia;
        private System.Windows.Forms.TextBox txtEdadPrevio;
        private System.Windows.Forms.TextBox txtPadecimientos;
        private System.Windows.Forms.TextBox txtAlergias;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPesoPrevio;
        private System.Windows.Forms.TextBox txtPadecimientosPrevios;
        private System.Windows.Forms.TextBox txtAlergiasPrevio;
    }
}