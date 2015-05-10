using System;

class TriangleBH
{
    // fields
    private decimal baseLength;
    private decimal height;

    // properties
    public decimal BaseLength
    {
        get
        {
            return baseLength;
        }
        set
        {
            baseLength = value;
        }
    }

    public decimal Height
    {
        get
        {
            return height;
        }
        set
        {
            height = value;
        }
    }

    // constructor
    public TriangleBH(decimal baseLength, decimal height)
    {
        this.BaseLength = baseLength;
        this.Height = height;
    }
          
    // method
    public decimal AreaBH
    {
        get
        {
            return (baseLength * height) / 2;
        }
    }
}

