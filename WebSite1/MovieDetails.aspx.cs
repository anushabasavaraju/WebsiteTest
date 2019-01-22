using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Newtonsoft.Json;
using RestSharp;

public partial class MovieDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session value taken from previous page.
        if (Application["titleid"] != null)
            TextBox18.Text = Application["titleid"].ToString();
        var movie_id = TextBox18.Text;
        //Connection to Rest API.
        var client = new RestClient("https://api.themoviedb.org/3/movie/"+movie_id+"?api_key=a93f2459376ce4775c3a48ab4fb05e05&language=en-US");
        var request = new RestRequest(Method.GET);
        string json = JsonConvert.SerializeObject(request);
        request.AddParameter("undefined", "{}", ParameterType.RequestBody);
        //Passing movie id as parameter to rest url.
        request.AddParameter("movie_id", movie_id);
        IRestResponse response = client.Execute(request);
        TextBox1.Text = response.Content;
        //Function call to display data on page.
        BindData(response.Content);
    }
    public void BindData(string json)
    {
        //De-serializing json data.
        var response = Newtonsoft.Json.JsonConvert.DeserializeObject<MovieDetailsClass.Rootobject>(json.ToString());
        var list = new List<MovieDetailsClass.Rootobject> { response };
        //Code to display json data on page.
        TextBox1.Text = response.adult.ToString();
        TextBox2.Text = response.adult.ToString();
        TextBox3.Text = response.budget.ToString();
        TextBox4.Text = response.id.ToString();
        TextBox5.Text = response.imdb_id.ToString();
        TextBox6.Text = response.original_language.ToString();
        TextBox7.Text = response.original_title.ToString();
        TextBox8.Text = response.overview.ToString();
        TextBox9.Text = response.popularity.ToString();
        TextBox10.Text = response.release_date.ToString();
        TextBox11.Text = response.revenue.ToString();
        TextBox12.Text = response.runtime.ToString();
        TextBox13.Text = response.status.ToString();
        TextBox14.Text = response.tagline.ToString();
        TextBox15.Text = response.title.ToString();
        TextBox16.Text = response.vote_average.ToString();
        TextBox17.Text = response.vote_count.ToString();
        //Code to display data in a Gridiew.
        DataTable dt = new DataTable();
        dt.Columns.Add("Genre id", typeof(string));
        dt.Columns.Add("Genre Name", typeof(string));
        foreach (var item in response.genres)
        {
            int genreid = item.id;
            string genrename = item.name;
            DataRow row = dt.NewRow();
            row[0] = genreid;
            row[1] = genrename;
            dt.Rows.Add(row);
        } 
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
}