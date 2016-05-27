using UnityEngine;
using System.Collections;

public class ActivateTextAtLines : MonoBehaviour {

    public TextAsset theText;

    public int startLine;
    public int endLine;

    public DialogueManager dialogueManager;

    public bool requireButtonPress;
    private bool waitButton;

	// Use this for initialization
	void Start () {

        dialogueManager = FindObjectOfType<DialogueManager>();

	}
	
	// Update is called once per frame
	void Update () {

        if (waitButton && Input.GetKeyDown(KeyCode.Return))
        {
            dialogueManager.ReloadScript(theText);
            dialogueManager.currentLine = startLine;
            dialogueManager.endAtLine = endLine;
            dialogueManager.EnableDialogueBox();
            waitButton = false;
        }
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            if (requireButtonPress)
            {
                waitButton = true;
                return;
            }

            dialogueManager.ReloadScript(theText);
            dialogueManager.currentLine = startLine;
            dialogueManager.endAtLine = endLine;
            dialogueManager.EnableDialogueBox();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "Player")
        {
            waitButton = false;
        }
    }
}
