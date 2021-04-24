﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG.Core;

namespace RPG.Combat
{

  public class Projectile : MonoBehaviour
  {

    [SerializeField] float speed = 1;
    [SerializeField] bool isHoming = false;
    Health target = null;
    float damage = 0;

    private void Start()
    {
      transform.LookAt(GetAimLocation());
    }

    // Update is called once per frame
    void Update()
    {
      if (target == null) return;
      if (isHoming && !target.IsDead())
      {
        transform.LookAt(GetAimLocation());
      }
      transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    public void SetTarget(Health target, float damage)
    {
      this.target = target;
      this.damage = damage;
    }

    private Vector3 GetAimLocation()
    {
      CapsuleCollider targetCapsule = target.GetComponent<CapsuleCollider>();
      if (targetCapsule == null)
      {
        return target.transform.position;
      }
      return target.transform.position + Vector3.up * targetCapsule.height / 2;
    }

    private void OnTriggerEnter(Collider other)
    {
      Health target = other.GetComponent<Health>();
      if (this.target != target) return;
      if (target.IsDead()) return;
      target.TakeDamage(damage);
      Destroy(gameObject);
    }
  }

}
