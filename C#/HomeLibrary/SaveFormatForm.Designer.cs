namespace HomeLibrary
{
    partial class SaveFormatForm
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
            this.txtCheckBox = new System.Windows.Forms.CheckBox();
            this.excelCheckBox = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.htmlCheckBox = new System.Windows.Forms.CheckBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCheckBox
            // 
            this.txtCheckBox.AutoSize = true;
            this.txtCheckBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtCheckBox.Location = new System.Drawing.Point(17, 37);
            this.txtCheckBox.Name = "txtCheckBox";
            this.txtCheckBox.Size = new System.Drawing.Size(54, 25);
            this.txtCheckBox.TabIndex = 0;
            this.txtCheckBox.Text = "TXT";
            this.txtCheckBox.UseVisualStyleBackColor = true;
            // 
            // excelCheckBox
            // 
            this.excelCheckBox.AutoSize = true;
            this.excelCheckBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.excelCheckBox.Location = new System.Drawing.Point(17, 68);
            this.excelCheckBox.Name = "excelCheckBox";
            this.excelCheckBox.Size = new System.Drawing.Size(69, 25);
            this.excelCheckBox.TabIndex = 2;
            this.excelCheckBox.Text = "Excel";
            this.excelCheckBox.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(167, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Выберите тип:";
            // 
            // htmlCheckBox
            // 
            this.htmlCheckBox.AutoSize = true;
            this.htmlCheckBox.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.htmlCheckBox.Location = new System.Drawing.Point(17, 99);
            this.htmlCheckBox.Name = "htmlCheckBox";
            this.htmlCheckBox.Size = new System.Drawing.Size(70, 25);
            this.htmlCheckBox.TabIndex = 4;
            this.htmlCheckBox.Text = "HTML";
            this.htmlCheckBox.UseVisualStyleBackColor = true;
            // 
            // saveButton
            // 
            this.saveButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.saveButton.Location = new System.Drawing.Point(12, 130);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(177, 38);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Сохранить";
            this.saveButton.UseVisualStyleBackColor = true;
            // 
            // SaveFormatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(201, 178);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.htmlCheckBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.excelCheckBox);
            this.Controls.Add(this.txtCheckBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SaveFormatForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Сохранение";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox txtCheckBox;
        private System.Windows.Forms.CheckBox excelCheckBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox htmlCheckBox;
        private System.Windows.Forms.Button saveButton;
    }
}