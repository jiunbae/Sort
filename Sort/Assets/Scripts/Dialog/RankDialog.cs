using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RankDialog : MonoBehaviour {
    public static RankDialog Instance;

    public GameObject canvas;

    bool isPoping = false, isPopup = false, toPopup = false;

	void Start ()
    {
        Instance = this;
        refresh();        
    }
	
    public void init()
    {
        transform.position = new Vector3(Utility.toPPIXScale(1600), transform.position.y, transform.position.z);
    }

    public void refresh()
    {
        JSONObject[] jsons = Network.getScore();
        
        for (int i = 0; i < jsons.Length; ++i)
        {
            GameObject reference = Resources.Load("Prefabs/Scores") as GameObject;
            GameObject Scores = Instantiate(reference) as GameObject;
            Scores.transform.position = new Vector3(
                Scores.transform.position.x, i * -150.0f, Scores.transform.position.z);

            Text[] texts = Scores.GetComponentsInChildren<Text>();
            for(int j = 0; j < texts.Length; ++j)
                texts[j].text = Utility.cut(jsons[i].GetField(texts[j].name).ToString());

            Scores.transform.SetParent(canvas.transform, false);
        }

    }

    void Update ()
    {
	    if (isPoping)
            StartCoroutine("Timer");
        else
            StopCoroutine("Timer");
	}

    public void OnClick()
    {
        if (isPopup)
            Instance.Popdown();
        else
            Instance.Popup();
    }

    void Popup()
    {
        isPoping = true;
        toPopup = true;
    }
    
    void Popdown()
    {
        isPoping = true;
        toPopup = false;
    }

    IEnumerator Timer()
    {
        Vector3 dest = (toPopup ? new Vector3(.0f, transform.position.y, transform.position.z) :
        new Vector3(Utility.toPPIXScale(1600), transform.position.y, transform.position.z));
        if (Utility.moveSmooth(transform, dest))
        {
            transform.position = dest;

            isPoping = false;
            isPopup = toPopup;

        }

        yield return new WaitForSeconds(.001f);
    }

    public static RankDialog GetInstance()
    {
        return Instance;
    }
}
