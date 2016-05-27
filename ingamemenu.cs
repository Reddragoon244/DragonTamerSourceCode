using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ingamemenu : MonoBehaviour {

    public GameObject Statinfo, Skillsinfo, PartyMenu, MainMenu;
    public Text[] stats;
    public Text[] skills;
    public Player_party party;
    public Player_Stats player;
    public Pets_stats[] pets;

    public SceneSwitch scene;

	// Use this for initialization
	void Start () {

        party = FindObjectOfType<Player_party>();
        player = FindObjectOfType<Player_Stats>();
        scene = FindObjectOfType<SceneSwitch>();
        pets[0] = party.party_clones[1].GetComponent<Pets_stats>();
        pets[1] = party.party_clones[2].GetComponent<Pets_stats>();
        pets[2] = party.party_clones[3].GetComponent<Pets_stats>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void playerstat()
    {
        Skillsinfo.SetActive(false);
        PartyMenu.SetActive(false);
        Statinfo.SetActive(true);


        stats[0].text = "Level : " + player.level + "\n"
                        + player.playername + "\n"
                        + "Health: " + player.health + "/" + player.healthMax + "\n"
                        + "Mana: " + player.mana + "/" + player.manaMax + "\n"
                        + "Attack: " + player.attackdam + "\n";
        stats[1].text = "Level : " + pets[0].level + "\n"
                        + pets[0].petname + "\n"
                        + "Health: " + pets[0].health + "/" + pets[0].healthMax + "\n"
                        + "Mana: " + pets[0].mana + "/" + pets[0].manaMax + "\n"
                        + "Attack: " + pets[0].attackdam + "\n";
        stats[2].text = "Level : " + pets[1].level + "\n"
                        + pets[1].petname + "\n"
                        + "Health: " + pets[1].health + "/" + pets[1].healthMax + "\n"
                        + "Mana: " + pets[1].mana + "/" + pets[1].manaMax + "\n"
                        + "Attack: " + pets[1].attackdam + "\n";
        stats[3].text = "Level : " + pets[2].level + "\n"
                        + pets[2].petname + "\n"
                        + "Health: " + pets[2].health + "/" + pets[2].healthMax + "\n"
                        + "Mana: " + pets[2].mana + "/" + pets[2].manaMax + "\n"
                        + "Attack: " + pets[2].attackdam + "\n";
    }

    public void partySkills()
    {
        Statinfo.SetActive(false);
        PartyMenu.SetActive(false);
        Skillsinfo.SetActive(true);

        skills[0].text = "Level : " + player.level + "\n"
                        + player.playername + "\n"
                        + "Ability1: " + player.ability1 + "\n"
                        + "Ability2: " + player.ability2 + "\n"
                        + "Ability3: " + player.ability3 + "\n"
                        + "Ability4: " + player.ability4 + "\n";
        skills[1].text = "Level : " + pets[0].level + "\n"
                        + pets[0].petname + "\n"
                        + "Ability1: " + pets[0].ability1 + "\n"
                        + "Ability2: " + pets[0].ability2 + "\n"
                        + "Ability3: " + pets[0].ability3 + "\n"
                        + "Ability4: " + pets[0].ability4 + "\n";
        skills[2].text = "Level : " + pets[1].level + "\n"
                        + pets[1].petname + "\n"
                        + "Ability1: " + pets[1].ability1 + "\n"
                        + "Ability2: " + pets[1].ability2 + "\n"
                        + "Ability3: " + pets[1].ability3 + "\n"
                        + "Ability4: " + pets[1].ability4 + "\n";
        skills[3].text = "Level : " + pets[2].level + "\n"
                        + pets[2].petname + "\n"
                        + "Ability1: " + pets[2].ability1 + "\n"
                        + "Ability2: " + pets[2].ability2 + "\n"
                        + "Ability3: " + pets[2].ability3 + "\n"
                        + "Ability4: " + pets[2].ability4 + "\n";
    }

    public void Party()
    {
        Statinfo.SetActive(false);
        PartyMenu.SetActive(true);
        Skillsinfo.SetActive(false);
    }

    public void MainMenuQuit()
    {
        MainMenu.SetActive(true);
    }

    public void MainMenuYes()
    {
        scene.SceneLoad("Main Menu");
    }

    public void MainMenuNo()
    {
        MainMenu.SetActive(false);
    }
}
