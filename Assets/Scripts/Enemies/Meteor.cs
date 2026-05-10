using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float speed = 5f;
    Rigidbody rb;
    Transform target;
	public bool isTeleporting = false;
	public MeteorSpawnerPRO spawner;
	public GameObject explosionPrefab;
	public GameObject floatingTextPrefab;
	bool isDestroyed = false;
	
	
	public void DestroyMeteor()
	{
		if (isDestroyed) return;
    	isDestroyed = true;
		if (GameManager.Instance != null)
		    GameManager.Instance.AddDestroyedMeteor();

		// 💥 взрыв
		if (explosionPrefab != null)
		{
		    GameObject explosion = Instantiate(
		        explosionPrefab,
		        transform.position,
		        Quaternion.identity
		    );
		    Destroy(explosion, 1f);
		}
		
		// ➕ всплывающий текст
		Canvas canvas = FindFirstObjectByType<Canvas>();

		if (floatingTextPrefab != null && canvas != null)
		{
			Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);

			GameObject textObj = Instantiate(floatingTextPrefab, canvas.transform);
			textObj.transform.position = screenPos;
		}

		Destroy(gameObject);
	}
	void OnDestroy()
	{
		var spawner = FindFirstObjectByType<MeteorSpawnerPRO>();
		if (spawner != null)
		    spawner.MeteorDestroyed();
	}
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
            target = player.transform;
    }

    void FixedUpdate()
    {
        if (target == null) return;

        Vector3 dir = (target.position - transform.position).normalized;

        rb.AddForce(dir * speed);
    }

    public void Push(Vector3 direction)
    {
        rb.AddForce(direction * 10f, ForceMode.Impulse);
    }
    
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
		    Debug.Log("Попадание!");

		    // просто телепорт игрока в центр
		    collision.transform.position = new Vector3(0, 0.5f, 0);

		    // тряска камеры
		    if (Camera.main != null)
		    {
		        var shake = Camera.main.GetComponent<CameraShake>();
		        if (shake != null)
		            shake.Shake();
		    }
		}
	}
}
