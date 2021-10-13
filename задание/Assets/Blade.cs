
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Blade : MonoBehaviour
{
    Rigidbody _rb;
    Camera _camera;
    
    public Transform _target;
    


    void Start()
    {
        _camera = Camera.main;
        _rb = GetComponent<Rigidbody>();
        
    }

    private void Update()
    {
        if (_kor.activeInHierarchy == true)
        {


            if (Input.GetMouseButton(0)) MoveBlade();
        }
        else
        {
            _button1.SetActive(false);
            _button.SetActive(false);
            _blade.SetActive(false);
            _buttonText.text = "Blade (off)";
        }
    }

    private void MoveBlade()
    {
        var xAngle = Vector3.SignedAngle(_target.up, transform.position, transform.right);
        _rb.rotation =
            Quaternion.Euler(xAngle, _camera.transform.eulerAngles.y + 90, _camera.transform.eulerAngles.z);
        _rb.position = _camera.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            Vector3.Distance(_camera.transform.position, _target.position)));

    }

    
    public GameObject _blade;
    public GameObject _kor;
    public GameObject _button;
    public GameObject _button1;
    public Text _buttonText;
    
   
    
    public void ButtonClicked()
    {
        if (_kor.activeInHierarchy == true)
        {
            
            _blade.SetActive(true);
            
            _buttonText.text = "Blade (on)";
            
        }
        else
        {
            
           _blade.SetActive(false);
            _buttonText.text = "Blade (off)";
        }
    }
    
    
    
}
