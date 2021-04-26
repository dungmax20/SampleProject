using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeController : MonoBehaviour
{
    [SerializeField] Transform top;
    [SerializeField] Transform bot;
    public void Init(float distance)
    {
        top.localPosition = Vector3.up * distance * 0.5f;
        bot.localPosition = Vector3.down * distance * 0.5f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ScoreManager.instance.AddScore(1);
    }
}
