using UnityEngine;

public class OuterMono_AirPressingRotation : AbstractOuterShipPitchRollYawMono
{
    public Transform m_toRotate;
    public float m_rotationSpeedPerSecond = 15f;
    public float m_lerpDelay = 1f;

    [Range(-1f, 1f)] public float m_leftRightRotationWanted = 0;
    [Range(-1f, 1f)] public float m_downUpRotationWanted = 0;
    [Range(-1f, 1f)] public float m_rollLeftRightWanted = 0;

    [Range(-1f, 1f)] public float m_leftRightRotationCurrent;
    [Range(-1f, 1f)] public float m_downUpRotationCurrent;
    [Range(-1f, 1f)] public float m_rollLeftRightCurrent;

    public override void SetPitchDownToTop(float percent)
    {
        m_downUpRotationWanted = percent;
    }

    public override void SetRollLeftToRight(float percent)
    {
        m_rollLeftRightWanted = percent;
    }

    public override void SetYawLeftToRight(float percent)
    {
        m_leftRightRotationWanted = percent;
    }

    void Update()
    {
        if (m_toRotate == null) return;

        float deltaTime = Time.deltaTime;

        // Smoothly interpolate towards the desired rotation values
        m_leftRightRotationCurrent = Mathf.Lerp(m_leftRightRotationCurrent, m_leftRightRotationWanted, m_lerpDelay * deltaTime);
        m_downUpRotationCurrent = Mathf.Lerp(m_downUpRotationCurrent, m_downUpRotationWanted, m_lerpDelay * deltaTime);
        m_rollLeftRightCurrent = Mathf.Lerp(m_rollLeftRightCurrent, m_rollLeftRightWanted, m_lerpDelay * deltaTime);

        // Apply rotation with correct time step
        Vector3 rotationVector = new Vector3(
            -m_downUpRotationCurrent * m_rotationSpeedPerSecond * deltaTime,
            m_leftRightRotationCurrent * m_rotationSpeedPerSecond * deltaTime,
            -m_rollLeftRightCurrent * m_rotationSpeedPerSecond * deltaTime
        );

        m_toRotate.Rotate(rotationVector, Space.Self);
    }
}
