using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBasedConsoleBattle : MonoBehaviour
{
    int playerHitpoints=10;
    int aiHitpoints = 10;
    bool defendOn = false;
    bool deadlyAttack = false;
    bool end = false;
    [SerializeField] TMPro.TMP_Text mydisplay;
    List<string> choices = new List<string>() { "Scissors", "Rock", "Paper" };
    void StartGame() {
        playerHitpoints = 10;
        aiHitpoints = 10;
        defendOn = false;
        deadlyAttack = false;
        end = false;
        string msg = $"Welcome to the Turn Based Console Battle \n [ Your Hitpoints = {playerHitpoints} | AI Hitpoints = {aiHitpoints}] \n Press one of the keys to make a move \n 1 = Attack \t 2 = Heal \t 3 = Defend \n Special Moves For a Duel of Scissors, Rock and Paper\n 4 = Scissors \t 5 = Rock \t 6 = Paper  ";
        Debug.Log(msg);
        mydisplay.text = msg;
    }

    string PlayerAttack() {
        aiHitpoints -= Random.Range(1, 3);
        string msg = $"You attacked \n [ Your Hitpoints = {playerHitpoints} | AI Hitpoints = {aiHitpoints}]\n";        
        return msg;
        
    }

    string PlayerHeal() {
        int inc = playerHitpoints + 2;
        if (inc > 10)
        {
            playerHitpoints = 10;
            string msg = $"You heal \n [ Your Hitpoints = {playerHitpoints} | AI Hitpoints = {aiHitpoints}]\n";            
            return msg;
        }
        else {
            playerHitpoints = inc;
            string msg = $"You heal \n [ Your Hitpoints = {playerHitpoints} | AI Hitpoints = {aiHitpoints}]\n";            
            return msg;
        }
    
    }

    string PlayerDefend() {
        defendOn = true;
        string msg = $"You choose defense \n [ Your Hitpoints = {playerHitpoints} | AI Hitpoints = {aiHitpoints}]\n";
        return msg;
    }

    string PlayerDuel(string choice) {
        return choice;
    
    }

    void AiDuel( string pchoice ) {
        string aichoice = choices[Random.Range(0, 3)];
        if (pchoice == aichoice)
        {
            string msg = $"You choose {pchoice} while the AI chooses {aichoice}\n It's a tie \n[Your Hitpoints = { playerHitpoints} | AI Hitpoints = { aiHitpoints}] \n Press one of the keys to make a move \n 1 = Attack \t 2 = Heal \t 3 = Defend \n Special Moves For a Duel of Scissors, Rock and Paper\n 4 = Scissors \t 5 = Rock \t 6 = Paper  ";
            Debug.Log(msg);
            mydisplay.text = msg;
        }
        else if ((pchoice == "Scissors" && aichoice == "Paper")|| (pchoice == "Paper" && aichoice == "Rock")|| (pchoice == "Rock" && aichoice == "Scissors"))
        {
            aiHitpoints -= 3;
            string msg = $"You choose {pchoice} while the AI chooses {aichoice}\n You win the duel ! \n the AI looses 3 Points \n[Your Hitpoints = { playerHitpoints} | AI Hitpoints = { aiHitpoints}] \n Press one of the keys to make a move \n 1 = Attack \t 2 = Heal \t 3 = Defend \n Special Moves For a Duel of Scissors, Rock and Paper\n 4 = Scissors \t 5 = Rock \t 6 = Paper  ";            
            Debug.Log(msg);
            mydisplay.text = msg;
        }
        else if ((aichoice == "Scissors" && pchoice == "Paper") || (aichoice == "Paper" && pchoice == "Rock") || (aichoice == "Rock" && pchoice == "Scissors")) {
            playerHitpoints -= 3;
            string msg = $"You choose {pchoice} while the AI chooses {aichoice}\n The AI wins the duel ! \n You loose 3 Points \n[Your Hitpoints = { playerHitpoints} | AI Hitpoints = { aiHitpoints}] \n Press one of the keys to make a move \n 1 = Attack \t 2 = Heal \t 3 = Defend \n Special Moves For a Duel of Scissors, Rock and Paper\n 4 = Scissors \t 5 = Rock \t 6 = Paper  ";            
            Debug.Log(msg);
            mydisplay.text = msg;
        }


    }

    void AiAttack(string playermsg){
        if (defendOn == false && deadlyAttack == false) {   
            int magnitude = Random.Range(1, 5);
            int dec = playerHitpoints - magnitude;           
            playerHitpoints = dec;
            string msg = playermsg+$"The AI attacks you loose {magnitude} hitpoints \n[Your Hitpoints = { playerHitpoints} | AI Hitpoints = { aiHitpoints}] \n Press one of the keys to make a move \n 1 = Attack \t 2 = Heal \t 3 = Defend \n Special Moves For a Duel of Scissors, Rock and Paper\n 4 = Scissors \t 5 = Rock \t 6 = Paper  ";
            Debug.Log(msg);
            mydisplay.text = msg;           
            

        }
        else if (defendOn == false && deadlyAttack == true)
        {

            playerHitpoints = 0;
            string msg = playermsg+$"The AI hits you with a deadly attack you loose all your points\n [ Your Hitpoints = {playerHitpoints} | AI Hitpoints = {aiHitpoints}]";
            Debug.Log($"The AI hits you with a deadly attack you loose all your points\n [ Your Hitpoints = {playerHitpoints} | AI Hitpoints = {aiHitpoints}]");
            mydisplay.text = msg;
        }
        else {
            defendOn = false;
            deadlyAttack = false;
            string msg = playermsg+$"The AI attacks, but you suceed to defend yourself \n [ Your Hitpoints = {playerHitpoints} | AI Hitpoints = {aiHitpoints}] \n Press one of the keys to make a move \n 1 = Attack \t 2 = Heal \t 3 = Defend \n Special Moves For a Duel of Scissors, Rock and Paper\n 4 = Scissors \t 5 = Rock \t 6 = Paper  ";
            Debug.Log(msg);
            mydisplay.text = msg;

        }

    }

    void AiCharge(string playermsg) {
        string msg = playermsg+$"The AI is charging Energy \n[ Your Hitpoints = {playerHitpoints} | AI Hitpoints = {aiHitpoints}] \n Press one of the keys to make a move \n 1 = Attack \t 2 = Heal \t 3 = Defend \n Special Moves For a Duel of Scissors, Rock and Paper\n 4 = Scissors \t 5 = Rock \t 6 = Paper  ";
        Debug.Log(msg);
        mydisplay.text = msg;
        deadlyAttack = true;
        
    }


    void AiMove(string playermsg) {

        if (Random.Range(0.0f, 1.0f) < 0.65f) {
            AiAttack(playermsg);
        } else {
            AiCharge(playermsg);
        }
    
    }

    string checkWinner() {
        if (aiHitpoints > playerHitpoints)
        {
            return "the AI";
        }
        else {
            return "you";
        }
    }

    void ControlInfo() {
        Debug.Log($"[ Your Hitpoints = {playerHitpoints} | AI Hitpoints = {aiHitpoints}]\n Press one of the keys  to make a move \n 1 = Attack \t 2 = Heal \t 3 = Defend \n Special Moves For a Duel of Scissors, Rock and Paper\n 4 = Scissors \t 5 = Rock \t 6 = Paper  ");
        
    }


    // Start is called before the first frame update
    void Start() {

        GameObject myterminal = GameObject.Find("coutput");
        mydisplay = myterminal.GetComponent<TMPro.TMP_Text>();
        string msg = $"Welcome to the Turn Based Console Battle \n [ Your Hitpoints = {playerHitpoints} | AI Hitpoints = {aiHitpoints}] \n Press one of the keys to make a move \n 1 = Attack \t 2 = Heal \t 3 = Defend \n Special Moves For a Duel of Scissors, Rock and Paper\n 4 = Scissors \t 5 = Rock \t 6 = Paper  ";
        Debug.Log(msg);
        mydisplay.text = msg;


    }

    // Update is called once per frame
    void Update()
    {
        if (aiHitpoints > 0 && playerHitpoints > 0) {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                
                AiMove(PlayerAttack());
                
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                
                AiMove(PlayerHeal());
                
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                
                AiMove(PlayerDefend());
               
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {

                AiDuel(PlayerDuel("Scissors"));

            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {

                AiDuel(PlayerDuel("Rock"));

            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {

                AiDuel(PlayerDuel("Paper"));

            }


        } else {
            if (end == false) {
                string msg = $"The End \n The Winner is {checkWinner()} \n Press R to restart the game";
                Debug.Log(msg);                
                mydisplay.text = msg;
                end = true;
            }

        }

        if (Input.GetKeyDown(KeyCode.R))
        {   
            Debug.Log("Restarting Game...");
            StartGame();
        }

    }
}
