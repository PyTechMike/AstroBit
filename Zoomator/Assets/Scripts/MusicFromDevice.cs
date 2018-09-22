using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;	

public class MusicFromDevice : MonoBehaviour {
	private System.IO.DirectoryInfo MusicFolder;
 	private WWW myClip;
 	public string myPath;
	private AudioSource audioSource;
	private Text folderCount;
	
	void Start () {
		folderCount = GameObject.Find("folderCount").GetComponent<Text> ();
		audioSource = GetComponent<AudioSource>();
		MusicFolder = new System.IO.DirectoryInfo(myPath);
		myClip = new WWW("file:///" + MusicFolder.GetFiles()[0].FullName);
		// myClip = new WWW(MusicFolder.GetFiles()[0].FullName);
		// myClip = new WWW("/sdcard/" + Android.OS.Environment.DirectoryMusic + "/Video.mp3");  
		audioSource.clip = myClip.GetAudioClip(false, false);
		folderCount.text = "well Done";
	}
	
	void Update () {
		if (!audioSource.isPlaying && audioSource.clip.isReadyToPlay){
			audioSource.Play();
     	}
	}
}
