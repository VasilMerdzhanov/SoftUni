using System;

class TriangleABAngle
{
    // fields
    private decimal sideA;
    private decimal sideB;
    private decimal angleAB;

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

    public decimal AngleAB
    {
        get
        {
            return angleAB;
        }
        set
        {
            angleAB = value;
        }
    }

    // constructor
    public TriangleABAngle(decimal sideA, decimal sideB, decimal angleAB)
    {
        this.SideA = sideA;
        this.SideB = sideB;
        this.AngleAB = angleAB;
    }

    // method
    public decimal AreaABAngle
    {
        get
        {
            return 0.5m * sideA * sideB * (decimal)Math.Sin((double)angleAB * Math.PI / 180);
        }
    }
}

