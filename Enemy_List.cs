using UnityEngine;
using System.Collections;

public class Enemy_List : MonoBehaviour {

    public GameObject gameManager;
    public GameObject[] enemies;
    public GameObject[] clones;

    public SceneSwitch scene;

    public  int i;

	// Use this for initialization
	void Start () {

        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        scene = gameManager.GetComponent<SceneSwitch>();

        if (scene.areaNum == 1)
        {
            i = RandomNumber(0, 8);
            clones[0] = Instantiate(enemies[i]);
            i = RandomNumber(0, 8);
            clones[1] = Instantiate(enemies[i]);
            i = RandomNumber(0, 8);
            clones[2] = Instantiate(enemies[i]);
            i = RandomNumber(0, 8);
            clones[3] = Instantiate(enemies[i]);

            clones[0].transform.position = new Vector3(4.5f, 2.0f, 0.0f);
            clones[1].transform.position = new Vector3(4.5f, -2.0f, 0.0f);
            clones[2].transform.position = new Vector3(3.0f, 0.0f, 0.0f);
            clones[3].transform.position = new Vector3(6.0f, 0.0f, 0.0f);
        }
        else if (scene.areaNum == 6)
        {
            i = RandomNumber(4, 10);
            clones[0] = Instantiate(enemies[i]);
            i = RandomNumber(4, 10);
            clones[1] = Instantiate(enemies[i]);
            i = RandomNumber(4, 10);
            clones[2] = Instantiate(enemies[i]);
            i = RandomNumber(4, 10);
            clones[3] = Instantiate(enemies[i]);

            clones[0].transform.position = new Vector3(4.5f, 2.0f, 0.0f);
            clones[1].transform.position = new Vector3(4.5f, -2.0f, 0.0f);
            clones[2].transform.position = new Vector3(3.0f, 0.0f, 0.0f);
            clones[3].transform.position = new Vector3(6.0f, 0.0f, 0.0f);
        }
        else if (scene.areaNum == 4)
        {
            i = RandomNumber(0, 8);
            clones[0] = Instantiate(enemies[i]);
            i = RandomNumber(0, 8);
            clones[1] = Instantiate(enemies[i]);
            i = RandomNumber(0, 8);
            clones[2] = Instantiate(enemies[i]);
            i = RandomNumber(0, 8);
            clones[3] = Instantiate(enemies[i]);

            clones[0].transform.position = new Vector3(4.5f, 2.0f, 0.0f);
            clones[1].transform.position = new Vector3(4.5f, -2.0f, 0.0f);
            clones[2].transform.position = new Vector3(3.0f, 0.0f, 0.0f);
            clones[3].transform.position = new Vector3(6.0f, 0.0f, 0.0f);
        }
        else if (scene.areaNum == 10)
        {
            clones[0] = Instantiate(enemies[13]);//Boss Adult Brown Dragon
            clones[0].transform.position = new Vector3(3.0f, 0.0f, 0.0f);
            clones[1] = Instantiate(enemies[12]);//Boss Baby Brown Dragon
            clones[1].transform.position = new Vector3(4.5f, 2.0f, 0.0f);
            clones[2] = Instantiate(enemies[12]);//Boss Baby Brown Dragon
            clones[2].transform.position = new Vector3(4.5f, -2.0f, 0.0f);
            clones[3] = null;
        }
        else if (scene.areaNum == 11)
        {
            clones[0] = Instantiate(enemies[11]);//Boss Adult Brown Dragon
            clones[0].transform.position = new Vector3(4.5f, 0.0f, 0.0f);
            clones[1] = null;
            clones[2] = null;
            clones[3] = null;
        }

        
	
	}
	
	// Update is called once per frame
	void Update () {



	}

    int RandomNumber(int min, int max)
    {
        int randNum;

        randNum = Random.Range(min, max);

        return randNum;
    }
}
