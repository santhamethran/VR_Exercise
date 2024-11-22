using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScene : MonoBehaviour
{
    [SerializeField] GameObject hand;
    // Start is called before the first frame update
    void OnCollisionEnter(Collision col){
        if(col.gameObject == hand){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
