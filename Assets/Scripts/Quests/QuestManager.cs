using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public QuestObject[] quests;
    public string[] speechTxt;
    public bool[] questCompleted;

    public DialogueControl dialogueControl;

    // Start is called before the first frame update
    void Start()
    {
        questCompleted = new bool[quests.Length];
    }

    public void ShowQuestText(string questText)
    {
        dialogueControl.sentences = new string[1];
        dialogueControl.sentences[0] = questText;
        dialogueControl.index = 0;
        dialogueControl.Speech(speechTxt);
    }
}