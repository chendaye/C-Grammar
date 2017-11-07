using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar
{
    public class PersonCompare
    {
        public string Name;
        public int Age;

        public PersonCompare(string name, int age)
        {
            Name = name;
            Age = age;
        }

        //比较  并进行类型检查
        public int CompareTo(object obj)
        {
            if(obj is PersonCompare)
            {
                PersonCompare otherPerson = obj as PersonCompare;
                return this.Age - otherPerson.Age;
            }else
            {
                throw new ArgumentException("比较的对象 不是 PersonCompare 类型");
            }
        }
    }
}
