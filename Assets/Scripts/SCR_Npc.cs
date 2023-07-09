using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_Npc : MonoBehaviour
{
    [Header("NPC Sight")]
    [SerializeField] public float detectionRange = 10f;
    [Tooltip("health value")]
    [Header("NPC abilities")]
    [SerializeField]
    private int maxHealth = 10;
    private int currentHealth;
    [SerializeField]
    private bool fear = false;
    private bool fearJump = false;
    private Animator animator;
    private Rigidbody rb;
    [Header("Emote")]
    public GameObject emote;
    public GameObject jim;

    [Header("Speed")]
    [Tooltip("set a speed setting")]
    [Range(1, 10)]
    public float speed = 5f;

    [Header("Transform Points")]
    [Tooltip("Place transform points here to make them go to it")]
    public Transform[] pathPoints;
    private int currentPointIndex = 0;
    GameObject _bullet;
    int detections;

    private SCR_AudioManager audioManager;

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
        rb = GetComponent<Rigidbody>();
        audioManager = FindObjectOfType<SCR_AudioManager>();
    }

    private void Update()
    {
        NpcBulletDetect();
        DetectBullets();
        MoveAlongPath();

        if (!fear)
        {

        }
        else
        {
            emote.SetActive(true);
            if (!fearJump)
            {
            rb.AddForce(Vector3.up * 100f);
                fearJump = true;
            }
        }
    }

   

    private void MoveAlongPath()
    {
        if (pathPoints.Length == 0)
        {
            Debug.LogWarning("No path points assigned.");
            return;
        }

        Transform currentPoint = pathPoints[currentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, currentPoint.position, speed * Time.deltaTime);

        animator.SetBool("IsIdle", false);


        if (transform.position == currentPoint.position)
        {
            currentPointIndex++;

            if (currentPointIndex >= pathPoints.Length)
            {
                currentPointIndex = 0;
            }
        }
    }

    private void DetectBullets()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, detectionRange);

        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Bullet"))
            {
                fear = true;
            }
        }
    }

    private void GameEnd()
    {
        SCR_GameManager._instance.LevelLoader(0);
    }

    public IEnumerator GameEndSequence()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(0.1f);
        GameEnd();
    }

    void NpcBulletDetect()
    {
        //Cat.SetDestination(Fish.position);

        GameObject _bullet = BulletPool.SharedInstance.GetPooledObject();

        bool npcBeenHit;

        if (detections >= 1) return;

        Vector3 npcToBullet = _bullet.transform.position - transform.position;
        float distbetweenBulletAndNpc = Mathf.Sqrt(npcToBullet.sqrMagnitude);
        npcBeenHit = distbetweenBulletAndNpc <= detectionRange ? true : false;


        if (npcBeenHit)
    
        {
            detections++;
            Debug.Log("hasSensed");
            //end music here
            FMODUnity.RuntimeManager.PlayOneShot("event:/Enemy Death");
            audioManager.bS.StopAndClear(audioManager.musicInstance);
            StartCoroutine(GameEndSequence());
        }


    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        // Implement death logic here, such as playing death animation, disabling the object, etc.
        Destroy(gameObject);
    }
}