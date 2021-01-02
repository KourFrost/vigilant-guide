using UnityEngine;
using WebSocketSharp;
public class WebsocketClient : MonoBehaviour
{
    WebSocket ws;
    public GameObject myPrefab;
    private void Start()
    {
        ws = new WebSocket("ws://localhost:8080");
        ws.Connect();
        ws.OnMessage += (sender, e) =>
        {
            ServerMessage serverMessage = JsonUtility.FromJson<ServerMessage>(e.Data);

            // ServerMessage serverMessage = JsonUtility.FromJson<ServerMessage>(e.Data);
            // switch (serverMessage.message) {
            //     case ServerMessagePlayers.message:
            //         WebsocketPlayerModel[] playerModels = (WebsocketPlayerModel[])serverMessage.data;
                    Debug.Log("List of Players"+serverMessage);
            //     break;
            // }
            // Debug.Log("Message Received from "+((WebSocket)sender).Url+", Data : "+e.Data);
            foreach(var playerModel in serverMessage.data)
            {
                Debug.Log(playerModel);
                Instantiate(myPrefab, new Vector3(playerModel.position.x, playerModel.position.y, 0), Quaternion.identity);
            }
        };
    }
    private void Update()
    {
        if(ws == null)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ws.Send("get players");
        }  
    }
}