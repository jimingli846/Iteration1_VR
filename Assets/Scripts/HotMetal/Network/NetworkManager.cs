using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net.Sockets;
using System.Net;
using System;
using System.Threading;
using System.Text;

public class NetworkManager : Singleton<NetworkManager> {

	public delegate void setStepHandler(string step);
	public event setStepHandler setStep;

	private Socket client;
	private byte[] bytes = new byte[256];
	private Thread thread;
	private string step;

	private static ManualResetEvent connectDone =   
		new ManualResetEvent(false);

	[Serializable]
	public class SAI {
		public string func;
		public string selection;
		public string action;
		public string input;
	}

	[Serializable]
	public class SetStep {
		public string func;
		public string step;
	}

	public void gradeSAI(string selection, string action, string input) {
		Debug.Log ("gradeSAI " + selection + " " + action + " " + input);
		SAI s = new SAI ();
		s.func = "gradeSAI";
		s.selection = selection;
		s.action = action;
		s.input = input;
		string json = JsonUtility.ToJson (s);
		Send (json);
	}

	public void reset() {
		SetStep s = new SetStep ();
		s.func = "reset";
		Send (JsonUtility.ToJson (s));
	}

    void OnDestroy()
    {
        thread.Abort();
        client.Close();
    }

	// Use this for initialization
	void Start () {
        if (true) return;
		try {
			IPAddress ipAddress = Dns.GetHostEntry ("").AddressList [0];
			IPEndPoint remoteEP = new IPEndPoint (ipAddress, 3100);

			client = new Socket (AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			Debug.Log(string.Format("Connecting {0}", remoteEP.ToString()));
			client.BeginConnect (remoteEP, ConnectCallback, null);
			connectDone.WaitOne();

			//Send("This is a test<EOF>");
			Debug.Log("Message sent");

			thread = new Thread(new ThreadStart(ReceiveData));
			thread.IsBackground = true;
			thread.Start();

			reset();
		} catch (Exception e) {
			Console.WriteLine (e.ToString ());
		}
	}

	private void ReceiveData() {
		try {
			while (true) {
				while (client.Available > 0) {
					Debug.Log(1111111111111);
					int bytesRec = client.Receive(bytes);
					String message = Encoding.ASCII.GetString(bytes, 0, bytesRec);
					Debug.Log(message);

					SetStep s = JsonUtility.FromJson<SetStep>(message);
					this.step = s.step;
				}
			}
		} catch (SocketException exception) {
			Debug.Log ("Socket exception: " + exception);
		}
	}

	private void Send(String data) {
        Debug.Log("Send " + data);
		byte[] byteData = Encoding.ASCII.GetBytes (data);

		client.BeginSend(byteData, 0, byteData.Length, 0, SendCallback, null);
	}

	private void SendCallback(IAsyncResult ar) {
		try {
			int bytesSent = client.EndSend(ar);

			Debug.Log(string.Format("Sent {0} bytes to server.", bytesSent));
		} catch (Exception e) {
			Debug.Log (e.ToString ());
		}
	}

	private void ConnectCallback(IAsyncResult ar) {
		try {
			client.EndConnect(ar);

			Debug.Log(string.Format("Socket connected to {0}", client.RemoteEndPoint.ToString()));
			connectDone.Set();
		} catch (Exception e) {
			Debug.Log (e.ToString ());
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (step != null) {
			setStep (step);
			step = null;
		}
	}
}
