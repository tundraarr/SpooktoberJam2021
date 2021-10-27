using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueRenderer : MonoBehaviour
{
    [SerializeField] private TMP_Text textSpace;

    [SerializeField] private Dialogue currentDialogue;
    private Queue<string> sentences = new Queue<string>();
    private string currentSentence;

    public void RenderText()
    {
        LoadNextSentence();
        textSpace.SetText(currentSentence);
    }

    public void LoadSentences(Dialogue dialogue)
    {
        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        //To clear the rendered dialogue when all sentences are finished
        sentences.Enqueue("");
    }

    public void LoadNextSentence()
    {
        if(sentences.Count > 0)
        {
            currentSentence = sentences.Dequeue();
        }
    }

    public void ClearDialogue()
    {
        sentences.Clear();
        currentDialogue = null;
        textSpace.SetText("");
    }

    public bool HasDialogueLoaded()
    {
        if(sentences.Count > 0)
        {
            return true;
        }
        return false;
    }

    public void SetCurrentDialogue(Dialogue dialogue)
    {
        currentDialogue = dialogue;
    }
}
