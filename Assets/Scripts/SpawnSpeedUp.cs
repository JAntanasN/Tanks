using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSpeedUp : MonoBehaviour
{
    public GameObject SpeedBox;


    private void Start()
    {
        InvokeRepeating("SpawnPrefab", 0, 2);
    }

    void SpawnPrefab()
    {
        float planeWidth = 60f;
        float planeLength = 90f;
        Vector3 randomPosition = new Vector3(
            Random.Range(-planeWidth / 2, planeWidth / 2),
            0,
            Random.Range(-planeLength / 2, planeLength / 2)
            );

        Instantiate(SpeedBox, randomPosition, Quaternion.identity);
    }
}
