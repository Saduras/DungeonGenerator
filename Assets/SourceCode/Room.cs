using UnityEngine;

public class Room : MonoBehaviour 
{
	public void Init(int width, int length)
	{
		transform.localScale = new Vector3 (width, 1f, length);
	}
}
