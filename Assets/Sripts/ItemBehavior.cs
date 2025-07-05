using UnityEngine;

public class ItemBehavior : MonoBehaviour
{
    public GameBehavior GameManager;
    void Start()
    {
        GameManager = GameObject.Find("Game Manager").GetComponent<GameBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 

    private void OnCollisionEnter(Collision collision)
    {
      if(collision.gameObject.name == "Player")
        {
            Destroy(this.transform.gameObject);
            Debug.Log("Item collected");
            GameManager.Items += 1;
        }


    }
}
