using UnityEngine;

public abstract class Clicker : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _mySprite;
    public float waitTime { get; } = 0.5f;

    [SerializeField] private int _points;

    private float _timer;
    [SerializeField] private float _timerToDespawn;

    private void OnEnable()
    {
        _timer = 0f;
    }

    private void Update()
    {
        _timer += Time.deltaTime;
        if(_timer >= _timerToDespawn) { NotClicked(); }
        else { }
    }

    private void NotClicked()
    {
        GameManager.Instance.ReduceHealth();
        EventsBus.ClickerGoesInactive();
        this.gameObject.SetActive(false);
    }

    private void Clicked()
    {
        EventsBus.GetPoints(_points);
        EventsBus.ClickerGoesInactive();
        this.gameObject.SetActive(false);
    }
}
