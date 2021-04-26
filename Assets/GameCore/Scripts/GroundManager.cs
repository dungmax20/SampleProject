using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundManager : MonoBehaviour
{
    [SerializeField] public float length = 10.42f;
    [SerializeField] public float speed = 3f;
    public List<Transform> ground=new List<Transform>();
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Awake()
    {
        GameStateManager.GameStateChanged += GameStateChanged;
    }
    private void GameStateChanged()
    {
        if (GameStateManager.CurrentState == GameState.Play)
        {
            StopAllCoroutines();
            for(int i = 0; i < ground.Count; i++)
            {
                var newX = -length * 0.5f + i * length;
                var newY=ground[i].position.y;
                ground[i].position = new Vector2(newX, newY);
            }
            StartCoroutine(Movement());
        }
    }
    IEnumerator Movement()
    {
        float timeToMove = length / speed;
        yield return null;
        var wait = new WaitForSeconds(timeToMove);
        while (true)
        {
            yield return wait;
            if(GameStateManager.CurrentState!=GameState.GameOver)
                Swap();
        }
    }

    private void Swap()
    {
        var first = ground[0];
        var last = ground[2];
        ground.RemoveAt(0);
        first.position = last.position + Vector3.right * length;
        ground.Add(first);
    }
}
