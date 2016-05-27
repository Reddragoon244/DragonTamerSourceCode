using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public GameObject gameManager;
    public Player_Stats player;

    SceneSwitch scene;

	// Use this for initialization
	void Start () {
        scene = gameManager.GetComponent<SceneSwitch>();

	}

    public void IntoWorld()
    {
        scene.SceneLoad("World");
    }

    public void PlayerName(string name)
    {
        player.playername = name;
    }

    public void quit()
    {
        Application.Quit();
    }
}
