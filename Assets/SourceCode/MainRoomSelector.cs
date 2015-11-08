using UnityEngine;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(RoomGenerator))]
public class MainRoomSelector : MonoBehaviour {

	public float aboveMeanWidthFactor = 1.25f;
	public float aboveMeanLengthFactor = 1.25f;

	[HideInInspector]
	public List<Room> mainRooms;
	[HideInInspector]
	public List<Room> sideRooms;

	Room[] _rooms;

	public void Run()
	{
		var generator = this.GetComponent<RoomGenerator> ();
		_rooms = generator.generatedRooms;

		float meanWidth = 0f;
		float meanLength = 0f;

		foreach (var room in _rooms) {
			meanWidth += room.width;
			meanLength += room.length;
		}

		meanWidth /= _rooms.Length;
		meanLength /= _rooms.Length;

		foreach (var room in _rooms) {
			if (room.width >= meanWidth * aboveMeanWidthFactor
			    && room.length >= meanLength * aboveMeanLengthFactor) 
			{
				mainRooms.Add (room);
				room.isMainRoom = true;
			} else {
				sideRooms.Add (room);
				room.isMainRoom = false;
			}
		}
	}
}
