using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Transform _start;
    
    [SerializeField] private Transform _end;

  //  [SerializeField] private float _duration = 2f;
    private float _currentTime;
    
    
    void Start()
    {
        
    }

   
    void Update()
    {
        _currentTime += Time.deltaTime;
        transform.position = Vector3.Lerp(_start.position,_end.position,_currentTime);
        
    }
}
