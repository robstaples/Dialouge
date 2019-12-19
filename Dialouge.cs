using System;
using System.Collections;
using System.Collections.Generic;

public class DialougeManager
{
    string startingConversation = "Hello what can i do for you";
    string option1 = "talk about jesus";
    string phrase1 = "do you have a moment to talk about our lord";
    string npcresponse1 = "Please go away";
    string option2 = "Somthing Dan would say";
    string phrase2 = "AIYAHHHH";
    string npcresponse2 = "We should build a wall?";
    string option3 = "goodbye";
    string phrase3 = "goodbye";
    string npcresponse3 = "ok byeeeeeee";

    public DialogueOptions startingDialouge;

    public DialougeManager()
    {
        DialogueOptions start = new DialogueOptions();
        DialogueOptions playerOptions = new DialogueOptions();
        DialogueOptions response1 = new DialogueOptions();
        DialogueOptions response2 = new DialogueOptions();
        DialogueOptions response3 = new DialogueOptions();

        start.options.Add(startingConversation, new Node(false, startingConversation, playerOptions));
        playerOptions.options.Add(option1, new Node(true, phrase1, response1));
        playerOptions.options.Add(option2, new Node(true, phrase2, response2));
        playerOptions.options.Add(option3, new Node(true, phrase3, response3));

        response1.options.Add(npcresponse1, new Node(false, npcresponse1, playerOptions));
        response2.options.Add(npcresponse2, new Node(false, npcresponse2, playerOptions));
        response3.options.Add(npcresponse3, new Node(false, npcresponse3, null));

        startingDialouge = start;
    }
}

public class Conversation
{
    string npcName;
    public DialogueOptions currentDialouge;
    public bool conversationEnded = false;

    public Conversation(string _npcName, DialogueOptions firstDialouge)
    {
        npcName = _npcName;
        currentDialouge = firstDialouge;
    }

    public void ContinueConversaton(Node nextConvo)
    {
        if (nextConvo.nextNode != null)
        {
            currentDialouge = nextConvo.nextNode;
        }
        else
        {
            conversationEnded = true;
        }
    }

    public void ChooseOption(Node option)
    {
        if (option.nextNode != null)
            currentDialouge = option.nextNode;
        else
        {
            conversationEnded = true;
        }
    }
}

public class DialogueOptions
{
    public Dictionary<string, Node> options;

    public DialogueOptions()
    {
        options = new Dictionary<string, Node>();
    }
}

public class Node
{
    bool playerSpeaking;
    public string phrase;
    public DialogueOptions nextNode;

    public Node(bool _playerSpeaking, string _phrase)
    {
        playerSpeaking = _playerSpeaking;
        phrase = _phrase;
    }

    public Node(bool _playerSpeaking, string _phrase, DialogueOptions _nextNode)
    {
        playerSpeaking = _playerSpeaking;
        phrase = _phrase;
        nextNode = _nextNode;
    }
}