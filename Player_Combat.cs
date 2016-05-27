using UnityEngine;
using System.Collections;

public class Player_Combat : MonoBehaviour {

    Animator anim;
    Player_Stats pstats;

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

	// Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
        pstats = GameObject.FindGameObjectWithTag("GameManager").GetComponent<Player_Stats>();

        anim.runtimeAnimatorController = Resources.Load(pstats.playerChoice) as RuntimeAnimatorController;////CHANGES THE ANIMATOR OF THIS GAME OBJECT



    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void isCast()
    {
        

        StartCoroutine(Timedelay(1, "isCast"));

    }

    public void isAttack()
    {


        StartCoroutine(Timedelay(1, "isAttack"));

    }


    IEnumerator Timedelay(float timedelay, string boolname)
    {
      //  anim = GetComponent<Animator>();

        anim.SetBool(boolname, true);

        yield return new WaitForSeconds(timedelay);

        anim.SetBool(boolname, false);
    }


}
