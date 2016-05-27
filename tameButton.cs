using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class tameButton : MonoBehaviour {

    public Button button;
    public Text text;
    public PlayerControls player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerControls>();

        if (text.text == "Combat")
        {
            text.text = "Combat";
            player.tamingCombat = "Combat";
            button.GetComponent<Image>().color = Color.red;
        }
        else
        {
            text.text = "Taming";
            player.tamingCombat = "Taming";
            button.GetComponent<Image>().color = new Color(0, 234, 255);
        }
	}

    public void TameCombat()
    {
        if (text.text == "Combat")
        {
            text.text = "Taming";
            player.tamingCombat = "Taming";
            button.GetComponent<Image>().color = new Color(0, 234, 255);
        }
        else
        {
            text.text = "Combat";
            player.tamingCombat = "Combat";
            button.GetComponent<Image>().color = Color.red;
        }
    }
}
