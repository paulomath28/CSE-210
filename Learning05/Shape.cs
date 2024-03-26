using System;

public class Shape
{
    private string color;

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public virtual double GetArea()
    {
        // Implementação padrão para obter a área (será sobrescrita nas classes derivadas)
        return 0;
    }
}
