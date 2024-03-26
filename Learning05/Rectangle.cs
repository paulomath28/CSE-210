public class Rectangle : Shape
{
    private double length;
    private double width;

    public Rectangle(string color, double length, double width)
    {
        Color = color;
        this.length = length;
        this.width = width;
    }

    public override double GetArea()
    {
        return length * width;
    }
}
