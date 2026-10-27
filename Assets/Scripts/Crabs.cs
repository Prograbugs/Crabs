using UnityEngine;
using System.Collections;
using System;

public class Crabs : MonoBehaviour
{
    enum _estado {victoria, derrota, fase2, jugando}
    Dado[] dados = new Dado[2];
    _estado _estadoActual = _estado.jugando;
    private int _valorAnterior;
    private bool _isFase1 = true;
    private int _resultadoTotal;
    [SerializeField] private int _cantidadCaras = 6;
    
    void Start()
    {
        for (int i = 0; i < dados.Length; i++)
        {
            dados[i] = new Dado(_cantidadCaras); 
        }
    }

    
    void Update()
    {
        switch(_estadoActual)
        {
            case _estado.jugando:
                Fase1();
                break;

            case _estado.victoria:
                Debug.Log("Ganaste");
                break;

            case _estado.derrota:
                Debug.Log("Perdiste");
                break;

            case _estado.fase2:
                Debug.Log("Entrando a fase 2");
                break;
        }
    }


    private int TirarDados()
    {
        int resultadoTotal = 0;
        for (int i = 0; i < dados.Length;  i++)
        {
            int resultado = dados[i].GetResultado();
            resultadoTotal += resultado;
        }
        return resultadoTotal;
    }

    private void Fase1() 
    {
        _resultadoTotal = TirarDados();

        if(_resultadoTotal == 7 || _resultadoTotal == 11) 
        { 
            Debug.Log("Ganaste");
            _estadoActual = _estado.victoria;
        }

        else if(_resultadoTotal == 2 || _resultadoTotal == 3 || _resultadoTotal == 12) 
        { 
            Debug.Log("Perdiste");
            _estadoActual = _estado.derrota;
        }
    }
    private void Fase2()
    {
        throw new NotImplementedException();
    }
}
