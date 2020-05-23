using Newtonsoft.Json;

namespace ACNHBot.Application.DataModels.Json
{
    public class Art
    {
        // Search by name = fake
        // Remove 1 from ID, search by that = real

        [JsonProperty("name")] public string Name { get; set; }

        [JsonProperty("genuine")] public bool Genuine { get; set; }

        [JsonProperty("image")] public string Image { get; set; }

        [JsonProperty("sell")] public int SellPrice { get; set; }

        [JsonProperty("realArtworkTitle")] public string RealArtworkTitle { get; set; }

        [JsonProperty("artist")] public string Artist { get; set; }

        [JsonProperty("museumDescription")] public string MuseumDescription { get; set; }

        [JsonProperty("internalId")] public int InternalId { get; set; }


        // {
        //     "name": "string",
        //     "image": "string",
        //     "highResTexture": "string",
        //     "genuine": true,
        //     "category": "string",
        //     "buy": 0,
        //     "sell": 0,
        //     "color1": "string",
        //     "color2": "string",
        //     "size": "string",
        //     "realArtworkTitle": "string",
        //     "artist": "string",
        //     "museumDescription": "string",
        //     "source": [
        //     "string"
        //         ],
        //     "sourceNotes": "string",
        //     "version": "string",
        //     "hhaConcept1": "string",
        //     "hhaConcept2": "string",
        //     "hhaSeries": "string",
        //     "hhaSet": "string",
        //     "interact": true,
        //     "tag": "string",
        //     "speakerType": "string",
        //     "lightingType": "string",
        //     "catalog": "string",
        //     "filename": "string",
        //     "internalID": 0,
        //     "uniqueEntryID": "string"
        // }
    }
}