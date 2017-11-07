using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar
{
    public class shallow_copy
    {
        public content_copy Content = new content_copy();

        //构造函数
        public shallow_copy(int newVal)
        {
            Content.Val = newVal;
        }

        //浅复制 引用对象与原对象相同
        public object GetCopy() => MemberwiseClone();
    }
}
