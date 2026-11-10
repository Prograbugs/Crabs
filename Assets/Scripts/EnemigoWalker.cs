using UnityEngine;

public class EnemigoWalker : EnemigoBase
{
    void Start()
    {
        Init();
    }

    void Update()
    {
        Move(8);
    }
}
