using UnityEngine;

public class OuterMono_ParticulePercent : MonoBehaviour
{
    [Range(0,1)]
    public float m_percentPower = 0.0f;
    public ParticleSystem m_particleSystem;
    public bool m_useValide;
    public float m_emissionMultiplicator = 1.0f;
    public AnimationCurve m_emissionPerPercent;
    public float m_emissionSizeMulticator=1f;
    public AnimationCurve m_sizePerPercent;

    private void Reset()
    {
        m_particleSystem = GetComponent<ParticleSystem>();
    }
    private void OnValidate()
    {
        if(m_useValide)
        {
            SetEmissionRate(m_percentPower);
        }
    }
    public void SetEmissionRate(double percent)
    {
        m_percentPower =(float) percent;
        if (m_particleSystem != null)
        {
            float rate = m_emissionPerPercent.Evaluate((float)percent)* m_emissionMultiplicator;
            var emission = m_particleSystem.emission;
            emission.rateOverTime = (float)rate; 

            float size= m_sizePerPercent.Evaluate((float)percent)* m_emissionSizeMulticator;
            var main = m_particleSystem.main;
            main.startSize = size;
        }
    }
}
