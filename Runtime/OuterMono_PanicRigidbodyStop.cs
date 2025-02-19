using UnityEngine;

public class OuterMono_PanicRigidbodyStop : MonoBehaviour
{
    public Rigidbody m_targetRigidbody;

    [ContextMenu("Stop Velocity")]
    public void StopVelocity() {

        StopLinearVelocity();
        StopRotationVelocity();

    }
    [ContextMenu("Stop Rotation Velocity")]
    public void StopRotationVelocity() { 
    

        if(m_targetRigidbody == null)
        {
            return;
        }
        m_targetRigidbody.angularVelocity= Vector3.zero;
    }
    [ContextMenu("Stop Linear Velocity")]
    public void StopLinearVelocity()
    {
        if (m_targetRigidbody == null)
        {
            return;
        }
        m_targetRigidbody.linearVelocity = Vector3.zero;

    }
}
