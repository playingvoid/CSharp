using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace DemoActiveX
{
    [ProgId("DemoActiveX.DemoActiceX")]
    [Guid("0914BAF8-F0E9-44EE-9EAA-920551DBE47F")]
    [ComVisible(true)]
    public class DemoActiveX
    {
        public String SayHello()
        {
            return "Hello World!!!!!!!!";
        }

        //[ComVisible(true)]
        public String SayHi()
        {
            return "Hi World!";
        }

    }
}
