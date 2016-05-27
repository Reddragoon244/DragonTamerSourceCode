using UnityEngine;
using System.Collections;

public class ParticleDestroy : MonoBehaviour {

    public ParticleSystem part;

    private bool waitDelay = true;

	// Use this for initialization
	void Start () {

        part = this.gameObject.GetComponentInChildren<ParticleSystem>();
	
	}
	
	// Update is called once per frame
	void Update () {

        if (part.IsAlive())
        {

        }
        else
        {
            if (waitDelay == true)
            {
                StartCoroutine(TimeDelay(1.0f));
            }
            else
                Destroy(this.gameObject);
        }
	
	}

    IEnumerator TimeDelay(float timedelay)
    {
        waitDelay = true;
        yield return new WaitForSeconds(timedelay);
        waitDelay = false;
    }
}
