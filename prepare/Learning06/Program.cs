using System;

class Program
{
    static void Main(string[] args)
    {
        var square = new Square ("red", 4.00);
        var rect = new Rectangle ("blue", 4.00, 2.00);
        var circle = new Circle ("green", 7.00);
        
        List<Shape> shape = new List<Shape>();
        shape.Add (square);
        shape.Add (rect);
        shape.Add (circle);

        foreach (Shape s in shape)
        {
            Console.WriteLine(s.GetColor());
            Console.WriteLine(s.GetArea());
            Console.WriteLine();
        }
        {
            
        }

    }
}