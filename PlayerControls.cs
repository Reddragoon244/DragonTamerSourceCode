using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour {

    Animator anim;
    public GameObject gameManager;
    public GameObject menu;
    public GameObject combattame;
    float speedMovement = 2.0f;
    int randNum;
    public  bool canMove;
    public string tamingCombat;
    public int randomMax = 15000;

    SceneSwitch scene;
    Player_Stats pstats;

	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();

        gameManager = GameObject.FindGameObjectWithTag("GameManager");

        scene = gameManager.GetComponent<SceneSwitch>();
        pstats = gameManager.GetComponent<Player_Stats>();
        anim.runtimeAnimatorController = Resources.Load(pstats.playerChoice) as RuntimeAnimatorController;////CHANGES THE ANIMATOR OF THIS GAME OBJECT

        if (menu.active == true)
            menu.SetActive(false);


        combattame.SetActive(true);

        this.transform.position = gameManager.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        if (!canMove)
        {
            return;
        }

        float input_X = Input.GetAxisRaw("Horizontal");
        float input_Y = Input.GetAxisRaw("Vertical");

        bool isWalking = (Mathf.Abs(input_X) + Mathf.Abs(input_Y)) > 0;

        anim.SetBool("isWalking", isWalking);
        if (isWalking)
        {
            anim.SetFloat("x", input_X);
            anim.SetFloat("y", input_Y);

            transform.position += new Vector3(input_X * speedMovement, input_Y * speedMovement, 0) * Time.deltaTime;//Change speedMovement to change how fast the player moves

            ///////////////////////////////Combat Triggers///////////////////////////////////////
            randNum = Random.Range(0, 5000);
            CombatTrigger();

        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menu.active == true)
            {
                menu.SetActive(false);
                combattame.SetActive(true);
            }
            else
            {
                combattame.SetActive(false);
                menu.SetActive(true);
            }

        }
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "boss")//Enter House
        {
            scene.areaNum = 11;
            scene.SceneLoad("Combat");
        }

        if (other.gameObject.tag == "Player's House")//Enter House
        {
            scene.areaNum = 2;
            transform.position = new Vector3(-50.98f, 0.358f, 0.0f);
        }

        if (other.gameObject.tag == "Player's House Exit")//Exit House
        {
            scene.areaNum = 0;
            transform.position = new Vector3(9.035f, 6.986f, 0.0f);
        }

        if (other.gameObject.tag == "Training House")//Enter House
        {
            scene.areaNum = 2;
            transform.position = new Vector3(54.04f, -41.02f, 0.0f);
        }

        if (other.gameObject.tag == "Training House Exit")//Exit House
        {
            scene.areaNum = 0;
            transform.position = new Vector3(42.11f, 5.31f, 0.0f);
        }

        if (other.gameObject.tag == "Castle's Front House")//Enter House
        {
            scene.areaNum = 2;
            transform.position = new Vector3(-38.57f, 48.925f, 0.0f);
        }

        if (other.gameObject.tag == "Castle's Front House Exit")//Exit House
        {
            scene.areaNum = 0;
            transform.position = new Vector3(35.466f, 32.912f, 0.0f);
        }

        if (other.gameObject.tag == "Orange House")//Enter House
        {
            scene.areaNum = 2;
            transform.position = new Vector3(176.913f, 40.726f, 0.0f);
        }

        if (other.gameObject.tag == "Orange House Exit")//Exit House
        {
            scene.areaNum = 0;
            transform.position = new Vector3(60.46f, 41.32f, 0.0f);
        }

        if (other.gameObject.tag == "Blue House")//Enter House
        {
            scene.areaNum = 2;
            transform.position = new Vector3(214.3f, 40.726f, 0.0f);
        }

        if (other.gameObject.tag == "Blue House Exit")//Exit House
        {
            scene.areaNum = 0;
            transform.position = new Vector3(71.47f, 41.32f, 0.0f);
        }

        if (other.gameObject.tag == "Green House")//Enter House
        {
            scene.areaNum = 2;
            transform.position = new Vector3(200.12f, 57.72f, 0.0f);
        }

        if (other.gameObject.tag == "Green House Exit")//Exit House
        {
            scene.areaNum = 0;
            transform.position = new Vector3(65.54f, 47.18f, 0.0f);
        }

        if (other.gameObject.tag == "Forest Inside Entrance")//Enter Forest Area 1 Entrance
        {
            pstats.combatready = false;
            scene.areaNum = 1;//the level i want the monsters to be
            transform.position = new Vector3(19.769f, 5.158f, 0.0f);
            Debug.Log("false");
        }

        if (other.gameObject.tag == "Forest Outside Entrance")//Exit Forest Area 1 Entrance
        {
            pstats.combatready = true;
            scene.areaNum = 1;//the level i want the monsters to be
            transform.position = new Vector3(220.00f, -26.00f, 0.0f);
            Debug.Log("true");
        }

        if (other.gameObject.tag == "Forest Inside Exit")//Enter Forest Area 1 Exit
        {
            pstats.combatready = false;
            scene.areaNum = 0;
            transform.position = new Vector3(35.624f, 5.14f, 0.0f);
            Debug.Log("false");
        }

        if (other.gameObject.tag == "Forest Outside Exit")//Exit Forest Area 1 Exit
        {
            pstats.combatready = true;
            scene.areaNum = 0;
            transform.position = new Vector3(276.6f, -26.00f, 0.0f);
            Debug.Log("true");
        }

        if (other.gameObject.tag == "Deep Forest Entrance")//Deep Forest Entrance
        {
            pstats.combatready = true;
            scene.areaNum = 4;//the level i want the monsters to be
            transform.position = new Vector3(330.7f, 68.8f, 0.0f);
            Debug.Log("true");
        }

        if (other.gameObject.tag == "Deep Forest Exit")//Deep Forest Exit
        {
            pstats.combatready = false;
            scene.areaNum = 0;
            transform.position = new Vector3(57.23f, 49.12f, 0.0f);
            Debug.Log("false");
        }

        if (other.gameObject.tag == "Cave Entrance")//Cave Entrance
        {
            pstats.combatready = true;
            scene.areaNum = 6;//the level i want the monsters to be
            transform.position = new Vector3(-97.67f, 56.43f, 0.0f);
            Debug.Log("true");
        }

        if (other.gameObject.tag == "Cave Exit")//Cave Exit
        {
            pstats.combatready = false;
            scene.areaNum = 0;
            transform.position = new Vector3(12.49f, 45.5f, 0.0f);
            Debug.Log("false");
        }

    }

    void CombatTrigger()
    {
        if (pstats.combatready == true)
        {
            randNum = Random.Range(0, randomMax);
            Debug.Log(randNum);

            if (randNum <= 20)
            {
                pstats.playerLocation();
                if (tamingCombat == "Combat")
                    scene.SceneLoad("Combat");
                else
                    scene.SceneLoad("Taming");
                /*need to save the areaNum for monsters and combat area also*/
            }

            if (randomMax <= 500)
            {

            }
            else
                randomMax -= 50;

        }
    }
}
