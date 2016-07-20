using UnityEngine;
using System.Collections;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using GooglePlayGames.BasicApi.Multiplayer;
using UnityEngine.SocialPlatforms;

using System;
using UnityEngine.UI;

public class GoogleLogin : MonoBehaviour {
    public static GoogleLogin instance;

    public static bool isInitilized = false;

    void Start()
    {
        instance = this;
        if (!isInitilized)
            Initilize();
    }

    public void Login()
    {
        if (!PlayGamesPlatform.Instance.localUser.authenticated)
            PlayGamesPlatform.Instance.Authenticate(GLogin);
        else
        {
            Debug.Log("google login failed");
        }
    }

    public void Logout()
    {
        if (PlayGamesPlatform.Instance.localUser.authenticated)
        {
            ((GooglePlayGames.PlayGamesPlatform)Social.Active).SignOut();
        }
    }

    void Initilize()
    {

        PlayGamesPlatform.DebugLogEnabled = true;
        PlayGamesPlatform.Activate();
        isInitilized = true;
    }

    void MatchCallback(TurnBasedMatch match, bool shouldAutoLaunch)
    {
        throw new NotImplementedException();
    }

    void InvitationCallback(Invitation invitation, bool shouldAutoAccept)
    {
        throw new NotImplementedException();
    }

    void GLogin(bool result)
    {
        if (result)
        {
            if (Social.localUser.userName == null)
                return;
            Global.GetInstance().Login("google", Social.localUser.userName, PlayGamesPlatform.Instance.GetToken());
        }
        else
        {
            Debug.Log("google login failed2");
        }
    }

    void GLogout()
    {
        if (Social.localUser.authenticated)
            ((PlayGamesPlatform)Social.Active).SignOut();
    }

    string GetGName()
    {
        if (Social.localUser.authenticated)
            return Social.localUser.userName;
        return null;
    }

    Texture2D GetGProfile()
    {
        if (Social.localUser.authenticated)
            return Social.localUser.image;
        return null;

    }
    public static GoogleLogin GetInstance()
    {
        if (!instance)
            instance = (GoogleLogin)FindObjectOfType(typeof(GoogleLogin));
        return instance;
    }
}
