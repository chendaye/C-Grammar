using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Grammar
{
    //用键值对访问集合
    public class Dictionnarys : DictionaryBase 
    {
        public void Add(string newID, Animal newAnimal)
        {
            //存储键和值
            Dictionary.Add(newID, newAnimal);
        }
        public void Remove(string animalID)
        {
            //通过键值删除集合元素
            Dictionary.Remove(animalID);
        }

        //构造函数
        public Dictionnarys() { }

        public Animal this[string animalID]
        {
            get { return (Animal)Dictionary[animalID]; }
            set { Dictionary[animalID] = value; }
        }
    }
}
