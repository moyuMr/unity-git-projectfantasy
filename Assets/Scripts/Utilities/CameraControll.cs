using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using Unity.VisualScripting;
using System;

public class CameraControll : MonoBehaviour
{
    private CinemachineConfiner2D confiner2D;
    public CinemachineCollisionImpulseSource impulseSource;
    public voidEventSO cameraShakeEvent;
    private void Awake() {
        confiner2D = GetComponent<CinemachineConfiner2D>();
    }
    private void OnEnable() {
        cameraShakeEvent.OnEventRaised += OnCameraShake;
    }

    private void OnDisable() {
        cameraShakeEvent.OnEventRaised -= OnCameraShake;
        
    }

    private void OnCameraShake()
    {
        impulseSource.GenerateImpulse();
    }

    //TODO场景切换后
    private void Start() {
        GetNewCameraBounds();    
    }
    private void GetNewCameraBounds(){
        var obj = GameObject.FindGameObjectWithTag("CineBounds");
        if (obj == null)
        {
            return;
        }
        confiner2D.m_BoundingShape2D = obj.GetComponent<Collider2D>();
        confiner2D.InvalidateCache();
    }
}
