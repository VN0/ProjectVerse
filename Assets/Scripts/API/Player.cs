﻿using System;
using System.Security.Cryptography.X509Certificates;
using Unity.Mathematics;

public class Player : PlayerReadOnly
{
    public float2 position { get; set; }
    public bool isMoving { get; set; }
    public bool isRunning { get; set; }
    public string currentRoom { get; set; }

    private RoomController _roomController;
    private PlayerController _playerController;

    public Player() {
        position = float2.zero;
        _roomController = RoomController.Instance;
        _playerController = PlayerController.Instance;
    }

    public void RequestRoomChange(String room, float2 pos) {
        Debug.Log("Room change requested to " + room + " at position " + pos); 
        _roomController.changeRoom(room);
        MovePlayer(pos);
    }

    public void MovePlayer(float2 pos) {
        _playerController.DirectMovePlayer(pos);
    }
}