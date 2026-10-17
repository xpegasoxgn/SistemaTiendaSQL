namespace Tienda.Presentacion
{
    partial class FormProductos
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtIdProducto = new TextBox();
            txtNombre = new TextBox();
            txtPrecio = new TextBox();
            txtStock = new TextBox();
            txtIdCategoria = new TextBox();
            btnListar = new Button();
            btnRegistrar = new Button();
            btnActualizar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            dgvProductos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Black", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(803, 56);
            label1.Name = "label1";
            label1.Size = new Size(790, 51);
            label1.TabIndex = 0;
            label1.Text = "SISTEMA DE GESTION DE PRODUCTOS";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 8.25F);
            label2.Location = new Point(644, 227);
            label2.Name = "label2";
            label2.Size = new Size(71, 20);
            label2.TabIndex = 1;
            label2.Text = "Codigo: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(630, 283);
            label3.Name = "label3";
            label3.Size = new Size(79, 25);
            label3.TabIndex = 2;
            label3.Text = "nombre:";
            label3.Click += label3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(650, 374);
            label4.Name = "label4";
            label4.Size = new Size(65, 25);
            label4.TabIndex = 3;
            label4.Text = "precio:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(651, 434);
            label5.Name = "label5";
            label5.Size = new Size(58, 25);
            label5.TabIndex = 4;
            label5.Text = "stock:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(616, 500);
            label6.Name = "label6";
            label6.Size = new Size(105, 25);
            label6.TabIndex = 5;
            label6.Text = "id categoria";
            // 
            // txtIdProducto
            // 
            txtIdProducto.Location = new Point(771, 220);
            txtIdProducto.Name = "txtIdProducto";
            txtIdProducto.ReadOnly = true;
            txtIdProducto.Size = new Size(150, 31);
            txtIdProducto.TabIndex = 6;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(771, 283);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(150, 31);
            txtNombre.TabIndex = 7;
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(771, 368);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(150, 31);
            txtPrecio.TabIndex = 8;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(771, 434);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(150, 31);
            txtStock.TabIndex = 9;
            // 
            // txtIdCategoria
            // 
            txtIdCategoria.Location = new Point(771, 497);
            txtIdCategoria.Name = "txtIdCategoria";
            txtIdCategoria.Size = new Size(150, 31);
            txtIdCategoria.TabIndex = 10;
            // 
            // btnListar
            // 
            btnListar.BackColor = SystemColors.AppWorkspace;
            btnListar.Location = new Point(1806, 190);
            btnListar.Name = "btnListar";
            btnListar.Size = new Size(112, 42);
            btnListar.TabIndex = 11;
            btnListar.Text = "LISTAR";
            btnListar.TextAlign = ContentAlignment.MiddleRight;
            btnListar.UseVisualStyleBackColor = false;
            btnListar.Click += btnListar_Click;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Location = new Point(1806, 264);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(112, 34);
            btnRegistrar.TabIndex = 12;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            // 
            // btnActualizar
            // 
            btnActualizar.Location = new Point(1806, 350);
            btnActualizar.Name = "btnActualizar";
            btnActualizar.Size = new Size(112, 34);
            btnActualizar.TabIndex = 13;
            btnActualizar.Text = "Actualizar";
            btnActualizar.UseVisualStyleBackColor = true;
            btnActualizar.Click += button3_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(1806, 432);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(112, 34);
            btnEliminar.TabIndex = 14;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(1806, 500);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(112, 34);
            btnLimpiar.TabIndex = 15;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.CellBorderStyle = DataGridViewCellBorderStyle.SingleVertical;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(747, 622);
            dgvProductos.MultiSelect = false;
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersWidth = 62;
            dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProductos.Size = new Size(1171, 520);
            dgvProductos.TabIndex = 16;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // FormProductos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(2503, 1259);
            Controls.Add(dgvProductos);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnActualizar);
            Controls.Add(btnRegistrar);
            Controls.Add(btnListar);
            Controls.Add(txtIdCategoria);
            Controls.Add(txtStock);
            Controls.Add(txtPrecio);
            Controls.Add(txtNombre);
            Controls.Add(txtIdProducto);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormProductos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sistema de productos";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txtIdProducto;
        private TextBox txtNombre;
        private TextBox txtPrecio;
        private TextBox txtStock;
        private TextBox txtIdCategoria;
        private Button btnListar;
        private Button btnRegistrar;
        private Button btnActualizar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private DataGridView dgvProductos;
    }
}
