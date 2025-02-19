using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class OuterMono_ButtonMotorInput : MonoBehaviour {

    public AbstractOuterShipMotorPercentMono m_combusionMotors;


    public MotorValue<AxisInput> m_inputs;
    public MotorValue<float> m_motorValue;

    private void OnEnable()
    {
        m_inputs.m_leftSide.EnableIt();
        m_inputs.m_leftFront.EnableIt();
        m_inputs.m_leftBack.EnableIt();
        m_inputs.m_leftTop.EnableIt();
        m_inputs.m_leftDown.EnableIt();
        m_inputs.m_rightSide.EnableIt();
        m_inputs.m_rightFront.EnableIt();
        m_inputs.m_rightBack.EnableIt();
        m_inputs.m_rightTop.EnableIt();
        m_inputs.m_rightDown.EnableIt();

        m_inputs.m_leftDown.m_onValueChanged += m_combusionMotors.SetMotorPercentLeftDown;
        m_inputs.m_leftSide.m_onValueChanged += m_combusionMotors.SetMotorPercentLeftSide;
        m_inputs.m_leftFront.m_onValueChanged += m_combusionMotors.SetMotorPercentLeftFront;
        m_inputs.m_leftBack.m_onValueChanged += m_combusionMotors.SetMotorPercentLeftBack;
        m_inputs.m_leftTop.m_onValueChanged += m_combusionMotors.SetMotorPercentLeftTop;
        m_inputs.m_rightSide.m_onValueChanged += m_combusionMotors.SetMotorPercentRightSide;
        m_inputs.m_rightFront.m_onValueChanged += m_combusionMotors.SetMotorPercentRightFront;
        m_inputs.m_rightBack.m_onValueChanged += m_combusionMotors.SetMotorPercentRightBack;
        m_inputs.m_rightTop.m_onValueChanged += m_combusionMotors.SetMotorPercentRightTop;
        m_inputs.m_rightDown.m_onValueChanged += m_combusionMotors.SetMotorPercentRightDown;

    }

    private void OnDisable()
    {

        m_inputs.m_leftSide.DisableIt();
        m_inputs.m_leftFront.DisableIt();
        m_inputs.m_leftBack.DisableIt();
        m_inputs.m_leftTop.DisableIt();
        m_inputs.m_leftDown.DisableIt();
        m_inputs.m_rightSide.DisableIt();
        m_inputs.m_rightFront.DisableIt();
        m_inputs.m_rightBack.DisableIt();
        m_inputs.m_rightTop.DisableIt();
        m_inputs.m_rightDown.DisableIt();
    }


    [System.Serializable]
    public class AxisInput
    {
        public InputActionReference m_inputAction;
        [Range(0, 1)]
        public float m_axisValue;
        public Action<float> m_onValueChanged;

        public void EnableIt()
        {
            if (m_inputAction == null)
                return;

            
            m_inputAction.action.Enable();
            m_inputAction.action.performed += ctx => Context(ctx);
            m_inputAction.action.started += ctx => Context(ctx);
            m_inputAction.action.canceled += ctx => Context(ctx);
        }

        private void Context(InputAction.CallbackContext ctx)
        {
            float value = ctx.ReadValue<float>();
            
            float current = m_axisValue;
            bool changed = value != current;
            if (changed)
            {
                m_axisValue = value;
                m_onValueChanged?.Invoke(m_axisValue);

            }
        }

        public void DisableIt()
        {
            if (m_inputAction == null)
                return;
            m_inputAction.action.Disable();
            m_inputAction.action.performed -= ctx => Context(ctx);
            m_inputAction.action.started -= ctx => Context(ctx);
            m_inputAction.action.canceled -= ctx => Context(ctx);

        }

    }
}


