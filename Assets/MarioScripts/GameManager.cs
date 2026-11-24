using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int Health { get; private set; } = 10;

    private void Awake()
    {
        Instance = this;
    }

    public void ReduceHealth()
    {
        Health--;
    }
}
