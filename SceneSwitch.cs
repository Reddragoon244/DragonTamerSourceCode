using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneSwitch : MonoBehaviour {

    public int sceneNumber;
    public int areaNum = 0;

    public void SceneLoad(string SceneName)
    {

        switch (SceneName)
        {
            case "":
                break;
            case "World":
                SceneManager.LoadScene(SceneName);
                areaNum = 0;
                sceneNumber = 1;
                break;
            case "Combat":
                SceneManager.LoadScene(SceneName);
                sceneNumber = 2;
                break;
            case "Main Menu":
                SceneManager.LoadScene(SceneName); 
                sceneNumber = 3;
                break;
            case "Menu":
                SceneManager.LoadScene(SceneName); 
                sceneNumber = 4;
                break;
            case "Combat Results":
                SceneManager.LoadScene(SceneName); 
                sceneNumber = 5;
                break;
            case "Taming":
                SceneManager.LoadScene(SceneName);
                sceneNumber = 6;
                break;

        } 


    }
}
