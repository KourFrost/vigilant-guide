using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ServerMessage
{
    public string message;
    public WebsocketPlayerModel[] data;
}

[Serializable]
public class ClientGetPlayersMessage
{
    public string MESSAGE = "get players";
}
[Serializable]
public class ClientAddPlayerMessage
{
    public string MESSAGE = "add players";
}

[Serializable]
public class ServerMessagePlayers
{
    public const string message = "players";
}

[Serializable]
public class WebsocketPlayerModel
{
    public int playerId;
    public Vector2 position;
}
