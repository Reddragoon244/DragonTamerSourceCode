using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerMenuImages : MonoBehaviour {

    public int playerParty;
    public Player_party party;
    public Image image;
    public Sprite sprite;


	// Use this for initialization
    void Start()
    {

        party = FindObjectOfType<Player_party>();

        image = this.gameObject.GetComponent<Image>();

    }
	
	// Update is called once per frame
	void Update () {

	    if (playerParty == 1)
        {
            if (party.party_clones[0] != null)
            {
                sprite = party.party_clones[0].GetComponent<SpriteRenderer>().sprite;
                image.sprite = sprite;
            }           
        }
        else if (playerParty == 2)
        {
            if (party.party_clones[1] != null)
            {
                sprite = party.party_clones[1].GetComponent<SpriteRenderer>().sprite;
                image.sprite = sprite;
            }
        }
        else if (playerParty == 3)
        {
            if (party.party_clones[2] != null)
            {
                sprite = party.party_clones[2].GetComponent<SpriteRenderer>().sprite;
                image.sprite = sprite;
            }
        }
        else if (playerParty == 4)
        {
            if (party.party_clones[3] != null)
            {
                sprite = party.party_clones[3].GetComponent<SpriteRenderer>().sprite;
                image.sprite = sprite;
            }
        }
        else if (playerParty == 5)
        {
            if (party.party_clones[4] != null)
            {
                sprite = party.party_clones[4].GetComponent<SpriteRenderer>().sprite;
                image.sprite = sprite;
            }
        }
        else if (playerParty == 6)
        {
            if (party.party_clones[5] != null)
            {
                sprite = party.party_clones[5].GetComponent<SpriteRenderer>().sprite;
                image.sprite = sprite;
            }
        }
        else if (playerParty == 7)
        {
            if (party.party_clones[6] != null)
            {
                sprite = party.party_clones[6].GetComponent<SpriteRenderer>().sprite;
                image.sprite = sprite;
            }
        }
        else if (playerParty == 8)
        {
            if (party.party_clones[7] != null)
            {
                sprite = party.party_clones[7].GetComponent<SpriteRenderer>().sprite;
                image.sprite = sprite;
            }
        }
	
	}

}
