using UnityEngine;

public class Lightning_blot : Bullet
{

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, 6, transform.position.z);
    }
}
