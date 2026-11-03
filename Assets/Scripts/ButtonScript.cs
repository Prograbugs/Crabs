using UnityEngine;
using UnityEngine.UI;

public class ButtonScript : MonoBehaviour
{
    public Button PlayerButton;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnEnable()
    {
        PlayerButton.onClick.AddListener(Crabs.Instance.Play);
    }

    private void OnDisable()
    {
        PlayerButton.onClick.RemoveListener(Crabs.Instance.Play);
    }
}
