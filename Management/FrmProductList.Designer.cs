namespace Management
{
    partial class FrmProductList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.lblLink = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.gvProdList = new System.Windows.Forms.DataGridView();
            this.colBtnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colBtnEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.colProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CURRENCY_CODE = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProductSummary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataSetProducts1 = new Management.Datasets.DataSetProducts();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProdList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProducts1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblLink);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Controls.Add(this.btnNew);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 75);
            this.panel1.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(382, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(256, 18);
            this.label6.TabIndex = 16;
            this.label6.Text = "You can confirm the products at following URL";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLink
            // 
            this.lblLink.AutoSize = true;
            this.lblLink.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblLink.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblLink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lblLink.Location = new System.Drawing.Point(381, 39);
            this.lblLink.Name = "lblLink";
            this.lblLink.Size = new System.Drawing.Size(270, 16);
            this.lblLink.TabIndex = 15;
            this.lblLink.Text = "https://demo.cdbc.cloud/pcstore/";
            this.lblLink.Click += new System.EventHandler(this.LblLink_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Georgia", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTitle.Location = new System.Drawing.Point(12, 24);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(246, 25);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Product Management";
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(856, 25);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(118, 30);
            this.btnNew.TabIndex = 0;
            this.btnNew.Text = "New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.BtnNew_Click);
            // 
            // gvProdList
            // 
            this.gvProdList.AllowUserToAddRows = false;
            this.gvProdList.AllowUserToDeleteRows = false;
            this.gvProdList.AutoGenerateColumns = false;
            this.gvProdList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gvProdList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvProdList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBtnDelete,
            this.colBtnEdit,
            this.colProductCode,
            this.colProductName,
            this.CURRENCY_CODE,
            this.colProductPrice,
            this.colProductSummary,
            this.colCategoryName});
            this.gvProdList.DataMember = "PRODUCTS";
            this.gvProdList.DataSource = this.dataSetProducts1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gvProdList.DefaultCellStyle = dataGridViewCellStyle2;
            this.gvProdList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gvProdList.Location = new System.Drawing.Point(0, 75);
            this.gvProdList.Margin = new System.Windows.Forms.Padding(4);
            this.gvProdList.MultiSelect = false;
            this.gvProdList.Name = "gvProdList";
            this.gvProdList.ReadOnly = true;
            this.gvProdList.RowHeadersWidth = 5;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(176)))), ((int)(((byte)(206)))));
            this.gvProdList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.gvProdList.RowTemplate.Height = 21;
            this.gvProdList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvProdList.Size = new System.Drawing.Size(1008, 566);
            this.gvProdList.TabIndex = 2;
            this.gvProdList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GvProdList_CellClick);
            // 
            // colBtnDelete
            // 
            this.colBtnDelete.FillWeight = 60F;
            this.colBtnDelete.HeaderText = "";
            this.colBtnDelete.Name = "colBtnDelete";
            this.colBtnDelete.ReadOnly = true;
            this.colBtnDelete.Text = "Delete";
            this.colBtnDelete.UseColumnTextForButtonValue = true;
            this.colBtnDelete.Width = 60;
            // 
            // colBtnEdit
            // 
            this.colBtnEdit.FillWeight = 60F;
            this.colBtnEdit.HeaderText = "";
            this.colBtnEdit.Name = "colBtnEdit";
            this.colBtnEdit.ReadOnly = true;
            this.colBtnEdit.Text = "Edit";
            this.colBtnEdit.UseColumnTextForButtonValue = true;
            this.colBtnEdit.Width = 60;
            // 
            // colProductCode
            // 
            this.colProductCode.DataPropertyName = "PRODUCT_CODE";
            this.colProductCode.FillWeight = 150F;
            this.colProductCode.HeaderText = "Code";
            this.colProductCode.Name = "colProductCode";
            this.colProductCode.ReadOnly = true;
            this.colProductCode.Width = 150;
            // 
            // colProductName
            // 
            this.colProductName.DataPropertyName = "PRODUCT_NAME";
            this.colProductName.FillWeight = 280F;
            this.colProductName.HeaderText = "Name";
            this.colProductName.Name = "colProductName";
            this.colProductName.ReadOnly = true;
            this.colProductName.Width = 280;
            // 
            // CURRENCY_CODE
            // 
            this.CURRENCY_CODE.DataPropertyName = "CURRENCY_CODE";
            this.CURRENCY_CODE.FillWeight = 60F;
            this.CURRENCY_CODE.HeaderText = "Currency";
            this.CURRENCY_CODE.Name = "CURRENCY_CODE";
            this.CURRENCY_CODE.ReadOnly = true;
            this.CURRENCY_CODE.Width = 60;
            // 
            // colProductPrice
            // 
            this.colProductPrice.DataPropertyName = "PRODUCT_PRICE";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = null;
            this.colProductPrice.DefaultCellStyle = dataGridViewCellStyle1;
            this.colProductPrice.FillWeight = 80F;
            this.colProductPrice.HeaderText = "Price";
            this.colProductPrice.Name = "colProductPrice";
            this.colProductPrice.ReadOnly = true;
            this.colProductPrice.Width = 80;
            // 
            // colProductSummary
            // 
            this.colProductSummary.DataPropertyName = "PRODUCT_SUMMARY";
            this.colProductSummary.FillWeight = 200F;
            this.colProductSummary.HeaderText = "Summary";
            this.colProductSummary.Name = "colProductSummary";
            this.colProductSummary.ReadOnly = true;
            this.colProductSummary.Width = 200;
            // 
            // colCategoryName
            // 
            this.colCategoryName.DataPropertyName = "CATEGORY_NAME";
            this.colCategoryName.FillWeight = 80F;
            this.colCategoryName.HeaderText = "Category";
            this.colCategoryName.Name = "colCategoryName";
            this.colCategoryName.ReadOnly = true;
            this.colCategoryName.Width = 80;
            // 
            // dataSetProducts1
            // 
            this.dataSetProducts1.DataSetName = "DataSetProducts";
            this.dataSetProducts1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // FrmProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 641);
            this.Controls.Add(this.gvProdList);
            this.Controls.Add(this.panel1);
            this.Name = "FrmProductList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product List";
            this.Load += new System.EventHandler(this.FrmProductList_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvProdList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetProducts1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView gvProdList;
        private Datasets.DataSetProducts dataSetProducts1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DataGridViewButtonColumn colBtnDelete;
        private System.Windows.Forms.DataGridViewButtonColumn colBtnEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CURRENCY_CODE;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProductSummary;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCategoryName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblLink;
    }
}