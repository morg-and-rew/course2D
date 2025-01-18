using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class CooldownBar : MonoBehaviour
{
    [SerializeField] private Image _barImage;
    [SerializeField] private VampirismAbility _vampirismAbility;

    private float _currentCooldown = 0f;
    private float _cooldownDuration = 6f;
    private float _rechargeTime = 6;
    private float _fullCooldown = 1f;

    public void ActivateCooldown()
    {
        if (_barImage.fillAmount == 1f)
            StartCooldown(_rechargeTime);
    }

    private void StartCooldown(float duration)
    {
        _cooldownDuration = duration;
        _currentCooldown = duration;
        _barImage.fillAmount = _fullCooldown;
        StartCoroutine(CooldownRoutine());
    }

    private IEnumerator CooldownRoutine()
    {
        while (_currentCooldown > 0f)
        {
            _currentCooldown -= Time.deltaTime; 
            _barImage.fillAmount = _currentCooldown / _cooldownDuration;

            yield return null;
        }

        while (_currentCooldown < _cooldownDuration)
        {
            _currentCooldown += Time.deltaTime; 
            _barImage.fillAmount = _currentCooldown / _cooldownDuration;

            yield return null;
        }

        _currentCooldown = _cooldownDuration; 
        _barImage.fillAmount = _fullCooldown;
    }
}