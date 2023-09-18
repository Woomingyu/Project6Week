using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//스테이터스 변화(더하기, 곱하기, 덮어쓰기)
public enum StatsChangeType
{
    Add,
    Multiple,
    Override,  
}

//클래스 직렬화
[Serializable]
public class CharacterStats // 데이터 단위로만 사용
{
    public StatsChangeType statsChangeType;
    
    [Range(1, 100)]public int maxHealth;
    [Range(1f, 20f)] public int speed;

    //공격 데이터(너무 많아지면 관리가 어려우므로 스크립터블 ob로 관리)
    public AttackSO attackSO;
}
