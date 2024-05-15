using System;
using ex4_1;
class Program
{
    static void Main()
    {
        LineArray<int> x = new LineArray<int>();
        x.Add(1);
        x.Add(2);
        x.Add(3);
        x.Add(4);
        x.Display();
    }
}