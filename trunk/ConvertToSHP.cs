using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using MapTools;

namespace OSM2SHP
{
    class ConvertToSHP
    {
        int areas = 0, ways = 0, points = 0;
        ArrayList linesNames, polygonsNames, pointsNames;
        osm infile;

        public ConvertToSHP(osm infile)
        {
            areas = 0;
            ways = 0;
            points = 0;

            this.infile = infile;

            foreach (way nWay in infile.wayCollection)
            {
                if (nWay.ndCollection[0].reff == nWay.ndCollection[nWay.ndCollection.Count - 1].reff)
                {
                    areas++;
                }
                else
                {
                    ways++;
                }

                foreach (nd nNd in nWay.ndCollection)
                {
                    node nNode = infile.nodeCollection.GetByRef(nNd.reff);
                    nNode.InWay = true;
                }

            }

            foreach (node nNode in infile.nodeCollection)
            {
                if (!nNode.InWay)
                {
                    points++;
                }
            }
        }

        private void WriteDBF(ShapeLib.ShapeType shapetype, string SHPFile)
        {
            string filename;
            int shapes = 0;
            ArrayList nameList;

            switch (shapetype)
            {
                case ShapeLib.ShapeType.Polygon:
                    filename = SHPFile + "-polygons";
                    shapes = areas;
                    nameList = polygonsNames;
                    break;
                case ShapeLib.ShapeType.PolyLine:
                    filename = SHPFile + "-lines";
                    shapes = ways;
                    nameList = linesNames;
                    break;
                case ShapeLib.ShapeType.Point:
                    filename = SHPFile + "-points";
                    shapes = points;
                    nameList = pointsNames;
                    break;
                default:
                    return;
            }

            IntPtr hDbf = ShapeLib.DBFCreate(filename);
            if (hDbf.Equals(IntPtr.Zero))
            {
                Console.WriteLine("Error:  Unable to create {0}.dbf!", filename);
                return;
            }

            // add some fields 
            int iRet = ShapeLib.DBFAddField(hDbf, "shapeID", ShapeLib.DBFFieldType.FTInteger, 4, 0);
            iRet = ShapeLib.DBFAddField(hDbf, "shapeName", ShapeLib.DBFFieldType.FTString, 50, 0);
            //iRet = ShapeLib.DBFAddField(hDbf, "dblField", ShapeLib.DBFFieldType.FTDouble, 8, 4);
            //iRet = ShapeLib.DBFAddField(hDbf, "boolField", ShapeLib.DBFFieldType.FTLogical, 1, 0);
            //iRet = ShapeLib.DBFAddField(hDbf, "dateField", ShapeLib.DBFFieldType.FTDate, 8, 0);

            // populate
            for (int iShape = 0; iShape < shapes; iShape++)
            {
                iRet = (ShapeLib.DBFWriteIntegerAttribute(hDbf, iShape, 0, iShape));
                iRet = (ShapeLib.DBFWriteStringAttribute(hDbf, iShape, 1, nameList[iShape].ToString()));
                //iRet = (ShapeLib.DBFWriteDoubleAttribute(hDbf, iShape, iField++, (100 * r.NextDouble())));
                //iRet = (ShapeLib.DBFWriteLogicalAttribute(hDbf, iShape, iField++, iShape % 2 == 0));
                //iRet = (ShapeLib.DBFWriteDateAttribute(hDbf, iShape, iField++, DateTime.Now));
            }

            // set a few null values
            //iRet = ShapeLib.DBFWriteNULLAttribute(hDbf, 0, 0);
            //iRet = ShapeLib.DBFWriteNULLAttribute(hDbf, 1, 1);
            //iRet = ShapeLib.DBFWriteNULLAttribute(hDbf, 2, 2);
            //iRet = ShapeLib.DBFWriteNULLAttribute(hDbf, 1, 3);
            //iRet = ShapeLib.DBFWriteNULLAttribute(hDbf, 0, 4);

            // modify a value
            //iRet = (ShapeLib.DBFWriteStringAttribute(hDbf, 2, 1, "Greetings, Earthlings"));

            ShapeLib.DBFClose(hDbf);
        }

