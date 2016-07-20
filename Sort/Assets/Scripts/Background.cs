using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        StartCoroutine("Timer");
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    void BgMove()
    {
        transform.position += new Vector3(-.05f, 0.0f, 0.0f);
        if (transform.position.x <= -8.709f)
            transform.position = new Vector3(8.0f, .0f, .0f);
        Validate();
    }

    IEnumerator Timer()
    {
        while (true) {
            BgMove();
            yield return new WaitForSeconds(.01f);
        }
    }
    void Validate()
    {
        if (transform.position.x < -9 || transform.position.x > 9)
            throw new System.Exception("err: out of range bg-fg");
    }
}
