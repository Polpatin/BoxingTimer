using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
namespace TimerApp
{
    public class MainPage : MonoBehaviour
    {
       //masshtab      
       //design 
      //sec regulirvka
      //Quit button
      //fix pause button-set unactive
        
        //рабочие
        public int sec;
        public int min;
        public int amountround;
        public int currentround;
        public bool TimerOn =false;
        public string workStatus;

        public float workprogress;
        public float restprogress;
        //отдых
        public int restsec;
        public int restmin;
        public bool RestOn = false;



        public float weringGlvsTime = 11;
        //поля

        public Image RedCirkle;
        public GameObject ProfileInfo;
        public GameObject Vremya;
        public GameObject Round;
        public GameObject PauseButton;
        public GameObject PauseBttnText;
        public GameObject StartBttnText;
        public AudioSource TikSound;
        public AudioSource GongSound1;
        public AudioSource TripleGong;
        public AudioSource DoorKnokingSound;
       
        //временное хранилище
        public static string tempProfile ;
        public static int tempRoundAmount;
        public static int tempcurrentround;
        public static int tempmin;
        public static int tempsec ;
        public static int temprestmin;
        public static int temprestsec ;

        public static bool reglfmentSetted;
        public static bool startCliked;
        public static bool glovesWered = false;

        public void WeringGloves()
        {
            workStatus = "wering";
            if (glovesWered == false)
            {
               // WerinGlovesProgress();
                Invoke("WeringGloves", 1f);
                weringGlvsTime--;
                TikSound.Play();
                if (weringGlvsTime <= 0)
                {
                    glovesWered = true; 
                    TimerOn = true; 
                    CancelInvoke();  GongSound1.Play(); 
                    TimeRun();
                    RedCirkle.GetComponent<Image>().fillAmount = workprogress;

                    Vremya.GetComponent<Text>().text = min.ToString("00") + ":" + sec.ToString("00");

                    Round.GetComponent<Text>().text = "Round:" + currentround.ToString("0") + ("/") + tempRoundAmount.ToString("0");
                }
                else
                {
                    Round.GetComponent<Text>().text = "Get ready";
                    RedCirkle.GetComponent<Image>().fillAmount = 0;
                    Vremya.GetComponent<Text>().text = "00" + ":" + weringGlvsTime.ToString("00");
                }
            }
         
          
        }
        public void TimeRun()
        {
            workStatus = "timer";
            if (TimerOn == true)
            {
                Invoke("TimeRun", 1f);
                sec--;
                DorKnoking();
                WorckProgress();

               

                switch (sec)
                {
                    
                    case (-5):
                        goto case (-1);
                    //case (-2):
                    //    goto case (-1);
                    //    break;
                    case (-1):

                        min--; sec = 59;

                        RedCirkle.GetComponent<Image>().fillAmount = workprogress;

                        Vremya.GetComponent<Text>().text = min.ToString("00") + ":" + sec.ToString("00");

                        Round.GetComponent<Text>().text = "Round:" + currentround.ToString("0") + ("/") + tempRoundAmount.ToString("0");
                        break;
                    default:
                        RedCirkle.GetComponent<Image>().fillAmount = workprogress;

                        Vremya.GetComponent<Text>().text = min.ToString("00") + ":" + sec.ToString("00");

                        Round.GetComponent<Text>().text = "Round:" + currentround.ToString("0") + ("/") + tempRoundAmount.ToString("0");
                        break;

                }
                switch (min)
                {
                    case (-1):
                        
                        if(currentround==tempRoundAmount)
                        {
                           
                            reglfmentSetted = false;
                            currentround = tempRoundAmount;
                            min = 0; sec = 0;
                            CancelInvoke();
                            TripleGong.Play();
                            workprogress = 0;

                            RedCirkle.GetComponent<Image>().fillAmount = workprogress;

                            Vremya.GetComponent<Text>().text = min.ToString("00") + ":" + sec.ToString("00");

                            Round.GetComponent<Text>().text = "Round:" + currentround.ToString("0") + ("/") + tempRoundAmount.ToString("0");
                        }
                        else
                        {

                            
                            RestOn = true; TimerOn = false; CancelInvoke(); Reglament();  RestRun(); GongSound1.Play();
                            RedCirkle.GetComponent<Image>().fillAmount = workprogress;

                            //Vremya.GetComponent<Text>().text = min.ToString("00") + ":" + sec.ToString("00");

                            //Round.GetComponent<Text>().text = "Round:" + currentround.ToString("0") + ("/") + tempRoundAmount.ToString("0");
                        }    

                        break;
                    case (-2):
                        goto case (-1);
                }

               
               
                


            }

        }

        public void RestRun()
        {
            workStatus = "rest";
            if (RestOn == true)
            {
                Invoke("RestRun", 1f);
                RestProgress();
                restsec--;
                DorKnoking();
                switch (restsec)
                {
                    case (-1):
                        restmin--; restsec = 59;
                        break;
                  
                    case (-4):
                        goto case (-1);
                }
                switch (restmin)
                {
                    case (-1):
                        RestOn = false; TimerOn = true; Reglament();  currentround++; CancelInvoke(); TimeRun(); GongSound1.Play();
                        break;
                    case (-5):
                        RestOn = false; TimerOn = true; Reglament(); currentround--; TimeRun(); GongSound1.Play();
                        break;
                    default:
                        RedCirkle.GetComponent<Image>().fillAmount = workprogress;
                        Round.GetComponent<Text>().text = "Rest:" + currentround.ToString("0") + ("/") + (tempRoundAmount - 1).ToString("0");
                        Vremya.GetComponent<Text>().text = restmin.ToString("00") + ":" + restsec.ToString("00");
                        break;
                }
                
               

            }



        }



