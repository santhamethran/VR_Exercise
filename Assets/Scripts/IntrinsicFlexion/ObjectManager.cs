using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OculusSampleFramework;
using TMPro;
public class ObjectManager : MonoBehaviour
{
    public bool sphere, done = false;
    public PoseDetectedManager _manager;
    public float speed;
    public Transform _init;

    private void Start()
    {
        _manager = FindObjectOfType<PoseDetectedManager>();
    }

    void OnEnable()
    {
        if(_init != null)
            transform.position = _init.position;
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.position -= Time.deltaTime * transform.forward * speed;      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!sphere && _manager.gestureLeftBool && other.name != "Wall" && !done)
        {
           
            done = true;
            gameObject.SetActive(false);
            Destroy(gameObject);
           // _manager.Score();
        }
        if (!sphere && _manager.gestureRightBool && other.name != "Wall" && !done)
        {
            
            done = true;
            gameObject.SetActive(false);
            Destroy(gameObject);
            //_manager.Score();
        }   
        else if(other.name == "Wall")
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision) {
        if (!sphere && _manager.gestureLeftBool && collision.gameObject.name != "Wall" && !done)
        {
           
            done = true;
            Destroy(gameObject);
            _manager.ScoreLeft();
        }
        else if (!sphere && _manager.gestureRightBool && collision.gameObject.name != "Wall" && !done)
        {
           
            done = true;
            Destroy(gameObject);
            _manager.ScoreRight();
        }
       else
         Destroy(gameObject);
    }
}
