using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CenterReactorText : MonoBehaviour {

	public GameObject CenterObject;

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
		text.text = (reactor.ReactorMaxHealth - reactor.ReactorDmg).ToString();
		rect.position = Camera.main.WorldToScreenPoint(CenterObject.transform.position);
		rect.rotation = CenterObject.transform.rotation;
	}
}
