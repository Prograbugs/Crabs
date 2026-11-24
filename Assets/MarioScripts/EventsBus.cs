using System;
using UnityEditor;
using UnityEngine;

public static class EventsBus
{
    #region Events
    public static event Action OnClickerInactive;
    public static event Action<int> OnGetPoints;
    #endregion

    #region EventCall
    public static void ClickerGoesInactive()
    {
        OnClickerInactive?.Invoke();
    }
    public static void GetPoints(int points)
    {
        OnGetPoints?.Invoke(points);
    }
    #endregion
}
