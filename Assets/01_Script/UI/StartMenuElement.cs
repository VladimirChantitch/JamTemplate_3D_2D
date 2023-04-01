using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace ui.template
{
    public class StartMenuElement : AbstractTemplateElement
    {
        public new class UxmlFactory : UxmlFactory<StartMenuElement, StartMenuElement.UxmlTraits> { }

        public StartMenuElement() { }

        public event Action onStartButton;
        public event Action onLoadButton;
        public event Action onSettingsButton;
        public event Action onCreditsButton;

        Button btn_start = null;
        Button btn_load = null;
        Button btn_settings = null;
        Button btn_credits = null;

        public void Init()
        {
            BindButtons();
        }

        private void BindButtons()
        {
            btn_start = this.Q<Button>("btn_start");
            btn_load = this.Q<Button>("btn_load");
            btn_settings = this.Q<Button>("btn_settings");
            btn_credits = this.Q<Button>("btn_credits");

            btn_start.clicked += () => onStartButton();
            btn_load.clicked += () => onLoadButton();
            btn_settings.clicked += () => onSettingsButton();
            btn_credits.clicked += () => onCreditsButton();
        }
    }
}

