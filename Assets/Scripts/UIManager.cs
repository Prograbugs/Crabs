using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textEstadoJuego;
    [SerializeField] private TextMeshProUGUI _textResultadoDados;

    private void OnEnable()
    {
        EventBus.OnMandarPrimerMensaje += SetPrimerMensaje;
        EventBus.OnMandarMensaje += SetMensaje;
        EventBus.OnResultadoDados += MostrarResultadoDados;
    }

    private void OnDisable()
    {
        EventBus.OnMandarPrimerMensaje -= SetPrimerMensaje;
        EventBus.OnMandarMensaje -= SetMensaje;
        EventBus.OnResultadoDados -= MostrarResultadoDados;
    }

    private void SetPrimerMensaje(string mensaje)
    {
        _textEstadoJuego.text = mensaje;
    }

    private void SetMensaje(string mensaje)
    {
        _textEstadoJuego.text = mensaje;
    }

    private void MostrarResultadoDados(string mensaje)
    {
        _textResultadoDados.text = "Tirada: " + mensaje;
    }
}
