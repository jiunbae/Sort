using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Linq;
using System.Collections.Generic;

public class GamePlay : MonoBehaviour {
    public static GamePlay Instance;

    public GameObject PlayParent, EndParent;
    public Text CountText, ScoreText, Debugs;

    public Image Normal, Select, Change;

    public AudioSource ef_clear, ef_swap;

    Button Clicked;
    GameObject ReadArray, PlayArray, OverArray;
    int[] PlayArrayInt;
    int MinSwapSize = 0;

    //게임 시작까지 대기 시간
    int count = 3;

        //카운팅 끝내는 중,   카운팅 끝,            끝나는중,           첫 Array
    bool isPoping = false, isCountOver = false, isEnding = false, isFirst = true,
        //게임플레이중,       Array 내려오는 중,  Array 내려가는 중
        isPlaying = false, isDowning = false, isFining = false,
        //클릭했을시,        박스 벌리기,      박스 벌리는 중,      박스 좁히는 중
        isClicked = false, isWide = false, isWiding = false, isNarrowing = false;

    readonly float ARRAYSTART = 600.0f, ARRAYPLAY = .0f, ARRAYEND = -900.0f;

    readonly int[] ARRAY_NARROWED = { -615, -369, -123, 123, 369, 615},
                   ARRAY_WIDED = { -760, -456, -152, 152, 456, 760 };


    void Start()
    {
        Instance = this;
        Global.State = Global.STATE.waiting;
        if (Global.State == Global.STATE.waiting)
        {
            CountText.transform.position += new Vector3(.0f, .0f, .0f);
            for (int i = 0; i < 5; ++i)
                Invoke("CountdownDisplay", i);
        }
    }

    void Update()
    {
        if (isPoping)
            StartCoroutine("CountTimer");
        else
            StopCoroutine("CountTimer");

        if (isDowning)
            StartCoroutine("ArrayDown");
        else
            StopCoroutine("ArrayDown");

        if (isFining)
            StartCoroutine("ArrayFinish");
        else
            StopCoroutine("ArrayFinish");

        if (isNarrowing || isWiding)
            StartCoroutine("ArraySize");
        else
            StopCoroutine("ArraySize");

        if (isEnding)
        {
            StartCoroutine("GameEnding");
        }
        else
            StopCoroutine("GameEnding");

    }

