using UnityEngine;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Graph generator.
/// Using generate Delaunay Triangulation algorithm from:
/// http://www.geom.uiuc.edu/~samuelp/del_project.html
/// </summary>

[RequireComponent(typeof(MainRoomSelector))]
public class GraphGenerator : MonoBehaviour {

	public void Triangulate()
	{
		var mainRoomSelector = GetComponent<MainRoomSelector> ();
		var mainRooms = mainRoomSelector.mainRooms;

		List<Vector3> points = new List<Vector3>();
		foreach (var room in mainRooms) {
			points.Add(room.transform.localPosition);
		}

		// Sort points by x coordinate
		points.Sort((v1, v2) => {
			if(v1.x != v2.x)
				return v1.x.CompareTo(v2.x);
			else
				return v1.y.CompareTo(v2.y);
		});

		var subsets = new List<List<Vector3>>();

		// Subdivide until each subset (list) has only up to 3 points
		Divide(new List<Vector3> (points), subsets);

		foreach (var subset in subsets) {
			for (int i = 1; i < subset.Count; i++) {
				Debug.DrawLine(subset [0], subset [i], Color.green);
			}
			Debug.DrawLine(subset [1], subset.Last(), Color.green);
		}
	}

	void Divide(List<Vector3> toDivide, List<List<Vector3>> subsets)
	{
		if (toDivide.Count <= 3) {
			subsets.Add (toDivide);
		} else {
			int middleIndex = toDivide.Count / 2;
			Divide (toDivide.GetRange (0, middleIndex), subsets);
			Divide (toDivide.GetRange (middleIndex, toDivide.Count - middleIndex), subsets);
		}
	}
}
