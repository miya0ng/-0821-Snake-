using System.Numerics;
using System.Runtime.Intrinsics;

Vector3 a = new Vector3(1, 2, 3);
Vector3 b = new Vector3(4, 5, 6);
Console.WriteLine(a + b); // (5, 7, 9)
Console.WriteLine(a - b); // (-3, -3, -3)
Console.WriteLine(a * 2); // (2, 4, 6)
Console.WriteLine(2 * b); // (8, 10, 12)
Console.WriteLine(Vector3.Dot(a, b)); // 1_4 + 2_5 + 3\\*6 = 32
Console.WriteLine(Vector3.Cross(a, b)); // (-3, 6, -3)

public struct Vector3
{
    float x, y, z;
    public Vector3()
    {
        x = 0; y = 0; z = 0;
    }
    public Vector3(float a, float b, float c)
    {
        x = a; y = b; z = c;
    }

    public static Vector3 operator +(Vector3 a, Vector3 b)
        => new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);

    public static Vector3 operator -(Vector3 a, Vector3 b)
          => new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);

    public static Vector3 operator *(Vector3 a, int b)
         => new Vector3(a.x * b, a.y * b, a.z * b);

    public static Vector3 operator *(int b, Vector3 a)
        => new Vector3(a.x * b, a.y * b, a.z * b);

    public static float Dot(Vector3 a, Vector3 b)
         => a.x * b.x + a.y * b.y + a.z * b.z;


    public static Vector3 Cross(Vector3 a, Vector3 b)
         => new Vector3(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);

    public override string ToString()
    {
        return $"{x},{y},{z}";
    }
}
