using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreeCamera : MonoBehaviour
{
    public GameObject _blade;
    public GameObject _controller;
    public Text _buttonText;
    public GameObject _kor;
    private void Start()
    {
       
    }

    public void whenButtonClicked()
    {
        if (_kor.activeInHierarchy == true)
        { 
            _kor.SetActive(false);
           _blade.SetActive(false);
           _controller.SetActive(true);
           _buttonText.text = "Free cam (on)";
        }
        else
        {
            _kor.SetActive(true);
            _controller.SetActive(false);
            _buttonText.text = "Free cam (off)";
        }
            
                 
    }
    
    
    
    
    
    
    
    
    
    
    
    
    
    
}
