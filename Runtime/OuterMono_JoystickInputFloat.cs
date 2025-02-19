using System;
using UnityEngine;
using UnityEngine.InputSystem;



[System.Serializable]
public class MotorValue<T> {

    [Header("Left")]
    public T m_leftFront;
    public T m_leftBack;
    public T m_leftTop;
    public T m_leftDown;
    public T m_leftSide;
    [Header("Right")]
    public T m_rightFront;
    public T m_rightBack;
    public T m_rightTop;
    public T m_rightDown;
    public T m_rightSide;

    internal void Clear()
    {
        m_leftBack = default;
        m_leftDown = default;
        m_leftFront = default;
        m_leftSide = default;
        m_leftTop = default;
        m_rightBack = default;
        m_rightFront = default;
        m_rightSide = default;
        m_rightTop = default;
        m_rightDown = default;
        
    }
}

public class OuterMono_JoystickInputFloat: MonoBehaviour
{
    public AbstractOuterShipPitchRollYawMono m_airPushMotors;
    public AbstractOuterShipMotorPercentMono m_combusionMotors;

    public AxisInput m_moveLeftToRight;
    public AxisInput m_moveFrontToBack;
    public AxisInput m_moveDownUp;

    public AxisInput m_airRotateYawLeftToRight;
    public AxisInput m_airRotatePitchDownToUp;
    public AxisInput m_airRotateRollLeftToRight;


    public MotorValue<float> m_motorValue;

    private void OnEnable()
    {
        m_moveLeftToRight.EnableIt();
        m_moveFrontToBack.EnableIt();
        m_moveDownUp.EnableIt();
        m_airRotateYawLeftToRight.EnableIt();
        m_airRotatePitchDownToUp.EnableIt();
        m_airRotateRollLeftToRight.EnableIt();

        m_motorValue.Clear();

        m_airRotatePitchDownToUp.m_onValueChanged += m_airPushMotors.SetPitchDownToTop;
        m_airRotateYawLeftToRight.m_onValueChanged += (pct) =>
        {
            m_airPushMotors.SetYawLeftToRight(pct);
            m_motorValue.m_leftFront = -pct * 0.5f;
            m_motorValue.m_leftBack = pct * 0.5f;
            m_motorValue.m_rightFront = pct * 0.5f;
            m_motorValue.m_rightBack = -pct * 0.5f;
        };
        m_airRotateRollLeftToRight.m_onValueChanged += (pct) =>
        {
            m_airPushMotors.SetRollLeftToRight(pct);
            m_motorValue.m_leftDown= pct * 0.5f;
            m_motorValue.m_leftTop = -pct * 0.5f;
            m_motorValue.m_rightDown = -pct * 0.5f;
            m_motorValue.m_rightTop = pct * 0.5f;

        };


        m_moveLeftToRight.m_onValueChanged += (pct) => {
            m_motorValue.m_leftSide = pct;
            m_motorValue.m_rightSide = -pct;
        };
        
        m_moveFrontToBack.m_onValueChanged += (pct) => {
            m_motorValue.m_leftFront = pct*0.5f;
            m_motorValue.m_rightFront = pct * 0.5f;
            m_motorValue.m_leftBack = pct * 0.5f;
            m_motorValue.m_rightBack = pct * 0.5f;
        };

        m_moveDownUp.m_onValueChanged += (pct) =>
        {
            m_motorValue.m_leftDown = pct * 0.5f;
            m_motorValue.m_rightDown = pct * 0.5f;
            m_motorValue.m_leftTop = -pct * 0.5f;
            m_motorValue.m_rightTop = -pct * 0.5f;
        };
        m_combusionMotors.SetMotorPercentLeftSide(m_motorValue.m_leftSide);
        m_combusionMotors.SetMotorPercentRightSide(m_motorValue.m_rightSide);
        m_combusionMotors.SetMotorPercentLeftFront(m_motorValue.m_leftFront);
        m_combusionMotors.SetMotorPercentRightFront(m_motorValue.m_rightFront);
        m_combusionMotors.SetMotorPercentLeftBack(m_motorValue.m_leftBack);
        m_combusionMotors.SetMotorPercentRightBack(m_motorValue.m_rightBack);
        m_combusionMotors.SetMotorPercentLeftTop(m_motorValue.m_leftTop);
        m_combusionMotors.SetMotorPercentRightTop(m_motorValue.m_rightTop);
        m_combusionMotors.SetMotorPercentLeftDown(m_motorValue.m_leftDown);
        m_combusionMotors.SetMotorPercentRightDown(m_motorValue.m_rightDown);
    }

    private void OnDisable()
    {
        m_moveLeftToRight.DisableIt();
        m_moveFrontToBack.DisableIt();
        m_moveDownUp.DisableIt();
        m_airRotateYawLeftToRight.DisableIt();
        m_airRotatePitchDownToUp.DisableIt();
        m_airRotateRollLeftToRight.DisableIt();

    }

    [System.Serializable]
    public class AxisInput { 
        public InputActionReference m_inputAction;
        [Range(-1,1)]
        public float m_axisValue;
        public Action<float> m_onValueChanged;
        public bool m_inverse;

        public void EnableIt()
        {
            if(m_inputAction==null)
                return;
            
            m_inputAction.action.Enable();
            m_inputAction.action.performed += ctx => Context(ctx);
            m_inputAction.action.started += ctx => Context(ctx);
            m_inputAction.action.canceled += ctx => Context(ctx);
        }

        private void Context(InputAction.CallbackContext ctx)
        {
            float value = ctx.ReadValue<float>();
            if (m_inverse)
                value = -value;
            float current = m_axisValue;
            bool changed= value != current;
            if(changed)
            {
                m_axisValue = value;
                m_onValueChanged.Invoke(m_axisValue);
        
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


