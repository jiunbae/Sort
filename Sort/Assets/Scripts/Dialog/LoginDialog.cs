using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoginDialog : MonoBehaviour
{
    public static LoginDialog Instance;
    Image[] childs;

    static float alpha = 0.0f, alpha_step = 0.06f;
    public static bool isPoping = false, isPopup = false, toPopup = false;

    void Start()
    {
        Instance = this;
        transform.position = new Vector3(.0f, 3.0f, .0f);
        childs = GetComponentsInChildren<Image>();

        foreach (Image renderer in childs)
            if (renderer.name != this.name)
            {
                renderer.GetComponent<Image>().color = new Color(
                         renderer.GetComponent<Image>().color.r, renderer.GetComponent<Image>().color.g, renderer.GetComponent<Image>().color.b, alpha);
                Text text = renderer.GetComponentInChildren<Text>();
                if (text != null)
                    text.color = renderer.color;
            }
    }

    void Update()
    {
        if (isPoping)
            StartCoroutine("Timer");
        else
            StopCoroutine("Timer");
    }

    IEnumerator Timer()
    {
        alpha += (toPopup ? 1 : -1) * alpha_step;
        if (alpha < 0.0f || alpha > 1.0f)
        {
            isPoping = false;
            isPopup = toPopup;
            if (!isPopup)
                transform.position = new Vector3(.0f, 3.0f, .0f);
        }
        
        foreach (Image renderer in childs)
            if (renderer.name != this.name)
            {
                renderer.GetComponent<Image>().color = new Color(
                         renderer.GetComponent<Image>().color.r, renderer.GetComponent<Image>().color.g, renderer.GetComponent<Image>().color.b, alpha);
                Text text = renderer.GetComponentInChildren<Text>();
                if (text != null)
                    text.color = renderer.color;
            }

        yield return new WaitForSeconds(.001f);
    }

    public static void Popup()
    {
        Instance.transform.position = new Vector3(.0f, -2.3f, .0f);
        if (!isPoping && !isPopup)
        {
            isPoping = true;
            toPopup = true;
        }
    }

    public static void Popdown()
    {
        Instance.transform.position = new Vector3(.0f, -2.3f, .0f);
        if (!isPoping && isPopup)
        {
            isPoping = true;
            toPopup = false;
        }
    }

    public static LoginDialog GetInstance()
    {
        return Instance;
    }
}
