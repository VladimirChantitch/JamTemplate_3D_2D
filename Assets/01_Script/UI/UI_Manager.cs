using System;
using System.Collections;
using System.Collections.Generic;
using ui.template;
using UnityEngine;
using UnityEngine.UIElements;

namespace ui
{
    [RequireComponent(typeof(UIDocument))]
    public class UI_Manager : MonoBehaviour
    {
        public SO_Template[] sO_Templates = null;

        public void Awake()
        {
            
        }
    }
}

