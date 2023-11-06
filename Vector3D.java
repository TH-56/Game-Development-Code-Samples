package Vector3D;

public class Vector3D implements InterfaceVector3D
{
    private double x;
    private double y;
    private double z;

    public Vector3D()
    {
        this.x = 0;
        this.y = 0;
        this.z = 0;
    }

    public Vector3D(double x, double y, double z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    @Override
    public double get(COMPONENTS component)
    {
        if(component == COMPONENTS.XCOMPONENT)
            return this.x;
        else if(component == COMPONENTS.YCOMPONENT)
            return this.y;
        else
            return this.z;
    }

    @Override
    public void set(COMPONENTS component, double value)
    {
        if(component == COMPONENTS.XCOMPONENT)
            this.x = value;
        else if(component == COMPONENTS.YCOMPONENT)
            this.y = value;
        else
            this.z = value;
    }

    @Override
    public InterfaceVector3D Add(InterfaceVector3D rhs)
    {
        InterfaceVector3D addition = new Vector3D();
        addition.set(COMPONENTS.XCOMPONENT, (this.get(COMPONENTS.XCOMPONENT) + rhs.get(COMPONENTS.XCOMPONENT)));
        addition.set(COMPONENTS.YCOMPONENT, (this.get(COMPONENTS.YCOMPONENT) + rhs.get(COMPONENTS.YCOMPONENT)));
        addition.set(COMPONENTS.ZCOMPONENT, (this.get(COMPONENTS.ZCOMPONENT) + rhs.get(COMPONENTS.ZCOMPONENT)));
        return addition;
    }

    @Override
    public InterfaceVector3D Subtract(InterfaceVector3D rhs)
    {
        InterfaceVector3D difference = new Vector3D();
        difference.set(COMPONENTS.XCOMPONENT, (this.get(COMPONENTS.XCOMPONENT) - rhs.get(COMPONENTS.XCOMPONENT)));
        difference.set(COMPONENTS.YCOMPONENT, (this.get(COMPONENTS.YCOMPONENT) - rhs.get(COMPONENTS.YCOMPONENT)));
        difference.set(COMPONENTS.ZCOMPONENT, (this.get(COMPONENTS.ZCOMPONENT) - rhs.get(COMPONENTS.ZCOMPONENT)));
        return difference;
    }

    @Override
    public InterfaceVector3D Multiply(double value)
    {
        InterfaceVector3D multiplied = new Vector3D();
        multiplied.set(COMPONENTS.XCOMPONENT, (this.get(COMPONENTS.XCOMPONENT) * value));
        multiplied.set(COMPONENTS.YCOMPONENT, (this.get(COMPONENTS.YCOMPONENT) * value));
        multiplied.set(COMPONENTS.ZCOMPONENT, (this.get(COMPONENTS.ZCOMPONENT) * value));
        return multiplied;
    }

    @Override
    public double Dot(InterfaceVector3D rhs)
    {
        double dotProduct = ((this.get(COMPONENTS.XCOMPONENT) * rhs.get(COMPONENTS.XCOMPONENT)) 
        + (this.get(COMPONENTS.YCOMPONENT) * rhs.get(COMPONENTS.YCOMPONENT)) 
        + (this.get(COMPONENTS.ZCOMPONENT) * rhs.get(COMPONENTS.ZCOMPONENT)));
        return dotProduct;
    }

    @Override
    public InterfaceVector3D Cross(InterfaceVector3D rhs)
    {
        InterfaceVector3D crossProduct = new Vector3D();
        crossProduct.set(COMPONENTS.XCOMPONENT, ((this.get(COMPONENTS.YCOMPONENT) * rhs.get(COMPONENTS.ZCOMPONENT)) - (this.get(COMPONENTS.ZCOMPONENT) * rhs.get(COMPONENTS.YCOMPONENT))));
        crossProduct.set(COMPONENTS.YCOMPONENT, ((this.get(COMPONENTS.ZCOMPONENT) * rhs.get(COMPONENTS.XCOMPONENT)) - (this.get(COMPONENTS.XCOMPONENT) * rhs.get(COMPONENTS.ZCOMPONENT))));
        crossProduct.set(COMPONENTS.ZCOMPONENT, ((this.get(COMPONENTS.XCOMPONENT) * rhs.get(COMPONENTS.YCOMPONENT)) - (this.get(COMPONENTS.YCOMPONENT) * rhs.get(COMPONENTS.XCOMPONENT))));
        return crossProduct;
    }

    @Override
    public double Norm()
    {
        double norm = Math.sqrt((this.get(COMPONENTS.XCOMPONENT) * this.get(COMPONENTS.XCOMPONENT) + this.get(COMPONENTS.YCOMPONENT) * this.get(COMPONENTS.YCOMPONENT) + this.get(COMPONENTS.ZCOMPONENT) * this.get(COMPONENTS.ZCOMPONENT)));
        return norm;
    }

    @Override
    public InterfaceVector3D Unit()
    {
        InterfaceVector3D unit = new Vector3D();
        double norm = this.Norm();
        unit.set(COMPONENTS.XCOMPONENT, (this.get(COMPONENTS.XCOMPONENT) / norm));
        unit.set(COMPONENTS.YCOMPONENT, (this.get(COMPONENTS.YCOMPONENT) / norm));
        unit.set(COMPONENTS.ZCOMPONENT, (this.get(COMPONENTS.ZCOMPONENT) / norm));
        return unit;
    }

    @Override
    public double AngleBetween(InterfaceVector3D rhs)
    {
        double dotProduct = this.Dot(rhs);
        double magnitude = this.Norm() * rhs.Norm();
        double angle = Math.acos((dotProduct) / (magnitude));
        return angle;
    }

    @Override
    public double DirectionAngle(COMPONENTS comp)
    {
        double directionAngle = Math.acos((this.get(comp)) / (this.Norm()));
        return directionAngle;
    }

    @Override
    public boolean Parallel(InterfaceVector3D rhs)
    {
        InterfaceVector3D cross = this.Cross(rhs);
        if((Math.abs(cross.get(COMPONENTS.XCOMPONENT)) < PRECISION) && (Math.abs(cross.get(COMPONENTS.YCOMPONENT)) < PRECISION) && (Math.abs(cross.get(COMPONENTS.ZCOMPONENT)) < PRECISION))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    @Override
    public boolean AntiParallel(InterfaceVector3D rhs)
    {
        if(Math.abs(this.Dot(rhs) / (this.Norm() * rhs.Norm()) + 1) < PRECISION)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    @Override
    public InterfaceVector3D Projection(InterfaceVector3D rhs)
    {
        double dotProduct = this.Dot(rhs);
        double magSquared = Math.pow(rhs.Norm(), 2);
        double scalar = dotProduct / magSquared;
        InterfaceVector3D temp = rhs;
        InterfaceVector3D result = temp.Multiply(scalar);
        return result;
    }

    @Override
    public boolean equals(Object o)
    {
        if((Math.abs(this.get(COMPONENTS.XCOMPONENT) - ((Vector3D) o).get(COMPONENTS.XCOMPONENT)) < PRECISION) && (Math.abs(this.get(COMPONENTS.YCOMPONENT) - ((Vector3D) o).get(COMPONENTS.YCOMPONENT)) < PRECISION) && (Math.abs(this.get(COMPONENTS.ZCOMPONENT) - ((Vector3D) o).get(COMPONENTS.ZCOMPONENT)) < PRECISION))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    @Override
    public String toString()
    {
        return "<" + this.get(COMPONENTS.XCOMPONENT) + ", " + this.get(COMPONENTS.YCOMPONENT) + ", " + this.get(COMPONENTS.ZCOMPONENT) + ">";
    }
}