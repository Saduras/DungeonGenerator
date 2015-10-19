using UnityEngine;

[RequireComponent(typeof(RoomGenerator))]
public class RoomSeperator : MonoBehaviour 
{
	public int steps = 100;
    public float damp = 0.5f;

	Room[] _rooms;

	public void Run()
	{
		int stepCount = 0;

		var generator = this.GetComponent<RoomGenerator> ();
		_rooms = generator.generatedRooms;

		if (_rooms.Length <= 0) {
			Debug.LogWarning ("No rooms found");
		}

		float maxVelocity = 0f;
		do {
			stepCount++;
			maxVelocity = 0f;

			foreach (var room in _rooms) {
				var velocity = ComputeVelocity (room);
				maxVelocity = Mathf.Max (velocity.magnitude, maxVelocity);

                velocity *= damp;

                velocity.x = Mathf.Ceil(velocity.x);
				velocity.y = 0f;
				velocity.z = Mathf.Ceil(velocity.z);

				room.transform.localPosition += velocity;
			}
		} while(maxVelocity > 0.1f && stepCount < steps);

		Debug.Log (string.Format ("Seperation finished after {0} steps. MaxVelocity left {1}", stepCount, maxVelocity));
	}

	Vector3 ComputeVelocity(Room currentRoom)
	{
		Vector3 velocity = Vector3.zero;

		foreach (var otherRoom in _rooms) {
			if (currentRoom != otherRoom) {
				var overlap = ComputeOverlapWithSign (currentRoom, otherRoom);
				velocity += overlap;
			}
		}

		return velocity;
	}

	Vector3 ComputeOverlapWithSign(Room firstRoom, Room secondRoom)
	{
		float xOverlap = Mathf.Max (0, Mathf.Min (firstRoom.right, secondRoom.right) - Mathf.Max (firstRoom.left, secondRoom.left));
		float zOverlap = Mathf.Max (0, Mathf.Min (firstRoom.top, secondRoom.top) - Mathf.Max (firstRoom.bottom, secondRoom.bottom));

		if (xOverlap > 0f && zOverlap > 0f) {
			float xDirection = Mathf.Sign (firstRoom.transform.localPosition.x - secondRoom.transform.localPosition.x);
			float zDirection = Mathf.Sign (firstRoom.transform.localPosition.z - secondRoom.transform.localPosition.z);

			return new Vector3 (xOverlap * xDirection, 0f, zOverlap * zDirection);
		} else {
			return Vector3.zero;
		}
	}
}
