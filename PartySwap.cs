using UnityEngine;
using System.Collections;

public class PartySwap : MonoBehaviour {

    public Player_party party;
    public GameObject partyHolder;
    public GameObject partyHolderCurrent;
    public int i, j;

	// Use this for initialization
	void Start () {

        party = FindObjectOfType<Player_party>();
	
	}

    void Update()
    {
        if (partyHolder != null && partyHolderCurrent != null)
        {
            party.party_clones[i] = partyHolderCurrent;
            party.party_clones[j] = partyHolder;

            partyHolder = null;
            partyHolderCurrent = null;
        }
    }

    public void PartyPlace1()
    {
        if (partyHolder == null)
        {
            if (party.party_clones[0] != null)
            {
                i = 0;
                partyHolder = party.party_clones[0];
            }
        }
        else
        {
            j = 0;
            partyHolderCurrent = party.party_clones[0];
        }
    }

    public void PartyPlace2()
    {
        if (partyHolder == null)
        {
            if (party.party_clones[1] != null)
            {
                i = 1;
                partyHolder = party.party_clones[1];
            }
        }
        else
        {
            j = 1;
            partyHolderCurrent = party.party_clones[1];
        }
    }

    public void PartyPlace3()
    {
        if (partyHolder == null)
        {
            if (party.party_clones[2] != null)
            {
                i = 2;
                partyHolder = party.party_clones[2];
            }
        }
        else
        {
            j = 2;
            partyHolderCurrent = party.party_clones[2];
        }
    }

    public void PartyPlace4()
    {
        if (partyHolder == null)
        {
            if (party.party_clones[3] != null)
            {
                i = 3;
                partyHolder = party.party_clones[3];
            }
        }
        else
        {
            j = 3;
            partyHolderCurrent = party.party_clones[3];
        }
    }

    public void PartyPlace5()
    {
        if (partyHolder == null)
        {
            if (party.party_clones[4] != null)
            {
                i = 4;
                partyHolder = party.party_clones[4];
            }
        }
        else
        {
            j = 4;
            partyHolderCurrent = party.party_clones[4];
        }
    }

    public void PartyPlace6()
    {
        if (partyHolder == null)
        {
            if (party.party_clones[5] != null)
            {
                i = 5;
                partyHolder = party.party_clones[5];
            }
        }
        else
        {
            j = 5;
            partyHolderCurrent = party.party_clones[5];
        }
    }

    public void PartyPlace7()
    {
        if (partyHolder == null)
        {
            if (party.party_clones[6] != null)
            {
                i = 6;
                partyHolder = party.party_clones[6];
            }
        }
        else
        {
            j = 6;
            partyHolderCurrent = party.party_clones[6];
        }
    }

    public void PartyPlace8()
    {
        if (partyHolder == null)
        {
            if (party.party_clones[7] != null)
            {
                i = 7;
                partyHolder = party.party_clones[7];
            }
        }
        else
        {
            j = 7;
            partyHolderCurrent = party.party_clones[7];
        }
    }

}
