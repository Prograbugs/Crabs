using UnityEngine;

public class Dado
{
    private int _cara;

    public Dado(int cara) 
    {
        _cara = cara;
    }

    private int GirarDado()
    {
        return Random.Range(1, _cara + 1);
    }

    public int GetResultado()
    {
        int resultado = GirarDado();
        return resultado;
    }
}
