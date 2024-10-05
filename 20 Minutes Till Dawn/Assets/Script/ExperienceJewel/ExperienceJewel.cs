using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceJewel : MonoBehaviour
{
    public float Experience { get; private set; }
    public bool MovingToPlayer { get; private set; }
    public float moveSpeed;
    private Transform Player;
    private void Update()
    {
        if (MovingToPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, Player.position, moveSpeed * Time.deltaTime);
        }
    }
    public void SetExperience(float _experience)
    {
        Experience = _experience;
    }
    public void MoveCheck(Transform _player)
    {
        MovingToPlayer = true;
        Player = _player;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            ExperienceControll.instance.AddExperience(Experience);
        }
    }
}
