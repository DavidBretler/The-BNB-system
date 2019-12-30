using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{

    public static class Cloning
    {//hosting unit order gestrequest
        public static BE.HostingUnit Clone(this BE.HostingUnit original)
        {
            BE.HostingUnit target = new BE.HostingUnit();
            target.setHostingUnitKey(original.getHostingUnitKey()) ;

            
            
 return target;
        }
        public static Lecture Clone(this Lecture original)
        {
            Lecture target = new Lecture();
            target.id = original.id;
           
 return target;
        }
        //and so on for each entity…
    }
}