        public string SaveToShapefile(string SHPFile, bool points, bool lines, bool polygons)
        {
            ShapeLib.ShapeType shapetype;
            double[] x, y;
            IntPtr hShpPoly = IntPtr.Zero, hShpLine = IntPtr.Zero, hShpPoint = IntPtr.Zero;

            linesNames = new ArrayList();
            polygonsNames = new ArrayList();
            pointsNames = new ArrayList();
            
            if (lines)
            {
                // create a new PolyLines shapefile
                hShpLine = ShapeLib.SHPCreate(SHPFile + "-lines", ShapeLib.ShapeType.PolyLine);
                if (hShpLine.Equals(IntPtr.Zero))
                    return "Cannot create lines file!";
            }

            if (polygons)
            {
                // create a new Polygons shapefile
                hShpPoly = ShapeLib.SHPCreate(SHPFile + "-polygons", ShapeLib.ShapeType.Polygon);
                if (hShpPoly.Equals(IntPtr.Zero))
                    return "Cannot create polygons file!";
            }

            if (points)
            {
                // create a new Points shapefile
                hShpPoint = ShapeLib.SHPCreate(SHPFile + "-points", ShapeLib.ShapeType.Point);
                if (hShpPoint.Equals(IntPtr.Zero))
                    return "Cannot create points file!";
            }

            /*iterate through OSM ways*/
            foreach (way strada in infile.wayCollection)
            {
                /*check if the way is closed, set shape type accordingly*/
                if (strada.ndCollection[0].reff == strada.ndCollection[strada.ndCollection.Count - 1].reff)
                {
                    shapetype = ShapeLib.ShapeType.Polygon;
                }
                else
                {
                    shapetype = ShapeLib.ShapeType.PolyLine;
                }
                x = new double[strada.ndCollection.Count];
                y = new double[strada.ndCollection.Count];

                /*iterate through all the nodes in the way, set x and y coords*/
                int i = 0;
                foreach (nd nod in strada.ndCollection)
                {
                    node nodcomplet = infile.nodeCollection.GetByRef(nod.reff);
                    /*TO DO: Regional settings - to be checked*/
                    x[i] = double.Parse(nodcomplet.lon.Replace('.', ','));
                    y[i] = double.Parse(nodcomplet.lat.Replace('.', ','));
                    nodcomplet.InWay = true;
                    i++;
                }

                /*finding way name*/
                string shapeName = "";
                foreach (tag t in strada.tagCollection)
                {
                    if (t.k == "name")
                    {
                        shapeName = t.v;
                        //break;
                    }

                    /*just to make sure that all the streets are
                     *put in the polylines file*/
                    if ((t.k == "highway") && (shapetype == ShapeLib.ShapeType.Polygon))
                    {
                        shapetype = ShapeLib.ShapeType.PolyLine;
                        areas--;
                        ways++;
                    }

                    /*exception for circular ways: junction:roundabout 
                     * should be marked as polyline, not as polygon*/
                    if ((t.k == "junction") && (t.v == "roundabout") && (shapetype == ShapeLib.ShapeType.Polygon))
                    {
                        shapetype = ShapeLib.ShapeType.PolyLine;
                        areas--;
                        ways++;
                    }
                }

                /*create object, write it to file and destroy it*/
                IntPtr pshpObj = ShapeLib.SHPCreateSimpleObject(shapetype,
                    strada.ndCollection.Count, x, y, new double[strada.ndCollection.Count]);
                int iRet;
                if ((shapetype == ShapeLib.ShapeType.PolyLine) && lines)
                {
                    iRet = ShapeLib.SHPWriteObject(hShpLine, -1, pshpObj);
                    /*add shape name to correct list*/
                    linesNames.Add(shapeName);
                }
                else if ((shapetype == ShapeLib.ShapeType.Polygon) && (polygons))
                {
                    iRet = ShapeLib.SHPWriteObject(hShpPoly, -1, pshpObj);
                    /*add shape name to correct list*/
                    polygonsNames.Add(shapeName);
                }
                ShapeLib.SHPDestroyObject(pshpObj);
            }

            if (points)
            {
                /*write the nodes that are not part of any way*/
                foreach (node nod in infile.nodeCollection)
                {
                    if (!nod.InWay)
                    {

                        x = new double[1];
                        y = new double[1];

                        /*TO DO: Regional settings - to be checked*/
                        x[0] = double.Parse(nod.lon.Replace('.', ','));
                        y[0] = double.Parse(nod.lat.Replace('.', ','));

                        /*finding node name*/
                        string shapeName = "";
                        foreach (tag t in nod.tagCollection)
                        {
                            if (t.k == "name")
                            {
                                shapeName = t.v;
                                break;
                            }
                        }

                        /*create object, write it to file and destroy it*/
                        IntPtr pshpObj = ShapeLib.SHPCreateSimpleObject(ShapeLib.ShapeType.Point,
                            1, x, y, new double[1]);
                        int iRet = ShapeLib.SHPWriteObject(hShpPoint, -1, pshpObj);
                        pointsNames.Add(shapeName);
                        ShapeLib.SHPDestroyObject(pshpObj);
                    }
                }
            }

            // free resources and write dbf files
            if (polygons)
            {
                ShapeLib.SHPClose(hShpPoly);
                WriteDBF(ShapeLib.ShapeType.Polygon, SHPFile);
            }
            if (lines)
            {
                ShapeLib.SHPClose(hShpLine);
                WriteDBF(ShapeLib.ShapeType.PolyLine, SHPFile);
            }
            if (points)
            {
                ShapeLib.SHPClose(hShpPoint);
                WriteDBF(ShapeLib.ShapeType.Point, SHPFile);
            }
            return "Completed!";
        }
    }
}
