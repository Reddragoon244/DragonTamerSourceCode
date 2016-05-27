using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleScreen : MonoBehaviour {

    public Text text;

    void Start() {

        text = this.gameObject.GetComponent<Text>();
        StartCoroutine(TimeDelay(3.0f));
 
    }

    IEnumerator TimeDelay(float timedelay)
    {
        yield return new WaitForSeconds(timedelay);
        text.CrossFadeColor(Color.black, 2.75f, true, true);//will execute after timedelay has been reached
    }
}
