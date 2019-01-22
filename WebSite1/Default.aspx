<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Welcome to the Ultimate Movie goers Guide - MOVIEDB</h1>
        
        <p>This is an ultimate guide for the movie buffs around. It helps you choose and know more about your favourite movie from a collection of movies around the world.</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h3>
                <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/NowPlaying.aspx">Now Playing</asp:HyperLink>
            </h3>
            
        </div>
        <div class="col-md-4">
            <h3>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Popular.aspx">Popular</asp:HyperLink>
            </h3>
            
        </div>
        <div class="col-md-4">
            <h3>
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/TopRated.aspx">Top Rated</asp:HyperLink>
            </h3>
            
        </div>
    
        <div class="col-md-4">
            
                <p>
                This site is still under construction. Inconviniences are regretted.</p>

            
        </div>
    </div>
</asp:Content>
