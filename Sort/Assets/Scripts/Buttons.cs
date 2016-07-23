using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public void OnClick()
    {
        switch (this.name)
        {
            case "LoginWithFacebook":
                {
                    if (LoginDialog.isPoping)
                        break;
                    if (!Global.isLogin)
                        FacebookLogin.GetInstance().Login();
                    break;
                }
            case "LoginWithGmail":
                {
                    if (LoginDialog.isPoping)
                        break;
                    if (!Global.isLogin)
                        GoogleLogin.GetInstance().Login();
                    break;
                }
            case "LoginWithDefault":
                {
                    if (LoginDialog.isPoping)
                        break;
                    if (!Global.isLogin)
                        GuestLogin.GetInstance().Login();
                    break;
                }
            case "Login":
                {
                    if (MenuDialog.isPoping)
                        break;
                    if (Global.isLogin)
                        Global.GetInstance().Logout();
                    else
                        Global.GetInstance().StateChange(Global.STATE.main_menu);
                    break;
                }
            case "Mode_classic":
                {
                    if (MenuDialog.isPoping)
                        break;
                    Global.GetInstance().LoadLevel("Sort_play");
                    Global.mode = Global.MODE.classic;
                    break;
                }
            case "Mode_time":
                {
                    if (MenuDialog.isPoping)
                        break;
                    Global.GetInstance().LoadLevel("Sort_play");
                    Global.mode = Global.MODE.timelimit;
                    break;
                }
            case "GameOverBg":
                {
                    Global.GetInstance().LoadLevel("Sort");
                    break;
                }
        }
    }
}
