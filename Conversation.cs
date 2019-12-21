using System;
using System.Collections;
using System.Collections.Generic;

namespace DialogueSystem
{
    public class Conversation
    {
        //Change to participant class
        public string[] participents;
        DialogueNode currentDialouge;
        public DialogueNode CurrentDialouge { get => currentDialouge; }
        public bool conversationEnded = false;

        public Conversation(string[] _participents, DialogueNode firstDialouge)
        {
            participents = _participents;
            currentDialouge = firstDialouge;
        }

        public string ContinueConversaton()
        {
            if (CurrentDialouge.GetType() == (typeof(Dialogue)))
            {
                Dialogue newDialogue = (Dialogue)currentDialouge;
                currentDialouge = newDialogue.nextNode;
                return newDialogue.phrase;
            }
            //Will cause infinate loop
            conversationEnded = true;
            return null;
        }

        public string GetCurrentSpeaker()
        {
            return CurrentDialouge.speaking;
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
}