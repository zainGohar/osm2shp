
namespace OSM2SHP
{

    /// <summary>
    /// Contains information about the conversion process.
    /// </summary>
    public class ConversionOptions
    {
        private bool _points;
        private bool _lines;
        private bool _polygons;
        private bool _convertTags;

        private string _projection;
        private string _filename;

        /// <summary>
        /// Should points be converted?
        /// </summary>
        public bool Points
        {
            get { return _points; }
            set { _points = value; }
        }

        /// <summary>
        /// Should lines be converted?
        /// </summary>
        public bool Lines
        {
            get { return _lines; }
            set { _lines = value; }
        }

        /// <summary>
        /// Should polygons be converted?
        /// </summary>
        public bool Polygons
        {
            get { return _polygons; }
            set { _polygons = value; }
        }

        /// <summary>
        /// Should OSM tags be used as the source of database entries?
        /// </summary>
        public bool ConvertTags
        {
            get { return _convertTags; }
            set { _convertTags = value; }
        }

        /// <summary>
        /// The projection to use
        /// </summary>
        public string Projection
        {
            get { return _projection; }
            set { _projection = value; }
        }

        /// <summary>
        /// The name of the target shape file
        /// </summary>
        public string Filename
        {
            get { return _filename; }
            set { _filename = value; }
        }

    }
}