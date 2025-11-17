using UnityEngine;

public class MultiRangeAttribute : PropertyAttribute
{
    public float min1;
    public float max1;
    public float min2;
    public float max2;

    public MultiRangeAttribute(float min1, float max1, float min2, float max2)
    {
        this.min1 = min1;
        this.max1 = max1;
        this.min2 = min2;
        this.max2 = max2;
    }
}