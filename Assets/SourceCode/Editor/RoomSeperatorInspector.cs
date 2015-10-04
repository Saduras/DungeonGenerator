using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoomSeperator))]
public class RoomSpereratorInspector : Editor 
{
	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();

		var targetSperator = target as RoomSeperator;

		if (GUILayout.Button ("Run")) 
		{
			targetSperator.Run ();
		}
	}

}
