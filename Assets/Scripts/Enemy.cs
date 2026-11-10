using UnityEngine;

public class Enemy : EnemigoBase
{
    void Start()
    {
        Init();
    }

    void Update()
    {
        Move();
        Jump();
    }

    protected override void Jump()
    {

        transform.Translate(Vector3.up * 1 * Time.deltaTime);
    }
}
