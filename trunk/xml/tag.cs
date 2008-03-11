
using System;
using System.Xml;
using System.Collections;

namespace OSM2SHP // TODO, let the user give a namespace
{
    public class tag
    {
        
        protected string _k = "";
        protected string _v = "";
        
        public string k
        {
            get { return _k; }
            set { _k = value; }
        }
				
        public string v
        {
            get { return _v; }
            set { _v = value; }
        }
				
    
        internal virtual void SaveXml(XmlNode xmlParent)
        {
            XmlAttribute xmlAttribute = null;
            XmlElement xmlElement = null;
		
		      
            if ( _k != "" )
            {
                xmlAttribute = xmlParent.OwnerDocument.CreateAttribute("k");
                xmlAttribute.Value = _k;
                xmlParent.Attributes.Append(xmlAttribute);
            }
          
            if ( _v != "" )
            {
                xmlAttribute = xmlParent.OwnerDocument.CreateAttribute("v");
                xmlAttribute.Value = _v;
                xmlParent.Attributes.Append(xmlAttribute);
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
						          
						            case "k" :
							              _k = xmlAttribute.Value;
							              break;
						          
						            case "v" :
							              _v = xmlAttribute.Value;
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
					            
  						
						            default:
							            throw new ApplicationException(this.GetType().Name + " - Unknown element : " + xmlNode.Name);
                    }
				        }
				      
		        }
      }
    
  
    }
	
    #region Collection
    
    public class tagCollection : IEnumerator, IEnumerable
    {
        
        private ArrayList _list = new ArrayList();
		
		    public int Count
		    {
			      get { return _list.Count; }
		    }
		
		    public tag this[int index]
		    {
			      get { return _list[index] as tag; }
			      set { _list[index] = value; }
		    }
		
		    public void Add(tag item)
		    {
			      _list.Add(item);
		    }
    		
		    public void Remove(tag item)
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


  