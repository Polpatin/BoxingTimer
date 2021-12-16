using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace TimerApp
{
    public class Options : MonoBehaviour
    {
       
        
        //+2s
        //csene autor
        //Set difrent buttons colo
        //fix  text roubd secinds
        public int choseUser;


        //Users Datas
        public string user1Name;
        public int user1Amount;
        public int user1RoundMinuts;
        public int user1RoundSecondsIn;
        public int user1RoundSecondsOut;
        public int user1RestMinuts;
        public int user1RestSecondsIn;
        public int user1RestSecondsOut;

        public string user2Name;
        public int user2Amount;
        public int user2RoundMinuts;
        public int user2RoundSecondsIn;
        public int user2RoundSecondsOut;
        public int user2RestMinuts;
        public int user2RestSecondsIn;
        public int user2RestSecondsOut;

        public string user3Name;
        public int user3Amount;
        public int user3RoundMinuts;
        public int user3RoundSecondsIn;
        public int user3RoundSecondsOut;
        public int user3RestMinutes;
        public int user3RestSecondsIn;
        public int user3RestSecondsOut;

      
        //Butttons Users
        public GameObject User1ButtonText;
        public GameObject User2ButtonText;
        public GameObject User3ButtonText;

        public GameObject InputPanel;
        public GameObject UserName;
        public GameObject UserRoundAmount;
        public GameObject UserRound;
        public GameObject UserRest;

        public void Start()
        {
            

                user1Name = PlayerPrefs.GetString("user1Name");
                user1RoundMinuts = PlayerPrefs.GetInt("User1Minuts");
                user1RoundSecondsOut = PlayerPrefs.GetInt("User1Seconds");
                user1RestMinuts = PlayerPrefs.GetInt("User1RestMinuts");
                user1RestSecondsOut = PlayerPrefs.GetInt("User1RestSeconds");
                user1Amount = PlayerPrefs.GetInt("User1Amount");
            User1ButtonText.GetComponent<Text>().text = user1Name + " " + user1RoundMinuts + "m" + user1RoundSecondsOut + "s+" +
                   user1RestMinuts + "m" + user1RestSecondsOut + "s " + "x" + user1Amount;

            user2Name = PlayerPrefs.GetString("user2Name");
                user2RoundMinuts = PlayerPrefs.GetInt("User2Minuts");
                user2RoundSecondsOut = PlayerPrefs.GetInt("User2Seconds");
                user2RestMinuts = PlayerPrefs.GetInt("User2RestMinuts");
                user2RestSecondsOut = PlayerPrefs.GetInt("User2RestSeconds");
                user2Amount = PlayerPrefs.GetInt("User2Amount");
            User2ButtonText.GetComponent<Text>().text = user2Name + " " + user2RoundMinuts + "m" + user2RoundSecondsOut + "s+" +
                       user2RestMinuts + "m" + user2RestSecondsOut + "s " + "x" + user2Amount;

            user3Name = PlayerPrefs.GetString("user3Name");
                user3RoundMinuts = PlayerPrefs.GetInt("User3Minuts");
                user3RoundSecondsOut = PlayerPrefs.GetInt("User3Seconds");
                user3RestMinutes = PlayerPrefs.GetInt("User3RestMinuts");
                user3RestSecondsOut = PlayerPrefs.GetInt("User3RestSeconds");
                user3Amount = PlayerPrefs.GetInt("User3Amount");
            User3ButtonText.GetComponent<Text>().text = user3Name + " " + user3RoundMinuts + "m" + user3RoundSecondsOut + "s+" +
                   user3RestMinutes + "m" + user3RestSecondsOut + "s " + "x" + user3Amount;

            Debug.LogError("Произошла попытка загрузить данные");

        }

        public void BackButton()
        {
           
            SceneManager.LoadScene(0);
            //Save data
            PlayerPrefs.SetString("ProfileName",MainPage.tempProfile);
            PlayerPrefs.SetInt("RoundAmount", MainPage.tempRoundAmount);
            PlayerPrefs.SetInt("CurrentRound", MainPage.tempcurrentround);
            PlayerPrefs.SetInt("Minuts", MainPage.tempmin);
            PlayerPrefs.SetInt("Seconds", MainPage.tempsec);
            PlayerPrefs.SetInt("RestMinuts", MainPage.temprestmin);
            PlayerPrefs.SetInt("RestSeconds", MainPage.temprestsec);
        }

        public void SetBoxingOptions()
        {
            MainPage.reglfmentSetted = false;
            MainPage.tempProfile="Amateur boxing";
            MainPage.tempRoundAmount = 3;
            MainPage.tempmin = 3;
            MainPage.tempsec = 00;
            MainPage.temprestmin = 1;
            MainPage.temprestsec = 00;

        }
        public void SetMuayThayOptions()
        {
            MainPage.reglfmentSetted = false;
            MainPage.tempProfile = "Muay Thai";
            MainPage.tempRoundAmount = 4;
            MainPage.tempmin = 2;
            MainPage.tempsec = 59;
            MainPage.temprestmin = 2;
            MainPage.temprestsec = 59;

        }
        public void SetMMAOptionsOptions()
        {
            MainPage.reglfmentSetted = false;
            MainPage.tempProfile = "MMA";
            MainPage.tempRoundAmount = 5;
            MainPage.tempmin = 4;
            MainPage.tempsec = 59;
            MainPage.temprestmin = 1;
            MainPage.temprestsec = 59;

        }
        public void SetProboxingOptions()
        {

            MainPage.reglfmentSetted = false;
            MainPage.tempProfile = "Professional boxing";
            MainPage.tempRoundAmount = 12;
            MainPage.tempmin = 2;
            MainPage.tempsec = 59;
            MainPage.temprestmin = 0;
            MainPage.temprestsec = 59;

        }

      
        public void SetUser1Options()
        {
            MainPage.reglfmentSetted = false;
            MainPage.tempProfile = user1Name;
            MainPage.tempRoundAmount = user1Amount ;
            MainPage.tempmin = user1RoundMinuts;
            MainPage.tempsec = user1RoundSecondsOut;
            MainPage.temprestmin = user1RestMinuts;
            MainPage.temprestsec = user1RestSecondsOut;

        }

        public void SetUser2Options()
        {
            MainPage.reglfmentSetted = false;
            MainPage.tempProfile = user2Name;
            MainPage.tempRoundAmount = user2Amount;
            MainPage.tempmin = user2RoundMinuts;
            MainPage.tempsec = user2RoundSecondsOut;
            MainPage.temprestmin = user2RestMinuts;
            MainPage.temprestsec = user2RestSecondsOut;

        }
        public void SetUser3Options()
        {
            MainPage.reglfmentSetted = false;
            MainPage.tempProfile = user3Name;
            MainPage.tempRoundAmount = user3Amount;
            MainPage.tempmin = user3RoundMinuts;
            MainPage.tempsec = user3RoundSecondsOut;
            MainPage.temprestmin = user3RestMinutes;
            MainPage.temprestsec = user3RestSecondsOut;

        }
        public void CanselUserSettings()
        {
            InputPanel.SetActive(false);
        }

        public void EnterUser1Settings()
        {
            ClearPanel();
            InputPanel.SetActive(true);
            choseUser = 1;
        }

        public void EnterUser2Settings()
        {
            ClearPanel();
            InputPanel.SetActive(true);
            choseUser = 2;
        }

        public void EnterUser3Settings()
        {
            ClearPanel();
            InputPanel.SetActive(true);
            choseUser = 3;
        }

        public void ClearPanel()
        {
            UserName.GetComponent<Text>().text = " ";      //НЕ ЧИСТИТ ПАНЕЛЬ
            UserRoundAmount.GetComponent<Text>().text = " ";
            UserRound.GetComponent<Text>().text = " ";
            UserRest.GetComponent<Text>().text = " ";
        }
        public void SaveUserData()
        {
            switch (choseUser)
            {
                case (1):
                    user1Name= UserName.GetComponent<Text>().text;
                    user1Amount= Convert.ToInt32 (UserRoundAmount.GetComponent<Text>().text);
                    user1RoundSecondsIn = Convert.ToInt32(UserRound.GetComponent<Text>().text);
                    user1RestSecondsIn = Convert.ToInt32(UserRest.GetComponent<Text>().text);                   
                    InputPanel.SetActive(false);
                    user1RoundMinuts = user1RoundSecondsIn / 60;
                    user1RoundSecondsOut = user1RoundSecondsIn % 60;
                    user1RestMinuts = user1RestSecondsIn / 60;
                    user1RestSecondsOut = user1RestSecondsIn % 60;

                    User1ButtonText.GetComponent<Text>().text = user1Name+" "+user1RoundMinuts+"m" +user1RoundSecondsOut+"s+"+
                        user1RestMinuts+"m"+user1RestSecondsOut+"s "+"x"+user1Amount;

                    PlayerPrefs.SetString("user1Name",user1Name);
                    PlayerPrefs.SetInt("User1Minuts", user1RoundMinuts);
                    PlayerPrefs.SetInt("User1Seconds", user1RoundSecondsOut);
                    PlayerPrefs.SetInt("User1RestMinuts", user1RestMinuts);
                    PlayerPrefs.SetInt("User1RestSeconds", user1RestSecondsOut);
                    PlayerPrefs.SetInt("User1Amount", user1Amount);
                   Debug.LogError("Data1 saved");
                    break;

                case (2):
                    user2Name = UserName.GetComponent<Text>().text;
                    user2Amount = Convert.ToInt32(UserRoundAmount.GetComponent<Text>().text);
                    user2RoundSecondsIn = Convert.ToInt32(UserRound.GetComponent<Text>().text);
                    user2RestSecondsIn = Convert.ToInt32(UserRest.GetComponent<Text>().text);
                    InputPanel.SetActive(false);
                    user2RoundMinuts = user2RoundSecondsIn / 60;
                    user2RoundSecondsOut = user2RoundSecondsIn % 60;
                    user2RestMinuts = user2RestSecondsIn / 60;
                    user2RestSecondsOut = user2RestSecondsIn % 60;
                    User2ButtonText.GetComponent<Text>().text = user2Name + " " + user2RoundMinuts + "m" + user2RoundSecondsOut + "s+" +
                        user2RestMinuts + "m" + user2RestSecondsOut + "s " + "x" + user2Amount;
                    PlayerPrefs.SetString("user2Name", user2Name);
                    PlayerPrefs.SetInt("User2Minuts", user2RoundMinuts);
                    PlayerPrefs.SetInt("User2Seconds", user2RoundSecondsOut);
                    PlayerPrefs.SetInt("User2RestMinuts", user2RestMinuts);
                    PlayerPrefs.SetInt("User2RestSeconds", user2RestSecondsOut);
                    PlayerPrefs.SetInt("User2Amount", user2Amount);
                    Debug.LogError("Data2 saved");
                    break;

                case (3):
                    user3Name = UserName.GetComponent<Text>().text;
                    user3Amount = Convert.ToInt32(UserRoundAmount.GetComponent<Text>().text);
                    user3RoundSecondsIn = Convert.ToInt32(UserRound.GetComponent<Text>().text);
                    user3RestSecondsIn = Convert.ToInt32(UserRest.GetComponent<Text>().text);
                    InputPanel.SetActive(false);
                    user3RoundMinuts = user3RoundSecondsIn / 60;
                    user3RoundSecondsOut = user3RoundSecondsIn % 60;
                    user3RestMinutes = user3RestSecondsIn / 60;
                    user3RestSecondsOut = user3RestSecondsIn % 60;
                    User3ButtonText.GetComponent<Text>().text = user3Name + " " + user3RoundMinuts + "m" + user3RoundSecondsOut + "s+" +
                        user3RestMinutes + "m" + user3RestSecondsOut + "s " + "x" + user3Amount;
                    PlayerPrefs.SetString("user3Name", user3Name);
                    PlayerPrefs.SetInt("User3Minuts", user3RoundMinuts);
                    PlayerPrefs.SetInt("User3Seconds", user3RoundSecondsOut);
                    PlayerPrefs.SetInt("User3RestMinuts", user3RestMinutes);
                    PlayerPrefs.SetInt("User3RestSeconds", user3RestSecondsOut);
                    PlayerPrefs.SetInt("User3Amount", user3Amount);
                    Debug.LogError("Data3 saved");
                    break;
            }
        }
    }
    
}