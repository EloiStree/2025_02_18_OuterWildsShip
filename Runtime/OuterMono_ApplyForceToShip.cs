using System;
using UnityEngine;
using static OuterMono_MotorPowerAndPosition;



public class OuterMono_ApplyForceToShip: MonoBehaviour {

    public OuterMono_MotorPowerAndPosition m_motorPowerAndPosition;


    public float m_leftRightForce = 2;
    public ForceMode m_forceModeSide = ForceMode.Impulse;

    public float m_rotationForce = 2;
    public ForceMode m_forceRotation = ForceMode.Impulse;


    public float m_leftBackForwardForce = 0;
    public float m_rightBackForwardForce = 0;
    public float m_leftRightHorizontalRotation = 0;

    public float m_leftDownTopForce = 0;
    public float m_rightDownTopForce = 0;
    public float m_tiltLeftRightForce = 0;

    public float m_horizontalLeftRightSideForce = 0;

    public float m_quadraForwardForce = 0;
    public float m_quadraUpForce = 0;

    public bool m_useRotation = true;
    public bool m_useVelocity = true;

    public void Update()
    {
        var t = m_motorPowerAndPosition;
        var r = t.m_toAffect;

        m_leftBackForwardForce = t.m_leftBack.m_motorPercentPower + -t.m_leftFront.m_motorPercentPower;
        m_rightBackForwardForce = t.m_rightBack.m_motorPercentPower + -t.m_rightFront.m_motorPercentPower;
        m_leftRightHorizontalRotation= -m_rightBackForwardForce + m_leftBackForwardForce;
        
        if (m_useRotation)
        r.AddRelativeTorque(new Vector3(0, 1, 0) * Time.deltaTime * m_leftRightHorizontalRotation* m_rotationForce, m_forceRotation);

        m_leftDownTopForce = t.m_leftDown.m_motorPercentPower + -t.m_leftTop.m_motorPercentPower;
        m_rightDownTopForce = t.m_rightDown.m_motorPercentPower + -t.m_rightTop.m_motorPercentPower;
        m_tiltLeftRightForce = -m_rightDownTopForce + m_leftDownTopForce;

        if (m_useRotation) 
            r.AddRelativeTorque(new Vector3(0, 0, 1) * Time.deltaTime * m_tiltLeftRightForce * m_rotationForce, m_forceRotation);

        m_horizontalLeftRightSideForce = t.m_leftSide.m_motorPercentPower + -t.m_rightSide.m_motorPercentPower;
        if(m_useVelocity)
            r.AddRelativeForce(new Vector3(1, 0, 0) * Time.deltaTime * m_horizontalLeftRightSideForce * m_leftRightForce, m_forceModeSide);

        m_quadraForwardForce = m_leftBackForwardForce + m_rightBackForwardForce ;
        if (m_useVelocity)
            r.AddRelativeForce(new Vector3(0, 0, 1) * Time.deltaTime * m_quadraForwardForce * m_leftRightForce, m_forceModeSide);

        m_quadraUpForce = m_leftDownTopForce + m_rightDownTopForce;
        if (m_useVelocity)
            r.AddRelativeForce(new Vector3(0, 1, 0) * Time.deltaTime * m_quadraUpForce * m_leftRightForce, m_forceModeSide);

    }


}
