using NUnit.Framework.Constraints;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEditor.Build.Content;

public class SpawnManager : MonoBehaviour
{
    [Header("Instance")]
    public static SpawnManager Instance;

    [Header("Spawn Positions")]
    [SerializeField] private float _minXSpawn = 5;
    [SerializeField] private float _maxXSpawn = 5;
    [SerializeField] private float _minYSpawn = 5;
    [SerializeField] private float _maxYSpawn = 5;
    private PositionGeneration _enemySpawnPoint;

    [Header("Prefabs")]
    [SerializeField] private GameObject _easyEnemyPrefab;
    [SerializeField] private GameObject _mediumEnemyPrefab;
    [SerializeField] private GameObject _difficultEnemyPrefab;

    [Header("Enemy To Spawn")]
    private int _easyEnemiesQuantity = 10;
    private int _mediumEnemiesQuantity = 5;
    private int _difficultEnemiesQuantity = 2;

    private List<GameObject> _enemies = new List<GameObject>();

    [Header("References")]
    private bool _canSpawn = true;

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }

        DontDestroyOnLoad(gameObject);
        for (int i = 0; i < _easyEnemiesQuantity; i++) 
        {
            GameObject enemy = Instantiate(_easyEnemyPrefab);
            enemy.SetActive(false);
            _enemies.Add(enemy); 
        }
        for (int i = 0; i < _mediumEnemiesQuantity; i++) 
        {
            GameObject enemy = Instantiate(_mediumEnemyPrefab);
            enemy.SetActive(false);
            _enemies.Add(enemy); 
        }
        for (int i = 0; i < _difficultEnemiesQuantity; i++) 
        {
            GameObject enemy = Instantiate(_difficultEnemyPrefab);
            enemy.SetActive(false);
            _enemies.Add(enemy); 
        }

        _enemySpawnPoint = new PositionGeneration(_minXSpawn, _maxXSpawn, _minYSpawn, _maxYSpawn);
    }

    private void Start()
    {
        SpawnEnemy();
    }

    private void OnEnable()
    {
        EventsBus.OnClickerInactive += SpawnEnemy;
    }

    private void OnDisable()
    {
        EventsBus.OnClickerInactive -= SpawnEnemy;
    }

    private void SpawnEnemy()
    {
        if(GameManager.Instance.Health > 0 && _canSpawn)
        {
            Vector2 position = _enemySpawnPoint.GetPosition();
            for(int i = 0; i < _enemies.Count; i++)
            { 
                int index = Random.Range(0, _enemies.Count - 1);
                if(_enemies[index].activeInHierarchy) { continue; }
                else
                {
                    _enemies[index].SetActive(true);
                    _enemies[index].transform.position = position;
                    Clicker enemyClicker = _enemies[index].GetComponent<Clicker>();
                    _canSpawn = false;
                    StartCoroutine(WaitToSpawn(enemyClicker.waitTime));
                }
            }
        }
    }

    private IEnumerator WaitToSpawn(float delay)
    {
        yield return new WaitForSeconds(delay);
        _canSpawn = true;
        SpawnEnemy();
    }
}
