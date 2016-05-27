using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class party_ui_stats : MonoBehaviour {

    public GameObject gameManager;
    public GameObject[] UIparty;
    public GameObject[] UIobjects;

    public Text[] ui;
    Enemy_List elist;

    Player_Stats player;
    Player_party party;
    public Pets_stats[] pet;
    public Monster_stats[] mstats;

    private bool waitDelay = true;
    private bool uistats = false;

    /*UIparty 0-4 Name, healthMax, healthCurrent, magicCurrent, magicMax  */

	// Use this for initialization
	void Start () {

        gameManager = GameObject.FindGameObjectWithTag("GameManager");

        for (int i = 0; i < 28; i++)
        {
            ui[i] = UIparty[i].GetComponent<Text>();
        }

        player = gameManager.GetComponent<Player_Stats>();
        party = gameManager.GetComponent<Player_party>();
        elist = GetComponent<Enemy_List>();

        StartCoroutine(TimeDelay(0.5f));

	}

    // Update is called once per frame
    void Update()
    {

        if (waitDelay == false)
        {
            if (party.party_clones[0].GetComponent<Pets_stats>() != null)
            {
                if (pet[0] == null)
                    pet[0] = party.party_clones[0].GetComponent<Pets_stats>();
            }

            if (party.party_clones[1].GetComponent<Pets_stats>() != null)
            {
                if (pet[0] == null)
                    pet[0] = party.party_clones[1].GetComponent<Pets_stats>();
                else
                    pet[1] = party.party_clones[1].GetComponent<Pets_stats>();
            }

            if (party.party_clones[2].GetComponent<Pets_stats>() != null)
            {
                if (pet[1] == null)
                    pet[1] = party.party_clones[2].GetComponent<Pets_stats>();
                else
                    pet[2] = party.party_clones[2].GetComponent<Pets_stats>();
            }

            if (party.party_clones[3].GetComponent<Pets_stats>() != null)
            {
                if (pet[2] == null)
                    pet[2] = party.party_clones[3].GetComponent<Pets_stats>();
            }


            if(elist.clones[0] != null)
                mstats[0] = elist.clones[0].GetComponent<Monster_stats>();

            if(elist.clones[1] != null)
                mstats[1] = elist.clones[1].GetComponent<Monster_stats>();

            if(elist.clones[2] != null)
                mstats[2] = elist.clones[2].GetComponent<Monster_stats>();

            if(elist.clones[3] != null)
                mstats[3] = elist.clones[3].GetComponent<Monster_stats>();

            uistats = true;
            waitDelay = true;
        }

        ///////////////////////////////////////*UI*/////////////////////////////////////////////////
        /////////////////////////////////////*UPDATES*//////////////////////////////////////////////
        /////////////////////////////////////*PLAYER*///////////////////////////////////////////////

        if (party.player_party[0] != null)//If the player is alive
        {
            ui[0].text = player.playername;
            ui[1].text = player.healthMax.ToString();
            ui[2].text = player.health.ToString();
            ui[3].text = player.mana.ToString();
            ui[4].text = player.manaMax.ToString();
            
        }
        else if (party.player_party[0] == null)//If player doesn't exist
        {
            Destroy(UIobjects[0]);
        }

        if (party.player_party[1] != null && uistats == true)//If first slot is filled
        {
            ui[5].text = pet[0].petname;
            ui[6].text = pet[0].healthMax.ToString();
            ui[7].text = pet[0].health.ToString();
            ui[8].text = pet[0].mana.ToString();
            ui[9].text = pet[0].manaMax.ToString();
        }
        else if (party.player_party[1] == null)//If first slot doesn't exist
        {
            Destroy(UIobjects[1]);
        }

        if (party.player_party[2] != null && uistats == true)//If second slot is filled
        {
            ui[10].text = pet[1].petname;
            ui[11].text = pet[1].healthMax.ToString();
            ui[12].text = pet[1].health.ToString();
            ui[13].text = pet[1].mana.ToString();
            ui[14].text = pet[1].manaMax.ToString();
        }
        else if (party.player_party[2] == null)//If second slot doesn't exist
        {
            Destroy(UIobjects[2]);
        }

        if (party.player_party[3] != null && uistats == true)//If third slot is filled
        {
            ui[15].text = pet[2].petname;
            ui[16].text = pet[2].healthMax.ToString();
            ui[17].text = pet[2].health.ToString();
            ui[18].text = pet[2].mana.ToString();
            ui[19].text = pet[2].manaMax.ToString();
        }
        else if (party.player_party[3] == null)//If third slot is filled
        {
            Destroy(UIobjects[3]);
        }

        ///////////////////////////////////////*UI*/////////////////////////////////////////////////
        /////////////////////////////////////*UPDATES*//////////////////////////////////////////////
        //////////////////////////////////////*ENEMY*///////////////////////////////////////////////

        if (elist.clones[0] != null && uistats == true)//If the enemy is alive
        {
            if (elist.clones[0].tag == "boss")
            {
                UIparty[28].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(275.0f, -45.0f, 0.0f);
                UIobjects[4].GetComponent<RectTransform>().anchoredPosition3D = new Vector3(-23.4f, -401.8f, 0.0f);
            }
            ui[20].text = mstats[0].health.ToString();
            ui[21].text = mstats[0].healthMax.ToString();

        }
        else if (elist.clones[0] == null)//If enemy doesn't exist
        {
            Destroy(UIobjects[4]);
            Destroy(UIparty[28]);
        }

        if (elist.clones[3] != null && uistats == true)//If the enemy is alive
        {
            ui[22].text = mstats[3].health.ToString();
            ui[23].text = mstats[3].healthMax.ToString();

        }
        else if (elist.clones[3] == null)//If enemy doesn't exist
        {
            Destroy(UIobjects[5]);
            Destroy(UIparty[30]);
        }

        if (elist.clones[2] != null && uistats == true)//If the enemy is alive
        {
            ui[24].text = mstats[2].health.ToString();
            ui[25].text = mstats[2].healthMax.ToString();

        }
        else if (elist.clones[2] == null)//If enemy doesn't exist
        {
            Destroy(UIobjects[6]);
            Destroy(UIparty[29]);
        }

        if (elist.clones[1] != null && uistats == true)//If the enemy is alive
        {
            ui[26].text = mstats[1].health.ToString();
            ui[27].text = mstats[1].healthMax.ToString();

        }
        else if (elist.clones[1] == null)//If enemy doesn't exist
        {
            Destroy(UIobjects[7]);
            Destroy(UIparty[31]);
        }

	}

    IEnumerator TimeDelay(float timedelay)
    {
        waitDelay = true;
        yield return new WaitForSeconds(timedelay);
        waitDelay = false;
    }
}
