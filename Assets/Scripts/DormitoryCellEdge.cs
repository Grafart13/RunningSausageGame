using UnityEngine;
using System.Collections;

public abstract class DormitoryCellEdge : MonoBehaviour {

    public DormitoryCell cell, otherCell;

    public DormitoryDirection direction;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Initialize(DormitoryCell cell, DormitoryCell otherCell, DormitoryDirection direction)
    {
        this.cell = cell;
        this.otherCell = otherCell;
        this.direction = direction;
        cell.SetEdge(direction, this);
        transform.parent = cell.transform;
        transform.localPosition = Vector3.zero;
		transform.localRotation = direction.ToRotation();
    }
}
