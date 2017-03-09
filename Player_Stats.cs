using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Player_Stats : MonoBehaviour {

    public GameObject player;

    public int healthMax; //max health of player
    public int health; //current health of player
    public int manaMax; //max mana of player
    public int mana; //current mana of player
    public int exp; //current experience of player
    public int expNext; //experience needed for next level
    public int level; //current level
    public int attackdam; //current attack power
    public status playerCondition = status.FINE; //current condition

    public Button startgame;
    public string playername = null;
    public string ability1 = null;
    public string ability2 = null;
    public string ability3 = null;
    public string ability4 = null;
    public string[] abilityList;
    public string[] activeabilities;
    public string playerChoice = " ";

    public bool levelCheck = false;
    public bool combatready = false;

    void Awake ()
    {

        DontDestroyOnLoad(transform.gameObject);
 
    }
	
	// Update is called once per frame
	void Update () {

        player = GameObject.FindGameObjectWithTag("Player");

        if (health > healthMax)
        {
            health = healthMax;
        }

        if (mana > manaMax)
        {
            mana = manaMax;
        }
        
        if (levelCheck == true)
        {
            if (exp >= expNext)
            {
                levelup();
                AbilityCheck();
                expCalc();
            }

        }
	
	}

    void levelup()
    {
        level++;
        healthMax += (100 * level);
        health = healthMax;
        manaMax += (20 * level);
        mana = manaMax;
        attackdam += (10 *level);

        levelCheck = false;
    }

    public void playerLocation()
    {
        this.transform.position = player.transform.position;
        Debug.Log(player.transform.position);
    }

    void expCalc()
    {
        expNext += (int)(exp * 1.5f);

    }

    void AbilityCheck()
    {
        if (playerChoice == "Animations/Warrior/Warrior")
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
        if (playerChoice == "Animations/Healer/Healer")
        {
            if (level == 2)
                ability1 = activeabilities[0] = abilityList[8];
            else if (level == 4)
                ability2 = activeabilities[1] = abilityList[9];
            else if (level == 7)
                ability3 = activeabilities[2] = abilityList[10];
            else if (level == 10)
                ability4 = activeabilities[3] = abilityList[11];
            
        }
        if (playerChoice == "Animations/Fighter/Fighter")
        {
            if (level == 2)
                ability1 = activeabilities[0] = abilityList[4];
            else if (level == 4)
                ability2 = activeabilities[1] = abilityList[5];
            else if (level == 7)
                ability3 = activeabilities[2] = abilityList[6];
            else if (level == 10)
                ability4 = activeabilities[3] = abilityList[7];
        }
    }

    public void ClassWarrior()
    {
        startgame.interactable = true;
        playerChoice = "Animations/Warrior/Warrior";
        ability1 = activeabilities[0] = abilityList[0];
    }

    public void ClassHealer()
    {
        startgame.interactable = true;
        playerChoice = "Animations/Healer/Healer";
        ability1 = activeabilities[0] = abilityList[8];
    }

    public void ClassFighter()
    {
        startgame.interactable = true;
        playerChoice = "Animations/Fighter/Fighter";
        ability1 = activeabilities[0] = abilityList[4];
    }
}
