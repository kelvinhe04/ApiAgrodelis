﻿namespace AgrodelisForm
{
    partial class Inventario
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventario));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle50 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle55 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle56 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle51 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle52 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle53 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle54 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dataGridViewInventario = new System.Windows.Forms.DataGridView();
            this.comboBoxVendedores = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTodoVendedores = new System.Windows.Forms.Button();
            this.ProductoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VendedorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreVendedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreCategoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventario)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(137)))), ((int)(((byte)(219)))));
            this.panel1.Controls.Add(this.btnCerrarSesion);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1427, 39);
            this.panel1.TabIndex = 22;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(137)))), ((int)(((byte)(219)))));
            this.btnCerrarSesion.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 0);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(162, 39);
            this.btnCerrarSesion.TabIndex = 19;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Location = new System.Drawing.Point(1382, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(45, 39);
            this.btnClose.TabIndex = 7;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label7.Location = new System.Drawing.Point(954, 2);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 32);
            this.label7.TabIndex = 18;
            this.label7.Text = "Inventario";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel4.Controls.Add(this.btnTodoVendedores);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.comboBoxVendedores);
            this.panel4.Controls.Add(this.dataGridViewInventario);
            this.panel4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.panel4.Location = new System.Drawing.Point(380, 280);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1322, 494);
            this.panel4.TabIndex = 23;
            // 
            // dataGridViewInventario
            // 
            this.dataGridViewInventario.AllowUserToAddRows = false;
            this.dataGridViewInventario.AllowUserToDeleteRows = false;
            dataGridViewCellStyle50.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewInventario.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle50;
            this.dataGridViewInventario.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(137)))), ((int)(((byte)(219)))));
            this.dataGridViewInventario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewInventario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInventario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductoId,
            this.NombreProducto,
            this.VendedorId,
            this.NombreVendedor,
            this.Descripcion,
            this.Stock,
            this.Precio,
            this.NombreCategoria});
            this.dataGridViewInventario.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(137)))), ((int)(((byte)(219)))));
            this.dataGridViewInventario.Location = new System.Drawing.Point(30, 177);
            this.dataGridViewInventario.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewInventario.Name = "dataGridViewInventario";
            this.dataGridViewInventario.ReadOnly = true;
            dataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle55.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle55.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle55.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle55.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle55.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle55.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle55.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewInventario.RowHeadersDefaultCellStyle = dataGridViewCellStyle55;
            this.dataGridViewInventario.RowHeadersWidth = 51;
            dataGridViewCellStyle56.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle56.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle56.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle56.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle56.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewInventario.RowsDefaultCellStyle = dataGridViewCellStyle56;
            this.dataGridViewInventario.RowTemplate.Height = 24;
            this.dataGridViewInventario.Size = new System.Drawing.Size(981, 268);
            this.dataGridViewInventario.TabIndex = 25;
            // 
            // comboBoxVendedores
            // 
            this.comboBoxVendedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxVendedores.FormattingEnabled = true;
            this.comboBoxVendedores.Location = new System.Drawing.Point(1042, 90);
            this.comboBoxVendedores.Name = "comboBoxVendedores";
            this.comboBoxVendedores.Size = new System.Drawing.Size(245, 28);
            this.comboBoxVendedores.TabIndex = 26;
            this.comboBoxVendedores.SelectedIndexChanged += new System.EventHandler(this.comboBoxVendedores_SelectedIndexChanged_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(315, 25);
            this.label1.TabIndex = 41;
            this.label1.Text = "Inventario de todos los vendedores";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1037, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 25);
            this.label2.TabIndex = 42;
            this.label2.Text = "Filtrar";
            // 
            // btnTodoVendedores
            // 
            this.btnTodoVendedores.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(89)))), ((int)(((byte)(137)))), ((int)(((byte)(219)))));
            this.btnTodoVendedores.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTodoVendedores.FlatAppearance.BorderColor = System.Drawing.SystemColors.HighlightText;
            this.btnTodoVendedores.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTodoVendedores.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTodoVendedores.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnTodoVendedores.Location = new System.Drawing.Point(30, 90);
            this.btnTodoVendedores.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTodoVendedores.Name = "btnTodoVendedores";
            this.btnTodoVendedores.Size = new System.Drawing.Size(128, 39);
            this.btnTodoVendedores.TabIndex = 24;
            this.btnTodoVendedores.Text = "Todos ";
            this.btnTodoVendedores.UseVisualStyleBackColor = false;
            this.btnTodoVendedores.Click += new System.EventHandler(this.btnTodoVendedores_Click);
            // 
            // ProductoId
            // 
            this.ProductoId.DataPropertyName = "ProductoId";
            this.ProductoId.HeaderText = "ProductoId";
            this.ProductoId.MinimumWidth = 6;
            this.ProductoId.Name = "ProductoId";
            this.ProductoId.ReadOnly = true;
            this.ProductoId.Width = 70;
            // 
            // NombreProducto
            // 
            this.NombreProducto.DataPropertyName = "NombreProducto";
            dataGridViewCellStyle51.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle51.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle51.SelectionForeColor = System.Drawing.Color.Black;
            this.NombreProducto.DefaultCellStyle = dataGridViewCellStyle51;
            this.NombreProducto.HeaderText = "Producto";
            this.NombreProducto.MinimumWidth = 6;
            this.NombreProducto.Name = "NombreProducto";
            this.NombreProducto.ReadOnly = true;
            this.NombreProducto.Width = 80;
            // 
            // VendedorId
            // 
            this.VendedorId.DataPropertyName = "VendedorId";
            this.VendedorId.HeaderText = "VendedorId";
            this.VendedorId.MinimumWidth = 6;
            this.VendedorId.Name = "VendedorId";
            this.VendedorId.ReadOnly = true;
            this.VendedorId.Width = 70;
            // 
            // NombreVendedor
            // 
            this.NombreVendedor.DataPropertyName = "NombreVendedor";
            this.NombreVendedor.HeaderText = "NombreVendedor";
            this.NombreVendedor.MinimumWidth = 6;
            this.NombreVendedor.Name = "NombreVendedor";
            this.NombreVendedor.ReadOnly = true;
            this.NombreVendedor.Width = 125;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 140;
            // 
            // Stock
            // 
            this.Stock.DataPropertyName = "Stock";
            dataGridViewCellStyle52.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle52.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle52.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle52.SelectionForeColor = System.Drawing.Color.Black;
            this.Stock.DefaultCellStyle = dataGridViewCellStyle52;
            this.Stock.HeaderText = "Stock";
            this.Stock.MinimumWidth = 6;
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            this.Stock.Width = 50;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "Precio";
            dataGridViewCellStyle53.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle53.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle53.SelectionForeColor = System.Drawing.Color.Black;
            this.Precio.DefaultCellStyle = dataGridViewCellStyle53;
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 50;
            // 
            // NombreCategoria
            // 
            this.NombreCategoria.DataPropertyName = "NombreCategoria";
            dataGridViewCellStyle54.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle54.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle54.SelectionForeColor = System.Drawing.Color.Black;
            this.NombreCategoria.DefaultCellStyle = dataGridViewCellStyle54;
            this.NombreCategoria.HeaderText = "Categoria";
            this.NombreCategoria.MinimumWidth = 6;
            this.NombreCategoria.Name = "NombreCategoria";
            this.NombreCategoria.ReadOnly = true;
            this.NombreCategoria.Width = 80;
            // 
            // Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1427, 694);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Inventario";
            this.Text = "Inventario";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Inventario_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInventario)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dataGridViewInventario;
        private System.Windows.Forms.ComboBox comboBoxVendedores;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnTodoVendedores;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductoId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn VendedorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreVendedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreCategoria;
    }
}