using UnityEngine;
using System.Collections;

public class Pets_stats : MonoBehaviour {

    public int healthMax;
    public int health;
    public int manaMax;
    public int mana;
    public int exp;
    public int expNext;
    public int level;
    public int attackdam;
    public float alpha = 1.0f;
    public status petCondition = status.FINE;

    public string petname = null;
    public string ability1 = null;
    public string ability2 = null;
    public string ability3 = null;
    public string ability4 = null;
    public string attack = null;
    public string[] abilityList;
    public string[] activeabilities;

    public bool levelCheck = false;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

	// Use this for initialization
	void Start () {

        alpha = 1.0f;

	}
	
	// Update is called once per frame
	void Update () {

        if (health > healthMax)
        {
            health = healthMax;
        }

        if (mana > manaMax)
        {
            mana = manaMax;
        }

        if(levelCheck == true)
        {
            if (exp >= expNext)
            {
                levelup();
                AbilityCheck();
                expCalc();
            }
            

        }

        if (health <= 0)
        {
            if(alpha >= 0)
                alpha -= 0.01f;

            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(alpha, alpha, alpha, alpha);
        }

	}

    void levelup()
    {
        level++;
        healthMax += (40 *level);
        health = healthMax;
        manaMax += (10 * level);
        mana = manaMax;
        attackdam += (10 * level);
        
        levelCheck = false;
    }

    void expCalc()
    {
        expNext += (int)(exp * 1.5f);

    }

    void AbilityCheck()
    {
        if (level == 2)
            ability1 = activeabilities[0] = abilityList[0];
        else if (level == 4)
            ability2 = activeabilities[1] = abilityList[1];
        else if (level == 7)
            ability3 = activeabilities[2] = abilityList[2];
        else if (level == 10)
            ability4 = activeabilities[3] = abilityList[3];
    }
}
