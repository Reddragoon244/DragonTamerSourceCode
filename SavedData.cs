using UnityEngine;
using System.Collections;

public class SavedData : MonoBehaviour {

    public GameObject gameManager;

    Player_party plist;
    Player_Stats playerstats;

	// Use this for initialization
	void Start () {

        plist = gameManager.GetComponent<Player_party>();
        playerstats = gameManager.GetComponent<Player_Stats>();

	}

    public void InitPlayerParty()
    {
        playerstats.ability1 = " ";
        playerstats.ability2 = " ";
        playerstats.ability3 = " ";
        playerstats.ability4 = " ";
        playerstats.attackdam = 10;
        playerstats.exp = 0;
        playerstats.health = 100;
        playerstats.healthMax = 100;
        playerstats.mana = 20;
        playerstats.manaMax = 20;
        playerstats.level = 1;
        playerstats.playername = "player";

        for (int i = 1; i < 4; i++)
        {
            plist.player_party[i] = null;
        }

    }

    public void CreatePlayerParty()
    {
        playerstats.ability1 = " ";
        playerstats.ability2 = " ";
        playerstats.ability3 = " ";
        playerstats.ability4 = " ";
        playerstats.attackdam = 10;
        playerstats.exp = 0;
        playerstats.health = 100;
        playerstats.healthMax = 100;
        playerstats.mana = 20;
        playerstats.manaMax = 20;
        playerstats.level = 1;
        playerstats.playername = "player";


        plist.player_party[1] = Resources.Load("Prefabs/Monsters/pet Blue Dragon") as GameObject;
        plist.player_party[2] = Resources.Load("Prefabs/Monsters/pet Green Adult Dragon") as GameObject;
        plist.player_party[3] = Resources.Load("Prefabs/Monsters/pet Baby Red Dragon") as GameObject;
        

    }
}
