using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VampirismAbility : MonoBehaviour
{
    [SerializeField] private Health _health;

    private int _damageAmount = 2;
    private int _drainIterations = 6;
    private float _drainRadius = 7f;
    private float _drainInterval = 1f;

    private Coroutine _vampirismCoroutine;
    private WaitForSeconds _waitForDrain;

    private void Awake()
    {
        _waitForDrain = new WaitForSeconds(_drainInterval);
    }

    public void ActivateVampirism()
    {
        if (_vampirismCoroutine == null)
            _vampirismCoroutine = StartCoroutine(VampireDrain());
    }

    private IEnumerator VampireDrain()
    {
        for (int i = 0; i < _drainIterations; i++)
        {
            List<ITakingDamage> targets = FindTargetsInRange();

            foreach (ITakingDamage target in targets)
            {
                target.TakeDamage(_damageAmount);
                _health.TakeHeal(_damageAmount);
            }

            yield return _waitForDrain;
        }

        StopVampirism();
    }

    private void StopVampirism()
    {
        if (_vampirismCoroutine != null)
        {
            StopCoroutine(_vampirismCoroutine);
            _vampirismCoroutine = null;
        }
    }

    private List<ITakingDamage> FindTargetsInRange()
    {
        List<ITakingDamage> targetsInRange = new List<ITakingDamage>();
        Collider2D playerCollider = GetComponent<Collider2D>();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(playerCollider.bounds.center, _drainRadius);

        foreach (Collider2D collider in colliders)
        {
            if (collider.TryGetComponent(out ITakingDamage target) && collider.TryGetComponent<Enemy>(out _))
                targetsInRange.Add(target);
        }

        return targetsInRange;
    }
}