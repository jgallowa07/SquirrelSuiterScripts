using UnityEngine;

public class WindmillSpinner : MonoBehaviour {
    public GameObject Windmill;
    public int SpinSpeed;

    private void start()
    {

    }

	// Update is called once per frame
	void Update () {
        SpinWindmill(SpinSpeed);
	}
    private void SpinWindmill(int speed)
    {
        Windmill.transform.Rotate(Vector3.right * speed);
    }
}
