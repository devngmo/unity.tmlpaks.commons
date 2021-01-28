using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace tmlpaks.commons.ui
{
    public class HealthBar : MonoBehaviour
    {
        public RectTransform Bg;
        public RectTransform Front;
        public float Min
        {
            get => sliderFill.minValue;
            set => sliderFill.minValue = value;
        }
        public float Max
        {
            get => sliderFill.maxValue;
            set => sliderFill.maxValue = value;
        }

        Slider sliderFill;

        public float Value
        {
            get => sliderFill.value;
            set
            {
                sliderFill.value = Mathf.Clamp(value, Min, Max);
            }
        }

        private void Awake()
        {
            sliderFill = GetComponent<Slider>();
        }

        void Start()
        {

        }

        void Update()
        {

        }
    }
}