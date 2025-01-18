using UnityEngine;

public class Coin : Collectible
{
    private int _coinValue = 20;

    public override void Collect(ICollectble collector)
    {
        base.Collect(collector);
        collector.CollectCoin(_coinValue);
    }
}