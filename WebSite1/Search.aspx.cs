using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using RestSharp;

public partial class Search : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Label2.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Label2.Visible = true;
        string moviename = TextBox1.Text;
        var client = new RestClient("https://api.themoviedb.org/3/movie/now_playing?page=1&2&language=en-US&api_key=a93f2459376ce4775c3a48ab4fb05e05");
        var request = new RestRequest(Method.GET);
        string json = JsonConvert.SerializeObject(request);
        request.AddParameter("undefined", "{}", ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);
        BindData(response.Content);
    }

    public void BindData(string json)
    {

        var response = Newtonsoft.Json.JsonConvert.DeserializeObject<NowPlayingClass.Rootobject>(json.ToString());
        var list = new List<NowPlayingClass.Rootobject> { response };
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
}