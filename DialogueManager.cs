using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour {

    public GameObject textBox;

    public Text theText;

    public TextAsset textFile;
    public string[] textLines;

    public bool isActive;
    public int currentLine;
    public int endAtLine;

    public PlayerControls player;

    private bool isTyping = false;
    private bool cancelTyping = false;

    public float typeSpeed;

	// Use this for initialization
	void Start () {

        player = GameObject.FindObjectOfType<PlayerControls>();

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }

        if (isActive)
        {
            EnableDialogueBox();
        }
        else
            DisableDialogueBox();
	}

    void Update()
    {
        if (!isActive)
        {
            return;
        }

        //theText.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (!isTyping)
            {
                currentLine += 1;

                if (currentLine > endAtLine)
                {
                    DisableDialogueBox();
                }
                else
                {
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }

            }
            else if(isTyping && !cancelTyping)
            {
                cancelTyping = true;
            }
        }

        
    }

    private IEnumerator TextScroll(string lineOfText)
    {
        int i = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        while(isTyping && !cancelTyping && (i < lineOfText.Length -1))
        {
            theText.text += lineOfText[i];
            i++;
            yield return new WaitForSeconds(typeSpeed);
        }

        theText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    public void EnableDialogueBox()
    {
        textBox.SetActive(true);
        isActive = true;

        if (isActive)
        {
            player.canMove = false;
        }

        StartCoroutine(TextScroll(textLines[currentLine]));

    }

    public void DisableDialogueBox()
    {
        textBox.SetActive(false);
        isActive = false;

            player.canMove = true;
        
    }

    public void ReloadScript(TextAsset theText)
    {
        if (theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }

    }

}
