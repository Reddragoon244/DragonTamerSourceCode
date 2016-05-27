using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Taming : MonoBehaviour {

    public GameObject gameManager;
    public TamingPetList petList;
    public GameObject help_text;
    public GameObject screenfade;
    public GameObject[] areas;
    public GameObject petnameChange;
    public GameObject buttons;
    public GameObject interactMenu;
    public Text textTame;

    SceneSwitch scene;
    ScreenFade fade;
    Player_party plist;

    private Text change;

    private bool waitDelay = true;

    public int i;
    public int tamingPercentage = 30;
    public int playerState = 1;

    public int petFightBack;
    public int playerAction = 0;

    public bool tameSuccess = false;

    public bool run;

	// Use this for initialization
	void Start () {

        petList = FindObjectOfType<TamingPetList>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager");

        change = help_text.GetComponent<Text>();

        scene = gameManager.GetComponent<SceneSwitch>();
        fade = screenfade.GetComponent<ScreenFade>();
        plist = gameManager.GetComponent<Player_party>();

        petnameChange.SetActive(false);
        buttons.SetActive(true);

        fade.FadeToClear();

        if (scene.areaNum == 1)
            Instantiate(areas[0]);
        else if (scene.areaNum == 6)
            Instantiate(areas[2]);

        StartCoroutine(TimeDelay(0.5f));
	
	}
	
	// Update is called once per frame
	void Update () {

        if (playerState == 1)//players turn
        {

            
        }
        else if (playerState == 0)//pets turn
        {
            petFightBack = RandomNumber(1, 10);

            if (petFightBack == 1)
            {
                change.text = "The monster accepts your action";
            }
            else if (petFightBack == 2)
            {
                change.text = "The monster lets out a shriek";
                tamingPercentage -= 20;
            }
            else if (petFightBack == 3 && playerAction == 1)
            {
                change.text = "The monster enjoys the food";
            }
            else if (petFightBack == 4 && playerAction == 2)
            {
                change.text = "The monster smacks its tail on the ground";
            }
            else if (petFightBack == 5)
            {
                change.text = "The monster breathes heavily...";
                tamingPercentage -= 20;
            }
            else if (petFightBack == 6 && playerAction == 3)
            {
                change.text = "The monster accepts your respect";
            }
            else if (petFightBack == 7 && playerAction == 3)
            {
                change.text = "The monster is insulted by your respectful action";
                tamingPercentage -= 40;
            }
            else if (petFightBack == 8)
            {
                change.text = "The monster just stares at you";
                tamingPercentage -= 20;
            }
            else if (petFightBack == 9)
            {
                change.text = "The monster lays its head down";
            }
            else if (petFightBack == 10 && tamingPercentage <= 20)
            {
                change.text = "The monster charges at you";
                StartCoroutine(TimeDelay(1.0f));
                textTame.text = "";
                Destroy(petList.clones);
                run = true;
            }
            else
            {
                change.text = "Your action didn't get the attention of the monster";
                tamingPercentage -= 30;
            }
            playerState = 1;
        }

        textTame.text = "Taming " + tamingPercentage + "%";

        if (tameSuccess == true)
        {
            for (i = 0; i < 8; i++)
            {
                if (plist.party_clones[i] == null)
                {
                    petList.clones.GetComponent<SpriteRenderer>().flipX = false;
                    plist.party_clones[i] = petList.clones;
                    break;
                }
            }

            scene.SceneLoad("World");

        }
        else if (run == true)
        {
            change.text = "You ran from the Monster";
            StartCoroutine(TimeDelay(2.0f));
            scene.SceneLoad("World");
        }
	}

    public void Tame()
    {
        if (tamingPercentage >= 90)
        {
            change.text = "You have tamed " + petList.clones.GetComponent<Pets_stats>().petname + ". Congratulations! ";

            petnameChange.SetActive(true);
            buttons.SetActive(false);
        }

        if (tamingPercentage < 30)
        {
            change.text = "You failed to tame and the monster is angry"; 
            playerState = 0;
        }
        else if (tamingPercentage < 50)
        {
            change.text = "You failed to tame and the monster is timid";
            playerState = 0;
        }
        else if (tamingPercentage < 70)
        {
            change.text = "You failed to tame and the monster is discouraged";
            playerState = 0;
        }
        else if (tamingPercentage < 90)
        {
            change.text = "You failed to tame, but the monster is calm";
            playerState = 0;
        }

    }

    public void Interact()
    {
        if (interactMenu.active == true)
            interactMenu.SetActive(false);
        else
            interactMenu.SetActive(true);
    }

    public void Feed()
    {
        tamingPercentage += 30;
        playerAction = 1;
        playerState = 0;
    }

    public void Fight()
    {
        tamingPercentage += 30;
        playerAction = 2;
        playerState = 0;
    }

    public void Respect()
    {
        tamingPercentage += 30;
        playerAction = 3;
        playerState = 0;
    }

    public void Wait()
    {
        tamingPercentage += 30;
        playerAction = 4;
        playerState = 0;
    }

    public void petName(string newPetname)
    {
        petList.clones.GetComponent<Pets_stats>().petname = newPetname;
        tameSuccess = true;
    }

    public void isRun()
    {
        textTame.text = "";
        Destroy(petList.clones);
        run = true;
    }

    int RandomNumber(int min, int max)
    {
        int randNum;

        randNum = Random.Range(min, max);

        return randNum;
    }

    IEnumerator TimeDelay(float timedelay)
    {
        waitDelay = true;
        yield return new WaitForSeconds(timedelay);
        waitDelay = false;
    }
}
