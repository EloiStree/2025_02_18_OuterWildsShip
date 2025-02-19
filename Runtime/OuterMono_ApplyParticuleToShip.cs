using UnityEngine;
using static OuterMono_MotorPowerAndPosition;
//public class OuterMono_TransformMotorMove {

//    public float m_rotateLeftRight;
//    public float m_tiltLeftRight;
//    public float 
//}



public class OuterMono_ApplyParticuleToShip : MonoBehaviour
{

    public OuterMono_MotorPowerAndPosition m_motors;

    private void Update()
    {
        DirtyFindAndApply(m_motors.m_leftBack);
        DirtyFindAndApply(m_motors.m_leftDown);
        DirtyFindAndApply(m_motors.m_leftFront);
        DirtyFindAndApply(m_motors.m_leftSide);
        DirtyFindAndApply(m_motors.m_leftTop);
        DirtyFindAndApply(m_motors.m_rightBack);
        DirtyFindAndApply(m_motors.m_rightDown);
        DirtyFindAndApply(m_motors.m_rightFront);
        DirtyFindAndApply(m_motors.m_rightSide);
        DirtyFindAndApply(m_motors.m_rightTop);
    }

    private void DirtyFindAndApply(MotorToPointForce m_motorInfo)
    {
        var p = m_motorInfo.m_motorPoint.GetComponentsInChildren<OuterMono_ParticulePercent>();
        foreach (var part in p)
        {
            {
                part.SetEmissionRate(m_motorInfo.m_motorPercentPower);
            }
        }
    }
}