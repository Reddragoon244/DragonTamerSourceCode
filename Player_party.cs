using UnityEngine;
using System.Collections;

public class Player_party : MonoBehaviour {

    public GameObject[] player_party;
    public GameObject[] party_clones;
    public PlayerControls player;

    public SceneSwitch scene;

    void Start()
    {
        scene = GetComponent<SceneSwitch>();

        if (scene.sceneNumber == 0)
        {
            for (int i = 0; i < 4; i++)
            {
                if (player_party[i] != null)
                {

                    if (party_clones[i] == null)
                    {
                            party_clones[i] = Instantiate(player_party[i]);
                            party_clones[i].transform.position = new Vector3(-20.0f, -20.0f, 0.0f);
                            party_clones[i].SetActive(false);
                    }

                }

            }
        }
    }

    // Use this for initialization
    void OnLevelWasLoaded()
    {
        if (scene.sceneNumber == 2)
        {
            
            for (int i = 0; i < 4; i++)
            {
                if (player_party[i] != null)
                {                    

                    if(party_clones[i] == null)
                        party_clones[i] = Instantiate(player_party[i]);
                    else
                        party_clones[i].SetActive(true);
                }

            }

            if (player_party[0] == null)
            {

            }
            else
                party_clones[0].transform.position = new Vector3(-4f, 2.0f, 0.0f);

            if (player_party[1] == null)
            {

            }
            else
                party_clones[1].transform.position = new Vector3(-4f, -2.0f, 0.0f);

            if (player_party[2] == null)
            {

            }
            else
                party_clones[2].transform.position = new Vector3(-2.5f, 0.0f, 0.0f);

            if (player_party[3] == null)
            {

            }
            else
                party_clones[3].transform.position = new Vector3(-5.5f, 0.0f, 0.0f);

        }

        if (scene.sceneNumber == 6)
        {
            for (int i = 0; i < 4; i++)
            {
                if (player_party[i] != null)
                {

                    if (party_clones[i] == null)
                    {
                        party_clones[i] = Instantiate(player_party[i]);
                        if (party_clones[i].name == "Player(no camera)(Clone)")
                        {
                            party_clones[i].SetActive(true);
                            party_clones[i].transform.position = new Vector3(-4.0f, 0.0f, 0.0f);
                        }
                        else
                            party_clones[i].SetActive(false);

                    }
                    else
                    {
                        if (party_clones[i].name == "Player(no camera)(Clone)")
                        {
                            party_clones[i].SetActive(true);
                            party_clones[i].transform.position = new Vector3(-4.0f, 0.0f, 0.0f);
                        }
                        else
                            party_clones[i].SetActive(false);
                    }

                }

            }

        }
        
        if (scene.sceneNumber == 1)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (party_clones[i] != null)
                    {
                        party_clones[i].SetActive(false);                     
                    }

                }
            }

    }

    public void DeactiveReactive()
    {
        for (int i = 0; i < 4; i++)
        {
            if(party_clones[i] != null)
                party_clones[i].SetActive(true);       
        }
    }

}
