using System;
using System.Collections;
using System.Collections.Generic;
using DialogueSystem;

namespace DialougeCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            DialogueManager manager = new DialogueManager();
            DialogueNode starting = manager.startingDialouge;
            Conversation convo = new Conversation(new string[] { "derek", "player" }, starting);

            while (!convo.conversationEnded)
            {
                if (convo.CurrentDialouge.GetType() == (typeof(DialogueOptions)))
                {
                    DialogueOptions newDialogue = (DialogueOptions)convo.CurrentDialouge;
                    Dialogue[] nodes = new Dialogue[100];
                    int i = 1;
                    foreach (KeyValuePair<string, Dialogue> option in newDialogue.Options)
                    {
                        Console.WriteLine(i + ": " + option.Key);
                        nodes[i] = option.Value;
                        i++;
                    }
                    Console.WriteLine("-----------------------------------------------");
                    int selection = int.Parse(Console.ReadLine());
                    Console.WriteLine("-----------------------------------------------");
                    Console.WriteLine(convo.GetCurrentSpeaker() + ": " + nodes[selection].phrase);
                    Console.WriteLine("-----------------------------------------------");
                    convo.ChooseOption(nodes[selection]);
                }
                else
                {
                    Console.WriteLine(convo.GetCurrentSpeaker() + ": " + convo.ContinueConversaton());
                    Console.WriteLine("-----------------------------------------------");
                }
            }
        }
    }
}
