using UnityEngine;
using UnityEngine.Events;

public class StartScreen : Window
{
    public event UnityAction PlayButtonClick;

    public override void Close()
    {
        CanvasGroup.alpha = 0;
        Button.interactable = false;
    }

    public override void Open()
    {
        CanvasGroup.alpha = 1;
        Button.interactable = true;
    }

    public override void OnButtonClick()
    {
        PlayButtonClick?.Invoke();
    }
}