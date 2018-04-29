using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Text.RegularExpressions;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class buttonanimation : MonoBehaviour, IPointerEnterHandler, ISelectHandler {
	public Text theText;
	public void OnPointerEnter(PointerEventData eventData){
		theText.color = Color.yellow;
	}
	public void OnSelect(BaseEventData eventData){
		theText.color = Color.black;
	}
	public void OnPointerOver(PointerEventData eventData){
		theText.color = Color.white;
	}
	public void OnPointerUp(PointerEventData eventData){
		theText.color = Color.white;
	}
	public void OnPointerDown(PointerEventData eventData){
		theText.color = Color.white;
	}
}
