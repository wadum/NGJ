using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CenterReactorText : MonoBehaviour {

	public GameObject CenterObject;
    public SpriteRenderer sprite;


    private Text text;
	private ReactorState reactor;
	private RectTransform rect;

	void Awake()
	{
		rect = GetComponent<RectTransform>();
		text = GetComponent<Text>();
		reactor = FindObjectOfType<ReactorState>();
      
    }

	// Update is called once per frame
	void Update () {
        sprite.color = new Color(1, 1f - ((float)reactor.ReactorDmg / (float)reactor.ReactorMaxHealth), 1f - ((float)reactor.ReactorDmg / (float)reactor.ReactorMaxHealth));
        text.text = (reactor.ReactorMaxHealth - reactor.ReactorDmg).ToString();
		rect.position = Camera.main.WorldToScreenPoint(CenterObject.transform.position);
		rect.rotation = CenterObject.transform.rotation;

       
    }
}
