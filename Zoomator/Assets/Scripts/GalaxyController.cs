using System.Collections;
using UnityEngine;

public class GalaxyController : MonoBehaviour {

	public float myArgs;
	private AnimationCurve curve = new AnimationCurve();
	private ParticleSystem ps;
	void Start () {
		ps = GetComponent<ParticleSystem>();
	}
	
	void Update () {
		var fo = ps.forceOverLifetime;
        fo.enabled = true;
        curve.AddKey(1f, 1f);
        fo.x = new ParticleSystem.MinMaxCurve(myArgs, curve);
	}
}
