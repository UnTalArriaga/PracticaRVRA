using UnityEngine;
using UnityEngine.AI;


public class EnemyToPlayer : MonoBehaviour
{
    private NavMeshAgent agent;
    private GameObject Player;
    private Animator animator;
    private float Proximity, P_origen;
    private bool Detect = false, Seguimiento = false, Hit = false, Origen = true, Shoot = false; 
    private Vector3 Position;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        Player = GameObject.Find("Player");
        Position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Proximity = Mathf.Sqrt(Mathf.Pow(Player.transform.position.x - transform.position.x, 2) + Mathf.Pow(Player.transform.position.y - transform.position.y, 2) + Mathf.Pow(Player.transform.position.z - transform.position.z, 2));
        if (Proximity > 15 && Proximity<30 && Origen)//Deteccion del player
        {
            Detect = true;
            animator.SetBool("Detect", Detect);
        }
        if (Proximity<15 && !Seguimiento) //seguimiento del player
        {
            Detect = false;
            Origen = false;
            Seguimiento = true;
            animator.SetBool("Origen", Origen);
            animator.SetBool("Detect", Detect);
            animator.SetBool("Seguimiento", Seguimiento);
            animator.SetFloat("Proximidad", Proximity);
            agent.destination = Player.transform.position;
        }
        if (Proximity < 20 && Seguimiento)
        {
            animator.SetFloat("Proximidad", Proximity); //si es menor a 2, realizara el ataque
            agent.destination = Player.transform.position;
        }

        if (Proximity > 20 && Seguimiento) //regreso al origen (se perdio de alcance al pleyer)
        {
            agent.destination = Position;
            Seguimiento = false;
            animator.SetFloat("Proximidad", Proximity);
            animator.SetBool("Seguimiento", Seguimiento);
        }
        if (!Origen && !Seguimiento) //regresando al punto inicial
        {
            P_origen = Mathf.Sqrt(Mathf.Pow(Position.x - transform.position.x, 2) + Mathf.Pow(Position.y - transform.position.y, 2) + Mathf.Pow(Position.z - transform.position.z, 2));
            if (P_origen < 0.1f)
            {
                Origen = true;
                animator.SetBool("Origen", Origen);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Hit = true;
            animator.SetBool("Hit", Hit);
            agent.isStopped = true;
        }
    }
}
