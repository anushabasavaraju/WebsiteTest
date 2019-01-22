using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization;
using System.Net;



public partial class NowPlaying : Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //Connection to Rest API.
        var client = new RestClient("https://api.themoviedb.org/3/movie/now_playing?page=1&language=en-US&api_key=a93f2459376ce4775c3a48ab4fb05e05");
        var request = new RestRequest(Method.GET);
        string json = JsonConvert.SerializeObject(request);
        request.AddParameter("undefined", "{}", ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);
        //Function call to display data on page.
        BindData(response.Content);
    }


      public void BindData(string json)
        {
            //De-serializing json data.
            var response = Newtonsoft.Json.JsonConvert.DeserializeObject<NowPlayingClass.Rootobject>(json.ToString());
            var list = new List<NowPlayingClass.Rootobject> { response};
            DataTable dt = new DataTable();
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Movie Id", typeof(int));
            foreach (var item in response.results)
               {
                string site = item.title;
                int id = item.id;
                DataRow row = dt.NewRow();
                row[0] = site;
                row[1] = id;
                dt.Rows.Add(row);
                }
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }   
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
          string selectedMovieid =  row.Cells[2].Text;
        //Storing selected movie id in a session variable.
        Application["titleid"] = selectedMovieid.ToString();
         Response.Redirect("MovieDetails.aspx");


       

    }
}


