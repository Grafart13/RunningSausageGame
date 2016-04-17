using UnityEngine;
using System.Collections;

public class WorldBuilder : MonoBehaviour
{

    private Dormitory dormInstance;

    public Dormitory dormPrefab;

    // Use this for initialization
    void Start()
    {
        BeginGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RestartGame();
        }
    }

    private void BeginGame()
    {
        dormInstance = Instantiate(dormPrefab) as Dormitory;
        dormInstance.Generate();
    }

    private void RestartGame()
    {
        Destroy(dormInstance.gameObject);
        BeginGame();
    }
}
