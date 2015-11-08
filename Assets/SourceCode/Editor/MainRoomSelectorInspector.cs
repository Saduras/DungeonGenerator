using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MainRoomSelector))]
public class MainRoomSelectorInspector : Editor
{
	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();

		var targetGenerator = target as MainRoomSelector;

		if (GUILayout.Button ("Run")) 
		{
			targetGenerator.Run ();
		}
	}
}