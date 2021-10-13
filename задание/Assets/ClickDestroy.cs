using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickDestroy : MonoBehaviour
{

    
    public int _cubesInRow = 5;
    public float _force;
    public float _radius;
    public GameObject _button;
    public GameObject _button1;
    
    
    
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit _hit;
            Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(_ray, out _hit))
            {
                MeshCollider bc = _hit.collider as MeshCollider ;
                if (bc != null)
                {
                    exlode();
                }
            }

        }
        
    }

    public void exlode()
    {
        _button.SetActive(false);
        _button1.SetActive(false);
        gameObject.SetActive(false);
        
        for (int x = 0; x < _cubesInRow; x++)
        {
            for (int y = 0; y < _cubesInRow; y++)
            {
                for (int z = 0; z < _cubesInRow; z++)
                {
                    createPiece(new Vector3(x,y,z));
                }
            }
        }
        
    }

    void createPiece(Vector3 coordinates)
    {
        GameObject _piece = GameObject.CreatePrimitive(PrimitiveType.Cube);

        Renderer _rd = _piece.GetComponent<Renderer>();
        _rd.material = GetComponent<Renderer>().material;

        _piece.transform.localScale = transform.localScale / _cubesInRow;

        Vector3 _firstCube = transform.position - transform.localScale / 2 + _piece.transform.localScale / 2;
        _piece.transform.position = _firstCube + Vector3.Scale(coordinates, _piece.transform.localScale);

        Rigidbody _rb = _piece.AddComponent<Rigidbody>();
        _rb.AddExplosionForce(_force, transform.position, _radius);
    }

    
    
    public GameObject _kor;
    public GameObject _controller;
    public Text _buttonText;
    public GameObject _blade;
   
    
    public void ButtonClicked()
    {
        if (_kor.activeInHierarchy == true)
        {
            GetComponent<ClickDestroy>().enabled = true;
            _blade.SetActive(false);
            _controller.SetActive(false);
            _buttonText.text = "Destroy (on)";
            _kor.SetActive(false);
        }
        else
        {
            GetComponent<ClickDestroy>().enabled = false;
            _kor.SetActive(true);
            _buttonText.text = "Destroy (off)";
        }
    }
    
}
