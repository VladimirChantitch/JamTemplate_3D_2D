using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace inputs
{
    public class InputManager : MonoBehaviour
    {
        Inputs inputs = null;

        private void Awake()
        {
            inputs = new Inputs();
        }

        private void OnEnable()
        {
            inputs.Enable();

            BindInputs();
        }

        private void BindInputs()
        {
            throw new NotImplementedException();
        }

        private void OnDisable()
        {
            inputs?.Disable();
        }
    }
}

