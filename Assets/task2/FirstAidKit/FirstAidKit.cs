using UnityEngine;

public class FirstAidKit : Collectible
{
    private int _recoveryHealth = 40;

    public override void Collect(ICollectble collector)
    {
        base.Collect(collector);
        collector.CollectFirstAidKit(_recoveryHealth);
    }
}