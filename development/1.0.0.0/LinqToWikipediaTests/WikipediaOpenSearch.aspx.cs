﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LinqToWikipedia;
using System.Text;

namespace LinqToWikipediaTests
{
    public partial class WikipediaOpenSearch : System.Web.UI.Page
    {
        public int DisplayResults 
        { 
            get {return Convert.ToInt32(ddl_results.SelectedValue); }
            set{ ddl_results.SelectedIndex = value;}
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 15; i++)
                ddl_results.Items.Add(new ListItem(i.ToString(), i.ToString()));

            if (!Page.IsPostBack) DisplayResults = 9;
        }

        protected void UpdateDisplayNumber(object sender, EventArgs e)
        {
            DisplayResults = ddl_results.SelectedIndex;
        }

        protected void OpenSearch_TextChanged(object sender, EventArgs e)
        {
            WikipediaContext datacontext = new WikipediaContext();

            var opensearch = (
                from p in datacontext.OpenSearch
                where p.Keyword == tb_OpenSearch.Text
                select p).Take(DisplayResults);

            dl_results.DataSource = opensearch;
            dl_results.DataBind();
        }

        protected string CheckImage(Uri image, Uri jumpurl)
        {
            StringBuilder sb = new StringBuilder();

            if (image != null)
            {
                sb.Append("<td rowspan='2'>");
                sb.Append("<a href='" + jumpurl + "' target='_blank'>");
                sb.Append("<img src='" + image + "' border='0'>");
                sb.Append("</a></td>");

                return sb.ToString();
            }

            return string.Empty;
        }
    }
}
