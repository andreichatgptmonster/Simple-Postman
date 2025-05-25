namespace Simple_Postman
{
    class http_client
    {
        public static async Task<string> SendAndGetResponseStatus(string url, string args, string method)
        {
            using HttpClient client = new HttpClient();

            string responseStatus = "";

            try
            {
                HttpResponseMessage response;

                if (method == "GET")
                {
                    if (!string.IsNullOrEmpty(args))
                    {
                        url += (url.Contains("?") ? "&" : "?") + args;
                    }

                    response = await client.GetAsync(url);
                }
                else
                {
                    var content = new StringContent(args ?? "", System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");
                    response = await client.PostAsync(url, content);
                }

                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine("Статус ответа: " + (int)response.StatusCode + " " + response.StatusCode);
                Console.WriteLine("Тело ответа:");
                return responseBody;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Произошла ошибка при выполнении запроса:");
                return ex.Message;
            }
        }
    }
}
