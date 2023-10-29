using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawmHealthUp : MonoBehaviour
{
    public GameObject HealthBox;
    public float spawnInterval = 2f;
    public Camera mainCamera;




    private void Start()
    {
        InvokeRepeating("SpawnPrefab", 0, spawnInterval);
    }

    void SpawnPrefab()
    {
        float planeWidth = 60f;
        float planeLength = 90f;


        Vector3 randomPositionLeft = new Vector3(
            Random.Range(-planeWidth / 2, 0), // Random X kordinartë in the left side, o 0.5f y kordinatë(virð þemës)
            0.5f,
            Random.Range(-planeLength / 2, planeLength / 2)  // Random Z kordinatë
        );

        Vector3 randomPositionRight = new Vector3(
            Random.Range(0, planeWidth / 2), // Random X kordinartë in the right side
            0.5f,
            Random.Range(-planeLength / 2, planeLength / 2) // Random Z kordinatë
        );

        // Spawn prefabs on both sides
        GameObject leftBox = Instantiate(HealthBox, randomPositionLeft, Quaternion.identity); //Health box spawning on the left
        GameObject rightBox = Instantiate(HealthBox, randomPositionRight, Quaternion.identity); //Health box spawning on the right

        // Get rigidbody component for prefab
        Rigidbody leftRigidbody = leftBox.GetComponent<Rigidbody>();
        Rigidbody rightRigidbody = rightBox.GetComponent<Rigidbody>();

        //Check if rigibody exits
        if (leftRigidbody != null)
        {
            leftRigidbody.velocity = Vector3.zero; //can't fly or go down
            leftRigidbody.constraints = RigidbodyConstraints.FreezePositionY; // Stays above virð ground

            // Check if camera exits
            if (mainCamera != null)
            {
                mainCamera.transform.position = new Vector3(0, 10, 0); // camera position so prefabs can spawn erywhere
            }
        }

        if (rightRigidbody != null)
        {
            rightRigidbody.velocity = Vector3.zero;
            rightRigidbody.constraints = RigidbodyConstraints.FreezePositionY;


            if (mainCamera != null)
            {
                mainCamera.transform.position = new Vector3(0, 10, 0);
            }
        }
    }
}
