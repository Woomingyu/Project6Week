using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownCharacterController controller;
    private CharcterStatsHandler _stats;

    private Vector2 movementDirection = Vector2.zero;
    private Rigidbody2D rigidbody;

    private void Awake()
    {
        //�÷��̾�� PlayerInputController�� �ְ� TopDownCharacterController�� �θ�� ����
        //�׷��� �÷��̾���� �������� TopDownCharacterController ȣ�Ⱑ��
        controller = GetComponent<TopDownCharacterController>();
        rigidbody = GetComponent<Rigidbody2D>();
        _stats = GetComponent<CharcterStatsHandler>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move; //OnMoveEvent�� ����(ȣ�� �� ���� �޴� �޼��� �߰�)
        //Ű���� ���� -> PlayerInputController -> �θ��� TopDownCharacterController�� ����
        //TopDownCharacterController�� �����ϰ��ִ� TopDownMovement�� �����
    }

    //���� ó���� ���� ���Ŀ� ȣ��
    private void FixedUpdate()
    {
        ApplyMovment(movementDirection);
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    //���� �̵�
    private void ApplyMovment(Vector2 direction)
    {
        direction = direction * 5 * _stats.CurrentStates.speed;

        //���ӵ��� �޾� rigidbody �̵�
        rigidbody.velocity = direction;
    }
}
