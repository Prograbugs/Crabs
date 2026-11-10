using UnityEngine;

public class EnemigoDown : EnemigoBase
{
    [SerializeField] protected int vida = 50;
    void Start()
    {
        Init();
    }

    void Update()
    {
        if (vida > 49)
        {
            Move();
        }
        else
        {
            Cavar();
        }
    }

    protected void Cavar(float speed = 5)
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
