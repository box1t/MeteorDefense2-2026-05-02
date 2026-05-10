using UnityEngine;
using System.Collections;

public class MeteorSpawnerPRO : MonoBehaviour
{
    public GameObject meteorPrefab;
    public Transform player;

    public float spawnDistance = 20f;

    public int baseCount = 5;
    public float waveDelay = 2f;

    public int maxMeteors = 15;
    int currentMeteors = 0;

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    IEnumerator SpawnLoop()
    {
        while (true)
        {
            int level = GameManager.Instance != null ? GameManager.Instance.level : 1;

            yield return StartCoroutine(SpawnWave(level));

            yield return new WaitForSeconds(waveDelay);
        }
    }

    IEnumerator SpawnWave(int level)
    {
        int count = baseCount + level * 3;

        int pattern = Random.Range(0, 3);

        if (pattern == 0)
            yield return StartCoroutine(SpawnCone(count, level));
        else if (pattern == 1)
            yield return StartCoroutine(SpawnWall(count, level));
        else
            yield return StartCoroutine(SpawnHole(count, level));
    }

    // =========================
    // 🔥 ВСЕГДА ОТ КОРАБЛЯ (НЕ ОТ КАМЕРЫ)
    // =========================
    Vector3 GetForwardDirection()
    {
        return player.forward;
    }

    Vector3 GetRightDirection()
    {
        return player.right;
    }

    // =========================
    // 🔥 КОНУС (ТОЛЬКО ВПЕРЁД)
    // =========================
    IEnumerator SpawnCone(int count, int level)
    {
        Vector3 forward = GetForwardDirection();
        Vector3 right = GetRightDirection();
        Vector3 up = Vector3.up;

        for (int i = 0; i < count; i++)
        {
            if (currentMeteors >= maxMeteors) yield break;

            Vector3 dir =
                forward
                + right * Random.Range(-0.5f, 0.5f)
                + up * Random.Range(-0.3f, 0.4f);

            dir.Normalize();

            // ❌ не даём появляться сзади
            if (Vector3.Dot(dir, forward) < 0.6f)
            {
                i--;
                continue;
            }

            SpawnMeteor(dir, level);

            yield return new WaitForSeconds(0.12f);
        }
    }

    // =========================
    // 🔥 СТЕНА ПЕРЕД КОРАБЛЁМ
    // =========================
    IEnumerator SpawnWall(int count, int level)
    {
        Vector3 forward = GetForwardDirection();
        Vector3 right = GetRightDirection();

        int width = Mathf.CeilToInt(Mathf.Sqrt(count));

        for (int x = -width; x <= width; x++)
        {
            if (currentMeteors >= maxMeteors) yield break;

            Vector3 offset = right * x * 1.5f;
            Vector3 spawnPos = player.position + forward * spawnDistance + offset;

            SpawnMeteorAtPosition(spawnPos, level);

            yield return new WaitForSeconds(0.05f);
        }
    }

    // =========================
    // 🔥 СТЕНА С ДЫРОЙ
    // =========================
    IEnumerator SpawnHole(int count, int level)
    {
        Vector3 forward = GetForwardDirection();
        Vector3 right = GetRightDirection();

        int width = Mathf.CeilToInt(Mathf.Sqrt(count));
        int holeIndex = Random.Range(-width, width);

        for (int x = -width; x <= width; x++)
        {
            if (currentMeteors >= maxMeteors) yield break;

            if (Mathf.Abs(x - holeIndex) < 2) continue;

            Vector3 offset = right * x * 1.5f;
            Vector3 spawnPos = player.position + forward * spawnDistance + offset;

            SpawnMeteorAtPosition(spawnPos, level);

            yield return new WaitForSeconds(0.05f);
        }
    }

    // =========================
    // 💥 СПАВН ПО НАПРАВЛЕНИЮ
    // =========================
    void SpawnMeteor(Vector3 direction, int level)
    {
        Vector3 spawnPos = player.position + direction * spawnDistance;

        GameObject m = Instantiate(meteorPrefab, spawnPos, Quaternion.identity);

        Rigidbody rb = m.GetComponent<Rigidbody>();

        float speed = Random.Range(3f, 6f) + level * 1.5f;

        rb.linearVelocity = -direction * speed;

        RegisterMeteor(m);
    }

    // =========================
    // 💥 СПАВН В ТОЧКЕ (НЕ В ЦЕНТР)
    // =========================
    void SpawnMeteorAtPosition(Vector3 pos, int level)
    {
        GameObject m = Instantiate(meteorPrefab, pos, Quaternion.identity);

        Rigidbody rb = m.GetComponent<Rigidbody>();

        // 🎯 цель НЕ центр — чтобы не "обтекали"
        Vector3 targetOffset =
            player.position
            + player.right * Random.Range(-2f, 2f)
            + Vector3.up * Random.Range(-1.5f, 1.5f);

        Vector3 dir = (targetOffset - pos).normalized;

        float speed = Random.Range(3f, 6f) + level * 1.5f;

        rb.linearVelocity = dir * speed;

        RegisterMeteor(m);
    }

    // =========================
    // 📊 УЧЁТ
    // =========================
    void RegisterMeteor(GameObject m)
    {
        currentMeteors++;

        Meteor meteor = m.GetComponent<Meteor>();
        if (meteor != null)
            meteor.spawner = this;
    }

    public void MeteorDestroyed()
    {
        currentMeteors--;
    }
}
