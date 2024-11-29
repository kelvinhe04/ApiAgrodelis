namespace AgrodelisForm
{
    partial class FormLogin
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
            this.panelLogin = new System.Windows.Forms.Panel();
            this.lblRegistrate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContraLogin = new System.Windows.Forms.TextBox();
            this.txtEmailLogin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panelRegistrar = new System.Windows.Forms.Panel();
            this.lblIniciarSesion = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEmailRegistrar = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtContraRegistrar = new System.Windows.Forms.TextBox();
            this.txtUsuarioRegistrar = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panelLogin.SuspendLayout();
            this.panelRegistrar.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.White;
            this.panelLogin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLogin.Controls.Add(this.lblRegistrate);
            this.panelLogin.Controls.Add(this.label1);
            this.panelLogin.Controls.Add(this.label7);
            this.panelLogin.Controls.Add(this.btnLogin);
            this.panelLogin.Controls.Add(this.label2);
            this.panelLogin.Controls.Add(this.txtContraLogin);
            this.panelLogin.Controls.Add(this.txtEmailLogin);
            this.panelLogin.Controls.Add(this.label3);
            this.panelLogin.Location = new System.Drawing.Point(570, 207);
            this.panelLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(340, 401);
            this.panelLogin.TabIndex = 9;
            this.panelLogin.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLogin_Paint);
            // 
            // lblRegistrate
            // 
            this.lblRegistrate.AutoSize = true;
            this.lblRegistrate.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.lblRegistrate.Location = new System.Drawing.Point(163, 331);
            this.lblRegistrate.Name = "lblRegistrate";
            this.lblRegistrate.Size = new System.Drawing.Size(107, 16);
            this.lblRegistrate.TabIndex = 11;
            this.lblRegistrate.Text = "Regístrate ahora";
            this.lblRegistrate.Click += new System.EventHandler(this.lblRegistrate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 330);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "¿No tienes cuenta?";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(121, 26);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(90, 32);
            this.label7.TabIndex = 9;
            this.label7.Text = "Login";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.btnLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnLogin.FlatAppearance.BorderColor = System.Drawing.SystemColors.HighlightText;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnLogin.Location = new System.Drawing.Point(111, 266);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(109, 43);
            this.btnLogin.TabIndex = 6;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(38, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email";
            // 
            // txtContraLogin
            // 
            this.txtContraLogin.Location = new System.Drawing.Point(41, 202);
            this.txtContraLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContraLogin.Name = "txtContraLogin";
            this.txtContraLogin.Size = new System.Drawing.Size(249, 22);
            this.txtContraLogin.TabIndex = 5;
            this.txtContraLogin.UseSystemPasswordChar = true;
            // 
            // txtEmailLogin
            // 
            this.txtEmailLogin.Location = new System.Drawing.Point(41, 130);
            this.txtEmailLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmailLogin.Name = "txtEmailLogin";
            this.txtEmailLogin.Size = new System.Drawing.Size(249, 22);
            this.txtEmailLogin.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(38, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contraseña";
            // 
            // panelRegistrar
            // 
            this.panelRegistrar.BackColor = System.Drawing.Color.White;
            this.panelRegistrar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelRegistrar.Controls.Add(this.lblIniciarSesion);
            this.panelRegistrar.Controls.Add(this.label9);
            this.panelRegistrar.Controls.Add(this.txtEmailRegistrar);
            this.panelRegistrar.Controls.Add(this.label4);
            this.panelRegistrar.Controls.Add(this.label5);
            this.panelRegistrar.Controls.Add(this.btnRegistrar);
            this.panelRegistrar.Controls.Add(this.label6);
            this.panelRegistrar.Controls.Add(this.txtContraRegistrar);
            this.panelRegistrar.Controls.Add(this.txtUsuarioRegistrar);
            this.panelRegistrar.Controls.Add(this.label8);
            this.panelRegistrar.Location = new System.Drawing.Point(570, 207);
            this.panelRegistrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelRegistrar.Name = "panelRegistrar";
            this.panelRegistrar.Size = new System.Drawing.Size(340, 472);
            this.panelRegistrar.TabIndex = 10;
            // 
            // lblIniciarSesion
            // 
            this.lblIniciarSesion.AutoSize = true;
            this.lblIniciarSesion.BackColor = System.Drawing.Color.White;
            this.lblIniciarSesion.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblIniciarSesion.Location = new System.Drawing.Point(184, 406);
            this.lblIniciarSesion.Name = "lblIniciarSesion";
            this.lblIniciarSesion.Size = new System.Drawing.Size(81, 16);
            this.lblIniciarSesion.TabIndex = 12;
            this.lblIniciarSesion.Text = "Inicia sesión";
            this.lblIniciarSesion.Click += new System.EventHandler(this.lblIniciarSesion_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(67, 406);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 16);
            this.label9.TabIndex = 11;
            this.label9.Text = "¿Ya tienes cuenta? ";
            // 
            // txtEmailRegistrar
            // 
            this.txtEmailRegistrar.Location = new System.Drawing.Point(42, 208);
            this.txtEmailRegistrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtEmailRegistrar.Name = "txtEmailRegistrar";
            this.txtEmailRegistrar.Size = new System.Drawing.Size(249, 22);
            this.txtEmailRegistrar.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(39, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 25);
            this.label4.TabIndex = 10;
            this.label4.Text = "Email";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(105, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(154, 32);
            this.label5.TabIndex = 9;
            this.label5.Text = "Registrate";
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(62)))), ((int)(((byte)(60)))));
            this.btnRegistrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnRegistrar.FlatAppearance.BorderColor = System.Drawing.SystemColors.HighlightText;
            this.btnRegistrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrar.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnRegistrar.Location = new System.Drawing.Point(111, 342);
            this.btnRegistrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(109, 43);
            this.btnRegistrar.TabIndex = 6;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = false;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(38, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "Usuario";
            // 
            // txtContraRegistrar
            // 
            this.txtContraRegistrar.Location = new System.Drawing.Point(42, 282);
            this.txtContraRegistrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtContraRegistrar.Name = "txtContraRegistrar";
            this.txtContraRegistrar.Size = new System.Drawing.Size(249, 22);
            this.txtContraRegistrar.TabIndex = 5;
            this.txtContraRegistrar.UseSystemPasswordChar = true;
            // 
            // txtUsuarioRegistrar
            // 
            this.txtUsuarioRegistrar.Location = new System.Drawing.Point(41, 134);
            this.txtUsuarioRegistrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtUsuarioRegistrar.Name = "txtUsuarioRegistrar";
            this.txtUsuarioRegistrar.Size = new System.Drawing.Size(249, 22);
            this.txtUsuarioRegistrar.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(39, 250);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(114, 25);
            this.label8.TabIndex = 2;
            this.label8.Text = "Contraseña";
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1211, 632);
            this.Controls.Add(this.panelRegistrar);
            this.Controls.Add(this.panelLogin);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogin";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.panelRegistrar.ResumeLayout(false);
            this.panelRegistrar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContraLogin;
        private System.Windows.Forms.TextBox txtEmailLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelRegistrar;
        private System.Windows.Forms.TextBox txtEmailRegistrar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtContraRegistrar;
        private System.Windows.Forms.TextBox txtUsuarioRegistrar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblIniciarSesion;
        private System.Windows.Forms.Label lblRegistrate;
        private System.Windows.Forms.Label label1;
    }
}

