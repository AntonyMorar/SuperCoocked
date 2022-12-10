using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderUI : MonoBehaviour
{
    // Serialized 
    [SerializeField] private Image timerImage;
    // private *****
    private bool _started;
    private float _orderTime = 30;
    private float _actualOrderTime;
    
    // Monobehavior Callbacks

    private void Start()
    {
        _started = true;
        _actualOrderTime = _orderTime;
    }

    private void OnEnable()
    {
        RectTransform rect = gameObject.GetComponent<RectTransform>();
        rect.localScale = Vector3.zero;
        LeanTween.scale(rect, Vector3.one,0.5f).setEase(LeanTweenType.easeOutSine);
    }

    private void Update()
    {
        if (!_started) return;

        _actualOrderTime -= Time.deltaTime;
        timerImage.fillAmount = _actualOrderTime / _orderTime;
        
        if (_actualOrderTime <= 0)
        {
            LeanTween.color(gameObject.GetComponent<RectTransform>(), Color.red, 0.5f).setDestroyOnComplete(true);
            _started = false;
        }
        
    }
    
    // Public Methods
    public void SetOrder(RecipeData recipeData)
    {
        _started = true;
        
    }
}
