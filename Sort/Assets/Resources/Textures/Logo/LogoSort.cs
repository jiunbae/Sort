using UnityEngine;
using System.Collections;

public class LogoSort : MonoBehaviour {
    bool state_over = false;
    bool state_moving = false;
    
    int sort_count = 3;
    int moving_first, moving_second;

    int[] text_index = { 1, 2, 3, 4 };
    int[] text_final_index = { 1, 2, 3, 4 };
    int[] xs = { 0, -3, -1, 1, 3 };
    static int[] xs_final = { 0, -3, -1, 1, 3 };
    
    SpriteRenderer[] texts;

    // Use this for initialization
    void Start ()
    {
        texts = GetComponentsInChildren<SpriteRenderer>();
        Validate();

        text_index = ArrayShuffle(text_index);
        int[] xss = { 0, 0, 0, 0, 0 };
        for (int i = 1; i < texts.Length; ++i)
            texts[i].transform.position = new Vector3(xss[i] = xs[text_index[i - 1]],
                texts[i].transform.position.y, texts[i].transform.position.z);
        xs = (int[])xss.Clone();
	}

	// Update is called once per frame
	void Update ()
    {
        if (!state_over)
        {
            if (!state_moving)
            {
                state_moving = true;
                StopCoroutine("Timer");
                toChange();
            }
            StartCoroutine("Timer");
        }
	}

    void Validate()
    {
        if (texts.Length != 5)
        {
            throw new System.Exception("err: there must be 4 texts");
        }
    }

    IEnumerator Timer()
    {
        SpriteRenderer first = texts[moving_first], second = texts[moving_second];
        
        if (sort_count > 0)
        {
            if (Utility.equal(first.transform.position.x, xs[moving_second], 0.05f) &&
                Utility.equal(second.transform.position.x, xs[moving_first], 0.05f))
            {
                state_moving = false;

                first.transform.position = new Vector3(xs[moving_second], first.transform.position.y, first.transform.position.z);
                second.transform.position = new Vector3(xs[moving_first], second.transform.position.y, second.transform.position.z);

                int temp = xs[moving_second];
                xs[moving_second] = xs[moving_first];
                xs[moving_first] = temp;
                
                --sort_count;
                yield break;
            }

            first.transform.position += new Vector3((xs[moving_second] - first.transform.position.x) / 8
                , .0f, .0f);
            second.transform.position += new Vector3((xs[moving_first] - second.transform.position.x) / 8
                , .0f, .0f);
        }
        else
        {
            bool chk = true;
            for (int i = 1; i < texts.Length; ++i)
                if (!Utility.equal(texts[i].transform.position.x, xs_final[i], 0.05f))
                    chk = false;

            if (chk)
            {
                state_moving = false;
                state_over = true;

                Global.GetInstance().StateChange(Global.STATE.main_menu);
                yield break;
            }

            for(int i = 1; i < texts.Length; ++i)
                if (!Utility.equal(texts[i].transform.position.x, xs_final[i], 0.03f))
                    texts[i].transform.position += new Vector3((xs_final[i] - texts[i].transform.position.x) / 8, .0f, .0f);
        }

        yield return new WaitForSeconds(.001f);
    }

    bool isSorted(int[] array)
    {
        for (int i = 0; i < array.Length; ++i)
            if (text_final_index[i] != array[i])
                return false;
        return true;
    }

    int[] ArrayShuffle(int[] array)
    {
        int[] ret = (int[])array.Clone();
        int i, j;
        do {
            i = Random.Range(0, ret.Length);
            j = Random.Range(0, ret.Length);
            int temp = ret[i];
            ret[i] = ret[j];
            ret[j] = temp;
        } while (isSorted(ret) || i == j);
        return ret;
    }

    void toMove(int index, int todex)
    {
        moving_first = index;
        moving_second = todex;
    }

    void toChange()
    {
        int[] array = ArrayShuffle(text_index);
        for(int i = 0; i < text_index.Length; ++i)
            if (array[i] != text_index[i])
            {
                toMove(array[i], text_index[i]);
                break;
            }
        text_index = (int[])array.Clone();
    }
}
