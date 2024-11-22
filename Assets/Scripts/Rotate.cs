using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    private bool _held = false;
    public bool Held
    {
        get
        {
            return _held;
        }
        set
        {
            _held = value;
            if(value)
                StartCoroutine(Hold(Index));
            else
                _mats[Index].color = Color.yellow;
        }
    }
    [SerializeField]
    private float _speed = 1f;
    public int Index;
    [SerializeField]
    private MeshRenderer[] _renderers = new MeshRenderer[2];
    private Material[] _mats = new Material[2];

    private void Start()
    {
        for (int i = 0; i < _renderers.Length; i++)
            _mats[i] = _renderers[i].material;
    }

    public void InitHold(int index)
    {
        Index = index;
        Held = true;
    }

    IEnumerator Hold(int index)
    {
        yield return new WaitForSeconds(5f);
        _mats[index].color = Color.red;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(!_held)
            gameObject.transform.Rotate(Vector3.up * _speed);
    }
}
