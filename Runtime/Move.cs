using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class MoveCubeFromInpuMono : MonoBehaviour
{
    public InputActionReference m_moveForward;
    public InputActionReference m_movebackward;
    public InputActionReference m_moveLeft;
    public InputActionReference m_moveRight;
    public InputActionReference m_moveUp;
    public InputActionReference m_moveDown;
    public InputActionReference m_reset;


    public Transform m_cubeToMove;


    public BoolChangeEvent m_isMovingForward;
    public BoolChangeEvent m_isMovingBackward;
    public BoolChangeEvent m_isMovingLeft;
    public BoolChangeEvent m_isMovingRight;
    public BoolChangeEvent m_isMovingUp;
    public BoolChangeEvent m_isMovingDown;
    public BoolChangeEvent m_isReset;


    [System.Serializable]
    public class BoolChangeEvent
    {
        public bool m_currentValue;

        public UnityEvent<bool> m_onValueChanged;
        public UnityEvent m_onTrue;
        public UnityEvent m_onFalse;

        public void SetNewValue(bool newValue)
        {
            bool changed = m_currentValue != newValue;
            m_currentValue = newValue;

            if (changed)
            {

                m_onValueChanged.Invoke(m_currentValue);
                if (m_currentValue)
                {
                    m_onTrue.Invoke();
                }
                else
                {
                    m_onFalse.Invoke();
                }
            }

        }
    }




    public void OnEnable()
    {
        m_moveForward.action.Enable();
        m_movebackward.action.Enable();
        m_moveLeft.action.Enable();
        m_moveRight.action.Enable();
        m_moveUp.action.Enable();
        m_moveDown.action.Enable();
        //m_moveForward.action.performed += (e) => { };
        m_moveForward.action.performed += MoveForward;
        m_moveForward.action.canceled += MoveForward;

        m_movebackward.action.performed += MoveBackward;
        m_movebackward.action.canceled += MoveBackward;

        m_moveLeft.action.performed += MoveLeft;
        m_moveLeft.action.canceled += MoveLeft;

        m_moveRight.action.performed += MoveRight;
        m_moveRight.action.canceled += MoveRight;

        m_moveUp.action.performed += MoveUp;
        m_moveUp.action.canceled += MoveUp;

        m_moveDown.action.performed += MoveDown;
        m_moveDown.action.canceled += MoveDown;

        m_reset.action.performed += Reset;
        m_reset.action.canceled += Reset;

    }


    private void MoveForward(InputAction.CallbackContext context)
    {
        m_isMovingForward.SetNewValue(context.ReadValueAsButton());

    }

    

    private void MoveBackward(InputAction.CallbackContext context)
    {
        m_isMovingBackward.SetNewValue(context.ReadValueAsButton());

    }

    private void MoveLeft(InputAction.CallbackContext context)
    {
        m_isMovingLeft.SetNewValue(context.ReadValueAsButton());

    }

    private void MoveRight(InputAction.CallbackContext context)
    {
        m_isMovingRight.SetNewValue(context.ReadValueAsButton());

    }

    private void MoveUp(InputAction.CallbackContext context)
    {
        m_isMovingUp.SetNewValue(context.ReadValueAsButton());

    }

    private void MoveDown(InputAction.CallbackContext context)
    {
        m_isMovingDown.SetNewValue(context.ReadValueAsButton());

    }

    private void Reset(InputAction.CallbackContext context)
    {
        m_isReset.SetNewValue(context.ReadValueAsButton());

    }
}
