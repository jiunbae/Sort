using UnityEngine;
using Facebook.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class FacebookLogin : MonoBehaviour {
    public static FacebookLogin instance;

    public static bool isInitilized = false;

    void Start()
    {
        instance = this;
    }
    
    public void Login()
    {
        if (!FB.IsInitialized)
            FB.Init(InitCallBack, onHideUnity);
        else
            FBLogin();
    }
    public void Logout()
    {
        FB.LogOut();
    }

    void InitCallBack()
    {
        isInitilized = true;
        if (FB.IsInitialized)
            FBLogin();
        else
            Debug.Log("facebook initilize failed");
    }

    void onHideUnity(bool isGameShown)
    {
        if(!isGameShown)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    void FBLogin()
    {
        FB.LogInWithReadPermissions(new List<string>() { "public_profile", "email", "user_friends" }, AuthCallback);
    }

    void AuthCallback(ILoginResult result)
    {
        if(FB.IsLoggedIn)
        {
            var aToken = AccessToken.CurrentAccessToken;

            string name = "";
            FB.API("/me?fields=first_name,last_name", HttpMethod.GET, delegate (IGraphResult APIResult ) {
                if (APIResult.ResultDictionary != null)
                {
                    name += APIResult.ResultDictionary["first_name"].ToString();
                    name += APIResult.ResultDictionary["last_name"].ToString();
                }
            });
            Global.GetInstance().Login("facebook", name, aToken.TokenString);
        }
        else
        {
            Debug.Log("facebook login failed");
        }
    }

    public static FacebookLogin GetInstance()
    {
        if (!instance)
            instance = (FacebookLogin) FindObjectOfType(typeof(FacebookLogin));
        return instance;
    }
}
