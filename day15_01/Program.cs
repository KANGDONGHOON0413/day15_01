using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day15_01
{
    delegate void dele(string str);

    class Test01
    {
        public event dele EventHandler01;

        public void func(string str)
        {
            EventHandler01(str);
        }
    }

    class Test02
    {
        public void print_A(string str)
        {
            Console.WriteLine("A:\t" + str);
        }
        public void print_B(string str)
        {
            Console.WriteLine("B:\t" + str);
        }
        public void print_C(string str)
        {
            Console.WriteLine("C:\t" + str);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Test01 t1 = new Test01();
            var t2 = new Test02();

            t1.EventHandler01 += new dele(t2.print_A);
            t1.EventHandler01 += new dele(t2.print_B);
            t1.func("alreay !");
            t1.EventHandler01 -= t2.print_A;
            t1.func("A was removed");

            var t3 = new Test02();
            t1.EventHandler01 += new dele(t3.print_C);
            t1.func("C was imported");
        }
    }
}
