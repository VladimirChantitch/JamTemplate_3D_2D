using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace ui.template
{
    public class WinMenuElement : AbstractTemplateElement
    {
        public new class UxmlFactory : UxmlFactory<WinMenuElement, WinMenuElement.UxmlTraits> { }

        public WinMenuElement() { }
    }
}

