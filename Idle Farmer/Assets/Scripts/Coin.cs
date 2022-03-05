public class Coin : Movable
{
    private int _value;
    public int Value => _value;

    public void SetValue(int value)
    {
        _value = value;
    }

    protected override void MoveCompleted()
    {
        base.MoveCompleted();

        FindObjectOfType<Character>().CoinsChage(_value);

        Destroy(gameObject);
    }
}
