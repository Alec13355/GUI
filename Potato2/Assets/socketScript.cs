using UnityEngine;

using System.Collections;

using System.Collections.Generic;


using System.Text;

using System;
using UnityEngine.UI;

/// <summary>
/// Base Code found here
/// @Author Girlscancode & Alec Harrison
/// https://girlscancode.wordpress.com/2014/08/27/unity3d-and-tcpip-socket-connections/comment-page-1/
/// 
/// </summary>
public class socketScript : MonoBehaviour
{
 

    public Button Button;
    public Button Button1;
    public Button Button2;
    public Button Button3;
    public Button Button4;
    public Button Button5;
    public Button Button6;
    public Button Button7;
    public Button Button8;
    public Button Button9;
    public Button Button10;
    public Button Button11;
    public Button Button12;
    public Button Button13;
    public Button Button14;

    //variables

    public TCPConnection myTCP;

    private string serverMsg;

    public string msgToServer;
   

    void Awake()
    {

        //add a copy of TCPConnection to this game object

        myTCP = gameObject.AddComponent<TCPConnection>();

    }



    void Start()
    {
        //A listener for each button that calls their own method.
        Button btn = Button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        Button btn1 = Button1.GetComponent<Button>();
        btn1.onClick.AddListener(TaskOnClick1);
        Button btn2 = Button2.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClick2);
        Button btn3 = Button3.GetComponent<Button>();
        btn3.onClick.AddListener(TaskOnClick3);
        Button btn4 = Button4.GetComponent<Button>();
        btn4.onClick.AddListener(TaskOnClick4);
        Button btn5 = Button5.GetComponent<Button>();
        btn5.onClick.AddListener(TaskOnClick5);
        Button btn6 = Button6.GetComponent<Button>();
        btn6.onClick.AddListener(TaskOnClick6);
        Button btn7 = Button7.GetComponent<Button>();
        btn7.onClick.AddListener(TaskOnCLick7);
        Button btn8 = Button8.GetComponent<Button>();
        btn8.onClick.AddListener(TaskOnCLick8);
        Button btn9 = Button9.GetComponent<Button>();
        btn9.onClick.AddListener(TaskOnCLick9);
        Button btn10 = Button10.GetComponent<Button>();
        btn10.onClick.AddListener(TaskOnCLick10);
        Button btn11 = Button11.GetComponent<Button>();
        btn11.onClick.AddListener(TaskOnCLick11);
        Button btn12 = Button12.GetComponent<Button>();
        btn12.onClick.AddListener(TaskOnCLick12);
        Button btn13 = Button13.GetComponent<Button>();
        btn13.onClick.AddListener(TaskOnCLick13);
        Button btn14 = Button14.GetComponent<Button>();
        btn14.onClick.AddListener(TaskOnCLick14);
    }
    //Each method for the button 
    //Each do something different and send it to the bot
    private void TaskOnCLick14()
    {
        myTCP.writeSocket("S");
        Debug.Log("SCAN");
    }
    private void TaskOnCLick13()
    {
        myTCP.writeSocket("i");
        Debug.Log("LED is yellow");
    }

    private void TaskOnCLick12()
    {
        myTCP.writeSocket("o");
        Debug.Log("LED is green");
    }

    private void TaskOnCLick11()
    {
        myTCP.writeSocket("p");
        Debug.Log("LED is red");
    }

    private void TaskOnCLick10()
    {
        myTCP.writeSocket("m");
        Debug.Log("Playing Imperial March");
    }

    private void TaskOnCLick9()
    {
        myTCP.writeSocket("n");
        Debug.Log("Playing Final Countdown");
    }

    private void TaskOnCLick8()
    {
        myTCP.writeSocket("c");
        Debug.Log("Rotating R 45Deg.");
    }

    private void TaskOnCLick7()
    {
        myTCP.writeSocket("d");
        Debug.Log("Rotating R 30Deg.");
    }

    private void TaskOnClick6()
    {
        myTCP.writeSocket("e");
        Debug.Log("Rotating R 15Deg.");
    }

    private void TaskOnClick5()
    {
        myTCP.writeSocket("q");
        Debug.Log("Rotating L 15Deg.");
    }

    private void TaskOnClick4()
    {
        myTCP.writeSocket("a");
        Debug.Log("Rotating L 30Deg.");
    }

    private void TaskOnClick3()
    {
        myTCP.writeSocket("z");
        Debug.Log("Rotating L 45Deg.");
    }

    private void TaskOnClick2()
    {
        myTCP.writeSocket("x");
        Debug.Log("Moving 10x");
    }

    void TaskOnClick()
    {
        myTCP.writeSocket("w");
        Debug.Log("Moving x");
    }
    void TaskOnClick1()
    {
        myTCP.writeSocket("s");
        Debug.Log("Moving 5x");
    }


    void Update()
    {

        

        //keep checking the server for messages, if a message is received from server, it gets logged in the Debug console (see function below)

        SocketResponse();



    }



    void OnGUI()
    {


        //This makes a connect button and starts the button
        //if connection has not been made, display button to connect

        if (myTCP.socketReady == false)
        {



            if (GUILayout.Button("Connect"))
            {

                //try to connect

                Debug.Log("Attempting to connect..");

                myTCP.setupSocket();

            }



        }



        //once connection has been made, display editable text field with a button to send that string to the server (see function below)
        //This is the feild you can enter keyboard inputs
        if (myTCP.socketReady == true)
        {



            msgToServer = GUILayout.TextField(msgToServer);



            if (GUILayout.Button("Write to server", GUILayout.Height(30)))
            {

                SendToServer(msgToServer);

            }



        }





    }



    //socket reading script
    //Recives the characters from the rumba
    void SocketResponse()
    {

        string serverSays = myTCP.readSocket();

        if (serverSays != "")
        {

            Debug.Log("[SERVER]" + serverSays);

        }



    }



    //send message to the server

    public void SendToServer(string str)
    {

        myTCP.writeSocket(str);

        Debug.Log("[CLIENT] -> " + str);

    }



}
