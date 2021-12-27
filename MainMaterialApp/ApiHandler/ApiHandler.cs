using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;


namespace MainMaterialApp.ApiHandler
{
    class ApiHandler
    {
        HttpClient client = new HttpClient();
        public ApiHandler()
        {
            /*client.BaseAddress = new Uri("http://95.111.193.87/");
            client.DefaultRequestHeaders.Add("Token", "757b50e7a32ed9c1cab0ef98549bcbf4dc6227ba");*/

        }
        public dynamic getApi(string apilink)
        {

            HttpResponseMessage response = client.GetAsync(apilink).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {

                return null;
            }

        }

        public dynamic postApi(string apilink, FormUrlEncodedContent formContent)
        {


            var response = client.PostAsync(apilink, formContent).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                return null;
            }

        }
        public dynamic deleteApi(string apilink)
        {


            var response = client.DeleteAsync(apilink).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsStringAsync().Result;
                return result;
            }
            else
            {
                return null;
            }

        }


    }
}
