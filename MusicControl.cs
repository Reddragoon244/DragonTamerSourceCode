using UnityEngine;
using System.Collections;

public class MusicControl : MonoBehaviour {

    public SceneSwitch scene;
    public AudioSource[] audio;

    public bool allMusicStopped = true;
    private float musicChange = 0.075f;

    /*
     * House is areaNum 2
     * World is areaNum 0
     * Forest is areaNum 1
     * Deep Forest is areaNum 4
     * Cave is areaNum 6
     */

    // Use this for initialization
	void Start () {

        scene = GameObject.FindGameObjectWithTag("GameManager").GetComponent<SceneSwitch>();
	
	}
	
	// Update is called once per frame
	void Update () {

        if (scene.areaNum == 0)
        {
            if (audio[1].volume <= 0.75f)
                audio[1].volume += musicChange;

            if (allMusicStopped == true && !audio[1].isPlaying)
            {
                audio[1].Play();
            }
            else
                StopAllMusic();
        }
        else if (scene.areaNum == 2)
        {
            if (audio[0].volume <= 0.75f)
                audio[0].volume += musicChange;

            if (allMusicStopped == true && !audio[0].isPlaying)
            {
                audio[0].Play();
            }
            else
                StopAllMusic();
        }
        else if (scene.areaNum == 1)
        {
            if (audio[2].volume <= 0.75f)
                audio[2].volume += musicChange;

            if (allMusicStopped == true && !audio[2].isPlaying)
            {
                audio[2].Play();
            }
            else StopAllMusic();
        }
        else if (scene.areaNum == 4)
        {
            if (audio[2].volume <= 0.75f)
                audio[2].volume += musicChange;

            if (allMusicStopped == true && !audio[2].isPlaying)
            {
                audio[2].Play();

            }
            else
                StopAllMusic();
        }
        else if (scene.areaNum == 6)
        {
            if (audio[3].volume <= 0.75f)
                audio[3].volume += musicChange;

            if (allMusicStopped == true && !audio[3].isPlaying)
            {
                audio[3].Play();
            }
            else
                StopAllMusic();
        }
	
	}

    void StopAllMusic()
    {
        if (audio[0].volume <= 0.0f)
            audio[0].Stop();
        else if (audio[0].isPlaying && scene.areaNum != 2)
        {
            allMusicStopped = false;
            audio[0].volume -= musicChange;
        }

        if (audio[1].volume <= 0.0f)
            audio[1].Stop();
        else if (audio[1].isPlaying && scene.areaNum != 0)
        {
            allMusicStopped = false;
            audio[1].volume -= musicChange;
        }

        if (audio[2].volume <= 0.0f)
            audio[2].Stop();
        else if (audio[2].isPlaying && (scene.areaNum != 1 | scene.areaNum != 4))
        {
            allMusicStopped = false;
            audio[2].volume -= musicChange;
        }

        if (audio[3].volume <= 0.0f)
            audio[3].Stop();
        else if (audio[3].isPlaying && scene.areaNum != 6)
        {
            allMusicStopped = false;
            audio[3].volume -= musicChange;
        }

        if (audio[4].volume <= 0.0f)
            audio[4].Stop();
        else if (audio[4].isPlaying)
        {
            allMusicStopped = false;
            audio[4].volume -= musicChange;
        }

        if (!audio[0].isPlaying && !audio[1].isPlaying && !audio[2].isPlaying && !audio[3].isPlaying && !audio[4].isPlaying)
            allMusicStopped = true;
    }
}
