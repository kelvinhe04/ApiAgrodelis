namespace AgrodelisForm
{
    partial class FormVendedor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVendedor));
            this.panel4 = new System.Windows.Forms.Panel();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.picBoxProducto = new System.Windows.Forms.PictureBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuNuevo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuRegistrar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuModificar = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuEliminar = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewProductos = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RutaImagen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CategoriaNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ofdProducto = new System.Windows.Forms.OpenFileDialog();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxProducto)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.btnCerrarSesion);
            this.panel4.Controls.Add(this.cmbCategoria);
            this.panel4.Controls.Add(this.picBoxProducto);
            this.panel4.Controls.Add(this.txtStock);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.menuStrip1);
            this.panel4.Controls.Add(this.dataGridViewProductos);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.txtPrecio);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.txtNombre);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.txtDescripcion);
            this.panel4.Controls.Add(this.label1);
            this.panel4.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.panel4.Location = new System.Drawing.Point(13, 146);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1664, 797);
            this.panel4.TabIndex = 18;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(334, 177);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(244, 24);
            this.cmbCategoria.TabIndex = 20;
            // 
            // picBoxProducto
            // 
            this.picBoxProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picBoxProducto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBoxProducto.Location = new System.Drawing.Point(334, 234);
            this.picBoxProducto.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picBoxProducto.Name = "picBoxProducto";
            this.picBoxProducto.Size = new System.Drawing.Size(189, 192);
            this.picBoxProducto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBoxProducto.TabIndex = 19;
            this.picBoxProducto.TabStop = false;
            this.picBoxProducto.Click += new System.EventHandler(this.picBoxProducto_Click);
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(44, 404);
            this.txtStock.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(248, 22);
            this.txtStock.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(330, 145);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "Categoria";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 372);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 36;
            this.label3.Text = "Stock";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuNuevo,
            this.toolStripMenuRegistrar,
            this.toolStripMenuModificar,
            this.toolStripMenuEliminar});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1662, 28);
            this.menuStrip1.TabIndex = 35;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuNuevo
            // 
            this.toolStripMenuNuevo.Name = "toolStripMenuNuevo";
            this.toolStripMenuNuevo.Size = new System.Drawing.Size(66, 24);
            this.toolStripMenuNuevo.Text = "Nuevo";
            this.toolStripMenuNuevo.Click += new System.EventHandler(this.toolStripMenuNuevo_Click);
            // 
            // toolStripMenuRegistrar
            // 
            this.toolStripMenuRegistrar.Name = "toolStripMenuRegistrar";
            this.toolStripMenuRegistrar.Size = new System.Drawing.Size(82, 24);
            this.toolStripMenuRegistrar.Text = "Registrar";
            this.toolStripMenuRegistrar.Click += new System.EventHandler(this.toolStripMenuRegistrar_Click);
            // 
            // toolStripMenuModificar
            // 
            this.toolStripMenuModificar.Name = "toolStripMenuModificar";
            this.toolStripMenuModificar.Size = new System.Drawing.Size(87, 24);
            this.toolStripMenuModificar.Text = "Modificar";
            this.toolStripMenuModificar.Click += new System.EventHandler(this.toolStripMenuModificar_Click);
            // 
            // toolStripMenuEliminar
            // 
            this.toolStripMenuEliminar.Name = "toolStripMenuEliminar";
            this.toolStripMenuEliminar.Size = new System.Drawing.Size(77, 24);
            this.toolStripMenuEliminar.Text = "Eliminar";
            this.toolStripMenuEliminar.Click += new System.EventHandler(this.toolStripMenuEliminar_Click);
            // 
            // dataGridViewProductos
            // 
            this.dataGridViewProductos.AllowUserToAddRows = false;
            this.dataGridViewProductos.AllowUserToDeleteRows = false;
            this.dataGridViewProductos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(74)))), ((int)(((byte)(104)))));
            this.dataGridViewProductos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProductos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Descripcion,
            this.Precio,
            this.Stock,
            this.RutaImagen,
            this.CategoriaNombre});
            this.dataGridViewProductos.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridViewProductos.Location = new System.Drawing.Point(529, 220);
            this.dataGridViewProductos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridViewProductos.Name = "dataGridViewProductos";
            this.dataGridViewProductos.ReadOnly = true;
            this.dataGridViewProductos.RowHeadersWidth = 51;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dataGridViewProductos.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewProductos.RowTemplate.Height = 24;
            this.dataGridViewProductos.Size = new System.Drawing.Size(710, 244);
            this.dataGridViewProductos.TabIndex = 25;
            this.dataGridViewProductos.SelectionChanged += new System.EventHandler(this.dataGridViewProductos_SelectionChanged);
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "Nombre";
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.Nombre.DefaultCellStyle = dataGridViewCellStyle1;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 80;
            // 
            // Descripcion
            // 
            this.Descripcion.DataPropertyName = "Descripcion";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.Descripcion.DefaultCellStyle = dataGridViewCellStyle2;
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.MinimumWidth = 6;
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 125;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "Precio";
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.Precio.DefaultCellStyle = dataGridViewCellStyle3;
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 80;
            // 
            // Stock
            // 
            this.Stock.DataPropertyName = "Stock";
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.Stock.DefaultCellStyle = dataGridViewCellStyle4;
            this.Stock.HeaderText = "Stock";
            this.Stock.MinimumWidth = 6;
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            this.Stock.Width = 60;
            // 
            // RutaImagen
            // 
            this.RutaImagen.DataPropertyName = "RutaImagen";
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            this.RutaImagen.DefaultCellStyle = dataGridViewCellStyle5;
            this.RutaImagen.HeaderText = "Ruta Imagen";
            this.RutaImagen.MinimumWidth = 6;
            this.RutaImagen.Name = "RutaImagen";
            this.RutaImagen.ReadOnly = true;
            this.RutaImagen.Width = 125;
            // 
            // CategoriaNombre
            // 
            this.CategoriaNombre.DataPropertyName = "CategoriaNombre";
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            this.CategoriaNombre.DefaultCellStyle = dataGridViewCellStyle6;
            this.CategoriaNombre.HeaderText = "Categoria";
            this.CategoriaNombre.MinimumWidth = 6;
            this.CategoriaNombre.Name = "CategoriaNombre";
            this.CategoriaNombre.ReadOnly = true;
            this.CategoriaNombre.Width = 160;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.label7.Location = new System.Drawing.Point(35, 49);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(194, 25);
            this.label7.TabIndex = 18;
            this.label7.Text = "Rellenar Productos";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(44, 333);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(248, 22);
            this.txtPrecio.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(36, 220);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Descripcion";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(40, 177);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(248, 22);
            this.txtNombre.TabIndex = 28;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(40, 302);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 20);
            this.label6.TabIndex = 31;
            this.label6.Text = "Precio";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(40, 250);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(248, 22);
            this.txtDescripcion.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(36, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "Nombre";
            // 
            // ofdProducto
            // 
            this.ofdProducto.FileName = "openFileDialog1";
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Location = new System.Drawing.Point(40, 87);
            this.btnCerrarSesion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(108, 40);
            this.btnCerrarSesion.TabIndex = 19;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // FormVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1373, 715);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormVendedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormVendedor";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxProducto)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuNuevo;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuRegistrar;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuModificar;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuEliminar;
        private System.Windows.Forms.DataGridView dataGridViewProductos;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picBoxProducto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.OpenFileDialog ofdProducto;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn RutaImagen;
        private System.Windows.Forms.DataGridViewTextBoxColumn CategoriaNombre;
    }
}