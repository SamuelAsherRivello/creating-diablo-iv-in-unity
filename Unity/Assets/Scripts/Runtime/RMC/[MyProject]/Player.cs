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
        private float _speed = 1;
        
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
            Vector3 move3 = new Vector3(move.x, 0, move.y);
            
            if (move3.magnitude > 0)
            {
                _animator.SetBool("IsRun", true);
                
                transform.Translate(move3 * Time.deltaTime * _speed, 
                    Space.World);
                
                transform.rotation = Quaternion.LookRotation(-move3);
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