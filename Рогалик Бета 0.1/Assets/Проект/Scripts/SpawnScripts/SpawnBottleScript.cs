using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBottleScript : MonoBehaviour
{

    public float randomX;
    public float randomY;
    public float randomZ;

    public GameObject HollyWater;
    public GameObject Position;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Instantiate(HollyWater, new Vector3(Random.Range(Position.transform.position.x + randomX, Position.transform.position.x - randomX), 
                                                Random.Range(Position.transform.position.y + randomY, Position.transform.position.y + randomY),
                                                Random.Range(Position.transform.position.z - randomZ, Position.transform.position.z + randomZ)),
                                                Quaternion.identity);
        }

    }
}
