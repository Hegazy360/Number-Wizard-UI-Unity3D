using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public int timesHit;
	public AudioClip crack;
	public Sprite[] hitSprites;
	private LevelManager levelManager;
	public static int breakableCount = 0;	
	private bool isBreakable;
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		//keep track
		if (isBreakable){
		
		breakableCount++;
		}
	timesHit = 0;
	levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnCollisionEnter2D (Collision2D collision)
	{
	
	if (isBreakable)
	{
	HandleHits();
	}
	else {
	
			audio.Play();
	}
		
		
	}
	
	void HandleHits ()
	{
		timesHit++;
		int maxHits= hitSprites.Length + 1;
		if (timesHit >= maxHits)
		{breakableCount--;
		levelManager.BrickDestroyed();
		AudioSource.PlayClipAtPoint (crack,	transform.position);
		Destroy(gameObject);}	
		else 
		{	
			audio.Play();
			LoadSprites();
			
		}
	
	}
	
	void LoadSprites () {
	
	int spriteIndex = timesHit - 1;
		if (hitSprites[spriteIndex]){
	this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
	}
	}
	
	
}
