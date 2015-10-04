using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RoomGenerator))]
public class RoomGeneratorInspector : Editor 
{
	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();

		var targetGenerator = target as RoomGenerator;

		if (GUILayout.Button ("Run")) 
		{
			targetGenerator.Run ();
		}
	}

}
