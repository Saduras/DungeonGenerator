using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GraphGenerator))]
public class GraphGeneratorInspector : Editor
{
	public override void OnInspectorGUI ()
	{
		base.OnInspectorGUI ();

		var targetGenerator = target as GraphGenerator;

		if (GUILayout.Button ("Triangulate")) 
		{
			targetGenerator.Triangulate();
		}
	}
}