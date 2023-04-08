using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace ui.template
{
    public class ATHElement : AbstractTemplateElement
    {
        public new class UxmlFactory : UxmlFactory<ATHElement, ATHElement.UxmlTraits> { }

        public ATHElement() { }
    }
}
