using UnityEngine;

public class RoomGenerator : MonoBehaviour 
{
	public GameObject roomPrefab;

	public int roomCount = 100;

	public int spaceWidth = 500;
	public int spaceLength = 500;

	public int minRoomWidth = 5;
	public int maxRoomWidth = 20;
	public int minRoomLength = 5;
	public int maxRoomLength = 20;

	public Room[] generatedRooms;

	public void Run()
	{
		for (int i = transform.childCount - 1; i >= 0; i--) {
			DestroyImmediate (transform.GetChild (i).gameObject);
		}
		generatedRooms = new Room[roomCount];


		for (int i = 0; i < roomCount; i++) 
		{
			var posX = Random.Range (0, spaceWidth);
			var posZ = Random.Range (0, spaceLength);
			var sizeX = Random.Range (minRoomWidth, maxRoomWidth);
			var sizeZ = Random.Range (minRoomLength, maxRoomLength);

			var instance = Instantiate (roomPrefab);
			instance.transform.SetParent (this.transform);
			instance.transform.localPosition = new Vector3 (posX, 0f, posZ);
			instance.transform.localScale = Vector3.one;

			var room = instance.GetComponent<Room> ();
			room.Init (sizeX, sizeZ);

			generatedRooms [i] = room;
		}
	}
}
