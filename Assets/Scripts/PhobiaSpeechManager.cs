using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using System.Net;
using System.IO;

public class PhobiaSpeechManager : MonoBehaviour
{
	private string token;
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
	
	KeywordRecognizer keywordRecognizer = null;
	public GameObject loadingImage;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Use this for initialization
    void Start()
    {
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
		
		keywords.Add("One", () =>
        {
			//loadingImage.SetActive(true);
			Application.LoadLevel(1);
        });
		keywords.Add("Two", () =>
        {
            //loadingImage.SetActive(true);
            Application.LoadLevel(2);    
        });
		keywords.Add("Three", () =>
        {
			//loadingImage.SetActive(true);
			Application.LoadLevel(3);
        });
		keywords.Add("Four", () =>
        {
			//loadingImage.SetActive(true);
			Application.LoadLevel(4);
        });
		keywords.Add("Five", () =>
        {
			//loadingImage.SetActive(true);
			Application.LoadLevel(5);
        });
		keywords.Add("Menu", () =>
        {
			//loadingImage.SetActive(true);
			Application.LoadLevel(0);
        });
        keywords.Add("Up", () =>
        {
            object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
            foreach (object o in obj)
            {
                GameObject go = (GameObject)o;
                if (go.name == "spider")
                    go.GetComponent<OpaqueSpiderWalker>().OpacityUp();
            }
        });
        keywords.Add("Down", () =>
        {
            object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
            foreach (object o in obj)
            {
                GameObject go = (GameObject)o;
                if (go.name == "spider")
                    go.GetComponent<OpaqueSpiderWalker>().OpacityDown();
            }
        });
        keywords.Add("Appear", () =>
        {
            object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
            foreach (object o in obj)
            {
                GameObject go = (GameObject)o;
                if (go.name == "spider")
                    go.GetComponent<OpaqueSpiderWalker>().Appear();
            }
        });
        keywords.Add("Disappear", () =>
        {
            object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
            foreach (object o in obj)
            {
                GameObject go = (GameObject)o;
                if (go.name == "spider")
                    go.GetComponent<OpaqueSpiderWalker>().Disappear();
            }
        });
        keywords.Add("Stop", () =>
        {
            object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
            foreach (object o in obj)
            {
                GameObject go = (GameObject)o;
                if (go.name == "spider")
                    go.GetComponent<OpaqueSpiderWalker>().Stop();
            }
        });
        keywords.Add("Move", () =>
        {
            object[] obj = GameObject.FindObjectsOfType(typeof(GameObject));
            foreach (object o in obj)
            {
                GameObject go = (GameObject)o;
                if (go.name == "spider")
                    go.GetComponent<OpaqueSpiderWalker>().Move();
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
