namespace HomeLibrary
{
    partial class EditSelectionForm
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
            this.confirmButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonType = new System.Windows.Forms.RadioButton();
            this.radioButtonTitle = new System.Windows.Forms.RadioButton();
            this.radioButtonAuthor = new System.Windows.Forms.RadioButton();
            this.radioButtonGenre = new System.Windows.Forms.RadioButton();
            this.radioButtonYear = new System.Windows.Forms.RadioButton();
            this.radioButtonDescription = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // confirmButton
            // 
            this.confirmButton.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.confirmButton.Location = new System.Drawing.Point(12, 223);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(245, 38);
            this.confirmButton.TabIndex = 7;
            this.confirmButton.Text = "Подтвердить";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(245, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Что хотите изменить?";
            // 
            // radioButtonType
            // 
            this.radioButtonType.AutoSize = true;
            this.radioButtonType.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonType.Location = new System.Drawing.Point(17, 37);
            this.radioButtonType.Name = "radioButtonType";
            this.radioButtonType.Size = new System.Drawing.Size(56, 25);
            this.radioButtonType.TabIndex = 8;
            this.radioButtonType.TabStop = true;
            this.radioButtonType.Text = "Тип";
            this.radioButtonType.UseVisualStyleBackColor = true;
            // 
            // radioButtonTitle
            // 
            this.radioButtonTitle.AutoSize = true;
            this.radioButtonTitle.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonTitle.Location = new System.Drawing.Point(17, 68);
            this.radioButtonTitle.Name = "radioButtonTitle";
            this.radioButtonTitle.Size = new System.Drawing.Size(105, 25);
            this.radioButtonTitle.TabIndex = 10;
            this.radioButtonTitle.TabStop = true;
            this.radioButtonTitle.Text = "Название";
            this.radioButtonTitle.UseVisualStyleBackColor = true;
            // 
            // radioButtonAuthor
            // 
            this.radioButtonAuthor.AutoSize = true;
            this.radioButtonAuthor.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.radioButtonAuthor.Location = new System.Drawing.Point(17, 99);
            this.radioButtonAuthor.Name = "radioButtonAuthor";
            this.radioButtonAuthor.Size = new System.Drawing.Size(75, 25);
            this.radioButtonAuthor.TabIndex = 11;
            this.radioButtonAuthor.TabStop = true;
            this.radioButtonAuthor.Text = "Автор";
            this.radioButtonAuthor.UseVisualStyleBackColor = true;
            // 
            // radioButtonGenre
            // 
            this.radioButtonGenre.AutoSize = true;
            this.radioButtonGenre.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.radioButtonGenre.Location = new System.Drawing.Point(17, 130);
            this.radioButtonGenre.Name = "radioButtonGenre";
            this.radioButtonGenre.Size = new System.Drawing.Size(75, 25);
            this.radioButtonGenre.TabIndex = 12;
            this.radioButtonGenre.TabStop = true;
            this.radioButtonGenre.Text = "Жанр";
            this.radioButtonGenre.UseVisualStyleBackColor = true;
            // 
            // radioButtonYear
            // 
            this.radioButtonYear.AutoSize = true;
            this.radioButtonYear.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.radioButtonYear.Location = new System.Drawing.Point(17, 161);
            this.radioButtonYear.Name = "radioButtonYear";
            this.radioButtonYear.Size = new System.Drawing.Size(54, 25);
            this.radioButtonYear.TabIndex = 13;
            this.radioButtonYear.TabStop = true;
            this.radioButtonYear.Text = "Год";
            this.radioButtonYear.UseVisualStyleBackColor = true;
            // 
            // radioButtonDescription
            // 
            this.radioButtonDescription.AutoSize = true;
            this.radioButtonDescription.Font = new System.Drawing.Font("Century Gothic", 12F);
            this.radioButtonDescription.Location = new System.Drawing.Point(17, 192);
            this.radioButtonDescription.Name = "radioButtonDescription";
            this.radioButtonDescription.Size = new System.Drawing.Size(113, 25);
            this.radioButtonDescription.TabIndex = 14;
            this.radioButtonDescription.TabStop = true;
            this.radioButtonDescription.Text = "Описание";
            this.radioButtonDescription.UseVisualStyleBackColor = true;
            // 
            // EditSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 271);
            this.Controls.Add(this.radioButtonDescription);
            this.Controls.Add(this.radioButtonYear);
            this.Controls.Add(this.radioButtonGenre);
            this.Controls.Add(this.radioButtonAuthor);
            this.Controls.Add(this.radioButtonTitle);
            this.Controls.Add(this.radioButtonType);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.label1);
            this.Name = "EditSelectionForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButtonType;
        private System.Windows.Forms.RadioButton radioButtonTitle;
        private System.Windows.Forms.RadioButton radioButtonAuthor;
        private System.Windows.Forms.RadioButton radioButtonGenre;
        private System.Windows.Forms.RadioButton radioButtonYear;
        private System.Windows.Forms.RadioButton radioButtonDescription;
    }
}