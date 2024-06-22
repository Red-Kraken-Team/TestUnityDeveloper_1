using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour
{
    [SerializeField] private GridConfig _gridConfig;

    [SerializeField] private GameObject _panelPrefab;

    //вопрос условий прокидывания нужного типа генерации, это костыльно
    private enum GridType { Solid, Random}
    [SerializeField] private GridType _gridType;

    private Grid _grid;

    private List<Tile> CurrentGrid => _grid.CurrentGrid;
    private float Step => _gridConfig.Step;

    private void Start()
    {
        GenerateGridInRunTime();
    }

    #region PUBLIC
    [ContextMenu("Generate")]
	public void GenerateGridInRunTime()
    {
        GetCurentGrid();

        InstantiatePanels();
    }
    #endregion

    #region PRIVATE
    private void GetCurentGrid()
    {
        switch(_gridType)
        {
            case GridType.Solid:
            default:
                _grid = new SolidGrid();
                break;
            case GridType.Random:
                _grid = new RandomGrid();
                break;

        }
        _grid.GenerateGrid(_gridConfig);
    }
    

    private void InstantiatePanels()
    {
        Vector3 firstTilePosition = transform.position;
        foreach(Tile tile in CurrentGrid)
        {
            if (tile.IsFilling == false)
                continue;
            Instantiate(_panelPrefab, GetTilePosition(firstTilePosition, tile), Quaternion.identity).transform.SetParent(transform);
        }
    }

    private Vector3 GetTilePosition(Vector3 startPosition, Tile tile)
    {
        return new Vector3(startPosition.x + tile.XKey * Step, startPosition.y, startPosition.z + tile.YKey*Step);

    }
    #endregion
}
