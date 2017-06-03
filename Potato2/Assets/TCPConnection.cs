using UnityEngine;
using System.Collections;
using System;
using System.IO;
using System.Net.Sockets;
/// @Author Girlscancode & Alec Harrison
/// https://girlscancode.wordpress.com/2014/08/27/unity3d-and-tcpip-socket-connections/comment-page-1/
///
public class TCPConnection : MonoBehaviour
{

    //the name of the connection, not required but better for overview if you have more than 1 connections running
    public string conName = "Localhost";

    //ip/address of the bot
    public string conHost = "192.168.1.1";

    //port for the bot
    public int conPort = 42880;

    //a true/false variable for connection status
    public bool socketReady = false;

    TcpClient mySocket;
    NetworkStream theStream;
    StreamWriter theWriter;
    StreamReader theReader;

    //try to initiate connection
    public void setupSocket()
    {
        try
        {
            mySocket = new TcpClient(conHost, conPort);
            theStream = mySocket.GetStream();
            theWriter = new StreamWriter(theStream);
            theReader = new StreamReader(theStream);
            socketReady = true;
        }
        catch (Exception e)
        {
            Debug.Log("Socket error:" + e);
        }
    }

    //send char to the bot
    public void writeSocket(string theLine)
    {
        if (!socketReady)
            return;
        String tmpString = theLine + "\r\n";
        theWriter.Write(tmpString);
        theWriter.Flush();
    }

    //read characters from bot
    public string readSocket()
    {
        String result = "";
        if (theStream.DataAvailable)
        {
            Byte[] inStream = new Byte[mySocket.SendBufferSize];
            theStream.Read(inStream, 0, inStream.Length);
            result += System.Text.Encoding.UTF8.GetString(inStream);
        }
        return result;
    }

    //disconnect from the socket
    public void closeSocket()
    {
        if (!socketReady)
            return;
        theWriter.Close();
        theReader.Close();
        mySocket.Close();
        socketReady = false;
    }

    //keep connection alive, reconnect if connection lost
    public void maintainConnection()
    {
        if (!theStream.CanRead)
        {
            setupSocket();
        }
    }


}