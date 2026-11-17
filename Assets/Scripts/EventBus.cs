using UnityEngine;
using System;
using UnityEditor;

public static class EventBus
{
    #region eventos
    public static event Action<string> OnMandarPrimerMensaje;
    public static event Action<string> OnMandarMensaje;
    public static event Action<string> OnResultadoDados;
    #endregion

    #region EventCall
    public static void MandarPrimerMensaje(string mensaje)
    {
        OnMandarPrimerMensaje?.Invoke(mensaje);
    }

    public static void MandarMensaje(string mensaje)
    {
        OnMandarMensaje?.Invoke(mensaje);
    }

    public static void ResultadoDados(string mensaje)
    {
        OnResultadoDados?.Invoke(mensaje);
    }
    #endregion
}