    IEnumerator CountTimer()
    {
        if (Utility.moveSmooth(CountText.transform, new Vector3(
            CountText.transform.position.x, 8.0f, CountText.transform.position.z)))
        {
            isPoping = false;
            yield break;
        }
        yield return new WaitForSeconds(.001f);
    }
    IEnumerator ArrayDown()
    {
        if (Utility.moveSmooth(PlayArray.transform, new Vector3(
            PlayArray.transform.position.x, Utility.toPPIYScale(ARRAYPLAY), PlayArray.transform.position.z)))
        {
            PlayArray.transform.position = new Vector3(
                PlayArray.transform.position.x, Utility.toPPIYScale(ARRAYPLAY), PlayArray.transform.position.z);
            isDowning = false;
            yield break;
        }

        yield return new WaitForSeconds(.001f);
    }
    IEnumerator ArrayFinish()
    {
        if (Utility.moveSmooth(OverArray.transform, new Vector3(
            OverArray.transform.position.x, Utility.toPPIYScale(ARRAYEND), OverArray.transform.position.z)))
        {
            OverArray.transform.position = new Vector3(
                OverArray.transform.position.x, Utility.toPPIYScale(ARRAYEND), OverArray.transform.position.z);

            foreach (Button btn in OverArray.GetComponentsInChildren<Button>())
                btn.onClick.RemoveAllListeners();

            Destroy(OverArray);
            isFining = false;
            yield break;
        }

        yield return new WaitForSeconds(.001f);
    }
    IEnumerator ArraySize()
    {
        int cnt = 0;
        if (isWiding)
        {
            foreach (Button btn in PlayArray.GetComponentsInChildren<Button>())
            {
                int index = int.Parse(btn.name);

                if (Utility.moveSmooth(btn.transform, new Vector3(
                    Utility.toPPIXScale(ARRAY_WIDED[index]),
                    btn.transform.position.y,
                    btn.transform.position.z), 0.3f))
                {
                    btn.transform.position = new Vector3(
                        Utility.toPPIXScale(ARRAY_WIDED[index]),
                        btn.transform.position.y,
                        btn.transform.position.z);
                    cnt++;
                }
            }
            
            if (cnt == PlayArray.GetComponentsInChildren<Button>().Length)
            {
                isWide = true;
                isWiding = false;
                yield break;
            }

        }
        else if(isNarrowing)
        {
            foreach (Button btn in PlayArray.GetComponentsInChildren<Button>())
            {
                int index = int.Parse(btn.name);
                
                if (Utility.moveSmooth(btn.transform, new Vector3(
                    Utility.toPPIXScale(ARRAY_NARROWED[index]),
                    btn.transform.position.y,
                    btn.transform.position.z), 0.3f))
                {
                    btn.transform.position = new Vector3(
                        Utility.toPPIXScale(ARRAY_NARROWED[index]),
                        btn.transform.position.y,
                        btn.transform.position.z);
                    btn.GetComponentInChildren<Image>().sprite = Normal.sprite;
                    cnt++;
                }
            }

            if (cnt == PlayArray.GetComponentsInChildren<Button>().Length)
            {
                isWide = false;
                isNarrowing = false;

                if (isSorted(Instance.PlayArrayInt))
                {
                    Instance.ArrayNext();
                }
                yield break;
            }
        }

        yield return new WaitForSeconds(.001f);
    }
    IEnumerator GameEnding()
    {
        if (Utility.moveSmooth(EndParent.transform, new Vector3(
            EndParent.transform.position.x, 1.0f, EndParent.transform.position.z)))
        {
            EndParent.transform.position = new Vector3(
              EndParent.transform.position.x, 1.0f, EndParent.transform.position.z);

            isEnding = false;
            yield break;
        }
        yield return new WaitForSeconds(0.01f);
    }

    void DisplayText(string text)
    {
        CountText.text = text;
    }

    void CountdownDisplay()
    {
        if (count <= 0 && !isCountOver)
        {
            isCountOver = true;
            DisplayText("Start!");
            Invoke("Popup", .1f);
            StartGame();
        }
        else if(!isCountOver)
            DisplayText((count--).ToString());
    }

    private void StartGame()
    {
        // add here: network - game start point
        Global.State = Global.STATE.playing;
        GamePlayUI.GetInstance().StartTimer();
        Network.GameStart();
        isPlaying = true;
        isFirst = true;
        ArrayNext();
    }

    public void EndGame(JSONObject json)
    {
        ScoreText.text = json.GetField("score").ToString();
        isEnding = true;
        isPlaying = false;
        ArrayOver();
        Network.NewScore(json);
        Network.GameEnd();
    }

    private void Popup()
    {
        isPoping = true;
    }

    void ArrayNext()
    {
        if (isFining || isDowning)
            return;

        isWide = false;
        isWiding = false;
        isNarrowing = false;

        if (!isFirst)
            ArrayOver();
        else
            isFirst = false;
        ArrayPrepare();
    }

    private void ArrayPrepare()
    {
        ReadArray = NewArray();
        ReadArray.transform.position = new Vector3(
            ReadArray.transform.position.x, Utility.toPPIYScale(600), ReadArray.transform.position.z);

        PlayArray = ReadArray;
        ReadArray = null;
        isDowning = true;
    }

    private void ArrayOver()
    {
        OverArray = PlayArray;
        isFining = true;
    }

