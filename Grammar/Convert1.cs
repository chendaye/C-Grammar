using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar
{
    public class Convert1
    {
        public int val; //int 

        //隐式转换 implicit
        public static implicit operator Convert2(Convert1 op1)
        {
            Convert2 Val = new  Convert2();
             Val.val = op1.val;

            return Val;
        }
    }

    public class Convert2
    {
        public double val; //double

        //显式转换 explicit
        public static explicit operator Convert1(Convert2 op2)
        {
            Convert1 Val = new Convert1();
            //checked { Val.val = (int)op2.val; };

            return Val;
        }

    }
}
