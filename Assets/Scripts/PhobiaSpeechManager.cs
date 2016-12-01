using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using System.Net;
using System.IO;
using HoloToolkit.Unity;

public class PhobiaSpeechManager : MonoBehaviour
{
	private string token;
    private int currLevel = 0;
    private bool levelOn = false;
    public class CoroutineWithData {
     public Coroutine coroutine { get; private set; }
     public object result;
     private IEnumerator target;
     public CoroutineWithData(MonoBehaviour owner, IEnumerator target) {
         this.target = target;
         this.coroutine = owner.StartCoroutine(Run());
     }
    
     private IEnumerator Run() {
         while(target.MoveNext()) {
             result = target.Current;
             yield return result;
         }
     }
	}
   
 	IEnumerator GetToken(System.Action<string> callBack) {
		WWW w = new WWW("http://ec2-54-183-221-129.us-west-1.compute.amazonaws.com/phobiacurer/getRandomToken.php");
		yield return w;
		callBack(w.text);
	}
	
	
	public void FetchToken() {
		GameObject.Find("LoginText").GetComponent<Text>().text = "Fetching token. Please wait ...";
		StartCoroutine(GetToken(callBack => {
        // callBack is going to be null until it’s set
			if(callBack != null) {
            // Now callBack acts as an int
				GameObject.Find("LoginText").GetComponent<Text>().text = "Enter token." + callBack;
				this.token = callBack; 
				GameObject.Find("Start").GetComponent<Text>().text = "Say start to continue";
			}
		}));
	}
	
	IEnumerator ValidateTokenForLogIn(System.Action<string> callBack, string token) {
		Debug.Log("http://ec2-54-183-221-129.us-west-1.compute.amazonaws.com/phobiacurer/validateToken.php?token=" + token);
		WWW w = new WWW("http://ec2-54-183-221-129.us-west-1.compute.amazonaws.com/phobiacurer/validateToken.php?token=" + token);
		yield return w;
		callBack(w.text);
	}
	
	public void ValidateToken() {
		GameObject.Find("Start").GetComponent<Text>().text = "Validating token...";
		StartCoroutine(ValidateTokenForLogIn(callBack => {
        // callBack is going to be null until it’s set
			if(callBack != null) {
            // Now callBack acts as an int
				if(callBack == "Valid")
					Application.LoadLevel(1);
				else
					GameObject.Find("Start").GetComponent<Text>().text = "Invalid. Please make sure you have logged in.";
			}
		}, this.token));
	}

	IEnumerator SendRatingForToken(System.Action<string> callBack, string token, int rating, int level) {
		Debug.Log("http://ec2-54-183-221-129.us-west-1.compute.amazonaws.com/phobiacurer/addDataForUser.php?token=" + token + "&rating=" + rating + "&level=" + level);
		WWW w = new WWW("http://ec2-54-183-221-129.us-west-1.compute.amazonaws.com/phobiacurer/addDataForUser.php?token=" + token + "&rating=" + rating + "&level=" + level);
		yield return w;
		callBack(w.text);
	}
	
	public void SendRatingForToken(int rating, int level) {
		//GameObject.Find("Start").GetComponent<Text>().text = "Validating token...";
		StartCoroutine(SendRatingForToken(callBack => {
        // callBack is going to be null until it’s set
			if(callBack != null) {
            // Now callBack acts as an int
				//GameObject.Find("Start").GetComponent<Text>().text = "Invalid. Please make sure you have logged in.";
			}
		}, this.token, rating, level));
	}
	
