using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public delegate void Hitteable(Enemy e);
    public static Hitteable Hitted;

    public enum STATES { ROAMING, CHASING, ATTACKING, LAST }
    public STATES currentState;
    public float speed;
    public Vector3 direction;
    public Transform target;
    public Vector3 steering;
    public float chasingDistance;
    public float attackingDistance;
    public float timeToAttack;
    public float timerAttack;
    public int damage;
    protected Vector3 velocity;
}
