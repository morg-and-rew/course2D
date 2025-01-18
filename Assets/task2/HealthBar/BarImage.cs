using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BarImage : HealthBar
{
    [SerializeField] private Image _healthBarImage;

    private Coroutine _smoothTransitionCoroutine;
    private float _targetFillAmount;

    protected override void UpdateVisuals(float fillAmount)
    {
        _targetFillAmount = fillAmount; 

        if (_smoothTransitionCoroutine != null)
            StopCoroutine(_smoothTransitionCoroutine);

        _smoothTransitionCoroutine = StartCoroutine(SmoothTransitionToTargetFill());
    }

    private IEnumerator SmoothTransitionToTargetFill()
    {
        float startFillAmount = _healthBarImage.fillAmount;
        float elapsedTime = 0f;
        float transitionDuration = 0.5f;

        while (elapsedTime < transitionDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / transitionDuration;
            _healthBarImage.fillAmount = Mathf.Lerp(startFillAmount, _targetFillAmount, t); 
            yield return null;
        }

        _healthBarImage.fillAmount = _targetFillAmount; 
    }
}