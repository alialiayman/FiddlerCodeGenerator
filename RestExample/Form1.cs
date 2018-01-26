using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;

namespace RestExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RunAll();
        }

        private readonly CookieContainer CookieJar = new CookieContainer();
        public void RunAll()
        {
            GETlogin2();

            var res = POSTlogin4();
            Console.Write(res);
        }

        private string GETlogin2()
        {
            var client = new RestClient("http://app1.babalumra.com/Security/login.aspx ");
            var request = new RestRequest("", Method.GET);
            client.CookieContainer = CookieJar;
            request.AddHeader("Host", "app1.babalumra.com");
            request.AddHeader("Upgrade-Insecure-Requests", "1");
            request.AddHeader("User-Agent", "User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36");
            request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
            request.AddHeader("Referer", "http://app1.babalumra.com/");
            request.AddHeader("Accept-Language", "en-US,en;q=0.9");
            //client.ExecuteAsync<LoginResponse>(request, response =>
            // {
            //  some action here based on response.Data;
            // });
            var response = client.Execute(request);

            return response.Content;
        }


        private string POSTlogin4()
        {
            var client = new RestClient("http://app1.babalumra.com/Security/login.aspx");
            var request = new RestRequest("", Method.POST);
            client.CookieContainer = CookieJar;
            request.AddHeader("Host", "app1.babalumra.com");
            request.AddHeader("Cache-Control", "max-age=0");
            request.AddHeader("Origin", "http://app1.babalumra.com");
            request.AddHeader("Upgrade-Insecure-Requests", "1");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("User-Agent", "User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/63.0.3239.132 Safari/537.36");
            request.AddHeader("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8");
            request.AddHeader("Referer", "http://app1.babalumra.com/Security/login.aspx");
            request.AddHeader("Accept-Language", "en-US,en;q=0.9");
            var srBody = new StringBuilder();
            srBody.Append("ScriptManager1_TSM=%3B%3BSystem.Web.Extensions%2C+Version%3D4.0.0.0%2C+Culture%3Dneutral%2C+PublicKeyToken%3D31bf3856ad364e35%3Aen-US%3Ad28568d3-e53e-4706-928f-3765912b66ca%3Aea597d4b%3Ab25378d2");
            srBody.Append("__EVENTTARGET=");
            srBody.Append("__EVENTARGUMENT=");
            srBody.Append("__VIEWSTATE=%2FwEPaA8FDzhkNTY0ZjgwNTMyMjgyMGTwGJ0cJhZ%2FT3vw4yr%2Fox5APogxuNJRIs4MIpcGnWwJoA%3D%3D");
            srBody.Append("__VIEWSTATEGENERATOR=A0A15FC2");
            srBody.Append("__EVENTVALIDATION=%2FwEdAAfBWJdf89%2BXAhRzr%2FA3HUQ5wq7Fr2euId72M7tGGVWWmtkujToWXoNg%2F%2BRhNc%2FN0HZJ6lrPISnVU8b7H%2FFQSsZepMlBX7INUQFuKH46Yb5wr5ByM%2B%2FsA3HrV5vAaYH7Y95CJRqBRwNy7ryDJ62zNGRJ9kjyivSeyictxat3uTaeGvvJ7odifNLoxeFGXcajGcA%3D");
            srBody.Append("TxtUserName=mardis");
            srBody.Append("TxtPassword=mardis%4039");
            srBody.Append("ddlYear=1439");
            srBody.Append("BtnLogin=Sign+in");
            var body = srBody.ToString();
            request.AddParameter("text/xml", body, ParameterType.RequestBody);
            var response = client.Execute(request);
            return response.Content;
        }








    }
}
