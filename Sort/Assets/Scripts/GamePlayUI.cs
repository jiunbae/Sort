using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour
{
    public static GamePlayUI Instance;
    public static readonly float TimeStep = (1.0f / 60.0f);

    public Text TimeText, SortedText, MoveText;
    long GameTimeStart = 0, GameMoveStart = 0, GameSortedStart = 0;
    long GameTime = 0, GameMove = 0, GameSorted = 0;
    float LastTime = 0, StartTime = 0, StopTime = 0;
    bool isStop = false;

    void Start()
    {
        Instance = this;
        
        switch(Global.mode)
        {
            case Global.MODE.classic:
                GameMoveStart = 100;
                break;
            case Global.MODE.timelimit:
                GameTimeStart = 100;
                break;
        }

        SortedTextUpdate();
        MoveTextUpdate();
        TimeTextUpdate();
    }

    void Update()
    {

    }

    public void Sorted()
    {
        ++GameSorted;
        SortedTextUpdate();
    }

    void SortedTextUpdate()
    {
        SortedText.text = Utility.fill(GameSorted.ToString(), 3);
    }

    public void Move()
    {
        ++GameMove;
        MoveTextUpdate();
    }

    void MoveTextUpdate()
    {
        MoveText.text = Utility.fill(
            (GameMoveStart == 0 ? GameMove : GameMoveStart - GameMove).ToString(), 3);
    }

    public void StartTimer()
    {
        isStop = false;
        StartTime = Time.time;
        InvokeRepeating("Timer", TimeStep, TimeStep);
    }

    public void StopTimer()
    {
        StopTime = Time.time;
        isStop = true;
        CancelInvoke();
    }

    void Timer()
    {
        GameTime = (int)((Time.time - StartTime) * 100.0f);
        TimeTextUpdate();
    }

    void TimeTextUpdate()
    {
        TimeText.text = Utility.fill(
            (GameTimeStart == 0 ? (GameTime / 100) : GameTimeStart - (GameTime / 100)).ToString(), 3);
    }

    public static GamePlayUI GetInstance()
    {
        return Instance;
    }
}
