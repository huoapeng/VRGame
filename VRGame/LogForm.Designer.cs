namespace VRGame
{
    partial class LogForm
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.findfile = new System.Windows.Forms.Button();
            this.filePath = new System.Windows.Forms.Label();
            this.resultllabel = new System.Windows.Forms.Label();
            this.generalResult = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // findfile
            // 
            this.findfile.Location = new System.Drawing.Point(75, 70);
            this.findfile.Name = "findfile";
            this.findfile.Size = new System.Drawing.Size(114, 53);
            this.findfile.TabIndex = 0;
            this.findfile.Text = "查找文件";
            this.findfile.UseVisualStyleBackColor = true;
            this.findfile.Click += new System.EventHandler(this.findfile_Click);
            // 
            // filePath
            // 
            this.filePath.AutoSize = true;
            this.filePath.Location = new System.Drawing.Point(241, 87);
            this.filePath.Name = "filePath";
            this.filePath.Size = new System.Drawing.Size(0, 18);
            this.filePath.TabIndex = 1;
            // 
            // resultllabel
            // 
            this.resultllabel.AutoSize = true;
            this.resultllabel.Location = new System.Drawing.Point(286, 217);
            this.resultllabel.Name = "resultllabel";
            this.resultllabel.Size = new System.Drawing.Size(0, 18);
            this.resultllabel.TabIndex = 2;
            // 
            // generalResult
            // 
            this.generalResult.Location = new System.Drawing.Point(75, 201);
            this.generalResult.Name = "generalResult";
            this.generalResult.Size = new System.Drawing.Size(114, 51);
            this.generalResult.TabIndex = 3;
            this.generalResult.Text = "生成结果";
            this.generalResult.UseVisualStyleBackColor = true;
            this.generalResult.Click += new System.EventHandler(this.generalResult_Click);
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 455);
            this.Controls.Add(this.generalResult);
            this.Controls.Add(this.resultllabel);
            this.Controls.Add(this.filePath);
            this.Controls.Add(this.findfile);
            this.Name = "LogForm";
            this.Text = "LogForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button findfile;
        private System.Windows.Forms.Label filePath;
        private System.Windows.Forms.Label resultllabel;
        private System.Windows.Forms.Button generalResult;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}