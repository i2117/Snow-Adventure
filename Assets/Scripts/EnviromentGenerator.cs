using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentGenerator : MonoBehaviour {

    public GameObject enviromentPrefab;
    public float spawningDistance = 100;
    public float spawningInterval = 20;

    float lastSpawnedZ;
    Transform player;

	IEnumerator Start () {
		while (true)
        {
            if (!player)
                player = GameObject.FindGameObjectWithTag("Player").transform;

            yield return null;
        }
	}
	
	void Update () {
        if (!player)
            return;

        if (lastSpawnedZ - player.position.z < 100)
        {
            lastSpawnedZ += spawningInterval;
            Instantiate(
                enviromentPrefab,
                new Vector3(0, 0, lastSpawnedZ),
                Quaternion.identity,
                null);
        }
	}

}
