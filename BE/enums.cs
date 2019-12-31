using System;
using System.Collections.Generic;
using System.Text;

namespace BE
{
   public class enums
    {
        public enum ResortType {house , hut, hotel }
        public enum Area { north,east,west,south}
        public enum orderStatus { inProgress,mailSent,close,finish}
        public enum orderGuestRequest {open,finishWithWebsite,closeDueDatePass }

    }
}
