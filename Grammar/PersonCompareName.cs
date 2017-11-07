using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Grammar
{
    public class PersonCompareName : IComparer
    {
        public static IComparer Default = new PersonCompareName();

        public int Compare(object x, object y)
        {
            if(x is PersonCompare && y is PersonCompare)
            {
                //调用，默认的比较方法
                return Comparer.Default.Compare(((PersonCompare)x).Name, ((PersonCompare)y).Name);
            }
            else
            {
                throw new ArgumentException("比较 的类型  不是 PersonCompare");
            }
        }
    }
}
