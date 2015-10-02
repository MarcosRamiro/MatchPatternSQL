using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace MatchPattnerSQL
{
    [XmlRoot("RulesSQL")]
    public class RulesSQL
    {
        
        //[DataMember]
        public string ID { get; set; }
        //[DataMember]
        public string Description { get; set; }
        //[DataMember]
        public string Pattern { get; set; }
    }
}
