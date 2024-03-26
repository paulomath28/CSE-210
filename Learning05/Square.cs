public class Square : Shape
{
    private double side;

    public Square(string color, double side)
    {
        Color = color;
        this.side = side;
    }

    public override double GetArea()
    {
        return side * side;
    }
}
