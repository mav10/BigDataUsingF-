namespace ChicagoCrime
{
  partial class Form1
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
            this.cmdByYear = new System.Windows.Forms.Button();
            this.graphPanel = new System.Windows.Forms.Panel();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.CrimesvsArrests = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.byArea = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.chicago = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdByYear
            // 
            this.cmdByYear.Location = new System.Drawing.Point(12, 12);
            this.cmdByYear.Name = "cmdByYear";
            this.cmdByYear.Size = new System.Drawing.Size(95, 62);
            this.cmdByYear.TabIndex = 0;
            this.cmdByYear.Text = "By Year";
            this.cmdByYear.UseVisualStyleBackColor = true;
            this.cmdByYear.Click += new System.EventHandler(this.cmdByYear_Click);
            // 
            // graphPanel
            // 
            this.graphPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.graphPanel.BackColor = System.Drawing.Color.White;
            this.graphPanel.Location = new System.Drawing.Point(123, 12);
            this.graphPanel.Name = "graphPanel";
            this.graphPanel.Size = new System.Drawing.Size(769, 454);
            this.graphPanel.TabIndex = 1;
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilename.BackColor = System.Drawing.SystemColors.Control;
            this.txtFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFilename.Location = new System.Drawing.Point(123, 474);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(769, 26);
            this.txtFilename.TabIndex = 2;
            this.txtFilename.Text = "Crimes-2013-2015.csv";
            // 
            // CrimesvsArrests
            // 
            this.CrimesvsArrests.Location = new System.Drawing.Point(12, 95);
            this.CrimesvsArrests.Name = "CrimesvsArrests";
            this.CrimesvsArrests.Size = new System.Drawing.Size(95, 62);
            this.CrimesvsArrests.TabIndex = 3;
            this.CrimesvsArrests.Text = "Arrest %";
            this.CrimesvsArrests.UseVisualStyleBackColor = true;
            this.CrimesvsArrests.Click += new System.EventHandler(this.CrimesvsArrests_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 177);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(95, 62);
            this.button1.TabIndex = 4;
            this.button1.Text = "By Crime";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 245);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(95, 29);
            this.textBox1.TabIndex = 5;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // byArea
            // 
            this.byArea.Location = new System.Drawing.Point(12, 293);
            this.byArea.Name = "byArea";
            this.byArea.Size = new System.Drawing.Size(95, 62);
            this.byArea.TabIndex = 6;
            this.byArea.Text = "By Area";
            this.byArea.UseVisualStyleBackColor = true;
            this.byArea.Click += new System.EventHandler(this.byArea_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(12, 361);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(95, 29);
            this.textBox2.TabIndex = 7;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // chicago
            // 
            this.chicago.Location = new System.Drawing.Point(12, 404);
            this.chicago.Name = "chicago";
            this.chicago.Size = new System.Drawing.Size(95, 62);
            this.chicago.TabIndex = 8;
            this.chicago.Text = "Chicago";
            this.chicago.UseVisualStyleBackColor = true;
            this.chicago.Click += new System.EventHandler(this.chicago_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 508);
            this.Controls.Add(this.chicago);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.byArea);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CrimesvsArrests);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.graphPanel);
            this.Controls.Add(this.cmdByYear);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chicago Crime Analysis";
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button cmdByYear;
    private System.Windows.Forms.Panel graphPanel;
    private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Button CrimesvsArrests;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button byArea;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button chicago;
    }
}

