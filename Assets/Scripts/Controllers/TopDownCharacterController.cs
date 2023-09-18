using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.XR;

public class TopDownCharacterController : MonoBehaviour
{
    //event 외부에서는 호출하지 못하게 막는다.
    //Action : 나중에 찾아보기* 함수를 등록 => 등록된 함수가 대신 호출
    public event Action<Vector2> OnMoveEvent;
    public event Action<Vector2> OnLookEvent;
    public event Action OnAttackEvent;


    private float tiemSinceLastAttack = float.MaxValue;

    //Attack에 대한 프로퍼티 //프로퍼티 == 변수 | 접근제한자 설정가능
    protected bool IsAttacking { get; set; }


    //이동
    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction); // ?. 앞의 내용이 null이 아닐때만 작동 Invoke == 함수호출
    }

    public void CallLookEvent(Vector2 direction)
    {
        OnLookEvent?.Invoke(direction);
    }


    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }

    //오버라이드해서 쓸 수 있도록
    //자식 클래스에서도 업데이트를 많이 쓰니까 ㅇㅇ
    protected virtual void Update()
    {
        HandleAttackDelay();
    }

    private void HandleAttackDelay()
    {
        //딜레이
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
