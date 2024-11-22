using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneControlPanels : MonoBehaviour
{
    public static SceneControlPanels instance;
    public bool IscontrolPanels;
    
    private void Awake()
    {
        
        if (instance == null)
        {
           
            instance = this;
          
            DontDestroyOnLoad(gameObject);
        }
        else
        {
           
            Destroy(gameObject);
        }
    }

   
}
