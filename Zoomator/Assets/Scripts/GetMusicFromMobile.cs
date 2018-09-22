using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GetMusicFromMobile : MonoBehaviour {

	private  string curPath;
 	private  List<string> curDirectoryFolderPaths = new List<string>() ;

	private Text folderPath;

	private System.IO.DirectoryInfo MusicFolder;
 	private WWW myClip;
 	public string myPath;
	private AudioSource audioSource;

	void Start () {
		// GetCurDirFolders();
		audioSource = GetComponent<AudioSource>();
		MusicFolder = new System.IO.DirectoryInfo(myPath);
		myClip = new WWW("file://" + MusicFolder.GetFiles()[0].FullName); 
		audioSource.clip = myClip.GetAudioClip(false, false);

		folderPath = GameObject.Find("FolderPath").GetComponent<Text> ();
		folderPath.text = Application.persistentDataPath;
	}
	
	void Update () {
		if (!audioSource.isPlaying && audioSource.clip.isReadyToPlay){
			audioSource.Play();
     	}
	}

	void GetCurDirFolders () {
     	curPath = Directory.GetCurrentDirectory();
     	foreach ( string folderPath in Directory.GetDirectories( curPath )) {
         	try {
             	curDirectoryFolderPaths.Add( folderPath );
         	} catch {
            	Debug.Log(2222);
         	}
    	}
    	// Debug.Log("Found "+curDirectoryFolderPaths.Count.ToString() + " Folder(s) in this Directory ");
 	} 
}
