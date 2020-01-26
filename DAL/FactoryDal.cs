using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    /// <summary>
    /// Factory method- enables us to change the DAL level without changing the Logic Level.
    /// </summary>
    public class FactoryDal
    {
        public static IDAL GetDal()
        {
            //return Dal_imp.GetDAL();
             return DAL_XML_imp.GetDALXml(); 
        }
    }
}