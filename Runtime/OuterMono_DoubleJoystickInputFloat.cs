using UnityEngine;
using UnityEngine.InputSystem;

public class OuterMono_DoubleJoystickInputFloat : MonoBehaviour {

    public AbstractOuterShipPitchRollYawMono m_airPushMotors;
    public AbstractOuterShipMotorPercentMono m_combusionMotors;

    public InputActionReference m_leftJoystick;
    public InputActionReference m_rightJoystick;

    public Vector2 m_leftJoystickValue;
    public Vector2 m_rightJoystickValue;

    private void OnEnable()
    {
        m_leftJoystick.action.Enable();
        m_rightJoystick.action.Enable();
        m_leftJoystick.action.performed += ctx => ContextLeftJoystick(ctx);
        m_leftJoystick.action.started += ctx => ContextLeftJoystick(ctx);
        m_leftJoystick.action.canceled += ctx => ContextLeftJoystick(ctx);
        m_rightJoystick.action.performed += ctx => ContextRightJoystick(ctx);
        m_rightJoystick.action.started += ctx => ContextRightJoystick(ctx);
        m_rightJoystick.action.canceled += ctx => ContextRightJoystick(ctx);
    }
    private void OnDisable()
    {
        m_leftJoystick.action.performed -= ctx => ContextLeftJoystick(ctx);
        m_leftJoystick.action.started -= ctx => ContextLeftJoystick(ctx);
        m_leftJoystick.action.canceled -= ctx => ContextLeftJoystick(ctx);
        m_rightJoystick.action.performed -= ctx => ContextRightJoystick(ctx);
        m_rightJoystick.action.started -= ctx => ContextRightJoystick(ctx);
        m_rightJoystick.action.canceled -= ctx => ContextRightJoystick(ctx);
    }

    private void ContextRightJoystick(InputAction.CallbackContext ctx)
    {
        Vector2 v = m_leftJoystickValue;
        m_rightJoystickValue = ctx.ReadValue<Vector2>();
        if (v != m_rightJoystickValue) { 
            m_airPushMotors.SetPitchDownToTop(-m_rightJoystickValue.y);
            m_airPushMotors.SetYawLeftToRight(m_rightJoystickValue.x);
        }
    }

    private void ContextLeftJoystick(InputAction.CallbackContext ctx)
    {
        Vector2 v = m_leftJoystickValue;
        m_leftJoystickValue = ctx.ReadValue<Vector2>();
        if (v != m_leftJoystickValue)
        { 
            m_combusionMotors.SetMotorPercentLeftSide(m_leftJoystickValue.x);
            m_combusionMotors.SetMotorPercentRightSide(-m_leftJoystickValue.x);
        
            m_combusionMotors.SetMotorPercentLeftTop(-m_leftJoystickValue.y);
            m_combusionMotors.SetMotorPercentRightTop(-m_leftJoystickValue.y);
            m_combusionMotors.SetMotorPercentLeftDown(m_leftJoystickValue.y);
            m_combusionMotors.SetMotorPercentRightDown(m_leftJoystickValue.y);
        }
    }
}


