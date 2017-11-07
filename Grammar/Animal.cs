using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Grammar
{
    public abstract class Animal
    {
        protected string name;
        //属性 存取器
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        //构造函数
        public Animal(string newName)
        {
            name = newName;
        }

        public void Feed() => WriteLine($"{name} has been fed");


    }
}
