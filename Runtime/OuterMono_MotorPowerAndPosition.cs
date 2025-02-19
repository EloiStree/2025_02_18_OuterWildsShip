using System;
using UnityEngine;
using UnityEngine.Events;
using static OuterMono_MotorPowerAndPosition;


public interface I_OuterShipPitchRollYaw
{
    public void SetPitchDownToTop(float percent);
    public void SetRollLeftToRight(float percent);
    public void SetYawLeftToRight(float percent);
}

public interface I_OuterShipMotorPercentSet
{ 
    public void SetMotorPercentLeftSide(float percent);
    public void SetMotorPercentRightSide(float percent);

    public void SetMotorPercentLeftFront(float percent);
    public void SetMotorPercentRightFront(float percent);
    
    public void SetMotorPercentLeftBack(float percent);
    public void SetMotorPercentRightBack(float percent);
    
    public void SetMotorPercentLeftTop(float percent);
    public void SetMotorPercentRightTop(float percent);
    
    public void SetMotorPercentLeftDown(float percent);
    public void SetMotorPercentRightDown(float percent);

}

public abstract class AbstractOuterShipPitchRollYawMono : MonoBehaviour, I_OuterShipPitchRollYaw
{
    public abstract void SetPitchDownToTop(float percent);
    public abstract void SetRollLeftToRight(float percent);
    public abstract void SetYawLeftToRight(float percent);
}

public abstract class AbstractOuterShipMotorPercentMono : MonoBehaviour, I_OuterShipMotorPercentSet
{
    public abstract void SetMotorPercentLeftBack(float percent);
    public abstract void SetMotorPercentLeftDown(float percent);
    public abstract void SetMotorPercentLeftFront(float percent);
    public abstract void SetMotorPercentLeftSide(float percent);
    public abstract void SetMotorPercentLeftTop(float percent);
    public abstract void SetMotorPercentRightBack(float percent);
    public abstract void SetMotorPercentRightDown(float percent);
    public abstract void SetMotorPercentRightFront(float percent);
    public abstract void SetMotorPercentRightSide(float percent);
    public abstract void SetMotorPercentRightTop(float percent);
}

public class OuterMono_MotorPowerAndPosition : AbstractOuterShipMotorPercentMono
{
    public Rigidbody m_toAffect;
    public Transform m_centerBetweenMotor;

    [Header("Left")]
    public MotorToPointForce m_leftFront;
    public MotorToPointForce m_leftBack;
    public MotorToPointForce m_leftTop;
    public MotorToPointForce m_leftDown;
    public MotorToPointForce m_leftSide;
    [Header("Right")]
    public MotorToPointForce m_rightFront;
    public MotorToPointForce m_rightBack;
    public MotorToPointForce m_rightTop;
    public MotorToPointForce m_rightDown;
    public MotorToPointForce m_rightSide;

    public override void SetMotorPercentLeftBack(float percent)
    {
        m_leftBack.m_motorPercentPower = percent;
    }

    public override void SetMotorPercentLeftDown(float percent)
    {
        m_leftDown.m_motorPercentPower = percent;
    }

    public override void SetMotorPercentLeftFront(float percent)
    {
        m_leftFront.m_motorPercentPower = percent;
    }

    public override void SetMotorPercentLeftSide(float percent)
    {
        m_leftSide.m_motorPercentPower = percent;
    }

    public override void SetMotorPercentLeftTop(float percent)
    {
        m_leftTop.m_motorPercentPower = percent;
    }

    public override void SetMotorPercentRightBack(float percent)
    {
        m_rightBack.m_motorPercentPower = percent;
    }

    public override void SetMotorPercentRightDown(float percent)
    {
        m_rightDown.m_motorPercentPower = percent;
    }

    public override void SetMotorPercentRightFront(float percent)
    {
        m_rightFront.m_motorPercentPower = percent;
    }

    public override void SetMotorPercentRightSide(float percent)
    {
        m_rightSide.m_motorPercentPower = percent;
    }

    public override void SetMotorPercentRightTop(float percent)
    {
        m_rightTop.m_motorPercentPower = percent;
    }

    [System.Serializable]
    public class MotorToPointForce {

        [Range(0, 1)]
        public float m_motorPercentPower = 0.0f;
        public Transform m_motorPoint;
    }
}


//public class OuterMono_TransformMotorMove {

//    public float m_rotateLeftRight;
//    public float m_tiltLeftRight;
//    public float 
//}