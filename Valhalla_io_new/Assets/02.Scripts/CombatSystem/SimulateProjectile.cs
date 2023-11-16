using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulateProjectile : MonoBehaviour
{
    #region Variables
    public class Projectile
    {
        public Vector3 initialPos;
        public Vector3 initialVelocity;
        public float elapsedTime;
        public GameObject effect;
    }

    public GameObject projectilePrefab;
    public float MaxProjectTime = 5;
    public float moveSpeed = 10;

    private Ray ray;
    private RaycastHit hitInfo;

    private List<Projectile> projectileList = new List<Projectile>();
    #endregion Variables

    #region Unity Methods
    private void Update()
    {
        UpdateProjectile(Time.deltaTime);
    }
    #endregion Unity Methods

    #region Main Methods
    public void Fire()
    {
        var projectile = CreateProjectile(transform.position, transform.forward * moveSpeed);
        projectileList.Add(projectile);
    }

    private Vector3 GetPosition(Projectile projectile)
    {
        return (projectile.initialPos) + (projectile.initialVelocity * projectile.elapsedTime);
    }

    private Projectile CreateProjectile(Vector3 position, Vector3 velocity)
    {
        Projectile projectile = new Projectile();
        projectile.initialPos = position;
        projectile.initialVelocity = velocity;
        projectile.elapsedTime = 0;
        projectile.effect = Instantiate(projectilePrefab, position, Quaternion.identity);

        return projectile;
    }

    private void UpdateProjectile(float deltaTime)
    {
        Simulate(deltaTime);
        DestroyProjectile();
    }

    private void Simulate(float deltaTime)
    {
        if (projectileList == null)
            return;
        if (projectileList.Count <= 0)
            return;

        projectileList.ForEach(projectile =>
        {
            Vector3 p0 = GetPosition(projectile);
            projectile.elapsedTime += deltaTime;
            Vector3 p1 = GetPosition(projectile);
            RaycastSegment(p0, p1, projectile);
        });
    }

    private void RaycastSegment(Vector3 start, Vector3 end, Projectile projectile)
    {
        Vector3 dir = (end - start).normalized;
        float distance = Vector3.Distance(start, end);

        ray.origin = start;
        ray.direction = dir;
        
        if(Physics.Raycast(ray, out hitInfo, distance))
        {
            projectile.effect.transform.position = hitInfo.point;
            projectile.elapsedTime = MaxProjectTime;
        }
        else
        {
            projectile.effect.transform.position = end;
        }
    }

    private void DestroyProjectile()
    {
        for (int i = projectileList.Count - 1; i >= 0; i--)
        {
            if(projectileList[i].elapsedTime >= MaxProjectTime)
            {
                Destroy(projectileList[i].effect);
                projectileList.RemoveAt(i);
            }
        }
    }
    #endregion Main Methods
}
