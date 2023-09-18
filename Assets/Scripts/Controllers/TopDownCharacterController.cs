using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.XR;

public class TopDownCharacterController : MonoBehaviour
{
    //event �ܺο����� ȣ������ ���ϰ� ���´�.
    //Action : ���߿� ã�ƺ���* �Լ��� ��� => ��ϵ� �Լ��� ��� ȣ��
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;


    private float tiemSinceLastAttack = float.MaxValue;

    //Attack�� ���� ������Ƽ //������Ƽ == ���� | ���������� ��������
    protected bool IsAttacking { get; set; }


    //�̵�
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); // ?. ���� ������ null�� �ƴҶ��� �۵� Invoke == �Լ�ȣ��
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }


    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }

    //�������̵��ؼ� �� �� �ֵ���
    //�ڽ� Ŭ���������� ������Ʈ�� ���� ���ϱ� ����
    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        //������
        if(tiemSinceLastAttack <= 0.2f) //TODO
        {
            tiemSinceLastAttack += Time.deltaTime;
        }

        if(IsAttacking && tiemSinceLastAttack > 0.2f)
        {
            tiemSinceLastAttack = 0;
            CallAttackEvent();
        }
    }
}
