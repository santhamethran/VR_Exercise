using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGrab : MonoBehaviour
{
    private bool _grabbable = false;
    [SerializeField]
    private int _index;
    [SerializeField]
    private Rotate _rotate;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        _grabbable = true;
    }

    private void OnTriggerExit(Collider other)
    {
        _grabbable = false;
    }

    public void Grab()
    {
        if (_grabbable)
        {
            _rotate.Index = _index;
        }
    }

    public void Release()
    {
        if(_rotate.Index == _index)
            _rotate.Held = false;
    }
}
