using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using static System.Console;

namespace Grammar
{
    //迭代器（foreach）
    public class iterator
    {
        private long min; //搜索范围的最小值
        private long max; //搜索范围最大值
        //this 是构造函数初始化器  this(2,100) 通过参数指明 在调用这个构造函数之前先执行 和这个参数匹配的构造函数
        //C# 里面的默认构造函数执行顺序  是从底层往上 执行  就是先执行基类的构造函数  在执行子类的构造函数
        public iterator() : this(2,100)
        {
            //执行此函数之前  先执行 iterator(long minmun, long maxmum)
        }
        public  iterator(long minmun, long maxmum)
        {
            if (minmun < 2)
            {
                min = 2;
            }
            else
            {
                min = minmun;
            }
            max = maxmum;
        }

        //这个类 枚举上下限之间的素数
        public IEnumerator GetEnumerator()
        {
            for (long possiblePrime = min; possiblePrime <= max; possiblePrime++)
            {
                bool isPrime = true;
                //能否被2 到 该数平方根之间的数整除  能就是素数  不能就不是
                for (long possibleFactor = 2; possiblePrime <= (long)Math.Floor(Math.Sqrt(possiblePrime)); possibleFactor++)
                {
                    long remainderAfterDivison = possiblePrime % possibleFactor;
                    if (remainderAfterDivison == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
                if (isPrime)
                {
                    //yield 关键字 可以返回任意类型的值 实际返回的是基类 object
                    yield return possiblePrime;
                }
            }
        }
    }
}
