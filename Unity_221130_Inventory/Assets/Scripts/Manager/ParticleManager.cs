using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    static private ParticleManager _instance;
    public static ParticleManager instance
    {
        get
        {
            if (_instance == null)
            {
                // 이 방법으로 사용하면 하이어라키 창에 DataManager를 넣지 않아도 됨
                GameObject obj = new GameObject("ParticleManager");
                _instance = obj.AddComponent<ParticleManager>();
            }
            return _instance;
        }
    }

    private Dictionary<string, List<GameObject>> totalParticle = new Dictionary<string, List<GameObject>>();
    
    public void CreateParticle()
    {
        AddParticle("EnergyExplosion");
    }

    private void AddParticle(string key, int poolCount = 20)
    {
        GameObject prefab = Resources.Load<GameObject>("Prefabs/Particles/" + key);

        List<GameObject> particles = new List<GameObject>(poolCount);

        for(int i = 0; i < poolCount; i++)
        {
            GameObject particle = Instantiate(prefab, transform);
            particle.SetActive(false);
            particle.name = key + "_" + i;
            particles.Add(particle);
        }

        totalParticle.Add(key, particles);
    }

    public void Play(string key, Vector3 pos, Quaternion rot)
    {
        if (!totalParticle.ContainsKey(key)) return;

        foreach(GameObject particle in totalParticle[key])
        {
            if(!particle.activeSelf)
            {
                particle.SetActive(true);
                particle.transform.position = pos;
                particle.transform.rotation = rot;
                return;
            }
        }
    }


}
