namespace OfflineCodingExercise.Presenter
{
    partial class FrmOpenlibrary
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnSelection = new System.Windows.Forms.Button();
            this.dgwOpenLibrary = new System.Windows.Forms.DataGridView();
            this.btnGenerateCsv = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwOpenLibrary)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File:";
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(74, 36);
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(599, 20);
            this.txtPath.TabIndex = 1;
            // 
            // btnSelection
            // 
            this.btnSelection.Location = new System.Drawing.Point(679, 34);
            this.btnSelection.Name = "btnSelection";
            this.btnSelection.Size = new System.Drawing.Size(75, 23);
            this.btnSelection.TabIndex = 2;
            this.btnSelection.Text = "Selection";
            this.btnSelection.UseVisualStyleBackColor = true;
            this.btnSelection.Click += new System.EventHandler(this.btnSelection_Click);
            // 
            // dgwOpenLibrary
            // 
            this.dgwOpenLibrary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwOpenLibrary.Location = new System.Drawing.Point(25, 80);
            this.dgwOpenLibrary.Name = "dgwOpenLibrary";
            this.dgwOpenLibrary.ReadOnly = true;
            this.dgwOpenLibrary.Size = new System.Drawing.Size(729, 346);
            this.dgwOpenLibrary.TabIndex = 3;
            // 
            // btnGenerateCsv
            // 
            this.btnGenerateCsv.Location = new System.Drawing.Point(25, 435);
            this.btnGenerateCsv.Name = "btnGenerateCsv";
            this.btnGenerateCsv.Size = new System.Drawing.Size(105, 23);
            this.btnGenerateCsv.TabIndex = 4;
            this.btnGenerateCsv.Text = "Generate csv file";
            this.btnGenerateCsv.UseVisualStyleBackColor = true;
            this.btnGenerateCsv.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // FrmOpenlibrary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 467);
            this.Controls.Add(this.btnGenerateCsv);
            this.Controls.Add(this.dgwOpenLibrary);
            this.Controls.Add(this.btnSelection);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmOpenlibrary";
            this.Text = "Open library data";
            ((System.ComponentModel.ISupportInitialize)(this.dgwOpenLibrary)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnSelection;
        private System.Windows.Forms.DataGridView dgwOpenLibrary;
        private System.Windows.Forms.Button btnGenerateCsv;
    }
}