using GameOfLife_Logic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GameOfLife_Interface
{
    public class OutputFile
    {
        public static void SaveGames(string fileName, List<Game> games)
        {
            var gameStates = new List<Dictionary<string, object>>();

            foreach (Game game in games)
            {
                var gameState = new Dictionary<string, object>()
                {
                    { "width", game.Width },
                    { "height", game.Height },
                    { "board", game.Board },
                    { "AliveCount", game.AliveCount },
                };

                gameStates.Add(gameState);
            }

            var json = JsonConvert.SerializeObject(gameStates);

            using (var writer = new StreamWriter(fileName))
            {
                writer.Write(json);
            }
        }

        public static List<Game> LoadGames(string fileName)
        {
            using (var reader = new StreamReader(fileName))
            {
                var json = reader.ReadToEnd();
                var gameStates = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(json);

                var games = new List<Game>();

                foreach (var gameState in gameStates)
                {
                    var width = Convert.ToInt32(gameState["width"]);
                    var height = Convert.ToInt32(gameState["height"]);
                    var aliveCount = Convert.ToInt32(gameState["AliveCount"]);
                    var boardData = (JArray)gameState["board"];
                    var board = new bool[width, height];

                    for (int i = 0; i < width; i++)
                    {
                        for (int j = 0; j < height; j++)
                        {
                            board[i, j] = (bool)boardData[i][j];
                        }
                    }

                    games.Add(new Game(width, height, board));
                }

                return games;
            }
        }
    }
}
