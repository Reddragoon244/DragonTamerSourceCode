using UnityEngine;
using System.Collections;

public enum status { STUN, POISON, BURN, BLOCK, ATTACKUP, DEFUP, ATTACKDOWN, DEFDOWN, FINE };

public class Ability_List : MonoBehaviour {

    public int damage;
    public int mana = 0;
    public bool all;
    public bool heal;
    public GameObject[] abilityList;
    public GameObject abilityParticle = null;

    status condition = status.FINE;

	// Use this for initialization
	void Start () {

        all = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public int getAbility(string ability,int level)
    {

        switch (ability)
        {
            case "":
                damage = 0;
                mana = 0;
                condition = status.FINE;
                break;
//////////////////////////*Dragons*///////////////////////////////
            case "Fire":
                all = false;
                heal = false;
                damage = 10 * level;
                mana = 10;
                condition = status.BURN;
                abilityParticle = abilityList[0];
                break;

            case "Fire breath":
                all = false;
                heal = false;
                damage = 20 * level;
                mana = 20;
                condition = status.BURN;
                abilityParticle = abilityList[1];
                break;

            case "Ice breath":
                all = false;
                heal = false;
                damage = 20 * level;
                mana = 20;
                condition = status.STUN;
                abilityParticle = abilityList[3];
                break;

            case "Ice":
                all = false;
                heal = false;
                damage = 10 * level;
                mana = 10;
                condition = status.STUN;
                abilityParticle = abilityList[2];
                break;

            case "Thunder breath":
                all = false;
                heal = false;
                damage = 20 * level;
                mana = 20;
                abilityParticle = abilityList[4];
                break;

            case "Thunder":
                all = false;
                heal = false;
                damage = 10 * level;
                mana = 10;
                abilityParticle = abilityList[4];
                break;

            case "Firestorm":
                all = true;
                heal = false;
                damage = 20 * level;
                mana = 20;
                condition = status.BURN;
                abilityParticle = abilityList[5];
                break;

            case "Thunderstorm":
                all = true;
                heal = false;
                damage = 20 * level;
                mana = 20;
                abilityParticle = abilityList[7];
                break;

            case "Icestorm":
                all = true;
                heal = false;
                damage = 20 * level;
                mana = 20;
                condition = status.STUN;
                abilityParticle = abilityList[6];
                break;

            case "Dragon Claw":
                all = false;
                heal = false;
                damage = 10 * level;
                mana = 5;
                break;

            case "Dragon Scales":
                all = false;
                heal = false;
                damage = 0;
                mana = 20;
                condition = status.DEFUP;
                break;

            case "Earthquake":
                all = true;
                heal = false;
                damage = 10 * level;
                mana = 20;
                condition = status.STUN;
                break;

            case "Earthen Breath":
                all = false;
                heal = false;
                damage = 20 * level;
                mana = 10;
                break;

            case "Cauterize":
                all = false;
                heal = true;
                damage = 5 * level;
                mana = 10;
                abilityParticle = abilityList[9];
                break;

            case "Tail Swipe":
                all = false;
                heal = false;
                damage = 20 * level;
                mana = 10;
                condition = status.DEFDOWN;
                break;

            case "Cataclysm":
                all = true;
                heal = false;
                damage = 100 * level;
                mana = 50;
                condition = status.BURN;
                break;
//////////////////////////*Warrior*///////////////////////////////
            case "Shield Bash":
                all = false;
                heal = false;
                damage = 20 * level;
                mana = 10;
                condition = status.STUN;
                break;

            case "Shield Block":
                all = false;
                heal = false;
                damage = 0;
                mana = 20;
                condition = status.BLOCK;
                break;

            case "First Aid":
                all = false;
                heal = true;
                damage = 5 * level;
                mana = 10;
                abilityParticle = abilityList[9];
                break;

            case "Earthen Dragon's Defence":
                all = true;
                heal = false;
                damage = 50 * level;
                mana = 30;
                condition = status.DEFUP;
                break;
//////////////////////////*Fighter*///////////////////////////////
            case "Mortal Strike":
                all = false;
                heal = false;
                damage = 20 * level;
                mana = 10;
                condition = status.ATTACKDOWN;
                break;

            case "Impale":
                all = false;
                heal = false;
                damage = 30 * level;
                mana = 20;
                condition = status.BURN;
                break;

            case "Attack Buff":
                all = true;
                heal = false;
                damage = 0;
                mana = 10;
                condition = status.ATTACKUP;
                break;

            case "Red Dragon's Fist":
                all = false;
                heal = false;
                damage = 50 * level;
                mana = 30;
                condition = status.BURN;
                break;
//////////////////////////*Healer*///////////////////////////////
            case "Heal":
                all = false;
                heal = true;
                damage = 10 * level;
                mana = 10;
                abilityParticle = abilityList[9];
                break;

            case "Holy Fire":
                all = false;
                heal = false;
                damage = 20 * level;
                mana = 20;
                condition = status.BURN;
                break;

            case "Protection Buff":
                all = true;
                heal = false;
                damage = 0;
                mana = 10;
                condition = status.DEFUP;
                break;

            case "Jade Dragon's Breath":
                all = true;
                heal = true;
                damage = 50 * level;
                mana = 30;
                abilityParticle = abilityList[10];
                break;
        }

        return damage;

    }
}
