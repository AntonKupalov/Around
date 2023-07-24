using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoloring : MonoBehaviour
{
    [SerializeField] 
    private float _recoloring = 2f;

    [SerializeField]
    private float _stop = 0.2f;

    private UnityEngine.Color _startColor;
    private UnityEngine.Color _nextColor;
    private Renderer _renderer;
    private float _time;

    private float _recoloringTime;
    
    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
        GenerateNextColor();
        
    }

    private void GenerateNextColor()
    {
        _startColor = _renderer.material.color;
        _nextColor = Random.ColorHSV(0f, 1f, 0.8f, 1f, 0f, 1f);
    }
   
   private void Update()
   {
       _time += Time.deltaTime;
       if (_time >= _stop)
       {
           ChangeColor();
           _time = 0;
       }
       
       
   }

   private void ChangeColor()
   {
      _recoloringTime += Time.deltaTime;
                    var progress = _recoloringTime / _recoloring;
                    var currentColor = UnityEngine.Color.Lerp(_startColor, _nextColor, progress);
                    _renderer.material.color = currentColor;
                    if (_recoloringTime >= _recoloring)
                    {
                        _recoloringTime = 0f;
                        GenerateNextColor(); 
                    }
     
   }
}
