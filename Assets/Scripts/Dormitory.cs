using UnityEngine;
using System.Collections;

public class Dormitory : MonoBehaviour {

    public int sizeX, sizeZ, floors, floorHeight;

    public DormitoryCell cellPrefab;

    private DormitoryCell[,] cells;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Generate()
    {
        cells = new DormitoryCell[sizeX, sizeZ];
        for (int i = 0; i < floors; i++)
        {
            CreateFloor(i);
        }
    }

    private void CreateFloor(int i)
    {
        for (int x = 0; x < sizeX; x++)
        {
            for (int z = 0; z < sizeZ; z++)
            {
                CreateCell(x, z, i);
            }
        }
    }

    private void CreateCell(int x, int z, int i)
    {
        DormitoryCell cell = Instantiate(cellPrefab) as DormitoryCell;
        cells[x, z] = cell;
        cell.name = "Dorm cell " + x + ", " + z + "; floor " + i;
        cell.transform.parent = transform;
        cell.transform.localPosition = new Vector3(x - sizeX * 0.5f + 0.5f, (float)(i * floorHeight), z - sizeZ * 0.5f + 0.5f);
    }
}
