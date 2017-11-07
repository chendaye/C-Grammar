using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar
{

    //泛型结构
    public struct MyGennric<T1, T2>
    {
        public T1 itme1;
        public T2 itme2;
    }

    //泛型接口
    //继承规则与类相同 如果继承一个基泛型接口 就必须遵循这些规则  例如保持基接口泛型参数的约束
    interface MG<T> where T:Animal
    {
        bool breed(T animal1, T animal2);
        T old { get; }
    }

    //泛型 类  约束类型（约束必须出现在继承说明符后面）
    class Generic<T1, T2, T3> where T1:Chiken where T2:Chiken where T3:Chiken
    {
        private T1 T1Object;    //T1类型的  变量
        //构造函数
        public Generic(T1 item)
        {
            T1Object = item;
        }

        //default 关键字
        public Generic()
        {
            //如果 T1 是值类型 T1Object  不能取 null   如果是引用类型  可以是 null
            //使用default 关键字  如果 是引用类型 就赋予 null  如果是值类型 就赋予默认值  数字类型 默认值是0
            T1Object = default(T1);
        }

        public T1 T1Objects
        {
            get
            {
                return T1Object;
            }
        }
    }
}
