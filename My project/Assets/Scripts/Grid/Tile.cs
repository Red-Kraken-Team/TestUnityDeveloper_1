public class Tile
{    

    public int XKey { get; private set; }
    public int YKey { get; private set; }
    public bool IsFilling { get; private set; }

    #region PUBLIC

    public Tile(int xKey, int yKey, bool isFilling)
    {
        XKey = xKey;
        YKey = yKey;
        IsFilling = isFilling;
    }
    #endregion

    #region PRIVATE

    #endregion
}
