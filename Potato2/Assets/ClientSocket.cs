using UnityEngine;                        // These are the librarys being used
using System.Collections;
using System;
using System.IO;
using System.Net.Sockets;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
/// <summary>
/// Base Code found here
/// https://girlscancode.wordpress.com/2014/08/27/unity3d-and-tcpip-socket-connections/comment-page-1/
/// </summary>
public class ClientSocket : MonoBehaviour
{

    public static void StartClient()
    {
        // Data buffer for incoming data.  
        byte[] bytes = new byte[1024];

        // Connect to a remote device.  
        try
        {
            // Establish the remote endpoint for the socket.  
            // This example uses port 11000 on the local computer.  
            IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint remoteEP = new IPEndPoint(ipAddress, 42880);

            // Create a TCP/IP  socket.  
            Socket sender = new Socket(AddressFamily.InterNetwork,
                SocketType.Raw, ProtocolType.Raw);

         
            try
            {
                sender.Connect(remoteEP);

                Debug.Log("Socket connected to {0}");

                // Encode the data string into a byte array.  
                byte[] msg = Encoding.ASCII.GetBytes("$");

                // Send the data through the socket.  
                int bytesSent = sender.Send(msg);

                // Receive the response from the remote device.  
                int bytesRec = sender.Receive(bytes);
                Debug.Log("Echoed test = {0}");
                
                
                // Release the socket.  
                sender.Shutdown(SocketShutdown.Both);
                sender.Close();

            }

            catch (ArgumentNullException ane)
            {
                Debug.Log("ArgumentNullException : {0} Null");
            }
            catch (SocketException se)
            {
                Debug.Log("SocketException : {0} Socket");
            }
            catch (Exception e)
            {
                Debug.Log("Unexpected exception : {0} E");
            }

        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
    }


    void Start()
    {
        StartClient();
        // setup the server connection when the program starts
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}