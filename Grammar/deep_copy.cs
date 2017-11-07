using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar
{
    public class deep_copy : ICloneable
    {
        public content_copy Content = new content_copy();

        //构造函数
        public deep_copy(int newVal)
        {
            Content.Val = newVal;
        }

        //深度复制
        public object Clone()
        {
            deep_copy cloned = new deep_copy(Content.Val);
            return cloned;
        }


    }
}
