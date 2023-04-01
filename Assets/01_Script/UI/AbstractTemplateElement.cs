using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace ui.template
{
    public abstract class AbstractTemplateElement : VisualElement
    {
        public event Action onFinishBinding;
    }
}

