using UnityEngine;

public class Room : MonoBehaviour 
{
	public Material defaultMaterial;
	public Material mainRoomMaterial;

	public float width { get { return transform.localScale.x; } }
	public float length { get { return transform.localScale.z; } }

	public float top  { get { return transform.localPosition.z + length / 2; } }
	public float bottom { get { return transform.localPosition.z - length / 2; } }
	public float left { get { return transform.localPosition.x - width / 2; } }
	public float right { get { return transform.localPosition.x + width / 2; } }

	public bool isMainRoom
	{
		set {
			GetComponent<MeshRenderer>().material = value ? mainRoomMaterial : defaultMaterial;
		}
	}

	public void Init(int width, int length)
	{
		transform.localScale = new Vector3 (width, 1f, length);
	}
}
