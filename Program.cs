using System;
using System.Collections;
using System.Collections.Generic;

namespace DialougeCreator
{
    class Program
    {
        static void Main(string[] args)
        {
            DialougeManager manager = new DialougeManager();
            DialogueOptions starting = manager.startingDialouge;
            Conversation convo = new Conversation("derek", starting);

            while (!convo.conversationEnded)
            {
                if (convo.currentDialouge.options.Count > 1)
                {
                    Node[] nodes = new Node[100];
                    int i = 1;
                    foreach (KeyValuePair<string, Node> option in convo.currentDialouge.options)
                    {
                        Console.WriteLine(option.Key);
                        nodes[i] = option.Value;
                        i++;
                    }
                    Console.WriteLine("-----------------------------------------------");
                    int selection = int.Parse(Console.ReadLine());
                    Console.WriteLine("-----------------------------------------------");
                    Console.WriteLine(nodes[selection].phrase);
                    Console.WriteLine("-----------------------------------------------");
                    convo.ChooseOption(nodes[selection]);
                }
                else
                {
                    foreach (KeyValuePair<string, Node> option in convo.currentDialouge.options)
                    {
                        Console.WriteLine(option.Key);
                        convo.ContinueConversaton(option.Value);
                    }
                    Console.WriteLine("-----------------------------------------------");
                }
            }
        }
    }
}
