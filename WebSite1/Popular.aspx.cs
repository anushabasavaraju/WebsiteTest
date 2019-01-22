using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serialization;
using System.Net;
using System.IO;
using System.Data;

public partial class Contact : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
            var client = new RestClient("https://api.themoviedb.org/3/movie/popular?page=2&language=en-US&api_key=a93f2459376ce4775c3a48ab4fb05e05");
            var request = new RestRequest(Method.GET);
            request.AddParameter("undefined", "{}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            BindData(response.Content);
    }
    public void BindData(string json)
    {
        var response = JsonConvert.DeserializeObject<PopularClass.Rootobject>(json.ToString());
        var list = new List<PopularClass.Rootobject> { response };
        DataTable dt = new DataTable();
        dt.Columns.Add("Title",typeof(string));
        dt.Columns.Add("ID", typeof(int));
        foreach (var item in response.results)
        {
            string movietitle = item.title;
            int id = item.id;
            DataRow row = dt.NewRow();
            row[0] = movietitle;
            row[1] = id;
            dt.Rows.Add(row);
        }
        GridView1.DataSource = dt;
        GridView1.DataBind();  
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = GridView1.SelectedRow;
        string selectedPopularMovieid = row.Cells[2].Text;
        Application["populartitleid"] = selectedPopularMovieid.ToString();
        Response.Redirect("PopularDetails.aspx");
    }
}


