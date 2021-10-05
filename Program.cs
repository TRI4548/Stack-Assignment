using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.Write("Nhap chuoi ky tu: ");
            // var a = Console.ReadLine();
            // var stak = TaoChuoiKyTu(a);
            // Console.WriteLine(stak.ToArray());

            Console.Write("Nhap mot cau bat ky: ");
            string[] tk = Console.ReadLine().Split();
            string a = tk[0];
            var capacity = tk.Length;
            var x = TaoChuoiTu(tk);
            while(capacity != 0)
            {
                var i = x.Pop();
                Console.Write($"{i} ");
                capacity--;
            }
        }
        static Stack<char> TaoChuoiKyTu(string a)
        {
            var stak = new Stack<char>();
            for(int i = 0; i < a.Length; i++)
            {
                stak.Push(a[i]);
            }
            return stak;
        }
        static Stack<string> TaoChuoiTu(string[] a)
        {
            var stak = new Stack<string>();
            for(int i = 0; i < a.Length; i++)
            {
                stak.Push(a[i]);
            }
            return stak;
        }
    }
}
