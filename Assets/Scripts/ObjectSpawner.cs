using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    public static int planesSpawned;

    float[] xCoords = { -0.25F, 0, 0.25F };
    float[] yCoords = { 1.35F,  2.1F };

    float zInterval = 0.3F;
    float spawnChance = 25;
    float enemyChance = 10;

    float lastZ;
    float startZ = -5;

    IEnumerator Start () {
        planesSpawned++;
        if (planesSpawned < 2)
            yield break;

        lastZ = startZ;
		while (lastZ < -startZ)
        {
            lastZ += zInterval;
            if (Util.randomProc(spawnChance))
                SpawnAtRandom(Util.randomProc(enemyChance));

            yield return null;
        }
	}

    void SpawnAtPoint(GameObject prefab, Vector3 point)
    {
        GameObject go = Instantiate(prefab, transform, true);
        go.transform.localPosition = point;
    }

    void SpawnAtRandom (bool isEnemy)
    {
        var point = new Vector3(
            Util.RandomFromArray(xCoords),
            isEnemy ? yCoords[0] : Util.RandomFromArray(yCoords),
            lastZ);

        var prefab = isEnemy ? 
            Storage.instance.enemyPrefab : 
            Storage.instance.bonusPrefabs
                [Random.Range(0, Storage.instance.bonusPrefabs.Length)];

        SpawnAtPoint(prefab, point);

    }
	
}
