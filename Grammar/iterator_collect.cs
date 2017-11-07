using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Grammar
{
    public class iterator_collect : DictionaryBase
    {
        //添加
        public void Add(string newID, Animal animal)
        {
            Dictionary.Add(newID, animal);
        }

        //移除
        public void Remove(string animalID)
        {
            Dictionary.Remove(animalID);
        }

        public Animal this[string newID]
        {
            //添加进来的 对象 保存在 Dictionary中
            get { return (Animal)Dictionary[newID]; }
            set { Dictionary[newID] = value; }
        }

        //简单迭代器
        public new IEnumerator GetEnumerator()
        {
            foreach (object animal in Dictionary.Values)
            {
                yield return (Animal)animal;
            }
        }
    }
}
