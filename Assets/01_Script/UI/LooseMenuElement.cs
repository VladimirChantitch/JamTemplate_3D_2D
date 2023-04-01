using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace ui.template
{
    public class LooseMenuElement : AbstractTemplateElement
    {
        public new class UxmlFactory : UxmlFactory<LooseMenuElement, LooseMenuElement.UxmlTraits> { }

        public LooseMenuElement() { }
    }
}
