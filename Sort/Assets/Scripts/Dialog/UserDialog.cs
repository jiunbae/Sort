using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserDialog : MonoBehaviour {

    public static UserDialog Instance;

    public Text username;

    bool isPoping = false, toPopup = false, isPopup = false;

	// Use this for initialization
	void Start ()
    {
        transform.position = new Vector3(.0f, 1.5f, .0f);
        isPopup = false;
        Instance = this;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isPoping)
            StartCoroutine("Timer");
        else
            StopCoroutine("Timer");
	}

    IEnumerator Timer()
    {
        Vector3 dest = (toPopup ? new Vector3(.0f, .0f, .0f) : new Vector3(.0f, 1.5f, .0f));

        if (Utility.moveSmooth(transform, dest))
        {
            transform.position = dest;
            isPopup = toPopup;
            isPoping = false;
        }
        yield return new WaitForSeconds(0.01f);
    }

    public static void setUserName(string name)
    {
        Instance.username.text = name;
        Instance.isPoping = true;
        Instance.toPopup = true;
    }

    public static void delUserName()
    {
        Instance.isPoping = true;
        Instance.toPopup = false;
    }

    public static UserDialog GetInstance()
    {
        return Instance;
    }
}
