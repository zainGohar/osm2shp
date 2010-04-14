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
        string OSMFile;
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

            ConversionOptions options = new ConversionOptions();
            options.Lines = cbLines.Checked;
            options.Points = cbPoints.Checked;
            options.Polygons = cbPolygons.Checked;
            options.ConvertTags = cbExtractMetaData.Checked;
            options.Projection = tbProjection.Text;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // This is to get around a peculiar behaviour of ShapeLib.
                // If the selected file has an extension, it is overwritten,
                // no matter which additions are made to the filename in
                // ConvertToSHP. By stripping the extension and all additions
                // made by previous runs of the program, it is ensured that
                // new *-points, *-lines, and *-polygons files are created.
                string tempName = saveFileDialog1.FileName;
                tempName = tempName.Substring(0, tempName.LastIndexOf("."));
                if (tempName.LastIndexOf("-points") > 0)
                {
                    tempName = tempName.Substring(0, tempName.LastIndexOf("-points"));
                }
                if (tempName.LastIndexOf("-lines") > 0)
                {
                    tempName = tempName.Substring(0, tempName.LastIndexOf("-lines"));
                }
                if (tempName.LastIndexOf("-polygons") > 0)
                {
                    tempName = tempName.Substring(0, tempName.LastIndexOf("-polygons"));
                }
                options.Filename = tempName;
            }
            else
                return;

            
            
            exportlog = export.SaveToShapefile(options);
            txtSave.Text += exportlog;

        }

    }
}