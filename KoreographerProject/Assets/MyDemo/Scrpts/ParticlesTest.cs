using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class ParticlesTest : MonoBehaviour {
    //TODO:做一个粒子效果
    public string eventID;
    public float particlesPerBeat = 100;//每个节拍的粒子喷出速率

    private ParticleSystem particleSystemCom;

	// Use this for initialization
	void Start () {
        particleSystemCom = GetComponent<ParticleSystem>();
        Koreographer.Instance.RegisterForEvents(eventID, CreateParticle);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void CreateParticle(KoreographyEvent koreographyEvent)//产生粒子
    {
        int particleCount=(int)(Koreographer.GetBeatTimeDelta()*particlesPerBeat);//产生粒子的数量
        particleSystemCom.Emit(particleCount);
    }
}
