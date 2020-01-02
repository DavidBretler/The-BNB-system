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
        public static Idal GetDal()
        {
            return new Dal_imp();
        }
    }
}