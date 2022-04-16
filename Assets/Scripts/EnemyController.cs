using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Enemy
{
    // In a real game, I'd build out separate controllers for the enemy classes, but this is just a demo
    
    [SerializeField] float moveSpeed = 5.0f;

    // Update is called once per frame
    protected override void Update()
    {
        // Run the Unit.base() function -- mainly to check if out-of-bounds
        base.Update();
        transform.Translate(Vector2.right * direction * Time.deltaTime * moveSpeed);
    }
}
