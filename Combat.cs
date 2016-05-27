using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Combat : MonoBehaviour {

    public GameObject gameManager;
    public GameObject help_text;
    public GameObject player;
    public Animator anim;
    public GameObject screenfade;
    public GameObject[] areas;
    public GameObject healingUI;

    SceneSwitch scene;

    public bool attack = false;
    public bool cast = false, UIcast = false;
    public bool run = false;
    public bool repeat = false;
    private bool choose = false;
    private int damage, min = 1, max = 4;

    Enemy_List elist;
    Player_party plist;
    public Monster_stats[] mstats;
    Player_Stats playerstats;
    public Pets_stats[] petstats;
    public Ability_List alist;
    ScreenFade fade;

    private Text change;
    private int monsterNumber, totalEXP;

    private bool waitDelay = true, ab1 = false, ab2 = false, ab3 = false, ab4 = false;
    public float alpha1 = 255, alpha2 = 255, alpha3 = 255;

    public Vector3 partyPos;

    public int playerState = 1;
    public int enemyState = 0;

	// Use this for initialization
	void Start () {

        gameManager = GameObject.FindGameObjectWithTag("GameManager");

        plist = gameManager.GetComponent<Player_party>();
        elist = GetComponent<Enemy_List>();
        change = help_text.GetComponent<Text>();
        alist = gameManager.GetComponent<Ability_List>();

        scene = gameManager.GetComponent<SceneSwitch>();
        fade = screenfade.GetComponent<ScreenFade>();

        playerstats = gameManager.GetComponent<Player_Stats>();

        if (plist.party_clones[0].GetComponent<Pets_stats>() != null)
        {
            if(petstats[0] == null)
                petstats[0] = plist.party_clones[0].GetComponent<Pets_stats>();
        }

        if (plist.party_clones[1].GetComponent<Pets_stats>() != null)
        {
            if (petstats[0] == null)
                petstats[0] = plist.party_clones[1].GetComponent<Pets_stats>();
            else
                petstats[1] = plist.party_clones[1].GetComponent<Pets_stats>();
        }

        if (plist.party_clones[2].GetComponent<Pets_stats>() != null)
        {
            if (petstats[1] == null)
                petstats[1] = plist.party_clones[2].GetComponent<Pets_stats>();
            else
                petstats[2] = plist.party_clones[2].GetComponent<Pets_stats>();
        }

        if (plist.party_clones[3].GetComponent<Pets_stats>() != null)
        {
            if (petstats[2] == null)
                petstats[2] = plist.party_clones[3].GetComponent<Pets_stats>();
        }

        fade.FadeToClear();

        if (scene.areaNum == 1)
            Instantiate(areas[0]);
        else if(scene.areaNum == 11)
            Instantiate(areas[3]);
        else if (scene.areaNum == 6)
            Instantiate(areas[2]);

        healingUI.SetActive(false);

        StartCoroutine(TimeDelay(0.5f));

	}
	
	// Update is called once per frame

    ///////////////////////////////////////////////*PLAYER COMBAT*///////////////////////////////////////////////////////////
    /// <summary>
    /// PLAYER COMBAT
    /// </summary>
	void Update () {


        if ((attack == true && playerState == 1) | (plist.player_party[0] == null && playerState == 1) | (cast == true && playerState == 1))//First Player Turn... 
        {
            if (playerstats != null)
            {
                change.text = playerstats.playername + " turn";

                if (choose == true)
                {

                    if (mstats[0] == null && mstats[1] == null && mstats[2] == null && mstats[3] == null)
                    {
                        /*INITAILIZATION*/
                        if(elist.clones[0] != null)
                            mstats[0] = elist.clones[0].GetComponent<Monster_stats>();

                        if(elist.clones[1] != null)
                            mstats[1] = elist.clones[1].GetComponent<Monster_stats>();

                        if(elist.clones[2] != null)
                            mstats[2] = elist.clones[2].GetComponent<Monster_stats>();

                        if(elist.clones[3] != null)
                            mstats[3] = elist.clones[3].GetComponent<Monster_stats>();


                        TotalEXP();
                    }


                    if (attack == true)
                    {
                        /* ALL ATTACK COMBAT NUMBERS HERE */
                        mstats[monsterNumber].health -= playerstats.attackdam;
                        change.text = playerstats.playername + " attacks " + mstats[monsterNumber].monstername;
                        repeat = false;
                    }
                    else if (cast == true)
                    {
                        /* ALL COMBAT CAST NUMBERS HERE */
                            if (playerstats.ability1 != null && ab1 == true)
                            {
                                damage = alist.getAbility(playerstats.ability1, playerstats.level);

                                if (0 <= playerstats.mana - alist.mana)
                                {
                                    if (alist.all == true)
                                    {
                                        playerstats.mana -= alist.mana;
                                        change.text = playerstats.playername + " casts " + playerstats.ability1;
                                        Instantiate(alist.abilityParticle);

                                        if (alist.heal == true)
                                        {
                                            playerstats.health += damage;
                                            petstats[0].health += damage;
                                            petstats[1].health += damage;
                                            petstats[2].health += damage;
                                        }
                                        else
                                        {
                                            if (elist.clones[0] != null)
                                                mstats[0].health -= damage;
                                            if (elist.clones[1] != null)
                                                mstats[1].health -= damage;
                                            if (elist.clones[2] != null)
                                                mstats[2].health -= damage;
                                            if (elist.clones[3] != null)
                                                mstats[3].health -= damage;
                                        }
                                    }
                                    else
                                    {
                                        if (alist.heal == true)
                                        {
                                            Instantiate(alist.abilityParticle, partyPos, Quaternion.identity);
                                        }
                                        else
                                        {
                                            mstats[monsterNumber].health -= damage;
                                            Instantiate(alist.abilityParticle, elist.clones[monsterNumber].transform.position, Quaternion.identity);
                                        }

                                        playerstats.mana -= alist.mana;
                                        change.text = playerstats.playername + " casts " + playerstats.ability1;
                                        
                                    }
                                    repeat = false;
                                }
                                else
                                {
                                    change.text = playerstats.playername +  " doesn't have enough Mana";
                                    repeat = true;
                                }

                                ab1 = false;

                            }
                            else if (playerstats.ability2 != null && ab2 == true)
                            {
                                damage = alist.getAbility(playerstats.ability2, playerstats.level);

                                if (0 <= playerstats.mana - alist.mana)
                                {
                                    if (alist.all == true)
                                    {
                                        playerstats.mana -= alist.mana;
                                        change.text = playerstats.playername + " casts " + playerstats.ability2;
                                        Instantiate(alist.abilityParticle);
                                        if (alist.heal == true)
                                        {
                                            playerstats.health += damage;
                                            petstats[0].health += damage;
                                            petstats[1].health += damage;
                                            petstats[2].health += damage;
                                        }
                                        else
                                        {
                                            if (elist.clones[0] != null)
                                                mstats[0].health -= damage;
                                            if (elist.clones[1] != null)
                                                mstats[1].health -= damage;
                                            if (elist.clones[2] != null)
                                                mstats[2].health -= damage;
                                            if (elist.clones[3] != null)
                                                mstats[3].health -= damage;
                                        }
                                    }
                                    else
                                    {
                                        if (alist.heal == true)
                                        {
                                            Instantiate(alist.abilityParticle, partyPos, Quaternion.identity);
                                        }
                                        else
                                        {
                                            mstats[monsterNumber].health -= damage;
                                            Instantiate(alist.abilityParticle, elist.clones[monsterNumber].transform.position, Quaternion.identity);
                                        }

                                        playerstats.mana -= alist.mana;
                                        change.text = playerstats.playername + " casts " + playerstats.ability2;
                                        
                                    }
                                    repeat = false;
                                }
                                else
                                {
                                    change.text = playerstats.playername + " doesn't have enough Mana";
                                    repeat = true;
                                }

                                ab2 = false;

                            }
                            else if (playerstats.ability3 != null && ab3 == true)
                            {
                                damage = alist.getAbility(playerstats.ability3, playerstats.level);

                                if (0 <= playerstats.mana - alist.mana)
                                {
                                    if (alist.all == true)
                                    {
                                        playerstats.mana -= alist.mana;
                                        change.text = playerstats.playername + " casts " + playerstats.ability3;
                                        Instantiate(alist.abilityParticle);

                                        if (alist.heal == true)
                                        {
                                            playerstats.health += damage;
                                            petstats[0].health += damage;
                                            petstats[1].health += damage;
                                            petstats[2].health += damage;
                                        }
                                        else
                                        {
                                            if (elist.clones[0] != null)
                                                mstats[0].health -= damage;
                                            if (elist.clones[1] != null)
                                                mstats[1].health -= damage;
                                            if (elist.clones[2] != null)
                                                mstats[2].health -= damage;
                                            if (elist.clones[3] != null)
                                                mstats[3].health -= damage;
                                        }
                                    }
                                    else
                                    {
                                        if (alist.heal == true)
                                        {
                                            Instantiate(alist.abilityParticle, partyPos, Quaternion.identity);
                                        }
                                        else
                                        {
                                            mstats[monsterNumber].health -= damage;
                                            Instantiate(alist.abilityParticle, elist.clones[monsterNumber].transform.position, Quaternion.identity);
                                        }

                                        playerstats.mana -= alist.mana;
                                        change.text = playerstats.playername + " casts " + playerstats.ability3;
                                    }
                                    repeat = false;
                                }
                                else
                                {
                                    change.text = playerstats.playername + " doesn't have enough Mana";
                                    repeat = true;
                                }

                                ab3 = false;

                            }
                            else if (playerstats.ability4 != null && ab4 == true)
                            {
                                damage = alist.getAbility(playerstats.ability4, playerstats.level);

                                if (0 <= (playerstats.mana - alist.mana))
                                {
                                    if (alist.all == true)
                                    {
                                        playerstats.mana -= alist.mana;
                                        change.text = playerstats.playername + " casts " + playerstats.ability4;
                                        Instantiate(alist.abilityParticle);
                                        if (alist.heal == true)
                                        {
                                            playerstats.health += damage;
                                            petstats[0].health += damage;
                                            petstats[1].health += damage;
                                            petstats[2].health += damage;
                                        }
                                        else
                                        {
                                            if (elist.clones[0] != null)
                                                mstats[0].health -= damage;
                                            if (elist.clones[1] != null)
                                                mstats[1].health -= damage;
                                            if (elist.clones[2] != null)
                                                mstats[2].health -= damage;
                                            if (elist.clones[3] != null)
                                                mstats[3].health -= damage;
                                        }
                                    }
                                    else
                                    {
                                        if (alist.heal == true)
                                        {
                                            Instantiate(alist.abilityParticle, partyPos, Quaternion.identity);
                                        }
                                        else
                                        {
                                            mstats[monsterNumber].health -= damage;
                                            Instantiate(alist.abilityParticle, elist.clones[monsterNumber].transform.position, Quaternion.identity);
                                        }

                                        playerstats.mana -= alist.mana;
                                        change.text = playerstats.playername + " casts " + playerstats.ability4;
                                    }
                                    repeat = false;
                                }
                                else
                                {
                                    change.text = playerstats.playername + " doesn't have enough Mana";
                                    repeat = true;
                                }

                                ab4 = false;

                            }

                        }

                    if (elist.clones[0] != null)
                    {
                        if (mstats[0].health <= 0 && mstats[0] != null)
                            DestoryMonster(0);
                    }

                    if (elist.clones[1] != null)
                    {
                        if (mstats[1].health <= 0 && mstats[1] != null)
                            DestoryMonster(1);
                    }

                    if (elist.clones[2] != null)
                    {
                        if (mstats[2].health <= 0 && mstats[2] != null)
                            DestoryMonster(2);
                    }

                    if (elist.clones[3] != null)
                    {
                        if (mstats[3].health <= 0 && mstats[3] != null)
                            DestoryMonster(3);
                    }
                        
                    if(repeat == false)
                        playerState = 2;

                    attack = false;
                    choose = false;
                    cast = false;
                    UIcast = false;
                    repeat = true;
                }
                else
                    change.text = "You need a Target";

            }
            else
            {
                playerState = 2;
                attack = false;
                cast = false;
                UIcast = false;
            }
        }

        else if ((attack == true && playerState == 2) | (plist.player_party[1] == null && playerState == 2) | (cast == true && playerState == 2))//Second Player Turn...
        {
            if (plist.player_party[1] != null && petstats[0].health > 0)
            {
                change.text = petstats[0].petname + " turn";

                if (choose == true)
                {

                    if (attack == true)
                    {
                        /* ALL COMBAT NUMBERS HERE */
                        mstats[monsterNumber].health -= petstats[0].attackdam;
                        change.text = petstats[0].petname + " attacks " + mstats[monsterNumber].monstername;
                        repeat = false;
                    }
                    else if (cast == true)
                    {
                        /* ALL COMBAT CAST NUMBERS HERE */
                            if (petstats[0].ability1 != null && ab1 == true)
                            {
                                damage = alist.getAbility(petstats[0].ability1, petstats[0].level);

                                if (0 <= petstats[0].mana - alist.mana)
                                {
                                    if (alist.all == true)
                                    {
                                        petstats[0].mana -= alist.mana;
                                        change.text = petstats[0].petname + " casts " + petstats[0].ability1;
                                        Instantiate(alist.abilityParticle);

                                        if (elist.clones[0] != null)
                                            mstats[0].health -= damage;
                                        if (elist.clones[1] != null)
                                            mstats[1].health -= damage;
                                        if (elist.clones[2] != null)
                                            mstats[2].health -= damage;
                                        if (elist.clones[3] != null)
                                            mstats[3].health -= damage;
                                    }
                                    else
                                    {
                                        mstats[monsterNumber].health -= damage;
                                        petstats[0].mana -= alist.mana;
                                        change.text = petstats[0].petname + " casts " + petstats[0].ability1;
                                        Instantiate(alist.abilityParticle, elist.clones[monsterNumber].transform.position, Quaternion.identity);
                                    }
                                    repeat = false;
                                }
                                else
                                {
                                    change.text = petstats[0].petname +  " doesn't have enough Mana";
                                    repeat = true;
                                }

                                ab1 = false;

                            }
                            else if (petstats[0].ability2 != null && ab2 == true)
                            {
                                damage = alist.getAbility(petstats[0].ability2, petstats[0].level);

                                if (0 <= petstats[0].mana - alist.mana)
                                {
                                    if (alist.all == true)
                                    {
                                        petstats[0].mana -= alist.mana;
                                        change.text = petstats[0].petname + " casts " + petstats[0].ability2;
                                        Instantiate(alist.abilityParticle);

                                        if (elist.clones[0] != null)
                                            mstats[0].health -= damage;
                                        if (elist.clones[1] != null)
                                            mstats[1].health -= damage;
                                        if (elist.clones[2] != null)
                                            mstats[2].health -= damage;
                                        if (elist.clones[3] != null)
                                            mstats[3].health -= damage;
                                    }
                                    else
                                    {
                                        mstats[monsterNumber].health -= damage;
                                        petstats[0].mana -= alist.mana;
                                        change.text = petstats[0].petname + " casts " + petstats[0].ability2;
                                        Instantiate(alist.abilityParticle, elist.clones[monsterNumber].transform.position, Quaternion.identity);
                                    }
                                    repeat = false;
                                }
                                else
                                {
                                    change.text = petstats[0].petname + " doesn't have enough Mana";
                                    repeat = true;
                                }

                                ab2 = false;

                            }
                            else if (petstats[0].ability3 != null && ab3 == true)
                            {
                                damage = alist.getAbility(petstats[0].ability3, petstats[0].level);

                                if (0 <= petstats[0].mana - alist.mana)
                                {
                                    if (alist.all == true)
                                    {
                                        petstats[0].mana -= alist.mana;
                                        change.text = petstats[0].petname + " casts " + petstats[0].ability3;
                                        Instantiate(alist.abilityParticle);

                                        if (elist.clones[0] != null)
                                            mstats[0].health -= damage;
                                        if (elist.clones[1] != null)
                                            mstats[1].health -= damage;
                                        if (elist.clones[2] != null)
                                            mstats[2].health -= damage;
                                        if (elist.clones[3] != null)
                                            mstats[3].health -= damage;
                                    }
                                    else
                                    {
                                        mstats[monsterNumber].health -= damage;
                                        petstats[0].mana -= alist.mana;
                                        change.text = petstats[0].petname + " casts " + petstats[0].ability3;
                                        Instantiate(alist.abilityParticle, elist.clones[monsterNumber].transform.position, Quaternion.identity);
                                    }
                                    repeat = false;
                                }
                                else
                                {
                                    change.text = petstats[0].petname + " doesn't have enough Mana";
                                    repeat = true;
                                }

                                ab3 = false;

                            }
                            else if (petstats[0].ability4 != null && ab4 == true)
                            {
                                damage = alist.getAbility(petstats[0].ability4, petstats[0].level);

                                if (0 <= (petstats[0].mana - alist.mana))
                                {
                                    if (alist.all == true)
                                    {
                                        petstats[0].mana -= alist.mana;
                                        change.text = petstats[0].petname + " casts " + petstats[0].ability4;
                                        Instantiate(alist.abilityParticle);

                                        if (elist.clones[0] != null)
                                            mstats[0].health -= damage;
                                        if (elist.clones[1] != null)
                                            mstats[1].health -= damage;
                                        if (elist.clones[2] != null)
                                            mstats[2].health -= damage;
                                        if (elist.clones[3] != null)
                                            mstats[3].health -= damage;
                                    }
                                    else
                                    {
                                        mstats[monsterNumber].health -= damage;
                                        petstats[0].mana -= alist.mana;
                                        change.text = petstats[0].petname + " casts " + petstats[0].ability4;
                                        Instantiate(alist.abilityParticle, elist.clones[monsterNumber].transform.position, Quaternion.identity);
                                    }
                                    repeat = false;
                                }
                                else
                                {
                                    change.text = petstats[0].petname + " doesn't have enough Mana";
                                    repeat = true;
                                }

                                ab4 = false;

                            }
                        }

                    if (elist.clones[0] != null)
                    {
                        if (mstats[0].health <= 0 && mstats[0] != null)
                            DestoryMonster(0);
                    }

                    if (elist.clones[1] != null)
                    {
                        if (mstats[1].health <= 0 && mstats[1] != null)
                            DestoryMonster(1);
                    }

                    if (elist.clones[2] != null)
                    {
                        if (mstats[2].health <= 0 && mstats[2] != null)
                            DestoryMonster(2);
                    }

                    if (elist.clones[3] != null)
                    {
                        if (mstats[3].health <= 0 && mstats[3] != null)
                            DestoryMonster(3);
                    }

                    if (repeat == false)
                        playerState = 3;

                    attack = false;
                    choose = false;
                    cast = false;
                    UIcast = false;
                    repeat = true;
                }
                else
                    change.text = "You need a Target";
            }
            else
            {
                playerState = 3;
                attack = false;
                cast = false;
                UIcast = false;
            }
        }

        else if ((attack == true && playerState == 3) | (plist.player_party[2] == null && playerState == 3) | (cast == true && playerState == 3))//Third Player Turn... 
        {
            if (plist.player_party[2] != null && petstats[1].health > 0)
            {
                change.text = petstats[1].petname + " turn";

                if (choose == true)
                {
                    if (attack == true)
                    {
                        /* ALL COMBAT NUMBERS HERE */
                        mstats[monsterNumber].health -= petstats[1].attackdam;
                        change.text = petstats[1].petname + " attacks " + mstats[monsterNumber].monstername;
                        repeat = false;
                    }
                    else if (cast == true)
                    {
                        /* ALL COMBAT CAST NUMBERS HERE */
                            if (petstats[1].ability1 != null && ab1 == true)
                            {
                                damage = alist.getAbility(petstats[1].ability1, petstats[1].level);

                                if (0 <= petstats[1].mana - alist.mana)
                                {
                                    if (alist.all == true)
                                    {
                                        petstats[1].mana -= alist.mana;
                                        change.text = petstats[1].petname + " casts " + petstats[1].ability1;
                                        Instantiate(alist.abilityParticle);

                                        if (elist.clones[0] != null)
                                            mstats[0].health -= damage;
                                        if (elist.clones[1] != null)
                                            mstats[1].health -= damage;
                                        if (elist.clones[2] != null)
                                            mstats[2].health -= damage;
                                        if (elist.clones[3] != null)
                                            mstats[3].health -= damage;
                                    }
                                    else
                                    {
                                        mstats[monsterNumber].health -= damage;
                                        petstats[1].mana -= alist.mana;
                                        change.text = petstats[1].petname + " casts " + petstats[1].ability1;
                                        Instantiate(alist.abilityParticle, elist.clones[monsterNumber].transform.position, Quaternion.identity);
                                    }
                                        repeat = false;
                                    
                                }
                                else
                                {
                                    change.text = petstats[1].petname + " doesn't have enough Mana";
                                    repeat = true;
                                }

                                ab1 = false;

                            }
                            else if (petstats[1].ability2 != null && ab2 == true)
                            {
                                damage = alist.getAbility(petstats[1].ability2, petstats[1].level);

                                if (0 <= petstats[1].mana - alist.mana)
                                {
                                    if (alist.all == true)
                                    {
                                        petstats[1].mana -= alist.mana;
                                        change.text = petstats[1].petname + " casts " + petstats[1].ability2;
                                        Instantiate(alist.abilityParticle);

                                        if (elist.clones[0] != null)
                                            mstats[0].health -= damage;
                                        if (elist.clones[1] != null)
                                            mstats[1].health -= damage;
                                        if (elist.clones[2] != null)
                                            mstats[2].health -= damage;
                                        if (elist.clones[3] != null)
                                            mstats[3].health -= damage;
                                    }
                                    else
                                    {
                                        mstats[monsterNumber].health -= damage;
                                        petstats[1].mana -= alist.mana;
                                        change.text = petstats[1].petname + " casts " + petstats[1].ability2;
                                        Instantiate(alist.abilityParticle, elist.clones[monsterNumber].transform.position, Quaternion.identity);
                                    }
                                    repeat = false;
                                }
                                else
                                {
                                    change.text = petstats[1].petname + " doesn't have enough Mana";
                                    repeat = true;
                                }

                                ab2 = false;

                            }
                            else if (petstats[1].ability3 != null && ab3 == true)
                            {
                                damage = alist.getAbility(petstats[1].ability3, petstats[1].level);

                                if (0 <= petstats[1].mana - alist.mana)
                                {
                                    if (alist.all == true)
                                    {
                                        petstats[1].mana -= alist.mana;
                                        change.text = petstats[1].petname + " casts " + petstats[1].ability3;
                                        Instantiate(alist.abilityParticle);

                                        if (elist.clones[0] != null)
                                            mstats[0].health -= damage;
                                        if (elist.clones[1] != null)
                                            mstats[1].health -= damage;
                                        if (elist.clones[2] != null)
                                            mstats[2].health -= damage;
                                        if (elist.clones[3] != null)
                                            mstats[3].health -= damage;
                                    }
                                    else
                                    {
                                        mstats[monsterNumber].health -= damage;
                                        petstats[1].mana -= alist.mana;
                                        change.text = petstats[1].petname + " casts " + petstats[1].ability3;
                                        Instantiate(alist.abilityParticle, elist.clones[monsterNumber].transform.position, Quaternion.identity);
                                    }
                                    repeat = false;
                                }
                                else
                                {
                                    change.text = petstats[1].petname + " doesn't have enough Mana";
                                    repeat = true;
                                }

                                ab3 = false;

                            }
                            else if (petstats[1].ability4 != null && ab4 == true)
                            {
                                damage = alist.getAbility(petstats[1].ability4, petstats[1].level);

                                if (0 <= (petstats[1].mana - alist.mana))
                                {
                                    if (alist.all == true)
                                    {
                                        petstats[1].mana -= alist.mana;
                                        change.text = petstats[1].petname + " casts " + petstats[1].ability4;
                                        Instantiate(alist.abilityParticle);

                                        if (elist.clones[0] != null)
                                            mstats[0].health -= damage;
                                        if (elist.clones[1] != null)
                                            mstats[1].health -= damage;
                                        if (elist.clones[2] != null)
                                            mstats[2].health -= damage;
                                        if (elist.clones[3] != null)
                                            mstats[3].health -= damage;
                                    }
                                    else
                                    {
                                        mstats[monsterNumber].health -= damage;
                                        petstats[1].mana -= alist.mana;
                                        change.text = petstats[1].petname + " casts " + petstats[1].ability4;
                                        Instantiate(alist.abilityParticle, elist.clones[monsterNumber].transform.position, Quaternion.identity);
                                    }
                                    repeat = false;
                                }
                                else
                                {
                                    change.text = petstats[1].petname + " doesn't have enough Mana";
                                    repeat = true;
                                }

                                ab4 = false;

                            }
                        }

                    if (elist.clones[0] != null)
                    {
                        if (mstats[0].health <= 0 && mstats[0] != null)
                            DestoryMonster(0);
                    }

                    if (elist.clones[1] != null)
                    {
                        if (mstats[1].health <= 0 && mstats[1] != null)
                            DestoryMonster(1);
                    }

                    if (elist.clones[2] != null)
                    {
                        if (mstats[2].health <= 0 && mstats[2] != null)
                            DestoryMonster(2);
                    }

                    if (elist.clones[3] != null)
                    {
                        if (mstats[3].health <= 0 && mstats[3] != null)
                            DestoryMonster(3);
                    }

                    if (repeat == false)
                        playerState = 4;

                    attack = false;
                    choose = false;
                    cast = false;
                    UIcast = false;
                    repeat = true;
                }
                else
                    change.text = "You need a Target";
            }
            else
            {
                playerState = 4;
                attack = false;
                cast = false;
                UIcast = false;
            }
        }

        else if ((attack == true && playerState == 4) | (plist.player_party[3] == null && playerState == 4) | (cast == true && playerState == 4))//Forth Player Turn... 
        {
            if (plist.player_party[3] != null && petstats[2].health > 0)
            {
                change.text = petstats[2].petname + " turn";

                if (choose == true)
                {
                    if (attack == true)
                    {
                        /* ALL COMBAT NUMBERS HERE */
                        mstats[monsterNumber].health -= petstats[2].attackdam;
                        change.text = petstats[2].petname + " attacks " + mstats[monsterNumber].monstername;
                        repeat = false;
                    }
                    else if (cast == true)
                    {
                        /* ALL COMBAT CAST NUMBERS HERE */
                            if (petstats[2].ability1 != null && ab1 == true)
                            {
                                damage = alist.getAbility(petstats[2].ability1, petstats[2].level);

                                if (0 <= petstats[2].mana - alist.mana)
                                {
                                    if (alist.all == true)
                                    {
                                        petstats[2].mana -= alist.mana;
                                        change.text = petstats[2].petname + " casts " + petstats[2].ability1;
                                        Instantiate(alist.abilityParticle);

                                        if (elist.clones[0] != null)
                                            mstats[0].health -= damage;
                                        if (elist.clones[1] != null)
                                            mstats[1].health -= damage;
                                        if (elist.clones[2] != null)
                                            mstats[2].health -= damage;
                                        if (elist.clones[3] != null)
                                            mstats[3].health -= damage;
                                    }
                                    else
                                    {
                                        mstats[monsterNumber].health -= damage;
                                        petstats[2].mana -= alist.mana;
                                        change.text = petstats[2].petname + " casts " + petstats[2].ability1;
                                        Instantiate(alist.abilityParticle, elist.clones[monsterNumber].transform.position, Quaternion.identity);
                                    }
                                    repeat = false;
                                }
                                else
                                {
                                    change.text = petstats[2].petname + " doesn't have enough Mana";
                                    repeat = true;
                                }

                                ab1 = false;

                            }
                            else if (petstats[2].ability2 != null && ab2 == true)
                            {
                                damage = alist.getAbility(petstats[2].ability2, petstats[2].level);

                                if (0 <= petstats[2].mana - alist.mana)
                                {
                                    if (alist.all == true)
                                    {
                                        petstats[2].mana -= alist.mana;
                                        change.text = petstats[2].petname + " casts " + petstats[2].ability2;
                                        Instantiate(alist.abilityParticle);

                                        if (elist.clones[0] != null)
                                            mstats[0].health -= damage;
                                        if (elist.clones[1] != null)
                                            mstats[1].health -= damage;
                                        if (elist.clones[2] != null)
                                            mstats[2].health -= damage;
                                        if (elist.clones[3] != null)
                                            mstats[3].health -= damage;
                                    }
                                    else
                                    {
                                        mstats[monsterNumber].health -= damage;
                                        petstats[2].mana -= alist.mana;
                                        change.text = petstats[2].petname + " casts " + petstats[2].ability2;
                                        Instantiate(alist.abilityParticle, elist.clones[monsterNumber].transform.position, Quaternion.identity);
                                    }
                                    repeat = false;
                                }
                                else
                                {
                                    change.text = petstats[2].petname + " doesn't have enough Mana";
                                    repeat = true;
                                }

                                ab2 = false;

                            }
                            else if (petstats[2].ability3 != null && ab3 == true)
                            {
                                damage = alist.getAbility(petstats[2].ability3, petstats[2].level);

                                if (0 <= petstats[2].mana - alist.mana)
                                {
                                    if (alist.all == true)
                                    {
                                        petstats[2].mana -= alist.mana;
                                        change.text = petstats[2].petname + " casts " + petstats[2].ability3;
                                        Instantiate(alist.abilityParticle);

                                        if (elist.clones[0] != null)
                                            mstats[0].health -= damage;
                                        if (elist.clones[1] != null)
                                            mstats[1].health -= damage;
                                        if (elist.clones[2] != null)
                                            mstats[2].health -= damage;
                                        if (elist.clones[3] != null)
                                            mstats[3].health -= damage;
                                    }
                                    else
                                    {
                                        mstats[monsterNumber].health -= damage;
                                        petstats[2].mana -= alist.mana;
                                        change.text = petstats[2].petname + " casts " + petstats[2].ability3;
                                        Instantiate(alist.abilityParticle, elist.clones[monsterNumber].transform.position, Quaternion.identity);
                                    }
                                    repeat = false;
                                }
                                else
                                {
                                    change.text = petstats[2].petname + " doesn't have enough Mana";
                                    repeat = true;
                                }

                                ab3 = false;

                            }
                            else if (petstats[2].ability4 != null && ab4 == true)
                            {
                                damage = alist.getAbility(petstats[2].ability4, petstats[2].level);

                                if (0 <= (petstats[2].mana - alist.mana))
                                {
                                    if (alist.all == true)
                                    {
                                        petstats[2].mana -= alist.mana;
                                        change.text = petstats[2].petname + " casts " + petstats[2].ability4;
                                        Instantiate(alist.abilityParticle);

                                        if (elist.clones[0] != null)
                                            mstats[0].health -= damage;
                                        if (elist.clones[1] != null)
                                            mstats[1].health -= damage;
                                        if (elist.clones[2] != null)
                                            mstats[2].health -= damage;
                                        if (elist.clones[3] != null)
                                            mstats[3].health -= damage;
                                    }
                                    else
                                    {
                                        mstats[monsterNumber].health -= damage;
                                        petstats[2].mana -= alist.mana;
                                        change.text = petstats[2].petname + " casts " + petstats[2].ability4;
                                        Instantiate(alist.abilityParticle, elist.clones[monsterNumber].transform.position, Quaternion.identity);
                                    }
                                    repeat = false;
                                }
                                else
                                {
                                    change.text = petstats[2].petname + " doesn't have enough Mana";
                                    repeat = true;
                                }

                                ab4 = false;

                            }
                        }

                    if (elist.clones[0] != null)
                    {
                        if (mstats[0].health <= 0 && mstats[0] != null)
                            DestoryMonster(0);
                    }
                    
                    if (elist.clones[1] != null)
                    {
                        if (mstats[1].health <= 0 && mstats[1] != null)
                            DestoryMonster(1);
                    }
                    
                    if (elist.clones[2] != null)
                    {
                        if (mstats[2].health <= 0 && mstats[2] != null)
                            DestoryMonster(2);
                    }
                    
                    if (elist.clones[3] != null)
                    {
                        if (mstats[3].health <= 0 && mstats[3] != null)
                            DestoryMonster(3);
                    }

                    if (repeat == false)
                    {
                        playerState = 0;
                        enemyState = 1;

                    }

                    attack = false;
                    choose = false;
                    cast = false;
                    UIcast = false;
                    repeat = true;
                }
                else
                    change.text = "You need a Target";
            }
            else
            {
                playerState = 0;
                enemyState = 1;
                attack = false;
                cast = false;
                UIcast = false;
            }
        }

        ///////////////////////////////////////////////*ENEMY COMBAT*///////////////////////////////////////////////////////////
        /// <summary>
        /// ENEMY COMBAT
        /// </summary>

        if (enemyState == 1 && waitDelay == false)//First Enemy Turn...
        {
            
            if (elist.clones[0] != null)
            {
                Debug.Log("enemey's turn 1");

                /* ALL COMBAT NUMBERS HERE */

                    RandomPlayerAbility(0);
                

                StartCoroutine(TimeDelay(5));
            }
                
            enemyState = 2;
            
        }

        else if (enemyState == 2 && waitDelay == false)//Second Enemy Turn...
        {
            
            if (elist.clones[1] != null)
            {
                Debug.Log("enemy's turn 2");

                /* ALL COMBAT NUMBERS HERE */

                    RandomPlayerAbility(1);
                

                StartCoroutine(TimeDelay(5));
            }

            enemyState = 3;
            
        }

        else if (enemyState == 3 && waitDelay == false)//Third Enemy Turn...
        {
            
            if (elist.clones[2] != null)
            {
                Debug.Log("enemy's turn 3");

                /* ALL COMBAT NUMBERS HERE */

                    RandomPlayerAbility(2);
                

                StartCoroutine(TimeDelay(5));
            }

            enemyState = 4;
            
        }

        else if (enemyState == 4 && waitDelay == false)//Forth Enemy Turn...
        {
            
            if (elist.clones[3] != null)
            {
                Debug.Log("enemy's turn 4");

                /* ALL COMBAT NUMBERS HERE */

                    RandomPlayerAbility(3);             

                StartCoroutine(TimeDelay(5));
            }

            playerState = 1;
            enemyState = 0;
            
        }

        ///////////////////////////////////////////////*END COMBAT*///////////////////////////////////////////////////////////
        /// <summary>
        /// END COMBAT
        /// </summary>

        if (elist.clones[1] == null && elist.clones[2] == null && elist.clones[3] == null && elist.clones[0] == null)
        {
            playerstats.exp += totalEXP;
            petstats[0].exp += totalEXP;
            petstats[1].exp += totalEXP;
            petstats[2].exp += totalEXP;

            playerstats.levelCheck = true;
            petstats[0].levelCheck = true;
            petstats[1].levelCheck = true;
            petstats[2].levelCheck = true;

            scene.SceneLoad("World");
                
        }
        else if (run == true)
        {
            if (scene.areaNum == 11)
            {
                change.text = "You can't ran from this Battle";
                run = false;
            }
            else
            {
                change.text = "You ran from Battle";
                StartCoroutine(TimeDelay(2.0f));
                scene.SceneLoad("World");
            }
        }

        if (playerstats.health <= 0)
        {
            change.text = "Your Hero has been slain";
            StartCoroutine(TimeDelay(3.0f));
            scene.SceneLoad("World");

        }

	}

    public void isAttack()
    {
        attack = true;
        cast = false;
    }

    public void isCast()
    {
        UIcast = true;
    }

    public void isAbility1()
    {
        if (playerState == 1)
        {
            damage = alist.getAbility(playerstats.ability1, playerstats.level);
            if (alist.heal == true)
                healingUI.SetActive(true);
        }

        ab1 = true;
        cast = true;
    }

    public void isAbility2()
    {
        if (playerState == 1)
        {
            damage = alist.getAbility(playerstats.ability2, playerstats.level);
            if (alist.heal == true)
                healingUI.SetActive(true);
        }

        ab2 = true;
        cast = true;
    }

    public void isAbility3()
    {
        if (playerState == 1)
        {
            damage = alist.getAbility(playerstats.ability3, playerstats.level);
            if (alist.heal == true)
                healingUI.SetActive(true);
        }

        ab3 = true;
        cast = true;
    }

    public void isAbility4()
    {
        if (playerState == 1)
        {
            damage = alist.getAbility(playerstats.ability4, playerstats.level);
            if (alist.heal == true)
                healingUI.SetActive(true);
        }

        ab4 = true;
        cast = true;
    }

    public void isRun()
    {
        run = true;
        cast = false;
    }

    public void top()
    {
        Debug.Log("Top");
        monsterNumber = 0;
        change.text = " ";
        choose = true;
    }

    public void down()
    {
        Debug.Log("Down");
        monsterNumber = 1;
        change.text = " ";
        choose = true;
    }

    public void left()
    {
        Debug.Log("Left");
        monsterNumber = 2;
        change.text = " ";
        choose = true;
    }

    public void right()
    {
        Debug.Log("Right");
        monsterNumber = 3;
        change.text = " ";
        choose = true;
    }

    public void Partytop()
    {
        Debug.Log("PartyTop");
        if (alist.heal == true)
        {
            partyPos = plist.party_clones[0].GetComponent<Transform>().position;
            if (plist.party_clones[0].GetComponent<Player_Combat>() != null)
                playerstats.health += damage;
            else
                plist.party_clones[0].GetComponent<Pets_stats>().health += damage;
            change.text = " ";
            choose = true;
            healingUI.SetActive(false);
        }
        else
            choose = false;
    }

    public void Partydown()
    {
        Debug.Log("PartyDown");
        if (alist.heal == true)
        {
            partyPos = plist.party_clones[1].GetComponent<Transform>().position;
            if (plist.party_clones[1].GetComponent<Player_Combat>() != null)
                playerstats.health += damage;
            else
                plist.party_clones[1].GetComponent<Pets_stats>().health += damage;
            change.text = " ";
            choose = true;
            healingUI.SetActive(false);
        }
        else
            choose = false;
    }

    public void Partyleft()
    {
        Debug.Log("PartyLeft");
        if (alist.heal == true)
        {
            partyPos = plist.party_clones[3].GetComponent<Transform>().position;
            if (plist.party_clones[3].GetComponent<Player_Combat>() != null)
                playerstats.health += damage;
            else
                plist.party_clones[3].GetComponent<Pets_stats>().health += damage;
            change.text = " ";
            choose = true;
            healingUI.SetActive(false);
        }
        else
            choose = false;
    }

    public void Partyright()
    {
        Debug.Log("PartyRight");
        if (alist.heal == true)
        {
            partyPos = plist.party_clones[2].GetComponent<Transform>().position;
            if (plist.party_clones[2].GetComponent<Player_Combat>() != null)
                playerstats.health += damage;
            else
                plist.party_clones[2].GetComponent<Pets_stats>().health += damage;
            change.text = " ";
            choose = true;
            healingUI.SetActive(false);
        }
        else
            choose = false;
    }

    void DestoryMonster(int i)
    {
        Destroy(elist.clones[i]);
        monsterNumber = 4;

    }

    IEnumerator TimeDelay(float timedelay)
    {
        waitDelay = true;
        yield return new WaitForSeconds(timedelay);
        waitDelay = false;    
    }

    void TotalEXP()
    {
        if (elist.clones[0] != null && elist.clones[1] == null && elist.clones[2] == null && elist.clones[3] == null)
            totalEXP = mstats[0].total_exp;
        else if (elist.clones[0] != null && elist.clones[1] != null && elist.clones[2] == null && elist.clones[3] == null)
            totalEXP = mstats[0].total_exp + mstats[1].total_exp;
        else if (elist.clones[0] != null && elist.clones[1] != null && elist.clones[2] != null && elist.clones[3] == null)
            totalEXP = mstats[0].total_exp + mstats[1].total_exp + mstats[2].total_exp;
        else if (elist.clones[0] != null && elist.clones[1] != null && elist.clones[2] != null && elist.clones[3] != null)
            totalEXP = mstats[0].total_exp + mstats[1].total_exp + mstats[2].total_exp + mstats[3].total_exp;
    }

    void RandomPlayerAttack(int damage, int effect, int i)
    {
        int randNum = 0;
        int OrderNum = 0;
        alist.all = false;

        randNum = Random.Range(min, max);

        if (randNum == 1)
        {
            if (playerstats.health <= 0)
            {
                min++;
                randNum = 2;
            }

            if (effect == 1 && randNum == 1)
            {
                if (alist.all == true)
                {
                    Instantiate(alist.abilityParticle);
                }
                else
                    Instantiate(alist.abilityParticle, FindObjectOfType<Player_Combat>().GetComponent<Transform>().position, Quaternion.identity);
            }
            else if(randNum == 1)
                change.text = mstats[i].monstername + " attacks " + playerstats.playername;

            if (playerstats.health > 0 && alist.all != true)
                playerstats.health -= damage;
        }

        if (randNum == 2)
        {
            if (petstats[0].health <= 0)
                randNum = 3;


            if (effect == 1 && randNum == 2)
            {
                if (alist.all == true)
                {
                    Instantiate(alist.abilityParticle);
                }
                else
                    Instantiate(alist.abilityParticle, petstats[0].GetComponent<Transform>().position, Quaternion.identity);
            }
            else if(randNum == 2)
                change.text = mstats[i].monstername + " attacks " + petstats[0].petname;

            if (petstats[0].health > 0 && alist.all != true)
                petstats[0].health -= damage;   
        }

        if (randNum == 3)
        {
            if (petstats[1].health <= 0)  
                randNum = 4;



            if (effect == 1 && randNum == 3)
            {
                if (alist.all == true)
                {
                    Instantiate(alist.abilityParticle);
                }
                else
                    Instantiate(alist.abilityParticle, petstats[1].GetComponent<Transform>().position, Quaternion.identity);
            }
            else if(randNum == 3)
                change.text = mstats[i].monstername + " attacks " + petstats[1].petname;

            if (petstats[1].health > 0 && alist.all != true)
                petstats[1].health -= damage;
        }

        if(randNum == 4)
        {
            if (petstats[2].health <= 0)
            {
                max--;
                OrderNum = 1;
            }

            if (effect == 1 && randNum == 4)
            {
                if (alist.all == true)
                {
                    Instantiate(alist.abilityParticle);
                }
                else
                    Instantiate(alist.abilityParticle, petstats[2].GetComponent<Transform>().position, Quaternion.identity);
            }
            else if(randNum == 4)
                change.text = mstats[i].monstername + " attacks " + petstats[2].petname;

            if (petstats[2].health > 0 && alist.all != true)
                petstats[2].health -= damage;
        }

        if (OrderNum == 1)
        {
            if (playerstats.health <= 0)
            {
                OrderNum = 2;
            }

            if (effect == 1 && randNum == 1)
            {
                if (alist.all == true)
                {
                    Instantiate(alist.abilityParticle);
                }
                else
                    Instantiate(alist.abilityParticle, playerstats.GetComponent<Transform>().position, Quaternion.identity);
            }
            else if (randNum == 1)
                change.text = mstats[i].monstername + " attacks " + playerstats.playername;

            if (playerstats.health > 0 && alist.all != true)
                playerstats.health -= damage;
        }

        if (OrderNum == 2)
        {
            if (petstats[0].health <= 0)
            {
                OrderNum = 3;
            }

            if (effect == 1 && randNum == 2)
            {
                if (alist.all == true)
                {
                    Instantiate(alist.abilityParticle);
                }
                else
                    Instantiate(alist.abilityParticle, petstats[0].GetComponent<Transform>().position, Quaternion.identity);
            }
            else if (randNum == 2)
                change.text = mstats[i].monstername + " attacks " + petstats[0].petname;

            if (petstats[0].health > 0 && alist.all != true)
                petstats[0].health -= damage;
        }

        if (OrderNum == 3)
        {
            if (effect == 1 && randNum == 3)
            {
                if (alist.all == true)
                {
                    Instantiate(alist.abilityParticle);
                }
                else
                    Instantiate(alist.abilityParticle, petstats[1].GetComponent<Transform>().position, Quaternion.identity);
            }
            else
                change.text = mstats[i].monstername + " attacks " + petstats[1].petname;

            if (petstats[1].health > 0 && alist.all != true)
                petstats[1].health -= damage;
        }

        if (alist.all == true)
        {
            playerstats.health -= damage;
            petstats[0].health -= damage;
            petstats[1].health -= damage;
            petstats[2].health -= damage;
        }

    }

    void RandomPlayerAbility(int i)
    {
        int randAbil = 0;
        int totalAbil = 5;
        int abilDam = 0;
        bool ManaEmpty = false;

        if (mstats[i].ability1 != "")
        {
            totalAbil++;
        }

        if (mstats[i].ability2 != "")
        {
            totalAbil++;
        }

        if (mstats[i].ability3 != "")
        {
            totalAbil++;
        }

        if (mstats[i].ability4 != "")
        {
            totalAbil++;
        }

        randAbil = Random.Range(1, totalAbil);


        if (randAbil == 6)
        {
            abilDam = alist.getAbility(mstats[i].ability1, mstats[i].level);

            if (0 >= mstats[i].mana - alist.mana)
            {
                change.text = mstats[i].monstername + " casts " + mstats[i].ability1;
                RandomPlayerAttack(abilDam, 1, i);
            }
            else
                ManaEmpty = true;

        }

        if (randAbil == 7)
        {
            abilDam = alist.getAbility(mstats[i].ability2, mstats[i].level);

            if (0 >= mstats[i].mana - alist.mana)
            {
                change.text = mstats[i].monstername + " casts " + mstats[i].ability2;
                RandomPlayerAttack(abilDam, 1, i);
            }
            else
                ManaEmpty = true;
        }

        if (randAbil == 8)
        {
            abilDam = alist.getAbility(mstats[i].ability3, mstats[i].level);

            if (0 >= mstats[i].mana - alist.mana)
            {
                change.text = mstats[i].monstername + " casts " + mstats[i].ability3;
                RandomPlayerAttack(abilDam, 1, i);
            }
            else
                ManaEmpty = true;
        }

        if (randAbil == 9)
        {
            abilDam = alist.getAbility(mstats[i].ability4, mstats[i].level);

            if (0 >= mstats[i].mana - alist.mana)
            {
                change.text = mstats[i].monstername + " casts " + mstats[i].ability4;
                RandomPlayerAttack(abilDam, 1, i);
            }
            else
                ManaEmpty = true;
        }

        if(randAbil < 6)
            RandomPlayerAttack(mstats[i].attackdam, 0, i);

        if(ManaEmpty == true)
            RandomPlayerAttack(mstats[i].attackdam, 0, i);

    }

}
