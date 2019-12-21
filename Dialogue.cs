using System;
using System.Collections;
using System.Collections.Generic;

namespace DialogueSystem
{
    public abstract class DialogueNode
    {
        public string speaking;

        public abstract int GetOptionCount();
    }

    public class DialogueOptions : DialogueNode
    {
        Dictionary<string, Dialogue> options;

        public Dictionary<string, Dialogue> Options { get => options; }

        public DialogueOptions(string _speaking)
        {
            speaking = _speaking;
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
}