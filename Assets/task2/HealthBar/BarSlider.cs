using UnityEngine;
using UnityEngine.UI;

public class BarSlider : HealthBar
{
    [SerializeField] private Slider _healthSlider;

    protected override void UpdateVisuals(float fillAmount)
    {
        if (_healthSlider != null)
        {
            _healthSlider.value = fillAmount;
        }
    }
}