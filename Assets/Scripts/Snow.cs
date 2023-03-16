using System.Collections;
using System.Collections.Generic;
using HP;
using UnityEngine;

public class Snow : MonoBehaviour
{
    [SerializeField] private GameObject _water;
    [SerializeField] private float _waterLifetime = 4f;
    
    private TypeOfElement _typeOfElement;
    

    public GameObject Water => _water;
    public float WaterLifetime => _waterLifetime;
    
    private new void Start()
    {
        _typeOfElement = TypeOfElement.Ice;
    }
    
    
}
