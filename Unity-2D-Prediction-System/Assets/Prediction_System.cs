using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Prediction_System : MonoBehaviour {

    List<GameObject> list_predictions;
   

	public Rigidbody2D rigi;
    private bool pressed = false;
    public GameObject Prediction_Objects;
    Vector2 v;

	[Range(1,250)]
    public int prediction_count = 30;

	public float speed = .3f;

	[Range(1f,10f)]
	public int space=1;

	List<GameObject> list_pooling = new List<GameObject>();

    void Start()
    {
        list_predictions = new List<GameObject>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetMouseButtonDown(0))
        {
            pressed = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            pressed = false;
            rigi.velocity = v;
     		
        }

        if (pressed)
        {
     		for (int i = 0; i < list_predictions.Count; i++)
            {
				list_pooling.Add (list_predictions[i]);
				list_predictions[i].SetActive (false);
            }
            list_predictions.Clear();
            Vector2 mous = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 pos = transform.position; 
            v = (mous - pos)*3f*speed;
          
            Vector2 velocity = v;
            Vector2 position = transform.position;
            float time = 25f / v.magnitude;
            for (int i = 0; i < prediction_count*space; i++)
            {

                velocity *= (1.0f - Time.fixedDeltaTime * rigi.drag * time); // drag
                velocity += Physics2D.gravity * rigi.gravityScale * Time.fixedDeltaTime * time; // gravity
                position += velocity * Time.fixedDeltaTime * time; // move point
				if(i%space != 0)
				{
					continue;
				}
				Create_Prediction(position);
            }
        }
	}

	void Create_Prediction(Vector2 position)
	{	
		GameObject new_predict;
		if (list_pooling.Count > 0) {
		
			new_predict = list_pooling [0];
			new_predict.transform.position = position;
			new_predict.SetActive (true);
			list_pooling.RemoveAt (0);
		} 
		else 
		{
			new_predict = (GameObject)Instantiate(Prediction_Objects,position, Quaternion.identity);
		}
		list_predictions.Add(new_predict);
	}
}
