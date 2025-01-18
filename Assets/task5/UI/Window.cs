using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] protected CanvasGroup CanvasGroup;
    [SerializeField] protected Button Button;
    [SerializeField] protected Image Image;

    private void OnEnable()
    {
        Button.onClick.AddListener(OnButtonClick);
    }    
    
    private void OnDisable()
    {
        Button.onClick.RemoveListener(OnButtonClick);
    }

    public abstract void OnButtonClick();
    public abstract void Open();
    public abstract void Close();
}