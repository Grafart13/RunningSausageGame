using UnityEngine;
using System.Collections;

public class DormitoryCell : MonoBehaviour {

    private DormitoryCellEdge[] edges = new DormitoryCellEdge[DormitoryDirections.Count];

	public IntVector2 coordinates;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void SetEdge (DormitoryDirection direction, DormitoryCellEdge edge)
    {
        edges[(int)direction] = edge;
    }

    public DormitoryCellEdge GetEdge(DormitoryDirection direction)
    {
        return edges[(int)direction];
    }
}
