using UnityEngine;
using System.Collections;

public class TamingPetList : MonoBehaviour {

    public GameObject gameManager;
    public GameObject[] pets;
    public GameObject clones;

    public SceneSwitch scene;

    public int i;

	// Use this for initialization
	void Start () {

        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        scene = gameManager.GetComponent<SceneSwitch>();

        if (scene.areaNum == 1)
        {
            i = RandomNumber(0, 3);
            clones = Instantiate(pets[i]);

            clones.transform.position = new Vector3(4.5f, 0.0f, 0.0f);
            clones.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (scene.areaNum == 6)
        {
            i = RandomNumber(4, 10);
            clones = Instantiate(pets[i]);

            clones.transform.position = new Vector3(4.5f, 0.0f, 0.0f);
            clones.GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (scene.areaNum == 4)
        {
            i = RandomNumber(0, 8);
            clones = Instantiate(pets[i]);

            clones.transform.position = new Vector3(4.5f, 0.0f, 0.0f);
            clones.GetComponent<SpriteRenderer>().flipX = true;
        }    
	
	}

    int RandomNumber(int min, int max)
    {
        int randNum;

        randNum = Random.Range(min, max);

        return randNum;
    }
	
}
