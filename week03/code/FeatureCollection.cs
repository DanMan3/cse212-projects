using System.Text.Json.Serialization;


public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessary

    public Feature[] Features { get; set; }


}

public class Feature
{
    public Properties Properties { get; set; }
}




public class Properties
{
    public string Place { get; set; }
    [JsonPropertyName("mag")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public decimal? Mag { get; set; }
}





//  [
// 1km NE of Pahala, Hawaii - Mag 2.36,
// 58km NW of Kandrian, Papua New Guinea - Mag 4.5,
// 16km NNW of Truckee, California - Mag 0.7,
// 9km S of Idyllwild, CA - Mag 0.25,
// 14km SW of Searles Valley, CA - Mag 0.36,
// 4km SW of Volcano, Hawaii - Mag 1.99,
// ...
// ]