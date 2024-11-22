using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PortalScript : MonoBehaviour
{
    public GameObject cube;
    public GameObject sphere;
    public int cubeCount;
    public int sphereCount;
    public int timeDelay;

    public void SpawnObjectFunctions()
    {
        StartCoroutine(SpawnObjects());
    }

    public IEnumerator SpawnObjects() {
        int totalObjects = cubeCount + sphereCount;
        int cubeCount1 = cubeCount;
        int sphereCount1 = sphereCount;

        while (true) {
            //for the total objects randomly instantiate the objects
            for (int i = 0; i < totalObjects; i++) {
                //if random number is greater than 0 instantiate cube else instantiate sphere and decrease the count
                if(Random.Range(0,2) == 0 && cubeCount1 > 0) {
                    GameObject obj = Instantiate(cube, transform.position, Quaternion.identity);
                    obj.GetComponent<ObjectManager>()._init = transform;
                    obj.transform.rotation = transform.rotation;
                    cubeCount1--;
                }
                else if(sphereCount1 > 0) {
                    GameObject obj = Instantiate(sphere, transform.position, Quaternion.identity);
                    obj.GetComponent<ObjectManager>()._init = transform;
                    obj.transform.rotation = transform.rotation;
                    sphereCount1--;
                }

                //spawn objects with 1 second delay between them
                yield return new WaitForSeconds(timeDelay);
            }

            //reset count
            cubeCount1 = cubeCount;
            sphereCount1 = sphereCount;
        }
    }
}
