using UnityEngine;
using System.Collections;

public class GuestLogin : MonoBehaviour {
    public static GuestLogin instance;

    void Start()
    {
        instance = this;
    }

    public void Login()
    {
        if (Global.isLogin)
            return;
        Global.GetInstance().Login("Guest", null, null);
    }

    public static GuestLogin GetInstance()
    {
        if (!instance)
            instance = (GuestLogin)FindObjectOfType(typeof(GuestLogin));
        return instance;
    }
}
