using System;
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

        public event Action onBackToMainMenu;

        Button btn_back_to_main;

        public void Init()
        {
            BindButtons();
        }

        private void BindButtons()
        {
            btn_back_to_main = this.Q<Button>("btn_back_to_main");

            btn_back_to_main.clicked += () => onBackToMainMenu?.Invoke();
        }
    }
}
