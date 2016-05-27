using UnityEngine;
using System.Collections;

public class CombatCollision : MonoBehaviour {

    public GameObject[] Spawner;
    GameObject[] combatSpawn;

    public int randomNum = 0, i = 0;
    private bool spawnChnager = true, waitDelay = false;

	// Use this for initialization
	void Start () {

        if(combatSpawn == null)
            combatSpawn = GameObject.FindGameObjectsWithTag("combattrigger");

        foreach (GameObject spawn in combatSpawn)
        {
            Spawner[i] = spawn;
            i++;
        }

        for (int i = 0; i < 42; i++)
        {
            Spawner[i].SetActive(false);
        }

        StartCoroutine(TimeDelay(3));

	}

    // Update is called once per frame
    void Update()
    {

        randomNum = Random.Range(0, 100);

        if (Spawner[i] == null && waitDelay == false)
            i = 0;
        else if(randomNum <= 65 && waitDelay == false)
            Spawner[i].SetActive(spawnChnager);
        else if(waitDelay == false)
            Spawner[i].SetActive(false);

        if(waitDelay == false)
            i++;

	}

    IEnumerator TimeDelay(float timedelay)
    {
        waitDelay = true;
        yield return new WaitForSeconds(timedelay);
        waitDelay = false;
    }
}
