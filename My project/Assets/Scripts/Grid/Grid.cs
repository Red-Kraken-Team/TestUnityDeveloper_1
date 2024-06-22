using System.Collections.Generic;

public abstract class Grid 
{
    public List<Tile> CurrentGrid { get; protected set; }

    protected Grid()
    {
        CurrentGrid = new List<Tile>();
    }

    #region PUBLIC
    public abstract void GenerateGrid(GridConfig gridConfig);

     #endregion

    #region PRIVATE

    #endregion
}
