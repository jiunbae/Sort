using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePlayUI : MonoBehaviour
{
    public static GamePlayUI Instance;
    public static readonly float TimeStep = (1.0f / 60.0f);

    public Text TimeText, SortedText, MoveText;

    public int minMove = 0;
    long GameTimeStart = 0, GameMoveStart = 0, GameSortedStart = 0;
    long GameTime = 0, GameMove = 0, GameClear = 0;
    float LastTime = 0, StartTime = 0, StopTime = 0;
    bool isStop = false, isPlay = true;

    void Start()
    {
        Instance = this;
        GameTimeStart = 0;
        GameMoveStart = 0;
        switch(Global.mode)
        {
            case Global.MODE.classic:
                GameMoveStart = 30;
                break;
            case Global.MODE.timelimit:
                GameTimeStart = 30;
                break;
        }

        SortedTextUpdate();
        MoveTextUpdate();
        TimeTextUpdate();
    }

    void Update()
    {

    }

    private static int Score(int move, int clear, int time, int min)
    {
        int score = 20 + (clear * 100 - (int)(System.Math.Log(move - min + 25) * 10) - time * 10) / 8;
        if (score < 0)
            score = 0;
        
        return score;
    }

    private static JSONObject pack(int score, int move, int clear, int time)
    {
        JSONObject json = new JSONObject(JSONObject.Type.OBJECT);
        json.AddField("score", score);
        json.AddField("move", move);
        json.AddField("clear", clear);
        json.AddField("time", time);
        json.AddField("mode", Global.mode.ToString());
        return json;
    }

    private void Over()
    {
        isPlay = false;
        int score = Score((int)GameMove, (int)GameClear, (int)(GameTimeStart == 0 ? (GameTime / 100) : GameTimeStart - (GameTime / 100)), minMove);
        GamePlay.GetInstance().EndGame(pack(score, (int)GameMove, (int)GameClear, (int)(GameTimeStart == 0 ? (GameTime / 100) : GameTimeStart - (GameTime / 100))));
    }

    public void Sorted()
    {
        ++GameClear;
        SortedTextUpdate();
    }

    void SortedTextUpdate()
    {
        SortedText.text = Utility.fill(GameClear.ToString(), 3);
    }

    public void Move()
    {
        ++GameMove;
        MoveTextUpdate();
    }

    void MoveTextUpdate()
    {
        if (GameMoveStart > 0 && GameMoveStart - GameMove <= 0)
            Over();
        MoveText.text = Utility.fill(
            (GameMoveStart == 0 ? GameMove : GameMoveStart - GameMove).ToString(), 3);
    }

    public void StartTimer()
    {
        isStop = false;
        isPlay = true;
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
        if (!isPlay)
            return;
        GameTime = (int)((Time.time - StartTime) * 100.0f);
        TimeTextUpdate();
    }

    void TimeTextUpdate()
    {
        if (GameTimeStart > 0 && (GameTimeStart - (GameTime / 100)) <= 0)
            Over();

        TimeText.text = Utility.fill(
            (GameTimeStart == 0 ? (GameTime / 100) : GameTimeStart - (GameTime / 100)).ToString(), 3);

        if (TimeText.text.Length > 3)
            TimeText.text = "999";
        
    }

    public static GamePlayUI GetInstance()
    {
        return Instance;
    }
}
