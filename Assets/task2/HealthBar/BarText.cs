using TMPro;
using UnityEngine;

public class BarText : HealthBar
{
    [SerializeField] private TextMeshProUGUI _healthText;

    protected override void UpdateVisuals(float fillAmount)
    {
        if (_healthText != null)
        {
            //_healthText.text = "Health: " + (_health.CurrentHealth).ToString() + "/" + MaxHealth.ToString();
        }
    }
}