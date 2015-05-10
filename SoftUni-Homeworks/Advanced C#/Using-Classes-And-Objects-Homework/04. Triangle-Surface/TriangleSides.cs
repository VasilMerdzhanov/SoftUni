using System;

class TriangleSides
{
    // fields
    private decimal sideA;
    private decimal sideB;
    private decimal sideC;

    // properties
    public decimal SideA
    {
        get
        {
            return sideA;
        }
        set
        {
            sideA = value;
        }
    }

    public decimal SideB
    {
        get
        {
            return sideB;
        }
        set
        {
            sideB = value;
        }
    }

    public decimal SideC
    {
        get
        {
            return sideC;
        }
        set
        {
            sideC = value;
        }
    }

    // constructor
    public TriangleSides(decimal sideA, decimal sideB, decimal sideC)
    {
        this.SideA = sideA;
        this.SideB = sideB;
        this.SideC = sideC;
    }

    // method
    public decimal AreaSides
    {
        get
        {
            decimal p = (sideA + sideB + sideC) / 2;
            return (decimal)Math.Sqrt((double)(p * (p - sideA) * (p - sideB) * (p - sideC)));
        }
    }
}

