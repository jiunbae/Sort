using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SceneMgr : MonoBehaviour {
    public static SceneMgr Instance;

    public static float step = 0.05f;
    public static bool isFade = true, isFading = false, toFade = false;

	void Start ()
    {
        Instance = this;
        Instance.transform.position = new Vector3(.0f, .0f, .0f);
        FadeOut();
    }

	void FixedUpdate ()
    {
        if (isFading)
            StartCoroutine("Timer");
        else
            StopCoroutine("Timer");
	}

    IEnumerator Timer()
    {
        GetComponent<Image>().color += new Color(.0f, .0f, .0f, (toFade ? 1 : -1) * step);
        if (Utility.equal(GetComponent<Image>().color.a, .0f, step / 2) ||
            Utility.equal(GetComponent<Image>().color.a, 1.0f, step / 2))
        {
            isFading = false;
            isFade = toFade;
            if (!isFade)
            {
                transform.position = new Vector3(.0f, 12.0f, .0f);
                GetComponent<Image>().color = new Color(.0f, .0f, .0f, .0f);
            }
            else
                GetComponent<Image>().color = new Color(.0f, .0f, .0f, 1.0f);
        }

        yield return new WaitForSeconds(.001f);
    }

    public static void FadeIn()
    {
        if (isFading)
            return;
        Instance.transform.position = new Vector3(.0f, .0f, .0f);
        isFading = true;
        toFade = true;
    }

    public static void FadeOut()
    {
        if (isFading)
            return;
        Instance.transform.position = new Vector3(.0f, .0f, .0f);
        isFading = true;
        toFade = false;
    }

    public static SceneMgr GetInstance()
    {
        return Instance;
    }
}
