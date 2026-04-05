using System;

namespace RhombusLibrary;

public class Rhombus
{
    private double d1;
    private double d2;
    private double side;

    public Rhombus(double d1, double d2, double side)
    {
        this.d1 = d1;
        this.d2 = d2;
        this.side = side;
    }

    public double GetArea()
    {
        return (d1 * d2) / 2.0;
    }

    public double GetPerimeter()
    {
        return 4 * side;
    }

    public void Print()
    {
        Console.WriteLine($"Rhombus: d1 = {d1}, d2 = {d2}, side = {side}, P = {GetPerimeter():F2}, S = {GetArea():F2}");
    }
}