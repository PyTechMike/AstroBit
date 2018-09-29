using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParamCube : MonoBehaviour {
	public int _band;
	public float _startScale, _scaleMultiplier;
	public bool isWall;
	Material _material;
	public float colorful;
	private Color realCol = new Color(0, 0, 0);
	private Color blueCol;

	void Start () {
		_material = GetComponent<MeshRenderer> ().materials [0];
	}
	
	void Update () {
		if(!isWall) {
			transform.localScale = new Vector3(transform.localScale.x, (AudioVis._audioBandBuffer[_band] * _scaleMultiplier) + _startScale, transform.localScale.z);
			Color _color = new Color(AudioVis._audioBandBuffer[_band], AudioVis._audioBandBuffer[_band]  + 0.1f, AudioVis._audioBandBuffer[_band] + colorful * 2);
			_material.SetColor("_EmissionColor", _color);
		} 
		if(isWall) {
			// Color _color = new Color(AudioVis.middleAudioBandBuffer, AudioVis.middleAudioBandBuffer  + 0.1f, AudioVis.middleAudioBandBuffer + colorful * 2);
			// _material.SetColor("_EmissionColor", _color);
			if(AudioVis.middleAudioBandBuffer > 0.6f) {
				realCol = Color.Lerp (realCol, new Color(0.870f, 0.090f, 0.090f), 7 * Time.deltaTime);
				_material.SetColor("_EmissionColor", realCol);
			} else if(AudioVis.middleAudioBandBuffer > 0.3f){
				realCol = Color.Lerp (realCol, new Color(0.203f, 0.196f, 0.862f), 7 * Time.deltaTime);
				_material.SetColor("_EmissionColor", realCol);
			} else {
				realCol = Color.Lerp (realCol, new Color(0.47f,0.78f,0.93f), 7 * Time.deltaTime);
				_material.SetColor("_EmissionColor", realCol);
			}
		}
	}
}
