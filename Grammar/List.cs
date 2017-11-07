using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Collections;

namespace Grammar
{
    //调用接口创建集合
    public class aniamlList : CollectionBase
    {
        public void Add(Animal newanimal)
        {
            //调用接口方法 添加集合对象
            List.Add(newanimal);
        }

        public void Remove(Animal oldanimal)
        {
            //调用接口方法 移除集合对象
            List.Remove(oldanimal);
        }
        //索引符  可以添加到类中提供类似 数组的访问  是特殊的属性
        public Animal this[int Index]
        {
            get { return (Animal)List[Index]; }
            set { List[Index] = value; }
        }
    }
}
