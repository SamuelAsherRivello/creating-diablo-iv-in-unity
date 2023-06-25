using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RMC.MyProject.Scenes
{
    //  Namespace Properties ------------------------------


    //  Class Attributes ----------------------------------


    /// <summary>
    /// Replace with comments...
    /// </summary>
    public class Player : MonoBehaviour
    {
        //  Events ----------------------------------------


        //  Properties ------------------------------------


        //  Fields ----------------------------------------
        private InputActions _inputActions;


        //  Unity Methods ---------------------------------
        protected void OnEnable()
        {
            if (_inputActions == null)
            {
                return;
            }
            _inputActions.Enable();
        }

        protected void OnDisable()
        {
            if (_inputActions == null)
            {
                return;
            }
            _inputActions.Disable();
        }

        protected void Start()
        {
            Debug.Log($"{GetType().Name}.Start()");
            _inputActions = new InputActions();
            _inputActions.Enable();
        }

        protected void Update()
        {
            Vector2 move = _inputActions.ActionMap.Move.ReadValue<Vector2>();
            Debug.Log("move: " + move);
        }


        //  Methods ---------------------------------------

        //  Event Handlers --------------------------------

    }
}