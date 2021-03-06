﻿using System;
using UnityEngine;
using UnityEngine.Events;
using Verse.API.Models;
using Verse.Systems.Visual;

public class SelectedRoomController : MonoBehaviour {
    public static SelectedRoomController Instance;

    public RoomLoadedEvent onRoomLoaded = new RoomLoadedEvent();
    public RoomUnloadedEvent onRoomUnloaded = new RoomUnloadedEvent();

    private RoomController _roomController;
    private Room _currentRoomOld;

    void Awake() {
        Instance = this;
    }

    void Start() {
        _roomController = RoomController.Instance;
    }

    public void SaveRoom() {
        Debug.Log("Saving Room");
        RoomFileSaver.SaveRoom(_currentRoomOld);
    }

    public void CreateNewRoom() {
        Debug.Log("Create new room");
    }

    public void CloseRoom() {
        if (_roomController.HasActiveRoom) {
            _roomController.DestroyRoom();
            onRoomUnloaded.Invoke(_currentRoomOld);
        }
    }

    public void LoadRoom(string room) {
        _roomController.ChangeRoom(room, null);
        //_currentRoomOld = _roomController.CurrentRoom;
        onRoomLoaded.Invoke(_currentRoomOld);
    }

    [Serializable]
    public class RoomLoadedEvent : UnityEvent<Room> { }

    [Serializable]
    public class RoomUnloadedEvent : UnityEvent<Room> { }
}