using RMC.Core.Audio;
using UnityEngine;

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
        [SerializeField] 
        private Animator _animator;
        
        [SerializeField] 
        private Rigidbody _rigidbody;

        
        [SerializeField] 
        private float _speed = 1;
        
        private Vector3 _lastMoveVector3 = Vector3.zero;
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
            Vector2 inputMoveVector2 = _inputActions.ActionMap.Move.ReadValue<Vector2>();
            _lastMoveVector3 = new Vector3(inputMoveVector2.x, 0, inputMoveVector2.y);

            if (_inputActions.ActionMap.Attack.WasPressedThisFrame())
            {
                _animator.SetTrigger("AttackTrigger");

                AudioManager.Instance.PlayAudioClip("SwordMiss01");

            }
        }
        
        protected void FixedUpdate ()
        {
            if (_lastMoveVector3.magnitude > 0)
            {
                _animator.SetBool("IsRun", true);
                
                Quaternion nextRotation = Quaternion.LookRotation(-_lastMoveVector3);
                Vector3 nextPosition = _rigidbody.transform.position +
                                       (_lastMoveVector3 * _speed);
                
                _rigidbody.Move(nextPosition, nextRotation);
                
            }
            else
            {
                _animator.SetBool("IsRun", false);
            }
           
           
        }


        //  Methods ---------------------------------------

        //  Event Handlers --------------------------------

    }
}