        public void StartTimer()
        {
           

            if (startCliked == false)
            {
                TimerOn = true; startCliked = true; glovesWered = false; Reglament(); weringGlvsTime = 6; WeringGloves();
                StartBttnText.GetComponent<Text>().text = "Restart";
            }
            else
            {
                StopTimer(); startCliked = true; reglfmentSetted = false;
                Reglament(); glovesWered = false; weringGlvsTime = 6; WeringGloves();
                StartBttnText.GetComponent<Text>().text = "Restart";
            }

        }

        public void StopTimer()
        {
            
            
            workStatus = "stop";
            CancelInvoke();
            TimerOn = false; min = 0; sec = 0; restsec = 0; restmin = 0; currentround = 1; workprogress = 1;
            startCliked = false; glovesWered = false;
            RedCirkle.GetComponent<Image>().fillAmount = workprogress;
            Vremya.GetComponent<Text>().text =("00:00");
            Round.GetComponent<Text>().text = (" ");
            StartBttnText.GetComponent<Text>().text = "Start";



        }

        public void PlayPause() //Умеет останавливать только раунды
        {
           
            if (workStatus == "wering")
            {

                if (glovesWered == false)
                {
                    glovesWered = true;
                    CancelInvoke();
                    PauseBttnText.GetComponent<Text>().text = "Continue";
                }
                else if (glovesWered == true)
                {
                    glovesWered = false;
                    PauseBttnText.GetComponent<Text>().text = "Pause";
                    WeringGloves();
                    
                }
               
                Debug.LogError("Сработала перчаткопауза");
            }
            if (workStatus == "timer")
            {
                if (TimerOn == true)
                {
                    TimerOn = false;
                    CancelInvoke();
                    PauseBttnText.GetComponent<Text>().text = "Continue";
                }
                else if (TimerOn == false)
                {
                    TimerOn = true; 
                    PauseBttnText.GetComponent<Text>().text = "Pause";
                    TimeRun();
                }
                Debug.LogError("Сработала таймерпауза");
            }

            if (workStatus == "rest")
            {
                if (RestOn == true)
                {
                    RestOn = false;
                    CancelInvoke();
                    PauseBttnText.GetComponent<Text>().text = "Continue";
                }
                else if (RestOn == false)
                {
                    RestOn = true; 
                    PauseBttnText.GetComponent<Text>().text = "Pause";
                    RestRun();
                }
                Debug.LogError("Сработала отдыхпауза");
            }
            
        }
    

        public void Reglament()
        {
            if (reglfmentSetted == false)
            {
                amountround = tempRoundAmount;
                currentround = 1 ;
                min = tempmin;
                sec = tempsec;
                restmin = temprestmin;
                restsec = temprestsec;
                reglfmentSetted = true;

               

              
            }
            else
            {
                min = tempmin;
                sec = tempsec;
                restmin = temprestmin;
                restsec = temprestsec;
            }
        }

        public void GoSetOptions()
        {
          
            SceneManager.LoadScene(1);
            
        }

        public void WorckProgress()
        {
            //workprogress = 0.5f;
            workprogress =1f- (1f / ((tempmin * 60f)+tempsec))*((min*60f)+sec);
            RedCirkle.fillAmount = workprogress;
        }
        public void RestProgress()
        {
            workprogress =1f- (1f / ((temprestmin * 60f) + temprestsec)) * ((restmin * 60f) + restsec);
            RedCirkle.fillAmount = workprogress;
        }
        public void WerinGlovesProgress()
        {
            workprogress = (1f / 6f) * weringGlvsTime;
        }

        public void IsRoundsEnd()
        {
            if(currentround==tempRoundAmount)
            {
                Vremya.GetComponent<Text>().text = "00" + ":" + weringGlvsTime.ToString("00");
                CancelInvoke();//добавить тройной гонг
                TripleGong.Play();
            }

        }

        public void DorKnoking()
        {
            if (workStatus == "timer")
            {
                if (sec == 10 & min==0)
                   {
                    DoorKnokingSound.Play();
                
                }
            }
            if (workStatus == "rest")
            {
                if (restsec == 10 & restmin==0)
                {
                    DoorKnokingSound.Play();
                  


                }
            }
        }
        public void QuittApp()
        {
           
            Application.Quit();
        }
        public void Start()
        {
              if(tempProfile=="")
            {
                
                tempProfile = "Standart";
                tempRoundAmount = 3;
                tempcurrentround = 1;
                tempmin = 2;
                tempsec = 60;
                temprestmin = 0;
                temprestsec = 60;
                ProfileInfo.GetComponent<Text>().text = "Profile: " + tempProfile;
                Debug.LogError("There is no save data!");
            }




           else
            {
                tempProfile = PlayerPrefs.GetString("ProfileName");
                tempRoundAmount = PlayerPrefs.GetInt("RoundAmount");
                tempcurrentround = PlayerPrefs.GetInt("CurrentRound");
                tempmin = PlayerPrefs.GetInt("Minuts");
                tempsec = PlayerPrefs.GetInt("Seconds");
                temprestmin = PlayerPrefs.GetInt("RestMinuts");
                temprestsec = PlayerPrefs.GetInt("RestSeconds");
                ProfileInfo.GetComponent<Text>().text = "Profile: " + tempProfile;
                Debug.LogError("Data loaded sukcesful");
            }
          


        }
      
    }


}