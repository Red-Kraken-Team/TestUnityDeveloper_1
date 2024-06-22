public class SolidGrid : Grid
{
    #region PUBLIC
    public override void GenerateGrid(GridConfig gridConfig)
    {
        for (int x = 0; x < gridConfig.XLimits; x++)
        {
            for (int y = 0; y < gridConfig.YLimits; y++)
            {
                CurrentGrid.Add(new Tile(x, y, true));
            }
        }
    }
    #endregion

    #region PRIVATE

    #endregion

}
