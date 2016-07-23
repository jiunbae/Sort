using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Text;

public class Network : MonoBehaviour {

    public static Network Instance;

    public delegate void HttpRequestDelegate(int id, WWW www);
    public event HttpRequestDelegate OnHttpRequest;
    private static string token = "";
    //http://52.78.104.39:5009/
    //http://127.0.0.1:5009/
    public static string server = "http://52.78.104.39:5009/",
        useragent = "application/sort";

    void Start ()
    {
        Instance = this;
	}
	
	void Update ()
    {
	
	}

    public static string getUsername(int id)
    {
        string url = server + "users";
        url += "?id=" + id;
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        System.IO.Stream response = request.GetResponse().GetResponseStream();
        System.IO.StreamReader reader = new System.IO.StreamReader(response);
        string result = reader.ReadToEnd();
        string res = Utility.erase(result);
        JSONObject json = new JSONObject(res.Substring(1, res.Length-2));
        if (!json)
            return null;
        string x = json.GetField("user").ToString();
        Debug.Log(x);

        return Utility.cut(json.GetField("user").ToString());
    }

    public static JSONObject[] getScore()
    {
        int max_size = 5, iter = 0;
        string url = server + "score";
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        System.IO.Stream response = request.GetResponse().GetResponseStream();
        System.IO.StreamReader reader = new System.IO.StreamReader(response);
        
        string result = reader.ReadToEnd();
        if (result.Length < 3)
            return null;
        string res = Utility.erase(result);
        res = res.Substring(2, res.Length - 4);

        string[] table = res.Split(new string[] { "},{" }, System.StringSplitOptions.None);
        int size = System.Math.Min(table.Length, max_size);
        JSONObject[] jsons = new JSONObject[size];
        foreach (string data in table)
        {
            if (iter >= size)
                break;
            JSONObject json = new JSONObject("{" + data + "}");
            json.AddField("name", getUsername(int.Parse(json.GetField("user").ToString())));
            jsons[iter] = json;
            ++iter;
        }
        return jsons;
    }

    public static HttpWebRequest newRequest(string url)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.UserAgent = ".NET Framework Sort Client";
        request.Method = "PUT";
        request.ContentType = "application/json";
        request.Credentials = CredentialCache.DefaultCredentials;
        return request;
    }

    public static JSONObject getResponseJson(WebResponse response)
    {
        System.IO.Stream receive = response.GetResponseStream();
        System.IO.StreamReader reader = new System.IO.StreamReader(receive, Encoding.GetEncoding("utf-8"));
        char[] read = new char[256];
        int count = reader.Read(read, 0, 256);
        string data = "";
        while (count > 0)
        {
            string str = new string(read, 0, count);
            data += str;
            count = reader.Read(read, 0, 256);
        }
        JSONObject json = new JSONObject(data);
        return json;
    }

    public static string Login()
    {
        string url = server + "users";
        url += "?user=" + Global.PlayerName;
        url += "&client=" + Global.LoginType;
        url += "&flag=" + "login";
        HttpWebRequest request = newRequest(url);
        WebResponse rs = request.GetResponse();
        JSONObject json = getResponseJson(rs);
        if (Utility.cut(json.GetField("return").ToString()) != "login")
        {
            UserDialog.setUserName(json.GetField("return").ToString());
            return null;
        }
        token = Utility.cut(json.GetField("token").ToString());
        return  Utility.cut(json.GetField("name").ToString());
    }

    public static void Logout()
    {
        string url = server + "users";
        url += "?user=" + Global.PlayerName;
        url += "&client=" + Global.LoginType;
        url += "&flag=" + "logout";
        url += "&token=" + token;
        HttpWebRequest request = newRequest(url);
        JSONObject json = getResponseJson(request.GetResponse());
        if (Utility.cut(json.GetField("return").ToString()) != "logout")
            return;
        token = "";
    }

    public static void NewScore(JSONObject json)
    {
        string url = server + "score";
        url += "?token=" + token;

        HttpWebRequest request = newRequest(url);
        System.IO.StreamWriter stream = new System.IO.StreamWriter(request.GetRequestStream());

        json.AddField("name", Global.PlayerName);
        stream.Write(json.ToString());
        stream.Flush();
        stream.Close();

        JSONObject response = getResponseJson(request.GetResponse());
        if (Utility.cut(response.GetField("return").ToString()) != "updated")
            return;
    }

    private static bool newTime(string flag)
    {
        string url = server + "time/" + Global.PlayerName;
        url += "?token=" + token;
        url += "&client=" + Global.LoginType;

        JSONObject json = new JSONObject();
        json.AddField("flag", flag);
        json.AddField("time", Utility.timestamp());

        HttpWebRequest request = newRequest(url);
        System.IO.StreamWriter stream = new System.IO.StreamWriter(request.GetRequestStream());

        stream.Write(json.ToString());
        stream.Flush();
        stream.Close();

        JSONObject response = getResponseJson(request.GetResponse());
        if (Utility.cut(response.GetField("return").ToString()) != "accept")
            return false;
        return true;
    }

    public static void GameStart()
    {
        if (newTime("game_start"))
        {

        }
    }

    public static void GameEnd()
    {
        if (newTime("game_end"))
        {

        }
    }

    public static Network GetInstance()
    {
        return Instance;
    }
}
