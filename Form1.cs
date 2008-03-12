using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MapTools;

namespace OSM2SHP
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        osm content;
        string OSMFile, SHPFile;
        ConvertToSHP export;


        private void tsbOpen_Click(object sender, EventArgs e)
        {

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                content = new osm();
                OSMFile = openFileDialog1.FileName;
                content.ReadFromFile(OSMFile);
            }
            else return;

            export = new ConvertToSHP(content);
            txtOpen.Clear();
            txtOpen.Text = "File '" + OSMFile + "' opened successfully!" + Environment.NewLine;
            txtOpen.Text += "It contains " + content.nodeCollection.Count.ToString();
            txtOpen.Text += " nodes and " + content.wayCollection.Count.ToString()+" ways.";
            txtOpen.Text += Environment.NewLine + Environment.NewLine;
            //txtOpen.Text += "In terms of shapefiles there are:" + Environment.NewLine;
            //txtOpen.Text += "  -" + areas.ToString() + " polygons" + Environment.NewLine;
            //txtOpen.Text += "  -" + ways.ToString() + " polylines" + Environment.NewLine;
            //txtOpen.Text += "  -" + points.ToString() + " points" + Environment.NewLine;
            
        }

        

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string exportlog;

            /*reinitialize shape names lists*/

            txtSave.Clear();
            /*check that at least one type of shape is selected*/
            if ((!cbLines.Checked) && (!cbPoints.Checked) && (!cbPolygons.Checked))
            {
                txtSave.Text = "You need to select at least one type of shape to export";
                return;
            }

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SHPFile = saveFileDialog1.FileName;
            }
            else
                return;

            exportlog = export.SaveToShapefile(SHPFile, cbPoints.Checked, cbLines.Checked, cbPolygons.Checked);
            txtSave.Text += exportlog;

        }
    }
}