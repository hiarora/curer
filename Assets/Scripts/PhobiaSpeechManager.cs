using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class PhobiaSpeechManager : MonoBehaviour
{
    KeywordRecognizer keywordRecognizer = null;
	public GameObject loadingImage;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // Use this for initialization
    void Start()
    {
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
