using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    /// <summary>
    /// Factory method- enables us to change the DAL level without changing the Logic Level.
    /// </summary>
    public class Factory
    {
        public static IBL GetBL()
        {
            return BL_imp.GetBL();
        }
    }
}