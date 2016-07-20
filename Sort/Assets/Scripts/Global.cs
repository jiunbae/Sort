using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Global : MonoBehaviour {

    public enum STATE { loading, main_menu, waiting, playing, dead };
    public enum MODE { classic, timelimit, aracde };

    public static Global instance;

    public static bool isLogin = false, isGuest = true, isLeveling = false;

    public static string PlayerName = "", LoginType = "Guest", Level = "Sort";
    private static string Logintoken, scene;

    public static STATE State = STATE.loading;
    public static  MODE mode = MODE.classic;

	void Start ()
    {
        if (name == "Sort")
            State = STATE.loading;
        else if (name == "Sort_play")
            State = STATE.waiting;
            
        instance = this;
	}
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Level == "Sort")
                Application.Quit();
            else if (Level == "Sort_play")
                LoadLevel("Sort");
        }
            

        if (isLeveling)
            StartCoroutine("Timer");
        else
            StopCoroutine("Timer");
    }

    public void StateChange(STATE state)
    {
        switch (state)
        {
            case STATE.loading:
                {
                    break;
                }
            case STATE.main_menu:
                {
                    if (isLogin)
                        MenuDialog.Popup();
                    else
                        LoginDialog.Popup();
                    break;
                }
            case STATE.waiting:
                {
                    break;
                }
            case STATE.playing:
                {
                    break;
                }
            case STATE.dead:
                {
                    break;
                }
        }
    }

    public void Login(string type, string name, string token)
    {
        if (State != STATE.main_menu && isLogin)
            return;

        isLogin = true;
        LoginType = type;
        PlayerName = name;
        Logintoken = token;
        
        if (type == "Guest")
        {
            isGuest = true;
            PlayerName = "Guest";
        }
        else
            isGuest = false;
        
        LoginDialog.Popdown();
        MenuDialog.Popup();
    }

    public void Logout()
    {
        if (State != STATE.main_menu && !isLogin)
            return;

        if(isLogin)
        {
            if(LoginType == "facebook")
            {
                FacebookLogin.GetInstance().Logout();
            }
            else if(LoginType == "google")
            {
                GoogleLogin.GetInstance().Logout();
            }
        }

        isLogin = false;
        LoginType = "Guest";
        PlayerName = "";
        Logintoken = "";
        
        LoginDialog.Popup();
        MenuDialog.Popdown();
    }

    public void LoadLevel(string level)
    {
        if (isLeveling)
            return;
        SceneMgr.FadeIn();
        scene = level;
        isLeveling = true;

        if (Level == "Sort")
        {
            MenuDialog.Popdown();
            LoginDialog.Popdown();
        }
    }

    private void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        isLeveling = false;
        Level = scene;
    }

    IEnumerator Timer()
    {
        if (!SceneMgr.isFading)
            LoadScene(scene);
        yield return new WaitForSeconds(.001f);
    }

    public static Global GetInstance()
    {
        return instance;
    }
}
