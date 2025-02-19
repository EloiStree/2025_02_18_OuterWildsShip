using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class RelayOuterShipPitchRollYawMono : AbstractOuterShipPitchRollYawMono
{
    public AbstractOuterShipPitchRollYawMono[] m_toRelayTo;

    
    [Range(-1f, 1f)] public float m_leftRightRotationWanted = 0;
    [Range(-1f, 1f)] public float m_downUpRotationWanted = 0;
    [Range(-1f, 1f)] public float m_rollLeftRightWanted = 0;

    public UnityEvent<float> m_onPitchRelayed;
    public UnityEvent<float> m_onRollRelayed;
    public UnityEvent<float> m_onYawRelayed;

    public bool m_useValide = false;
    public void OnValidate()
    {
        if (m_useValide ) {
                SetPitchDownToTop(m_downUpRotationWanted);
                SetRollLeftToRight(m_rollLeftRightWanted);
                SetYawLeftToRight(m_leftRightRotationWanted);
        }
    }
    public override void SetPitchDownToTop(float percent)
    {
        percent = Mathf.Clamp(percent, -1f, 1f);
        foreach (var item in m_toRelayTo)
        {
            item?.SetPitchDownToTop(percent);
        }
        m_onPitchRelayed?.Invoke(percent);
    }

    public override void SetRollLeftToRight(float percent)
    {
        percent = Mathf.Clamp(percent, -1f, 1f);
        foreach (var item in m_toRelayTo)
        {
            item?.SetRollLeftToRight(percent);
        }
        m_onRollRelayed?.Invoke(percent);
    }

    public override void SetYawLeftToRight(float percent)
    {
        percent = Mathf.Clamp(percent, -1f, 1f);
        foreach (var item in m_toRelayTo)
        {
            item?.SetYawLeftToRight(percent);
        }
        m_onYawRelayed?.Invoke(percent);
    }
}


//public class OuterMono_TransformMotorMove {

//    public float m_rotateLeftRight;
//    public float m_tiltLeftRight;
//    public float 
//}