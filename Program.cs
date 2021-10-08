using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bai 1:");
            Console.Write("Nhap chuoi ky tu: ");
            var a = Console.ReadLine();
            var stak = TaoChuoiKyTu(a);
            Console.WriteLine(stak.ToArray());

            Console.WriteLine("Bai 2:");
            Console.Write("Nhap mot cau bat ky: ");
            string[] tk = Console.ReadLine().Split();
            string chuoi = tk[0];
            var capacity = tk.Length;
            var x = TaoChuoiTu(tk);
            while (capacity != 0)
            {
                var i = x.Pop();
                Console.Write($"{i} ");
                capacity--;
            }

            Console.WriteLine("Bai 3: ");
            Console.Write("Mang co bao nhieu phan tu?: ");
            int n = int.Parse(Console.ReadLine());
            int[] data = new int[n];
            string[] tk1 = Console.ReadLine().Split();
            for (int i = 0; i < n; i++)
            {
                data[i] = int.Parse(tk1[i]);
            }

            QuickSortStack(ref data);
            for (int i = 0; i < n; i++)
            {
                Console.Write(data[i] + " ");
            }

            Console.WriteLine("Bai 4: ");
            Console.Write("Nhap infix: ");
            string infix = Console.ReadLine();
            Console.WriteLine(infixToPostfix(infix));
        }
        #region Reverse a word
        static Stack<char> TaoChuoiKyTu(string a)
        {
            var stak = new Stack<char>();
            for (int i = 0; i < a.Length; i++)
            {
                stak.Push(a[i]);
            }
            return stak;
        }
        #endregion
        #region Reverse a sentence
        static Stack<string> TaoChuoiTu(string[] a)
        {
            var stak = new Stack<string>();
            for (int i = 0; i < a.Length; i++)
            {
                stak.Push(a[i]);
            }
            return stak;
        }
        #endregion
        #region Iterative QuickSort
        public static void QuickSortStack(ref int[] data)
        {
            int startIndex = 0;
            int endIndex = data.Length - 1;
            int top = -1;
            int[] stack = new int[data.Length];

            stack[++top] = startIndex;
            stack[++top] = endIndex;

            while (top >= 0)
            {
                endIndex = stack[top--];
                startIndex = stack[top--];

                int p = Partition(ref data, startIndex, endIndex);

                if (p - 1 > startIndex)
                {
                    stack[++top] = startIndex;
                    stack[++top] = p - 1;
                }

                if (p + 1 < endIndex)
                {
                    stack[++top] = p + 1;
                    stack[++top] = endIndex;
                }
            }
        }

        private static int Partition(ref int[] data, int left, int right)
        {
            int x = data[right];
            int i = (left - 1);

            for (int j = left; j <= right - 1; ++j)
            {
                if (data[j] <= x)
                {
                    ++i;
                    Swap(ref data[i], ref data[j]);
                }
            }

            Swap(ref data[i + 1], ref data[right]);

            return (i + 1);
        }

        private static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        #endregion        
        #region Infix to Postfix 
        public static string infixToPostfix(string expn)
        {
            Stack<char> stak = new Stack<char>();
            string output = "";
            char temp;
            foreach (char ch in expn)
            {
                if (ch >= '0' && ch <= '9')
                {
                    output += ch;
                }
                else
                {
                    switch (ch)
                    {
                        case '+':
                        case '-':
                        case '*':
                        case '/':
                        case '%':
                            if (stak.Count == 0)
                            {
                                stak.Push(ch);
                                output += "";
                            }
                            else if (stak.Count != 0)
                            {
                                if (precedence(stak.Peek()) >= precedence(ch))
                                {
                                    output += stak.Pop();
                                    stak.Push(ch);
                                }
                                else
                                {
                                    stak.Push(ch);
                                }
                            }
                            break;

                        case '(':
                            stak.Push(ch);
                            break;

                        case ')':
                            while (stak.Count != 0 && (temp = stak.Pop()) != '(')
                            {
                                output = output + temp;
                            }
                            break;
                    }
                }
            }
            while (stak.Count != 0)
            {
                output += stak.Pop();
            }
            return output;
        }
        public static int precedence(char ch)
        {
            switch (ch)
            {
                case '+':
                case '-':
                    return 12;
                case '*':
                case '/':
                case '%':
                    return 13;
            }
            return -1;
        }
        #endregion
    }
}
