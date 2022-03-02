
namespace PrecastConcretePlantView
{
    partial class FormReinforced
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
            this.labelName = new System.Windows.Forms.Label();
            this.labelPrice = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.groupBoxComponent = new System.Windows.Forms.GroupBox();
            this.ButtonRef = new System.Windows.Forms.Button();
            this.ButtonDel = new System.Windows.Forms.Button();
            this.ButtonUpd = new System.Windows.Forms.Button();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ButtonSave = new System.Windows.Forms.Button();
            this.ButtonCansel = new System.Windows.Forms.Button();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnComponent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBoxComponent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 19);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(80, 20);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Название:";
            // 
            // labelPrice
            // 
            this.labelPrice.AutoSize = true;
            this.labelPrice.Location = new System.Drawing.Point(13, 53);
            this.labelPrice.Name = "labelPrice";
            this.labelPrice.Size = new System.Drawing.Size(48, 20);
            this.labelPrice.TabIndex = 1;
            this.labelPrice.Text = "Цена:";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(117, 16);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(265, 27);
            this.textBoxName.TabIndex = 2;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(117, 53);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(125, 27);
            this.textBoxPrice.TabIndex = 3;
            // 
            // groupBoxComponent
            // 
            this.groupBoxComponent.Controls.Add(this.ButtonRef);
            this.groupBoxComponent.Controls.Add(this.ButtonDel);
            this.groupBoxComponent.Controls.Add(this.ButtonUpd);
            this.groupBoxComponent.Controls.Add(this.ButtonAdd);
            this.groupBoxComponent.Controls.Add(this.dataGridView);
            this.groupBoxComponent.Location = new System.Drawing.Point(13, 107);
            this.groupBoxComponent.Name = "groupBoxComponent";
            this.groupBoxComponent.Size = new System.Drawing.Size(736, 356);
            this.groupBoxComponent.TabIndex = 4;
            this.groupBoxComponent.TabStop = false;
            this.groupBoxComponent.Text = "Компоненты";
            // 
            // ButtonRef
            // 
            this.ButtonRef.Location = new System.Drawing.Point(612, 210);
            this.ButtonRef.Name = "ButtonRef";
            this.ButtonRef.Size = new System.Drawing.Size(94, 29);
            this.ButtonRef.TabIndex = 4;
            this.ButtonRef.Text = "Обновить";
            this.ButtonRef.UseVisualStyleBackColor = true;
            this.ButtonRef.Click += new System.EventHandler(this.ButtonRef_Click);
            // 
            // ButtonDel
            // 
            this.ButtonDel.Location = new System.Drawing.Point(612, 157);
            this.ButtonDel.Name = "ButtonDel";
            this.ButtonDel.Size = new System.Drawing.Size(94, 29);
            this.ButtonDel.TabIndex = 3;
            this.ButtonDel.Text = "Удалить";
            this.ButtonDel.UseVisualStyleBackColor = true;
            this.ButtonDel.Click += new System.EventHandler(this.ButtonDel_Click);
            // 
            // ButtonUpd
            // 
            this.ButtonUpd.Location = new System.Drawing.Point(612, 102);
            this.ButtonUpd.Name = "ButtonUpd";
            this.ButtonUpd.Size = new System.Drawing.Size(94, 29);
            this.ButtonUpd.TabIndex = 2;
            this.ButtonUpd.Text = "Изменить";
            this.ButtonUpd.UseVisualStyleBackColor = true;
            this.ButtonUpd.Click += new System.EventHandler(this.ButtonUpd_Click);
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Location = new System.Drawing.Point(612, 45);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(94, 29);
            this.ButtonAdd.TabIndex = 1;
            this.ButtonAdd.Text = "Добавить";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.ColumnComponent,
            this.ColumnCount});
            this.dataGridView.Location = new System.Drawing.Point(6, 26);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.RowTemplate.Height = 29;
            this.dataGridView.Size = new System.Drawing.Size(569, 324);
            this.dataGridView.TabIndex = 0;
            // 
            // ButtonSave
            // 
            this.ButtonSave.Location = new System.Drawing.Point(546, 473);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(94, 29);
            this.ButtonSave.TabIndex = 5;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // ButtonCansel
            // 
            this.ButtonCansel.Location = new System.Drawing.Point(655, 473);
            this.ButtonCansel.Name = "ButtonCansel";
            this.ButtonCansel.Size = new System.Drawing.Size(94, 29);
            this.ButtonCansel.TabIndex = 6;
            this.ButtonCansel.Text = "Отмена";
            this.ButtonCansel.UseVisualStyleBackColor = true;
            this.ButtonCansel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // ID
            // 
            this.ID.HeaderText = "Id";
            this.ID.MinimumWidth = 6;
            this.ID.Name = "ID";
            this.ID.Visible = false;
            this.ID.Width = 125;
            // 
            // ColumnComponent
            // 
            this.ColumnComponent.HeaderText = "Компонент";
            this.ColumnComponent.MinimumWidth = 6;
            this.ColumnComponent.Name = "ColumnComponent";
            this.ColumnComponent.Width = 400;
            // 
            // ColumnCount
            // 
            this.ColumnCount.HeaderText = "Количество";
            this.ColumnCount.MinimumWidth = 6;
            this.ColumnCount.Name = "ColumnCount";
            this.ColumnCount.Width = 125;
            // 
            // FormReinforced
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 514);
            this.Controls.Add(this.ButtonCansel);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.groupBoxComponent);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelPrice);
            this.Controls.Add(this.labelName);
            this.Name = "FormReinforced";
            this.Text = "Изделие";
            this.Load += new System.EventHandler(this.FormReinforced_Load);
            this.groupBoxComponent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelPrice;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.GroupBox groupBoxComponent;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button ButtonRef;
        private System.Windows.Forms.Button ButtonDel;
        private System.Windows.Forms.Button ButtonUpd;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonSave;
        private System.Windows.Forms.Button ButtonCansel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnComponent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCount;
    }
}