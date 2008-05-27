
using System;
using System.Xml;
using System.Collections;

namespace OSM2SHP // TODO, let the user give a namespace
{
    public class nd
    {
        
        protected int _reff = 0;
        
        public int reff
        {
            get { return _reff; }
            set { _reff = value; }
        }
				
    
        internal virtual void SaveXml(XmlNode xmlParent)
        {
            XmlAttribute xmlAttribute = null;
            XmlElement xmlElement = null;
		
		      
            if ( _reff != 0 )
            {
                xmlAttribute = xmlParent.OwnerDocument.CreateAttribute("ref");
                xmlAttribute.Value = _reff.ToString();
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
						          
						            case "ref" :
							              _reff = Convert.ToInt32(xmlAttribute.Value);
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
                                        break;
							            //throw new ApplicationException(this.GetType().Name + " - Unknown element : " + xmlNode.Name);
                    }
				        }
				      
		        }
      }
    
  
    }
	
    #region Collection
    
    public class ndCollection : IEnumerator, IEnumerable
    {
        
        private ArrayList _list = new ArrayList();
		
		    public int Count
		    {
			      get { return _list.Count; }
		    }
		
		    public nd this[int index]
		    {
			      get { return _list[index] as nd; }
			      set { _list[index] = value; }
		    }
		
		    public void Add(nd item)
		    {
			      _list.Add(item);
		    }
    		
		    public void Remove(nd item)
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


  