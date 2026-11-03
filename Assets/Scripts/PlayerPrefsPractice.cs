using UnityEngine;

public class PlayerPrefsPractice : MonoBehaviour
{
    public float vida = 2f;
    public int limit = 5;
    void Start()
    {
        PlayerPrefs.SetFloat(Constance.VidaPlayer, vida);
        Debug.Log(PlayerPrefs.GetFloat(Constance.VidaPlayer));
        PlayerPrefs.SetInt(Constance.LifeLimit, limit);
        Debug.Log(StablishBool());
    }

    private bool StablishBool()
    {
        bool isAlive = PlayerPrefs.GetFloat(Constance.VidaPlayer) >= PlayerPrefs.GetInt(Constance.LifeLimit) ? true : false;
        return isAlive;
    }
}
