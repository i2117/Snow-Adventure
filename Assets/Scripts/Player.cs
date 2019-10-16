using System;
using UnityEngine;

public class Player : MonoBehaviour {

    public static Action onHitEnemy;
    public static Action<int> onCollectedBonus;

    private void OnTriggerEnter(Collider other)
    {
        var item = other.GetComponent<Item>();
        if (!item)
            return;

        if (item.isEnemy)
        {
            Debug.Log("Enemy!");
            if (onHitEnemy != null)
                onHitEnemy();

            SoundManager.instance.PlaySound(SoundManager.instance.lostSound);
        } else
        {
            Debug.Log("Bonus!");
            if (onCollectedBonus != null)
                onCollectedBonus(Game.instance.bonusPoints);

            Instantiate(
                Storage.instance.bonusParticle,
                item.transform.position,
                Quaternion.identity,
                null);
   
            SoundManager.instance.PlaySound(SoundManager.instance.bonusCollectedSound);
        }

        Destroy(item.gameObject);
    }
}
