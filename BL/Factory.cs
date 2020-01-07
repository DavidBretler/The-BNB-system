using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class Factory
    {
        public static IBL GetBL()
        {
            return new BL_imp();
        }
    }
}
