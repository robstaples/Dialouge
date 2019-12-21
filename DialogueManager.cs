using System;
using System.Collections;
using System.Collections.Generic;

namespace DialogueSystem
{
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
            Dialogue start = new Dialogue("Derek", startingConversation);
            DialogueOptions playerOptions = new DialogueOptions("You");
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
}