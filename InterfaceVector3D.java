package Vector3D;

public interface InterfaceVector3D
{

    public enum COMPONENTS {XCOMPONENT, YCOMPONENT, ZCOMPONENT};

    static final double PRECISION = 0.000001;

    public abstract double get(COMPONENTS component);

    public abstract void set(COMPONENTS component, double value);

    public abstract InterfaceVector3D Add(InterfaceVector3D rhs);

    public abstract InterfaceVector3D Subtract(InterfaceVector3D rhs);

    public abstract InterfaceVector3D Multiply(double value);

    public abstract double Dot(InterfaceVector3D rhs);

    public abstract InterfaceVector3D Cross(InterfaceVector3D rhs);

    public abstract double Norm();

    public abstract InterfaceVector3D Unit();

    public abstract double AngleBetween(InterfaceVector3D rhs);

    public abstract double DirectionAngle(COMPONENTS comp);

    public abstract boolean Parallel(InterfaceVector3D rhs);

    public abstract boolean AntiParallel(InterfaceVector3D rhs);

    public abstract InterfaceVector3D Projection(InterfaceVector3D rhs);
}