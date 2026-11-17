using UnityEngine;

public class Crabs : MonoBehaviour
{
    public static Crabs Instance;
    enum _estado { victoria, derrota, fase2, jugando }
    Dado[] dados = new Dado[2];
    _estado _estadoActual = _estado.jugando;
    private int _valorAnterior;
    private int _resultadoTotal;
    private bool _isEntrandoFase2 = true;
    [SerializeField] private int _cantidadCaras = 6;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        for (int i = 0; i < dados.Length; i++)
        {
            dados[i] = new Dado(_cantidadCaras);
        }
    }

    public void Play()
    {
        switch (_estadoActual)
        {
            case _estado.jugando:
                Fase1();
                break;

            case _estado.fase2:
                Fase2();
                break;
        }

        switch (_estadoActual)
        {
            case _estado.victoria:
                Victoria();
                break;

            case _estado.derrota:
                Derrota();
                break;
        }

    }

    private int TirarDados()
    {
        int resultadoTotal = 0;
        for (int i = 0; i < dados.Length; i++)
        {
            int resultado = dados[i].GetResultado();
            resultadoTotal += resultado;
        }
        return resultadoTotal;
    }

    private void Fase1()
    {
        EventBus.MandarPrimerMensaje("Jugando Primera Fase");
        _resultadoTotal = TirarDados();

        if (_resultadoTotal == 7 || _resultadoTotal == 11)
        {
            _estadoActual = _estado.victoria;
        }

        else if (_resultadoTotal == 2 || _resultadoTotal == 3 || _resultadoTotal == 12)
        {
            _estadoActual = _estado.derrota;
        }
        else
        {
            _valorAnterior = _resultadoTotal;
            _estadoActual = _estado.fase2;
        }
        EventBus.ResultadoDados(_resultadoTotal.ToString());
    }
    private void Fase2()
    {
        if (_isEntrandoFase2)
        {
            EventBus.MandarMensaje("Entrando a la Fase 2");
            _isEntrandoFase2 = false;
        }
        else { EventBus.MandarMensaje("Jugando Fase 2"); }
        _resultadoTotal = TirarDados();

        if (_resultadoTotal == _valorAnterior) { _estadoActual = _estado.victoria; }

        else if (_resultadoTotal == 7) { _estadoActual = _estado.derrota; }

        EventBus.ResultadoDados(_resultadoTotal.ToString());
    }

    private void Victoria()
    {
        JsonConverter.Instance.PlayerInfo.VictoriasTotales += 1;
        EventBus.MandarMensaje("Ganaste");
        EventBus.ResultadoDados(_resultadoTotal.ToString());
        JsonConverter.Instance.SaveJson();
        _estadoActual = _estado.jugando;
    }
    private void Derrota()
    {
        JsonConverter.Instance.PlayerInfo.DerrotasTotales += 1;
        EventBus.MandarMensaje("Perdiste");
        EventBus.ResultadoDados(_resultadoTotal.ToString());
        JsonConverter.Instance.SaveJson();
        _estadoActual = _estado.jugando;
    }
}
