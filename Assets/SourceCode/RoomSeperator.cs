using UnityEngine;

[RequireComponent(typeof(RoomGenerator))]
public class RoomSeperator : MonoBehaviour 
{
	void Run()
	{
		var generator = this.GetComponent<RoomGenerator> ();
		var rooms = generator.generatedrRooms;

		if (rooms.Length <= 0) {
			Debug.LogWarning ("No rooms found");
		}
	}

}
