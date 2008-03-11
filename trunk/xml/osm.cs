
using System;
using System.Xml;
using System.Collections;

namespace OSM2SHP // TODO, let the user give a namespace
{
    public class osm
    {
        
        protected string _version = "";
        protected string _generator = "";
        protected nodeCollection _nodeCollection = new nodeCollection();
        protected wayCollection _wayCollection = new wayCollection();
        
        public string version
        {
            get { return _version; }
            set { _version = value; }
        }
				
        public string generator
        {
            get { return _generator; }
            set { _generator = value; }
        }
				
        public nodeCollection nodeCollection
        {
            get { return _nodeCollection; }
            set { _nodeCollection = value; }
        }
				
        public wayCollection wayCollection
        {
            get { return _wayCollection; }
            set { _wayCollection = value; }
        }
				
    
        public void SaveToFile(string file)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement xmlElement = xmlDocument.CreateElement("osm");
            xmlDocument.AppendChild(xmlElement);

            this.SaveXml(xmlElement);
            xmlDocument.Save(file);
        }
    
  
    
        internal virtual void SaveXml(XmlNode xmlParent)
        {
            XmlAttribute xmlAttribute = null;
            XmlElement xmlElement = null;
		
		      
            if ( _version != "" )
            {
                xmlAttribute = xmlParent.OwnerDocument.CreateAttribute("version");
                xmlAttribute.Value = _version;
                xmlParent.Attributes.Append(xmlAttribute);
            }
          
            if ( _generator != "" )
            {
                xmlAttribute = xmlParent.OwnerDocument.CreateAttribute("generator");
                xmlAttribute.Value = _generator;
                xmlParent.Attributes.Append(xmlAttribute);
            }
          
            foreach ( node item in _nodeCollection )
            {
                xmlElement = xmlParent.OwnerDocument.CreateElement("node");
                item.SaveXml(xmlElement);
                // When nothing is on the xmlElement then don't add it				
                if ( xmlElement.ChildNodes.Count != 0 || xmlElement.Attributes.Count != 0 || xmlElement.InnerXml.Length != 0 )
                    xmlParent.AppendChild(xmlElement);
            }
          
            foreach ( way item in _wayCollection )
            {
                xmlElement = xmlParent.OwnerDocument.CreateElement("way");
                item.SaveXml(xmlElement);
                // When nothing is on the xmlElement then don't add it				
                if ( xmlElement.ChildNodes.Count != 0 || xmlElement.Attributes.Count != 0 || xmlElement.InnerXml.Length != 0 )
                    xmlParent.AppendChild(xmlElement);
            }
          
        }
    
  
      
        public virtual void ReadFromFile(string filename)
        {
			      XmlDocument xmlDocument = new XmlDocument();
			      xmlDocument.Load(filename);
			
			      XmlElement xmlElement = null;
			
			      foreach ( XmlNode xmlNode in xmlDocument.ChildNodes )
			      {
				        if ( xmlNode.NodeType == XmlNodeType.Element )
				        {
					          xmlElement = xmlNode as XmlElement;
					          break;
				        }
			      }
			
			      if ( xmlElement != null )
				        this.ReadXml(xmlElement);
        }
    
  
    
        internal virtual void ReadXml(XmlElement xmlParent)
        {
	          if ( xmlParent.Attributes != null )
			      {
                foreach ( XmlAttribute xmlAttribute in xmlParent.Attributes )
		            {
			              switch ( xmlAttribute.Name )
					          {
						          
						            case "version" :
							              _version = xmlAttribute.Value;
							              break;
						          
						            case "generator" :
							              _generator = xmlAttribute.Value;
							              break;
						          
  						
						            default:
							              throw new ApplicationException(this.GetType().Name + " - Unknown attribute : " + xmlAttribute.Name);
                    }
                }
            }
		   
		        foreach ( XmlNode xmlNode in xmlParent.ChildNodes )
		        {
				        if ( xmlNode.NodeType == XmlNodeType.Element )
				        {
					          switch ( xmlNode.Name )
					          {
					            
						            case "node" :
							              node itemnode = new node();
							              itemnode.ReadXml(xmlNode as XmlElement);
							              _nodeCollection.Add(itemnode);
							              break;
					            
						            case "way" :
							              way itemway = new way();
							              itemway.ReadXml(xmlNode as XmlElement);
							              _wayCollection.Add(itemway);
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
    
    public class osmCollection : IEnumerator, IEnumerable
    {
        
        private ArrayList _list = new ArrayList();
		
		    public int Count
		    {
			      get { return _list.Count; }
		    }
		
		    public osm this[int index]
		    {
			      get { return _list[index] as osm; }
			      set { _list[index] = value; }
		    }
		
		    public void Add(osm item)
		    {
			      _list.Add(item);
		    }
    		
		    public void Remove(osm item)
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


  