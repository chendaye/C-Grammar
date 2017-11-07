using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grammar
{
    //这个类是 int 值的一个包装器
    public class OperateNum
    {
        public int val;

        //重载 + 
        public static OperateNum operator +(OperateNum op1, OperateNum op2)
        {
            OperateNum Val = new OperateNum();
            Val.val = op1.val + op2.val;
            return Val;
        }

        //重载 -
        public static OperateNum operator -(OperateNum op1)
        {
            OperateNum Val = new OperateNum();
            Val.val = -op1.val;
            return Val;
        }

        //重载成对的运算符
        public static bool operator == (OperateNum op1, OperateNum op2)
        {
            return (op1.val == op2.val);
        }

        public static bool operator !=(OperateNum op1, OperateNum op2)
        {
            return !(op1.val == op2.val);
        }

        //重载成对的运算符  最好重写一下两个方法
        //这两个 方法可用于比较对象  可以确保类的用户无论使用什么技术都能得到相同的结果
        public override bool Equals(object obj)
        {
            return (val == ((OperateNum)obj).val);
        }

        public override int GetHashCode()
        {
            return val;
        }
    }

    public class OperateNum2
    {
        public int val;
    }

    public class OperateNum3
    {
        public int val;
    }

    public class OperateNum4
    {
        public int val;
        //混合类型  如果把相同的重载方法 加到 OperateNum3  就不行  因为不知道要用哪一个重载方法
        //如果是混合类型  操作数的顺序 要和重载方法的参数顺序一致  否则报错  （只能是 op3 + op4）
        public static OperateNum2 operator + (OperateNum3 op3, OperateNum4 op4)
        {
            OperateNum2 Val = new OperateNum2();
            Val.val = op3.val + op4.val;
            return Val;
        }
    }
}
