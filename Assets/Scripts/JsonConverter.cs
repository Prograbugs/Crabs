using System.IO;
using UnityEngine;

public class JsonConverter : MonoBehaviour
{
    public static JsonConverter Instance;
    public PlayerInfo PlayerInfo;

    private string _path;
    private string _infoJson;

    private void Awake()
    {
        Instance = this;
        _path = Path.Combine(Application.persistentDataPath, "DatosGuardados.json");
        Debug.Log(_path);
        if (File.Exists(_path))
        {
            ReadJson();
        }
        else
        {            
            CreateJson();
        }
    }

    private void ReadJson()
    {
        _infoJson = File.ReadAllText(_path);
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(_infoJson);
    }

    private void CreateJson()
    {
        PlayerInfo = new PlayerInfo();
        _infoJson = JsonUtility.ToJson(PlayerInfo, true);
        File.WriteAllText(_path, _infoJson);
    }

    public void SaveJson()
    {
        _infoJson = JsonUtility.ToJson(PlayerInfo, true);
        File.WriteAllText(_path, _infoJson);
    }
}
