using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//�������ͽ� ��ȭ(���ϱ�, ���ϱ�, �����)
public enum StatsChangeType
{
    Add,
    Multiple,
    Override,  
}

//Ŭ���� ����ȭ
[Serializable]
public class CharacterStats // ������ �����θ� ���
{
    public StatsChangeType statsChangeType;
    
    [Range(1, 100)]public int maxHealth;
    [Range(1f, 20f)] public int speed;

    //���� ������(�ʹ� �������� ������ �����Ƿ� ��ũ���ͺ� ob�� ����)
    public AttackSO attackSO;
}
