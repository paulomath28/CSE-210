class Program
{
    static void Main(string[] args)
    {
        var shapes = new List<Shape>
        {
            new Square("Red", 5),
            new Rectangle("Blue", 4, 6),
            new Circle("Green", 3)
        };

        foreach (var shape in shapes)
        {
            Console.WriteLine($"Shape: {shape.Color}, Area: {shape.GetArea():F2}");
        }
    }
}
