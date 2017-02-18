using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] attackerPrefabArray;

	// Update is called once per frame
	void Update () {
		foreach(GameObject thisAttacker in attackerPrefabArray)
        {
            if(isTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
	}

    void Spawn(GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject) as GameObject;
        myAttacker.transform.parent = transform;
        myAttacker.transform.position = transform.position;
    }

    bool isTimeToSpawn (GameObject attackerGameObject)
    {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();

        float spawnDelay = attacker.seenEverySeconds;
        float spawnsPerSecond = 0.5f / spawnDelay;

        if(Time.deltaTime > spawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by framerate");
        }

        float threshold = spawnsPerSecond * Time.deltaTime / 5;

        return (Random.value < threshold);
    }
}
