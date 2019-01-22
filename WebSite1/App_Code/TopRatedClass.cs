using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using Newtonsoft.Json;


/// <summary>
/// Summary description for TopRatedClass
/// </summary>
public class TopRatedClass
{
    public class Rootobject
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public Result[] results { get; set; }
    }

    public class Result
    {
        public int vote_count { get; set; }
        public int id { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public string title { get; set; }
        public float popularity { get; set; }
        public string poster_path { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public int[] genre_ids { get; set; }
        public string backdrop_path { get; set; }
        public bool adult { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
    }

    private static T _download_serialized_json_data<T>(string url) where T : new()
    {
        using (var w = new WebClient())
        {
            var json_data = string.Empty;
            try
            {
                json_data = w.DownloadString(url);
            }
            catch (Exception) { }
            return !string.IsNullOrEmpty(json_data) ? JsonConvert.DeserializeObject<T>(json_data) : new T();

        }
    }
    public TopRatedClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}