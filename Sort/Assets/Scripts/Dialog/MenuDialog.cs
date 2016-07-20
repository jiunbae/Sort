using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuDialog : MonoBehaviour {
    public static MenuDialog Instance;
    
    public Text LoginText;
    public GameObject LoginButton;
    public Sprite Sprite, Red_Sprite;

    static float delta = 0.1f;
    public static bool isPoping = false, isPopup = false, toPopup = false;
    
    void Start ()
    {
        Instance = this;
        transform.position = new Vector3(transform.position.x, -1.8f, transform.position.z);
    }

	void Update ()
    {
        if (isPoping)
            StartCoroutine("Timer");
        else
            StopCoroutine("Timer");
    }

    IEnumerator Timer()
    {
        transform.position += new Vector3(.0f, (toPopup ? 1 : -1) * delta, .0f);

        if (transform.position.y > .0f || transform.position.y < -1.8f)
        {
            if (transform.position.y > 0.0f)
                transform.position = new Vector3(transform.position.x, .0f, transform.position.z);
            if (transform.position.y < -1.8f)
                transform.position = new Vector3(transform.position.x, -1.8f, transform.position.z);

            isPoping = false;
            isPopup = toPopup;
        }
        
        yield return new WaitForSeconds(.001f);
    }
    public static void Popup()
    {
        if (!isPoping && !isPopup)
        {
            if (Global.isLogin && !Global.isGuest)
            {
                Instance.LoginText.text = "Logout";
                Instance.LoginButton.GetComponent<Image>().sprite = Instance.Red_Sprite;
            }
            else
            {
                Instance.LoginText.text = "Login";
                Instance.LoginButton.GetComponent<Image>().sprite = Instance.Sprite;
            }
            isPoping = true;
            toPopup = true;
        }
    }

    public static void Popdown()
    {
        if (!isPoping && isPopup)
        {
            isPoping = true;
            toPopup = false;
        }
    }

    public static MenuDialog GetInstance()
    {
        return Instance;
    }
}
