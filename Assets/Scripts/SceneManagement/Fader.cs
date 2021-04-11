﻿using System.Collections;
using UnityEngine;


namespace RPG.SceneManagement
{
  public class Fader : MonoBehaviour
  {
    CanvasGroup canvasGroup;

    private void Start()
    {
      canvasGroup = GetComponent<CanvasGroup>();
    }

    IEnumerator FadeOutIn()
    {
      yield return FadeOut(3f);
      yield return FadeIn(1f);
    }

    public IEnumerator FadeOut(float time)
    {
      //moving alpha towards 1
      while (canvasGroup.alpha != 1)
      {
        canvasGroup.alpha += Time.deltaTime / time;
        yield return null;
      }
    }

    public IEnumerator FadeIn(float time)
    {
      //moving alpha towards 1
      while (canvasGroup.alpha > 0)
      {
        canvasGroup.alpha -= Time.deltaTime / time;
        yield return null;
      }
    }
  }
}