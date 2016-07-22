using UnityEngine;

public class Utility : MonoBehaviour {
    public static float accuracy = 0.00001f;
    public static System.Random random = new System.Random();

    public static bool equal(float first, float second) {
        return equal(first, second, accuracy);
    }

    public static bool equal(float first, float second, float accuracy) {
        return first >= second - accuracy && first <= second + accuracy;
    }

    public static string fill(string str, int toSize, char filler = '0')
    {
        return (new string(filler, toSize)).Substring(0, toSize - str.Length) + str;
    }

    public static string cut(string str)
    {
        if (str[0] == '\"')
            return str.Substring(1, str.Length - 2);
        return str;
    }

    public static string timestamp()
    {
        return System.DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
    }

    public static bool moveSmooth(Transform transform, Vector3 destination, float step = 0.1f)
    {
        transform.position += new Vector3(
            (destination.x - transform.position.x) * step,
            (destination.y - transform.position.y) * step,
            (destination.z - transform.position.z) * step);
        
        if (equal(transform.position.x, destination.x, step) &&
            equal(transform.position.y, destination.y, step) &&
            equal(transform.position.z, destination.z, step))
                return true;

        return false;
    }

    public static float toPPIYScale(float value)
    {
        // -1.8f
        float zero = 0, scale = 0.009256516587677725f;

        return zero + value * scale;
    }

    public static float toPPIXScale(float value)
    {
        float zero = 0, scale = 0.009256516587677725f;

        return zero + value * scale;
    }

    public static float toCanvasYScale(float value)
    {
        float zero = 1.8f, scale = 108.032f;

        return (value + zero) * scale;
    }
    public static float toCanvasXScale(float value)
    {
        float zero = 0, scale = 0.009256516587677725f;

        return zero + value * scale;
    }
}
