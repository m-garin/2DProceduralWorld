using ProceduralWorld.Map.Tiles;
using ProceduralWorld.Map.Tiles.Display;
using ProceduralWorld.Map.Tiles.Repository;
using ProceduralWorld.Map.Tiles.Display.All;
using UnityEngine;
using ProceduralWorld.RNG;

namespace ProceduralWorld.Map
{
    /// <summary>
    ///  Класс DrawMap
    ///  Управляет отрисовкой карты
    /// </summary>
    public class DrawMap
    {
        IDisplayMode<ITile> displayMode;
        readonly TileGenerator tileGenerator;
        readonly ITilesRepository tilesRepository;

        /// <summary>
        /// Текущие границы отображаемого мира
        /// </summary>
        RectInt currentBoundary;
        ChunkGenerator chunkGenerator;

        public DrawMap()
        {
            tilesRepository = new RNDRepository(new PerlinNoise());
            tileGenerator = new TileGenerator(tilesRepository)
            {
                SetTilesViewer = new AllDisplay() //можем подменять динамически
            };
            chunkGenerator = new ChunkGenerator(tileGenerator);
            currentBoundary = new RectInt(0, 0, 0, 0);
            chunkGenerator.Add(0,0,0,0); //инициализировали первый 
        }

        /// <summary>
        /// Проверить границы видимости и перерисовать карту
        /// </summary>
        public void Redraw(RectInt newBoundary)
        {
            // количество открытий (сверху, снизу, слева, справа)
            int createOperationCount = 0;
            // количество сокрытий (сверху, снизу, слева, справа)
            int hideOperationCount = 0;
            // если граница стала больше справа, то создаем новые тайлы (планеты), которые должны быть в новой открытой области 
            if (newBoundary.xMax > currentBoundary.xMax)
            {
                chunkGenerator.Add(currentBoundary.xMax + 1, currentBoundary.yMin, newBoundary.xMax, currentBoundary.yMax);
                currentBoundary.xMax = newBoundary.xMax;
                createOperationCount++;
            }
            else
            {
                // если граница стала меньше справа, то скрываем тайлы
                if (currentBoundary.xMax > newBoundary.xMax)
                {
                    chunkGenerator.Remove(newBoundary.xMax + 1, currentBoundary.yMin, currentBoundary.xMax, currentBoundary.yMax);
                    currentBoundary.xMax = newBoundary.xMax;
                    hideOperationCount++;
                }
            }

            // если граница стала больше слева
            if (newBoundary.xMin < currentBoundary.xMin)
            {
                chunkGenerator.Add(newBoundary.xMin, currentBoundary.yMin, currentBoundary.xMin - 1, currentBoundary.yMax);
                currentBoundary.xMin = newBoundary.xMin;
                createOperationCount++;
            }
            else
            {
                // если граница стала меньше слева
                if (currentBoundary.xMin < newBoundary.xMin)
                {
                    chunkGenerator.Remove(currentBoundary.xMin, currentBoundary.yMin, newBoundary.xMin - 1, currentBoundary.yMax);
                    currentBoundary.xMin = newBoundary.xMin;
                    hideOperationCount++;
                }
            }

            // если граница стала больше сверху
            if (newBoundary.yMax > currentBoundary.yMax)
            {
                chunkGenerator.Add(currentBoundary.xMin, currentBoundary.yMax + 1, currentBoundary.xMax, newBoundary.yMax);
                currentBoundary.yMax = newBoundary.yMax;
                createOperationCount++;
            }
            else
            {
                // если граница стала меньше сверху
                if (currentBoundary.yMax > newBoundary.yMax)
                {
                    chunkGenerator.Remove(currentBoundary.xMin, newBoundary.yMax + 1, currentBoundary.xMax, currentBoundary.yMax);
                    currentBoundary.yMax = newBoundary.yMax;
                    hideOperationCount++;
                }
            }

            // если граница стала больше снизу
            if (newBoundary.yMin < currentBoundary.yMin)
            {
                chunkGenerator.Add(currentBoundary.xMin, newBoundary.yMin, currentBoundary.xMax, currentBoundary.yMin - 1);
                currentBoundary.yMin = newBoundary.yMin;
                createOperationCount++;
            }
            else
            {
                // если граница стала меньше снизу
                if (currentBoundary.yMin < newBoundary.yMin)
                {
                    chunkGenerator.Remove(currentBoundary.xMin, currentBoundary.yMin, currentBoundary.xMax, newBoundary.yMin - 1);
                    currentBoundary.yMin = newBoundary.yMin;
                    hideOperationCount++;
                }
            }
        }
    }
}

