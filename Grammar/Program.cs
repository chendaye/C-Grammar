using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using static System.Console;
using System.Timers;


namespace Grammar
{
    class Program
    {
        //创建一个结构类型
        struct Mystruct
        {
            public int val;
        }


        //封箱为接口
        struct Mystruct2 : MyInterface
        {
            public int val;
        }

        static int counter = 0;

        static string displayString = "隔一段时间出现";

        static void Main(string[] args)
        {
            WriteLine("创建一个 Array 类型的  Animal ");
            //创建一个集合
            Animal[]  animalArray = new Animal[2];
            //实例化 一个奶牛对象
            Cow myCow = new Cow("Lea");
            //给集合赋值
            animalArray[0] = myCow;
            animalArray[1] = new Chiken("Noa");

            //遍历对象数组
            foreach (Animal myAnimal in animalArray)
            {
                WriteLine($"new {myAnimal.ToString()} 对象加入数组" + $"collect ,Name {myAnimal.Name}");
            }

            WriteLine($"数组 集合包含 {animalArray.Length} 个对象");

            //调用对象方法
            animalArray[0].Feed();
            //调用对象方法 类型转换
            ((Chiken)animalArray[1]).LayEgg();
            WriteLine();

            WriteLine("创建一个 ArrayList 集合 类型的  Animal ");
            //创建一个集合
            ArrayList animalArrayList = new ArrayList();
            //新的Cow 实例
            Cow myCow2 = new Cow("cow2");
            //在集合中添加元素
            animalArrayList.Add(myCow2);
            animalArrayList.Add(new Chiken("chiken2"));

            //遍历集合
            foreach (Animal myAnimal in animalArrayList)
            {
                WriteLine($"new {myAnimal.ToString()} 对象加入集合" + $"collect ,Name {myAnimal.Name}");
            }
            WriteLine($"集合包含 {animalArrayList.Count} 个对象");
            //调用对象方法
            ((Animal)animalArrayList[0]).Feed();
            ((Chiken)animalArrayList[1]).LayEgg();

            WriteLine();

            //移除集合元素
            animalArrayList.RemoveAt(0);
            ((Animal)animalArrayList[0]).Feed();

            //一次添加多个元素
            animalArrayList.AddRange(animalArray);
            //animalArrayList中的第三项  是 animalArray 的第二项
            ((Chiken)animalArrayList[2]).LayEgg();
            myCow.Name = "Alert";

            //迭代器
            iterator iterator = new iterator(2, 1000);
            foreach (long i in iterator)
            {
                WriteLine($"{i}");
            }

            //迭代器 和 集合
            iterator_collect iterator_collect = new iterator_collect();
            iterator_collect.Add("iterator_collect", new Chiken("iterator_collect"));
            foreach (Animal animal in iterator_collect)
            {
                WriteLine($"{animal.Name}");
            }

            //浅复制 复制的是引用 指向同一个对象
            shallow_copy shallow = new shallow_copy(1);
            shallow_copy mycopy = (shallow_copy)shallow.GetCopy();
            WriteLine($"{mycopy.Content.Val}");
            shallow.Content.Val = 777;
            WriteLine($"{mycopy.Content.Val}");



            //深度复制 复制完全一样的 对象
            deep_copy deep = new deep_copy(1);
            deep_copy deep_Copy = (deep_copy)deep.Clone();
            WriteLine($"{deep_Copy.Content.Val}");
            deep.Content.Val = 666;
            WriteLine($"{deep_Copy.Content.Val}");

            //compare 比较
            //封箱（boxing） 把值类型转换为System.Object 类型 或者转换为由值类型 实现的接口类型
            Mystruct myValue = new Mystruct();  //创建一个类型为 Mystruct 的新变量 myValue 
            myValue.val = 666;  //给结构的 val 成员赋值
            object refType = myValue;  //把myValue 封箱在 object 类型的变量中

            //这种方式封箱 的变量 包含值类型副本的一个引用 不是包含原值类型的一个引用
            //验证
            myValue.val = 777;
            Mystruct myValue2 = (Mystruct)refType;  //拆箱
            WriteLine($"{myValue2.val}"); //666

            //可以把值类型封装到接口类型中 只要实现这个接口即可
            Mystruct2 mystruct2 = new Mystruct2();  //封箱
            MyInterface refType2 = mystruct2; // 把结构封箱到一个接口（MyInterface）中

            //用数据类型转换语法拆箱
            Mystruct2 mystruct3 = (Mystruct2)refType2;  //拆箱

            //封箱不需要额外的操作  但拆箱一个值需要进行显示转换  就是要进行数据类型转换
            //封箱是隐式的 不需要数据类型转换
            //封箱重要的原因 1： 它允许在项的类型是object的集合中使用值类型 2：允许在值类型上调用object方法


            //is 运算符 用来检测对象是不是给定的类型 或者是否可以转化成给定的类型  如果是 返回 TRUE
            //语法 A is B
            // B是一个给定的 类 类型  如果 A是B类型 或者继承了B类型  或者A可以封箱到B类型中 返回 true
            // B是一个给定的 接口 类型  如果A是B类型  或者A实现了接口B  返回 TRUE
            // B是一个给定的 值 类型   如果A是B类型  或者 A苦役拆箱到 B类型  返回 true


            //比较值
            //1: 运算符重载
            //一般类型  和混合类型  +=、=、&&、|| 不能重载  一些运算符必须成对重载 （< >/ <= >）


            //IComparable  IComparer 接口是 .NET Framework 中比较对象的标准方式 
            //IComparable 在要比较的对象中实现 可以比较该对象和另一个对象
            //IComparer 在一个单独的类中实现 可以比较任意两个对象

            ArrayList list = new ArrayList();
            list.Add(new PersonCompare("abel", 18));
            list.Add(new PersonCompare("chen", 19));

            for(int i=0; i< list.Count; i++)
            {
                WriteLine($"{(list[i] as PersonCompare).Name} { (list[i] as PersonCompare).Age}");
            }

            //list.Sort();

            for (int i = 0; i < list.Count; i++)
            {
                WriteLine($"{(list[i] as PersonCompare).Name} { (list[i] as PersonCompare).Age}");
            }

            list.Sort(PersonCompareName.Default);

            for (int i = 0; i < list.Count; i++)
            {
                WriteLine($"{(list[i] as PersonCompare).Name} { (list[i] as PersonCompare).Age}");
            }


            //重载转换运算符  除了重载数学运算符外 还可以 定义类型间的 隐式和显示转换
            //如果要在不相干的类型之间转换 例如 没有继承关系 也没有接口 就必须这么做
            //Convert1 包含一个 int 值 Convert2 包含一个 double 值
            //int 可以隐式转化为 double  ；所以 可以在 Convert1 Convert2 之间用 implicit  指定隐式转换
            //反过来不行  Convert2 Convert1 之间的转换 定义为显式 转换 explicit

            Convert1 convert1 = new Convert1();
            convert1.val = 3;
            Convert2 convert2 = convert1;  //Convert1 隐式转换为 Convert2

            //反过来
            Convert2 convert22= new Convert2();
            convert22.val = 3e15;
            Convert1 convert11 = (Convert1)convert22;  //Convert2 显式转换为 Convert1


            //as 运算符  把一种类型 转换为指定的引用类型 A as B
            //使用情况 
            //A 的 类型是 B
            //A 可以隐式转换为 B
            //A 可以封箱到 B
            //如果不能转换 表达式的结果就是 null



            //泛型   泛型是一种特殊的类型
            System.Nullable<int> nullint;   //可空类型
            int? nullints;  //效果同上
            nullint = null; //赋值 空
            if(nullint == null)
            {
                WriteLine("可空类型");
            }
            if(nullint.HasValue)
            {
                WriteLine("是否有值！");
            }

            //运算符和可空类型
            int? opl = 5;
            int? ret = opl * 2;

            //显式转换
            int ret1 = (int)opl * 2;
            //通过值来访问
            int ret2 = opl.Value * 3;

            //有一个或者两个  为 null
            int? opl2 = null;
            int? opl3 = 7;

            int? opl4 = opl2 * opl3;
            WriteLine($"{opl4}");

            //两个表达式等价
            int? x = opl2 ?? opl3;
            int? y = opl2 == null ? opl3 : opl2;


            //集合 泛型
            List<Animal> animalClo = new List<Animal>();
            animalClo.Add(new Chiken("a"));
            animalClo.Add(new Chiken("b"));
            foreach(Animal ani in animalClo)
            {
                ani.Feed();
            }

            //键值对集合
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            dictionary.Add("a", 1);
            dictionary.Add("b", 2);
            //迭代键 值
            foreach(string key in dictionary.Keys)
            {
                WriteLine(key);
            }

            foreach (int val in dictionary.Values)
            {
                WriteLine(val);
            }

            foreach(KeyValuePair<string,int> thing in dictionary)
            {
                WriteLine(thing.Key+thing.Value);
            }


            //事件
            Timer myTimer = new Timer(100);
            myTimer.Elapsed += new ElapsedEventHandler(WriteChar);  //委托 += 运算符 给事件添加一个处理程序  引发Elapsed 事件时 会调用此处理程序
            myTimer.Start(); //使用 Start() 启动Timer 对象时 引发一系列事件 根据指定的时间段来引发事件
            System.Threading.Thread.Sleep(200); //让计时器把消息发送给控制台应用程序
            ReadKey();

            //特性  为所创建的类提供额外信息的方式
            //将特性名用 方括号扩起来 放在要应用的目标代码前，可以为一段代码添加多个特性 用逗号隔开
            //[TimersDescription]

            //获取特性
            Type classType = typeof(Chiken);
            object[] attributes = classType.GetCustomAttributes(true);

           

        }

        static void WriteChar(object source, ElapsedEventArgs e)
        {
            Write(displayString[counter++ % displayString.Length]);
        }

       
    }
}
