﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematics
{
  public class CinematicTrigger : MonoBehaviour
  {
    [SerializeField] bool triggered = false;

    private void OnTriggerEnter(Collider other)
    {
      if (!triggered && other.tag == "Player")
      {
        triggered = true;
        GetComponent<PlayableDirector>().Play();
      }
    }
  }
}