using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.Speech;
using System.Net;
using System.IO;


 
public class LoginSpeechManager : MonoBehaviour
{
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
	private string token; 
    KeywordRecognizer keywordRecognizer = null;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();	
	
	IEnumerator GetToken(System.Action<string> callBack) {
		WWW w = new WWW("http://ec2-54-183-221-129.us-west-1.compute.amazonaws.com/phobiacurer/getRandomToken.php");
		yield return w;
		callBack(w.text);
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

    // Use this for initialization
    void Start()
    {
		/*keywords.Add("Token", () =>
        {
			//loadingImage.SetActive(true);
			FetchToken();
        });
		// Tell the KeywordRecognizer about our keywords.
        keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());

        // Register a callback for the KeywordRecognizer and start recognizing!
        keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
        keywordRecognizer.Start();*/
    }

    private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        /*System.Action keywordAction;
        if (keywords.TryGetValue(args.text, out keywordAction))
        {
            keywordAction.Invoke();
        }*/
    }
}
