using UnityEngine;

public abstract class EnemigoBase : MonoBehaviour
{
    [SerializeField] protected string _nombre;
    [SerializeField] protected Sprite _sprite;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    protected void Move(float speed = 5)
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    virtual protected void Jump() { }

    
    protected void Init()
    {
        this.gameObject.name = _nombre;
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        sprite.sprite = _sprite;
    }
}
