using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CenterReactorText : MonoBehaviour {

	public GameObject CenterObject;
    public SpriteRenderer sprite;

    public GameObject leak1, leak2;

    private Text text;
	private ReactorState reactor;
	private RectTransform rect;
    private ParticleEmitter particle1, particle2;

	void Awake()
	{
		rect = GetComponent<RectTransform>();
		text = GetComponent<Text>();
		reactor = FindObjectOfType<ReactorState>();
        /*particle1 = leak1.GetComponent<ParticleEmitter>();
        particle2 = leak2.GetComponent<ParticleEmitter>();*/
    }

	// Update is called once per frame
	void Update () {
        sprite.color = new Color(1, 1f - ((float)reactor.ReactorDmg / (float)reactor.ReactorMaxHealth), 1f - ((float)reactor.ReactorDmg / (float)reactor.ReactorMaxHealth));
        text.text = (reactor.ReactorMaxHealth - reactor.ReactorDmg).ToString();
		rect.position = Camera.main.WorldToScreenPoint(CenterObject.transform.position);
		rect.rotation = CenterObject.transform.rotation;

        /*particle1.maxEmission = reactor.ReactorMaxHealth * 2;
        particle2.maxEmission = reactor.ReactorMaxHealth * 2;*/
    }
}
