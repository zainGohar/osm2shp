
using System;
using System.Xml;
using System.Collections;

namespace OSM2SHP // TODO, let the user give a namespace
{
    public class node
    {
        
        protected int _id = 0;
        protected DateTime _timestamp = DateTime.MinValue;
        protected string _visible = "";
        protected string _lat = "";
        protected string _lon = "";
        protected tagCollection _tagCollection = new tagCollection();
        protected bool _inway = false;
        
        public int id
        {
            get { return _id; }
            set { _id = value; }
        }

        public bool InWay
        {
            get { return _inway; }
            set { _inway = value; }
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
				
        public string lat
        {
            get { return _lat; }
            set { _lat = value; }
        }
				
        public string lon
        {
            get { return _lon; }
            set { _lon = value; }
        }
				
        public tagCollection tagCollection
        {
            get { return _tagCollection; }
            set { _tagCollection = value; }
        }
				
    
        internal virtual void SaveXml(XmlNode xmlParent)
        {
            XmlAttribute xmlAttribute = null;
            XmlElement xmlElement = null;
		
		      
            if ( _id != 0 )
            {
                xmlAttribute = xmlParent.OwnerDocument.CreateAttribute("id");
                xmlAttribute.Value = _id.ToString();
                xmlParent.Attributes.Append(xmlAttribute);
            }
          
            if ( _timestamp != DateTime.MinValue )
            {
                xmlAttribute = xmlParent.OwnerDocument.CreateAttribute("timestamp");
                xmlAttribute.Value = _timestamp.ToString("yyyy/MM/dd HH:mm:ss");;
                xmlParent.Attributes.Append(xmlAttribute);
            }
          
            if ( _visible != "" )
            {
                xmlAttribute = xmlParent.OwnerDocument.CreateAttribute("visible");
                xmlAttribute.Value = _visible;
                xmlParent.Attributes.Append(xmlAttribute);
            }
          
            if ( _lat != "" )
            {
                xmlAttribute = xmlParent.OwnerDocument.CreateAttribute("lat");
                xmlAttribute.Value = _lat;
                xmlParent.Attributes.Append(xmlAttribute);
            }
          
            if ( _lon != "" )
            {
                xmlAttribute = xmlParent.OwnerDocument.CreateAttribute("lon");
                xmlAttribute.Value = _lon;
                xmlParent.Attributes.Append(xmlAttribute);
            }
          
            foreach ( tag item in _tagCollection )
            {
                xmlElement = xmlParent.OwnerDocument.CreateElement("tag");
                item.SaveXml(xmlElement);
                // When nothing is on the xmlElement then don't add it				
                if ( xmlElement.ChildNodes.Count != 0 || xmlElement.Attributes.Count != 0 || xmlElement.InnerXml.Length != 0 )
                    xmlParent.AppendChild(xmlElement);
            }
          
        }
    
  
    
        internal virtual void ReadXml(XmlElement xmlParent)
        {
	          if ( xmlParent.Attributes != null )
			      {
                foreach ( XmlAttribute xmlAttribute in xmlParent.Attributes )
		            {
			              switch ( xmlAttribute.Name )
					          {
						          
						            case "id" :
							              _id = Convert.ToInt32(xmlAttribute.Value);
							              break;
						          
						            case "timestamp" :
							              _timestamp = Convert.ToDateTime(xmlAttribute.Value);
							              break;
						          
						            case "visible" :
							              _visible = xmlAttribute.Value;
							              break;
						          
						            case "lat" :
							              _lat = xmlAttribute.Value;
							              break;
						          
						            case "lon" :
							              _lon = xmlAttribute.Value;
							              break;
						          
  						
						            default:
                                        break;
							              //throw new ApplicationException(this.GetType().Name + " - Unknown attribute : " + xmlAttribute.Name);
                    }
                }
            }
		   
		        foreach ( XmlNode xmlNode in xmlParent.ChildNodes )
		        {
				        if ( xmlNode.NodeType == XmlNodeType.Element )
				        {
					          switch ( xmlNode.Name )
					          {
					            
						            case "tag" :
							              tag itemtag = new tag();
							              itemtag.ReadXml(xmlNode as XmlElement);
							              _tagCollection.Add(itemtag);
							              break;
					            
  						
						            default:
                                        break;
							            //throw new ApplicationException(this.GetType().Name + " - Unknown element : " + xmlNode.Name);
                    }
				        }
				      
		        }
      }
    
  
    }
	
    #region Collection
    
    public class nodeCollection : IEnumerator, IEnumerable
    {
        
        private ArrayList _list = new ArrayList();
		
		    public int Count
		    {
			      get { return _list.Count; }
		    }
		
		    public node this[int index]
		    {
			      get { return _list[index] as node; }
			      set { _list[index] = value; }
		    }

            public node GetByRef(int id)
            {
                foreach (node nod in _list)
                    if (nod.id == id)
                        return nod;
                return null;
            }
            
            public void Add(node item)
		    {
			      _list.Add(item);
		    }
    		
		    public void Remove(node item)
		    {
			      _list.Remove(item);
		    }
        
        
        #region IEnumerator/IEnumerable Members

		    private int _position = -1;
        
		    public void Reset()
		    {
			      _position = -1;
		    }

		    public object Current
		    {
			      get{ return _list[_position]; }
		    }

		    public bool MoveNext()
		    {
			      _position++;
			      
            if (_position == _list.Count)
				        return false;
			      else
				        return true;
		    }

		    public IEnumerator GetEnumerator()
		    {
			      return _list.GetEnumerator();
		    }

		    #endregion
  

    }
    
    #endregion
}


  