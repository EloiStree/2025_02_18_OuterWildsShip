using System;
using UnityEngine;

public class OuterMono_FacadeRelayShipMotorPercent : AbstractOuterShipMotorPercentMono {



    [Header("Side")]
    [Range(0,1)] public float m_leftSideMotorPercent = 0.0f;
    [Range(0,1)] public float m_rightSideMotorPercent = 0.0f;

    [Header("Front")]
    [Range(0,1)] public float m_leftFrontMotorPercent = 0.0f;
    [Range(0,1)] public float m_rightFrontMotorPercent = 0.0f;

    [Header("Back")]
    [Range(0,1)] public float m_leftBackMotorPercent = 0.0f;
    [Range(0,1)] public float m_rightBackMotorPercent = 0.0f;

    [Header("Top")]
    [Range(0,1)] public float m_leftTopMotorPercent = 0.0f;
    [Range(0,1)] public float m_rightTopMotorPercent = 0.0f;

    [Header("Down")]
    [Range(0,1)] public float m_leftDownMotorPercent = 0.0f;
    [Range(0,1)] public float m_rightDownMotorPercent = 0.0f;

    [Header("Debug OnValide")]
    public bool m_useValide = false;

    public void OnValidate()
    {
        if (m_useValide)
        {
            SetMotorPercentLeftSide(m_leftSideMotorPercent);
            SetMotorPercentRightSide(m_rightSideMotorPercent);
            SetMotorPercentLeftFront(m_leftFrontMotorPercent);
            SetMotorPercentRightFront(m_rightFrontMotorPercent);
            SetMotorPercentLeftBack(m_leftBackMotorPercent);
            SetMotorPercentRightBack(m_rightBackMotorPercent);
            SetMotorPercentLeftTop(m_leftTopMotorPercent);
            SetMotorPercentRightTop(m_rightTopMotorPercent);
            SetMotorPercentLeftDown(m_leftDownMotorPercent);
            SetMotorPercentRightDown(m_rightDownMotorPercent);
        }
    }


    public AbstractOuterShipMotorPercentMono[] m_toRelayTo;

    public override void SetMotorPercentLeftBack(float percent)
    {
        percent = Mathf.Clamp(percent, 0f, 1f);
        m_leftBackMotorPercent = percent;
        foreach (var item in m_toRelayTo)item?.SetMotorPercentLeftBack(percent);}

    public override void SetMotorPercentLeftDown(float percent)
    {
        percent = Mathf.Clamp(percent, 0f, 1f);
        m_leftDownMotorPercent = percent;
        foreach (var item in m_toRelayTo) item?.SetMotorPercentLeftDown(percent); }

    public override void SetMotorPercentLeftFront(float percent)
    {
        percent = Mathf.Clamp(percent, 0f, 1f);
        m_leftFrontMotorPercent = percent;
        foreach (var item in m_toRelayTo) item?.SetMotorPercentLeftFront(percent); }

    public override void SetMotorPercentLeftSide(float percent)
    {
        percent = Mathf.Clamp(percent, 0f, 1f);
        m_leftSideMotorPercent = percent;
        foreach (var item in m_toRelayTo) item?.SetMotorPercentLeftSide(percent); }

    public override void SetMotorPercentLeftTop(float percent)
    {
        percent = Mathf.Clamp(percent, 0f, 1f);
        m_leftTopMotorPercent = percent;
        foreach (var item in m_toRelayTo) item?.SetMotorPercentLeftTop(percent); }

    public override void SetMotorPercentRightBack(float percent)
    {
        percent = Mathf.Clamp(percent, 0f, 1f);
        m_rightBackMotorPercent = percent;
        foreach (var item in m_toRelayTo) item?.SetMotorPercentRightBack(percent); }

    public override void SetMotorPercentRightDown(float percent)
    {
        percent = Mathf.Clamp(percent, 0f, 1f);
        m_rightDownMotorPercent = percent;
        foreach (var item in m_toRelayTo) item?.SetMotorPercentRightDown(percent); }

    public override void SetMotorPercentRightFront(float percent)
    {
        percent = Mathf.Clamp(percent, 0f, 1f);
        m_rightFrontMotorPercent = percent;
        foreach (var item in m_toRelayTo) item?.SetMotorPercentRightFront(percent); }

    public override void SetMotorPercentRightSide(float percent)
    {
        percent = Mathf.Clamp(percent, 0f, 1f);
        m_rightSideMotorPercent = percent;
        foreach (var item in m_toRelayTo) item?.SetMotorPercentRightSide(percent); }

    public override void SetMotorPercentRightTop(float percent)
    {
        percent = Mathf.Clamp(percent, 0f, 1f);
        m_rightTopMotorPercent = percent;
        foreach (var item in m_toRelayTo) item?.SetMotorPercentRightTop(percent); }

}


//public class OuterMono_TransformMotorMove {

//    public float m_rotateLeftRight;
//    public float m_tiltLeftRight;
//    public float 
//}