using System;
using System.Collections.Generic;

namespace OSM2SHP {

    /// <summary>
    /// Holds meta data of shapes. Currently, the name is specified directly
    /// and the rest of the OSM tags go into a dictionary that reflects the
    /// key-value pairs used in OSM.
    /// </summary>
    public class MetaData
    {
        private string _name;
        private Dictionary<string, string> _tags = new Dictionary<string,string>();

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Dictionary<string, string> tags
        {
            get { return _tags; }
            set { _tags = value; }
        }
            
    }
}