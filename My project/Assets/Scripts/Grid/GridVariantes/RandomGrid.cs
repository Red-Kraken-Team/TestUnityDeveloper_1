using UnityEngine;

public class RandomGrid : Grid
{
    public override void GenerateGrid(GridConfig gridConfig)
    {
        for (int x = 0; x < gridConfig.XLimits; x++)
        {
            for (int y = 0; y < gridConfig.YLimits; y++)
            {
                CurrentGrid.Add(new Tile(x, y, GetRandomBool()));
            }
        }
    }

    private bool GetRandomBool()
    {
        return (Random.Range(0, 2) != 0) ? true : false; 
    }
}
