using UnityEngine;
using System.Collections;

public class Monster_stats : MonoBehaviour {

    SceneSwitch scene;

    public int healthMax;
    public int health;
    public int mana;
    public int total_exp;
    public int level;
    public int attackdam;
    public int randNum;
    public status monsterCondition = status.FINE;

    public string ability1 = "";
    public string ability2 = "";
    public string ability3 = "";
    public string ability4 = "";
    public string item = "";
    public string monstername;

    public bool waitDelay = true;

	// Use this for initialization
	void Start () {

        scene = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SceneSwitch>();

        StartCoroutine(TimeDelay(0.5f));

        RandomLevel(scene.areaNum);

        levelinit(randNum);
	}

    void Update()
    {
        if (health > healthMax)
        {
            health = healthMax;
        }
    }

    void levelinit(int a)
    {

        level = a;
        healthMax = level * (healthMax * level);
        health = healthMax;
        mana = level * (mana * level);
        total_exp *= level;
        attackdam = level * (attackdam * level);

    }

    IEnumerator TimeDelay(float timedelay)
    {
        waitDelay = true;
        yield return new WaitForSeconds(timedelay);
        waitDelay = false;
    }

    void RandomLevel(int a)
    {
        if (a == 1)
        {
            randNum = Random.Range(1, 2);
        }
        else if (a == 4)
        {
            randNum = Random.Range(4, 7);
        }
        else if (a == 6)
        {
            randNum = Random.Range(5, 9);
        }
        else if (a == 11)
        {
            randNum = 10;
        }
        else
            randNum = 1;
    }
}
