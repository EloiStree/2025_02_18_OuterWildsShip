public class OuterMono_ParticuleAirRotation : AbstractOuterShipPitchRollYawMono
{

    public OuterMono_ParticulePercent m_pitchDown;
    public OuterMono_ParticulePercent m_pitchUp;
    public OuterMono_ParticulePercent m_rollLeft;
    public OuterMono_ParticulePercent m_rollRight;
    public OuterMono_ParticulePercent m_yawLeft;
    public OuterMono_ParticulePercent m_yawRight;

    public override void SetPitchDownToTop(float percent)
    {
        m_pitchDown?.SetEmissionRate(-percent);
        m_pitchUp?.SetEmissionRate(percent);
    }

    public override void SetRollLeftToRight(float percent)
    {
        m_rollLeft?.SetEmissionRate(-percent);
        m_rollRight?.SetEmissionRate(percent);
    }

    public override void SetYawLeftToRight(float percent)
    {
        m_yawLeft?.SetEmissionRate(-percent);
        m_yawRight?.SetEmissionRate(percent);
    }
}


//public class OuterMono_TransformMotorMove {

//    public float m_rotateLeftRight;
//    public float m_tiltLeftRight;
//    public float 
//}