    private GameObject NewArray()
    {
        GameObject reference = Resources.Load("Prefabs/Array") as GameObject;
        GameObject Array = Instantiate(reference) as GameObject;
        
        MinSwapSize = GetMinSwapSize(PlayArrayInt = CreateSwapedArray());
        GamePlayUI.GetInstance().minMove += MinSwapSize;
        Button[] Arrays = Array.GetComponentsInChildren<Button>();
        for (int i = 0; i < Arrays.Length; ++i)
        {
            Button btn = Arrays[i];
            btn.name = i.ToString();
            btn.GetComponentInChildren<Text>().text = PlayArrayInt[i].ToString();
            btn.onClick.AddListener(() => OnClick(btn));
        }

        Array.transform.SetParent(PlayParent.transform, false);

        return Array;
    }
    
    void ButtonSwap(Button tar)
    {
        if (Clicked == null)
            return;
        
        int first = int.Parse(tar.name), second = int.Parse(Clicked.name);
        int temp = PlayArrayInt[first];
        PlayArrayInt[first] = PlayArrayInt[second];
        PlayArrayInt[second] = temp;

        string text = tar.name;
        tar.name = Clicked.name;
        Clicked.name = text;

        ef_swap.PlayOneShot(ef_swap.clip);

        if (isSorted(Instance.PlayArrayInt))
        {
            GamePlayUI.GetInstance().Sorted();
            ef_clear.PlayOneShot(ef_clear.clip);
        }
    }

    public static void OnClick(Button btn)
    {
        if(!Instance.isWide)
        {
            Instance.isClicked = true;
            Instance.isWiding = true;
            Instance.Clicked = btn;
            btn.GetComponentInChildren<Image>().sprite = Instance.Select.sprite;
        }
        else
        {
            Instance.ButtonSwap(btn);
            Instance.isClicked = false;
            Instance.isNarrowing = true;

            if (btn.name != Instance.Clicked.name)
            {
                btn.GetComponentInChildren<Image>().sprite = Instance.Change.sprite;
                GamePlayUI.GetInstance().Move();
            }
            else
                Instance.Clicked.GetComponentInChildren<Image>().sprite = Instance.Normal.sprite;

            Instance.Clicked = null;
        }
    }

    public static bool isSorted(int[] array)
    {
        return isSorted(array, (int f, int s) => { return f > s; });
    }

    public static bool isSorted(int[] array, Func<int, int, bool> func)
    {
        if (array.Length < 2)
            return true;
        for (int i = 1; i < array.Length; ++i)
            if (func(array[i - 1], array[i]))
                return false;
        return true;
    }

    public static int[] CreateSortedArray(int low = 1, int high = 9, int size = 6)
    {
        List<int> linear = (from i in Enumerable.Range(low, high) select i).ToList();

        size = linear.Count - size;
        while(size-- > 0)
            linear.RemoveAt(Utility.random.Next(0, linear.Count));

        return linear.ToArray();
    }

    public static int[] CreateSwapedArray(int low = 1, int high = 9, int size = 6)
    {
        int swap_size = Utility.random.Next(3, 10);
        int[] ret = CreateSortedArray(low, high, size);

        do {
            for(int k = 0; k < swap_size; ++k)
            {
                int i = Utility.random.Next(0, size), j = Utility.random.Next(0, size);
                int temp = ret[i];
                ret[i] = ret[j];
                ret[j] = temp;
            }
        } while (isSorted(ret));

        return ret;
    }

    public static int GetMinSwapSize(int[] ary)
    {
        List<int> array = ary.ToList(), arraySort = ary.ToList();
        arraySort.Sort();

        bool[] chk = Enumerable.Repeat(false, array.Count).ToArray();

        int cycle = 0;

        for(int i = 0, idx; i < arraySort.Count; ++i)
        {
            if (chk[i])
                continue;

            chk[idx = i] = true;
            while(arraySort[i] != array[idx])
                chk[idx = arraySort.FindIndex((int v) => {
                    return array[idx] == v;
                })] = true;
            ++cycle;
        }
        
        return array.Count - cycle;
    }

    public static GamePlay GetInstance()
    {
        return Instance;
    }
}
