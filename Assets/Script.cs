using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using Newtonsoft.Json;

public class data
{
    public string str;
    public string Date_time;
}

public class Script : MonoBehaviour
{
    string String = string.Empty;
    Rect Window = new Rect(0, 0, Screen.width, Screen.height);
    Rect Window1 = new Rect(0, 0, Screen.width, Screen.height);
    bool Pop_up_window = false;
    bool Pop_up_window2 = false;
    bool Pop_up_window3 = false;
    bool Pop_up_window4 = false;
    bool Pop_up_window5 = false;
    string DisplaySring = string.Empty;
    private GUIStyle guiStyle = new GUIStyle(); //create a new variable
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        GUI.backgroundColor = Color.blue;
        GUI.Window(0, Window, Display, "String-Input");
        if (Pop_up_window)
        {
            GUI.Window(0, Window1, Display1, "SUBMISSION");
        }
        if (Pop_up_window2)
        {
            GUI.Window(0, Window1, Display2, "");
        }
        if (Pop_up_window3)
        {
            GUI.Window(0, Window1, Display3, "");
        }
        if (Pop_up_window4)
        {
            GUI.Window(0, Window1, Display4, "");
        }
        if (Pop_up_window5)
        {
            GUI.Window(0, Window1, Display5, "");
        }

    }

    void Display(int ID)
    {
        guiStyle.fontSize = 35;
        GUI.Label(new Rect(90,50,80,80), "Enter Data :-", guiStyle);
        String = GUI.TextArea(new Rect(100,100,300,300), String);
        if (GUI.Button(new Rect(410,150,150,100), "RETRIVE"))
        {
            if (File.Exists("Store.txt"))
            {
                DisplaySring = File.ReadAllText("Store.json");
                Pop_up_window2 = true;
            }
            else
            {
                Pop_up_window3 = true;
            }
        }
        if (GUI.Button(new Rect(410, 250, 150, 100), "SUBMIT"))
        {
            if (String.IsNullOrEmpty(String))
            {
                Pop_up_window4 = true;
            }
            else
            {
                if (String.Contains("Electrical"))
                {
                    Pop_up_window5 = true;
                    String = string.Empty;
                }
                else
                {
                    data d = new data();
                    d.Date_time = DateTime.Now.ToString();
                    d.str = String;
                    string JSON_result = JsonConvert.SerializeObject(d);
                    StreamWriter file = new StreamWriter("Store.json");
                    file.Write(JSON_result.ToString());
                    file.Close();
                    Pop_up_window = true;
                    /*StreamWriter file = new StreamWriter("Store.txt");
                    DateTime date = DateTime.Now;
                    string date_time = date.ToString();
                    string Main_string = String + " :- " + date_time;
                    file.Write(Main_string);
                    file.Close();
                    Pop_up_window = true;*/
                    String = string.Empty;
                }
            }
        }
    }

    void Display1(int ID)
    {
        guiStyle.fontSize = 35;
        GUI.Label(new Rect(300,150,120,120), "Record Submitted Successfully", guiStyle);
        if (GUI.Button(new Rect(475, 250, 150, 100), "OK"))
        {
            Pop_up_window = false;
        }

    }
    void Display2(int ID)
    {
        guiStyle.fontSize = 35;
        GUI.Label(new Rect(90, 50, 80, 80), "Retrived Data :-", guiStyle);
        guiStyle.fontSize = 35;
        data d = JsonConvert.DeserializeObject<data>(DisplaySring);
        GUI.TextField(new Rect(new Rect(100, 100, 300, 300)), ""+d.str+" :- "+d.Date_time);
        if (GUI.Button(new Rect(410, 200, 150, 100), "OK"))
        {
            Pop_up_window2 = false;
        }

    }
    void Display3(int ID)
    {
        guiStyle.fontSize = 35;
        GUI.Label(new Rect(400, 150, 120, 120), "No Record Found", guiStyle);
        if (GUI.Button(new Rect(475, 250, 150, 100), "OK"))
        {
            Pop_up_window3 = false;
        }
    }
    void Display4(int ID)
    {
        guiStyle.fontSize = 35;
        GUI.Label(new Rect(400, 150, 120, 120), "Input Can't be empty", guiStyle);
        if (GUI.Button(new Rect(475, 250, 150, 100), "OK"))
        {
            Pop_up_window4 = false;
        }
    }
    void Display5(int ID)
    {
        guiStyle.fontSize = 35;
        GUI.Label(new Rect(350, 150, 120, 120), "OOPS! contains Electrical", guiStyle);
        if (GUI.Button(new Rect(475, 250, 150, 100), "OK"))
        {
            Application.OpenURL("https://picsum.photos/200/300");
            Pop_up_window5 = false;
        }
    }
}