	KeywordRecognizer keywordRecognizer = null;
	public GameObject loadingImage;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Use this for initialization
    void Start()
    {
        TextToSpeechManager tts = null;
        tts = this.GetComponent<TextToSpeechManager>();
        keywords.Add("Token", () =>
        {
            //loadingImage.SetActive(true);
            FetchToken();
        });
		
		keywords.Add("Start", () =>
        {
			//loadingImage.SetActive(true);
			ValidateToken();
        });
		keywords.Add("Level One", () =>
        {
            if (currLevel == 0)
            {
                currLevel = 1;
                levelOn = true;
                Application.LoadLevel(2);
            }
        });
		keywords.Add("Level Two", () =>
        {
            if (currLevel == 0)
            {
                currLevel = 2;
                levelOn = true;
                Application.LoadLevel(3);
            }
        });
		keywords.Add("Level Three", () =>
        {
            if (currLevel == 0)
            {
                currLevel = 3;
                levelOn = true;
                Application.LoadLevel(4);
            }
        });
		keywords.Add("Level Four", () =>
        {
            if (currLevel == 0)
            {
                currLevel = 4;
                levelOn = true;
                Application.LoadLevel(5);
            }
        });
		keywords.Add("Level Five", () =>
        {
            if (currLevel == 0)
            {
                currLevel = 5;
                levelOn = true;
                Application.LoadLevel(6);
            }
        });
		keywords.Add("Menu", () =>
        {   
            if (currLevel != 0)
            { 
                if (tts != null)
                {
                    string msg = "Please enter a rating for the amount of fear you've experienced on this level by speaking rate followed by a number from one through five. For example, rate five.";
                    tts.SpeakText(msg);
                }
            }
        });
        keywords.Add("Rate One", () =>
        {
            if (currLevel != 0)
            {
                levelOn = false;
                SendRatingForToken(1, currLevel);
                currLevel = 0;
                Application.LoadLevel(1);
            }
        });
        keywords.Add("Rate Two", () =>
        {
            if (currLevel != 0)
            {
                levelOn = false;
                SendRatingForToken(2, currLevel);
                currLevel = 0;
                Application.LoadLevel(1);
            }
        });
        keywords.Add("Rate Three", () =>
        {
            if (currLevel != 0)
            {
                levelOn = false;
                SendRatingForToken(3, currLevel);
                currLevel = 0;
                Application.LoadLevel(1);
            }
        });
        keywords.Add("Rate Four", () =>
        {
            if (currLevel != 0)
            {
                levelOn = false;
                SendRatingForToken(4, currLevel);
                currLevel = 0;
                Application.LoadLevel(1);
            }
        });
        keywords.Add("Rate Five", () =>
        {
            if (currLevel != 0)
            {
                levelOn = false;
                SendRatingForToken(5, currLevel);
                currLevel = 0;
                Application.LoadLevel(1);
            }
        });
        keywords.Add("Up", () =>
        {
            if (currLevel == 4)
            {
                object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
                foreach (object o in obj)
                {
                    GameObject go = (GameObject)o;
                    if (go.name == "spider")
                        go.GetComponent<OpaqueSpiderWalker>().OpacityUp();
                }
            }   
        });
        keywords.Add("Down", () =>
        {
            if (currLevel == 4)
            {
                object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
                foreach (object o in obj)
                {
                    GameObject go = (GameObject)o;
                    if (go.name == "spider")
                        go.GetComponent<OpaqueSpiderWalker>().OpacityDown();
                }
            }
        });
        keywords.Add("Appear", () =>
        {
            if (currLevel == 4)
            {
                object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
                foreach (object o in obj)
                {
                    GameObject go = (GameObject)o;
                    if (go.name == "spider")
                        go.GetComponent<OpaqueSpiderWalker>().Appear();
                }
            }
        });
        keywords.Add("Disappear", () =>
        {
            if (currLevel == 4)
            {
                object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
                foreach (object o in obj)
                {
                    GameObject go = (GameObject)o;
                    if (go.name == "spider")
                        go.GetComponent<OpaqueSpiderWalker>().Disappear();
                }
            }
        });
        keywords.Add("Stop", () =>
        {
            if (currLevel == 4)
            {
                object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
                foreach (object o in obj)
                {
                    GameObject go = (GameObject)o;
                    if (go.name == "spider")
                        go.GetComponent<OpaqueSpiderWalker>().Stop();
                }
            }
        });
        keywords.Add("Move", () =>
        {
            if (currLevel == 4)
            {
                object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
                foreach (object o in obj)
                {
                    GameObject go = (GameObject)o;
                    if (go.name == "spider")
                        go.GetComponent<OpaqueSpiderWalker>().Move();
                }
            }
        });


        // Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }
    }
}
