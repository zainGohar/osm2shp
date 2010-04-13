
using System;
using System.Xml;
using System.Collections;

namespace OSM2SHP
{
    /// <summary>
    /// Super class for node and way.
    /// </summary>
    public class element
    {

        protected int _id = 0;
        protected DateTime _timestamp = DateTime.MinValue;
        protected string _visible = "";
        protected bool _deleted = false;
        protected ndCollection _ndCollection = new ndCollection();
        protected tagCollection _tagCollection = new tagCollection();

        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public DateTime timestamp
        {
            get { return _timestamp; }
            set { _timestamp = value; }
        }

        public string visible
        {
            get { return _visible; }
            set { _visible = value; }
        }

        public bool deleted
        {
            get { return _deleted; }
            set { _deleted = value; }
        }

        public ndCollection ndCollection
        {
            get { return _ndCollection; }
            set { _ndCollection = value; }
        }

        public tagCollection tagCollection
        {
            get { return _tagCollection; }
            set { _tagCollection = value; }
        }
    }
}