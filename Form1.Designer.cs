namespace OSM2SHP
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlOpen = new System.Windows.Forms.Panel();
            this.txtOpen = new System.Windows.Forms.TextBox();
            this.pnlSave = new System.Windows.Forms.Panel();
            this.txtSave = new System.Windows.Forms.TextBox();
            this.pnlOptions = new System.Windows.Forms.Panel();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.tbProjection = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbExtractMetaData = new System.Windows.Forms.CheckBox();
            this.cbPolygons = new System.Windows.Forms.CheckBox();
            this.cbLines = new System.Windows.Forms.CheckBox();
            this.cbPoints = new System.Windows.Forms.CheckBox();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlOpen.SuspendLayout();
            this.pnlSave.SuspendLayout();
            this.pnlOptions.SuspendLayout();
            this.grpOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "osm";
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "OSM files|*.osm";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOpen,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(594, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbOpen
            // 
            this.tsbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpen.Image")));
            this.tsbOpen.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbOpen.Name = "tsbOpen";
            this.tsbOpen.Size = new System.Drawing.Size(23, 22);
            this.tsbOpen.Text = "Open OSM file";
            this.tsbOpen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tsbOpen.Click += new System.EventHandler(this.tsbOpen_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "Save Shapefile";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlOpen);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.pnlSave);
            this.splitContainer1.Panel2.Controls.Add(this.pnlOptions);
            this.splitContainer1.Size = new System.Drawing.Size(594, 239);
            this.splitContainer1.SplitterDistance = 197;
            this.splitContainer1.TabIndex = 2;
            // 
            // pnlOpen
            // 
            this.pnlOpen.Controls.Add(this.txtOpen);
            this.pnlOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlOpen.Location = new System.Drawing.Point(0, 0);
            this.pnlOpen.Name = "pnlOpen";
            this.pnlOpen.Size = new System.Drawing.Size(197, 239);
            this.pnlOpen.TabIndex = 0;
            // 
            // txtOpen
            // 
            this.txtOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOpen.Location = new System.Drawing.Point(0, 0);
            this.txtOpen.Multiline = true;
            this.txtOpen.Name = "txtOpen";
            this.txtOpen.ReadOnly = true;
            this.txtOpen.Size = new System.Drawing.Size(197, 239);
            this.txtOpen.TabIndex = 0;
            // 
            // pnlSave
            // 
            this.pnlSave.Controls.Add(this.txtSave);
            this.pnlSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSave.Location = new System.Drawing.Point(0, 105);
            this.pnlSave.Name = "pnlSave";
            this.pnlSave.Size = new System.Drawing.Size(393, 134);
            this.pnlSave.TabIndex = 1;
            // 
            // txtSave
            // 
            this.txtSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSave.Location = new System.Drawing.Point(0, 0);
            this.txtSave.Multiline = true;
            this.txtSave.Name = "txtSave";
            this.txtSave.ReadOnly = true;
            this.txtSave.Size = new System.Drawing.Size(393, 134);
            this.txtSave.TabIndex = 1;
            // 
            // pnlOptions
            // 
            this.pnlOptions.BackColor = System.Drawing.SystemColors.Control;
            this.pnlOptions.Controls.Add(this.grpOptions);
            this.pnlOptions.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlOptions.Location = new System.Drawing.Point(0, 0);
            this.pnlOptions.Name = "pnlOptions";
            this.pnlOptions.Size = new System.Drawing.Size(393, 105);
            this.pnlOptions.TabIndex = 0;
            // 
            // grpOptions
            // 
            this.grpOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOptions.Controls.Add(this.tbProjection);
            this.grpOptions.Controls.Add(this.label1);
            this.grpOptions.Controls.Add(this.cbExtractMetaData);
            this.grpOptions.Controls.Add(this.cbPolygons);
            this.grpOptions.Controls.Add(this.cbLines);
            this.grpOptions.Controls.Add(this.cbPoints);
            this.grpOptions.Location = new System.Drawing.Point(16, 3);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(365, 96);
            this.grpOptions.TabIndex = 0;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // tbProjection
            // 
            this.tbProjection.Location = new System.Drawing.Point(88, 63);
            this.tbProjection.Name = "tbProjection";
            this.tbProjection.Size = new System.Drawing.Size(271, 20);
            this.tbProjection.TabIndex = 5;
            this.tbProjection.Text = "GEOGCS[\"GCS_WGS_1984\",DATUM[\"D_WGS_1984\",SPHEROID[\"WGS_1984\",6378137,298.25722356" +
                "3]],PRIMEM[\"Greenwich\",0],UNIT[\"Degree\",0.017453292519943295]]\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Projection";
            // 
            // cbExtractMetaData
            // 
            this.cbExtractMetaData.AutoSize = true;
            this.cbExtractMetaData.Location = new System.Drawing.Point(31, 40);
            this.cbExtractMetaData.Name = "cbExtractMetaData";
            this.cbExtractMetaData.Size = new System.Drawing.Size(148, 17);
            this.cbExtractMetaData.TabIndex = 3;
            this.cbExtractMetaData.Text = "Convert tags to meta data";
            this.cbExtractMetaData.UseVisualStyleBackColor = true;
            // 
            // cbPolygons
            // 
            this.cbPolygons.AutoSize = true;
            this.cbPolygons.Location = new System.Drawing.Point(205, 17);
            this.cbPolygons.Name = "cbPolygons";
            this.cbPolygons.Size = new System.Drawing.Size(69, 17);
            this.cbPolygons.TabIndex = 2;
            this.cbPolygons.Text = "Polygons";
            this.cbPolygons.UseVisualStyleBackColor = true;
            // 
            // cbLines
            // 
            this.cbLines.AutoSize = true;
            this.cbLines.Checked = true;
            this.cbLines.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLines.Location = new System.Drawing.Point(118, 17);
            this.cbLines.Name = "cbLines";
            this.cbLines.Size = new System.Drawing.Size(51, 17);
            this.cbLines.TabIndex = 1;
            this.cbLines.Text = "Lines";
            this.cbLines.UseVisualStyleBackColor = true;
            // 
            // cbPoints
            // 
            this.cbPoints.AutoSize = true;
            this.cbPoints.Location = new System.Drawing.Point(31, 17);
            this.cbPoints.Name = "cbPoints";
            this.cbPoints.Size = new System.Drawing.Size(55, 17);
            this.cbPoints.TabIndex = 0;
            this.cbPoints.Text = "Points";
            this.cbPoints.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 264);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmMain";
            this.Text = "OSM2SHP";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.pnlOpen.ResumeLayout(false);
            this.pnlOpen.PerformLayout();
            this.pnlSave.ResumeLayout(false);
            this.pnlSave.PerformLayout();
            this.pnlOptions.ResumeLayout(false);
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbOpen;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.Panel pnlSave;
        private System.Windows.Forms.Panel pnlOpen;
        private System.Windows.Forms.TextBox txtOpen;
        private System.Windows.Forms.TextBox txtSave;
        private System.Windows.Forms.CheckBox cbPolygons;
        private System.Windows.Forms.CheckBox cbLines;
        private System.Windows.Forms.CheckBox cbPoints;
        private System.Windows.Forms.CheckBox cbExtractMetaData;
        private System.Windows.Forms.TextBox tbProjection;
        private System.Windows.Forms.Label label1;
    }
}

