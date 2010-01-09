﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LinqToWikipedia;

namespace LinqToWikipediaTests
{
    public partial class WikipediaQuery : System.Web.UI.Page
    {
        public int DisplayResults
        {
            get { return Convert.ToInt32(ddl_results.SelectedValue); }
            set { ddl_results.SelectedIndex = value; }
        }

        public int SkipNumber
        {
            get { return Convert.ToInt32(ddl_skip.SelectedValue); }
            set { ddl_skip.SelectedIndex = value; }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            btn_query.Click += new EventHandler(btn_query_Click);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 50; i++)
                ddl_results.Items.Add(new ListItem(i.ToString(), i.ToString()));

            for (int i = 0; i <= 100; i++)
                ddl_skip.Items.Add(new ListItem(i.ToString(), i.ToString()));

            if (!Page.IsPostBack)
            {
                DisplayResults = 24;
                SkipNumber = 0;
            }
        }

        protected void UpdateDisplayNumber(object sender, EventArgs e)
        {
            DisplayResults = ddl_results.SelectedIndex;
        }

        protected void UpdateSkipNumber(object sender, EventArgs e)
        {
            SkipNumber = ddl_skip.SelectedIndex;
        }

        protected void btn_query_Click(object sender, EventArgs e)
        {
            WikipediaContext datacontext = new WikipediaContext();

            var query = (
                from wikipedia in datacontext.Query
                where
                    wikipedia.Keyword == tb_keyword1.Text &&
                    wikipedia.Keyword == tb_keyword2.Text &&
                    wikipedia.Keyword == tb_keyword3.Text &&
                    wikipedia.Keyword == tb_keyword4.Text &&
                    wikipedia.Keyword == tb_keyword5.Text
                select wikipedia).Skip(SkipNumber).Take(DisplayResults);

            dl_results.DataSource = query;
            dl_results.DataBind();

            foreach (WikipediaQueryResult result in query.Take(1))
                lbl_totalrecords.Text = result.RecordCount.ToString();
        }
    }
}