using System;
using System.Collections;
using System.Collections.Generic;

public class DialogueManager
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

    public DialogueNode startingDialouge;

    public DialogueManager()
    {
        Dialogue start = new Dialogue("You", startingConversation);
        DialogueOptions playerOptions = new DialogueOptions();
        Dialogue response1 = new Dialogue("Derek", npcresponse1);
        Dialogue response2 = new Dialogue("Derek", npcresponse2);
        Dialogue response3 = new Dialogue("Derek", npcresponse3);

        start.AddConnection(playerOptions);

        playerOptions.AddOption(option1, new Dialogue("You", phrase1, response1));
        playerOptions.AddOption(option2, new Dialogue("You", phrase2, response2));
        playerOptions.AddOption(option3, new Dialogue("You", phrase3, response3));

        response1.AddConnection(playerOptions);
        response2.AddConnection(playerOptions);

        startingDialouge = start;
    }
}

public class Conversation
{
    //Change to participant class
    public string[] participents;
    DialogueNode currentDialouge;
    public bool conversationEnded = false;

    public Conversation(string[] _participents, DialogueOptions firstDialouge)
    {
        participents = _participents;
        currentDialouge = firstDialouge;
    }

    public string GetDialogueType()
    {
        if (currentDialouge.GetOptionCount() > 1)
        {
            return "Options";
        }
        return "Monolouge";
    }

    public string ContinueConversaton()
    {
        if (currentDialouge.GetType() == (typeof(DialogueOptions)))
        {

            foreach (KeyValuePair<string, Dialogue> option in (DialogueOptions)currentDialouge)
            {
                if (option.Value.nextNode != null)
                {
                    currentDialouge = option.Value.nextNode;
                }
                else
                {
                    conversationEnded = true;
                }
                return option.Key;
            }
        }
        //Will cause infinate loop
        return null;
    }

    public string GetCurrentSpeaker()
    {
        return currentDialouge.speaking;
    }

    public void ChooseOption(Dialogue option)
    {
        if (option.nextNode != null)
            currentDialouge = option.nextNode;
        else
        {
            conversationEnded = true;
        }
    }
}

public abstract class DialogueNode
{
    public string speaking;

    public abstract int GetOptionCount();
}

public class DialogueOptions : DialogueNode
{
    Dictionary<string, Dialogue> options;

    public Dictionary<string, Dialogue> Options { get => options; }

    public DialogueOptions()
    {
        options = new Dictionary<string, Dialogue>();
    }
    public void AddOption(string option, Dialogue dialouge)
    {
        options.Add(option, dialouge);
    }

    public void ChangeOption(string option, Dialogue dialouge)
    {
        throw new NotImplementedException();
    }

    public void AddConnection(string option, DialogueNode connection)
    {
        throw new NotImplementedException();
    }

    public void RemoveConnection(string option)
    {
        throw new NotImplementedException();
    }

    public override int GetOptionCount()
    {
        return Options.Count;
    }
}

public class Dialogue : DialogueNode
{
    public string phrase;
    public DialogueNode nextNode;

    public Dialogue(string _speaking, string _phrase)
    {
        speaking = _speaking;
        phrase = _phrase;
    }

    public Dialogue(string _speaking, string _phrase, DialogueNode _nextNode)
    {
        speaking = _speaking;
        phrase = _phrase;
        nextNode = _nextNode;
    }

    public void AddConnection(DialogueNode connection)
    {
        nextNode = connection;
    }

    public void RemoveConnection()
    {
        throw new NotImplementedException();
    }

    public override int GetOptionCount()
    {
        return 1;
    }
}