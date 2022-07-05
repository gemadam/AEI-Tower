using UnityEngine;

public class Chest : MonoBehaviour
{
    public bool IsOpen = false;
    public Sprite ChestOpenSprite;
    public GameManager GameManager;

    public void Open()
    {
        if (IsOpen)
            return;

        this.GetComponent<SpriteRenderer>().sprite = ChestOpenSprite;

        this.IsOpen = true;

        var r = Random.value;

        if (r < 0.25f)
        {
            GameManager.UIManager.DisplayMessage("You found exam from previous year on the internet... Good for you :)");
            GameManager.ScoreManager.AddMaterials(1);
        }
        else if (r < 0.5f)
        {
            GameManager.UIManager.DisplayMessage("Professor has changed questions on the second term... So unlucky :'(");

            if (GameManager.ScoreManager.Materials > 0)
                GameManager.ScoreManager.AddMaterials(-1);
        }
        else if (r < 0.75f)
        {
            GameManager.UIManager.DisplayMessage("Professor had a good day... Everyone present get 3 :D");

            GameManager.ScoreManager.AddPoints(5);
        }
        else
        {
            GameManager.UIManager.DisplayMessage("Empty chest... Maybe next time...");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            var player = collision.gameObject.GetComponent<Player>();

            GameManager.CollisionManager.OnPlayerCollisionWithChest(this, player);
        }
    }
}
