using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace ui.template
{
    [CreateAssetMenu(menuName = "ui_template")]
    public class SO_Template : ScriptableObject
    {
        [SerializeField] private VisualTreeAsset _treeAsset;
        [SerializeField] private GameState _subState;

        public VisualTreeAsset TreeAsset { get => _treeAsset; }
        public GameState SubState { get => _subState; }
    }
}

