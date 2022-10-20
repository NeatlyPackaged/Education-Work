using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class agent : MonoBehaviour
{

    [SerializeField] Transform player;
    private Vector3 target;

    public NavMeshAgent agents;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);
        agents = GetComponentInChildren<NavMeshAgent>();
        agents.updateRotation = false;
        agents.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        agents.SetDestination(player.position);
        Debug.Log("is Moving towards the Player");
    }

    private void OnDisable()
    {
        agents.ResetPath();
    }
}
