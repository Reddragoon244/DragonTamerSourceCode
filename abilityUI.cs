using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class abilityUI : MonoBehaviour {

    public GameObject ability1UI;
    public GameObject ability2UI;
    public GameObject ability3UI;
    public GameObject ability4UI;

    public GameObject gameManager;

    public Text[] abilName;


    public GameObject combat;
    Combat ui;
    public Pets_stats[] pet;
    Player_Stats player;
    Player_party clones;

    private bool active1 = false, active2 = false, active3 = false, active4 = false;

	// Use this for initialization
	void Start () {

        gameManager = GameObject.FindGameObjectWithTag("GameManager");

        ui = combat.GetComponent<Combat>();
        player = gameManager.GetComponent<Player_Stats>();

        abilName[0] = ability1UI.GetComponentInChildren<Text>();
        abilName[1] = ability2UI.GetComponentInChildren<Text>();
        abilName[2] = ability3UI.GetComponentInChildren<Text>();
        abilName[3] = ability4UI.GetComponentInChildren<Text>();


        clones = gameManager.GetComponent<Player_party>();
	}

    // Update is called once per frame
    void Update()
    {

        ability1UI.SetActive(active1);
        ability2UI.SetActive(active2);
        ability3UI.SetActive(active3);
        ability4UI.SetActive(active4);

        if (ui.UIcast == true)
        {

            if (clones.party_clones[0].GetComponent<Pets_stats>() != null)
            {
                if (pet[0] == null)
                    pet[0] = clones.party_clones[0].GetComponent<Pets_stats>();
            }

            if (clones.party_clones[1].GetComponent<Pets_stats>() != null)
            {
                if (pet[0] == null)
                    pet[0] = clones.party_clones[1].GetComponent<Pets_stats>();
                else
                    pet[1] = clones.party_clones[1].GetComponent<Pets_stats>();
            }

            if (clones.party_clones[2].GetComponent<Pets_stats>() != null)
            {
                if (pet[1] == null)
                    pet[1] = clones.party_clones[2].GetComponent<Pets_stats>();
                else
                    pet[2] = clones.party_clones[2].GetComponent<Pets_stats>();
            }

            if (clones.party_clones[3].GetComponent<Pets_stats>() != null)
            {
                if (pet[2] == null)
                    pet[2] = clones.party_clones[3].GetComponent<Pets_stats>();
            }

            active1 = true;
            active2 = true;
            active3 = true;
            active4 = true;

            if (ui.playerState == 1)
            {
                if (player.ability1 != null)
                    abilName[0].text = player.ability1;
                else
                    active1 = false;
                if (player.ability2 != null)
                    abilName[1].text = player.ability2;
                else
                    active2 = false;
                if (player.ability3 != null)
                    abilName[2].text = player.ability3;
                else
                    active3 = false;
                if (player.ability4 != null)
                    abilName[3].text = player.ability4;
                else
                    active4 = false;
            }
            else if (ui.playerState == 2)
            {
                if (pet[0].ability1 != null)
                    abilName[0].text = pet[0].ability1;
                else
                    active1 = false;
                if (pet[0].ability2 != null)
                    abilName[1].text = pet[0].ability2;
                else
                    active2 = false;
                if (pet[0].ability3 != null)
                    abilName[2].text = pet[0].ability3;
                else
                    active3 = false;
                if (pet[0].ability4 != null)
                    abilName[3].text = pet[0].ability4;
                else
                    active4 = false;

            }
            else if (ui.playerState == 3)
            {
                if (pet[1].ability1 != null)
                    abilName[0].text = pet[1].ability1;
                else
                    active1 = false;
                if (pet[1].ability2 != null)
                    abilName[1].text = pet[1].ability2;
                else
                    active2 = false;
                if (pet[1].ability3 != null)
                    abilName[2].text = pet[1].ability3;
                else
                    active3 = false;
                if (pet[1].ability4 != null)
                    abilName[3].text = pet[1].ability4;
                else
                    active4 = false;
            }
            else if (ui.playerState == 4)
            {
                if (pet[2].ability1 != null)
                    abilName[0].text = pet[2].ability1;
                else
                    active1 = false;
                if (pet[2].ability2 != null)
                    abilName[1].text = pet[2].ability2;
                else
                    active2 = false;
                if (pet[2].ability3 != null)
                    abilName[2].text = pet[2].ability3;
                else
                    active3 = false;
                if (pet[2].ability4 != null)
                    abilName[3].text = pet[2].ability4;
                else
                    active4 = false;
            }
        }
        else
        {
            active1 = false;
            active2 = false;
            active3 = false;
            active4 = false;
        }
	
	}



}
