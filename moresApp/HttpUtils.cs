namespace HTTPUtils
{
    class Response
    {
        public string? content { get; set; }
        public int statusCode { get; set; }
        public string url { get; set; }
    }

    class HttpUtils
    {

        private HttpClient httpClient = new HttpClient();


        private static HttpUtils _instance = null;

        public static HttpUtils instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new HttpUtils();
                }
                return _instance;
            }
        }

        private HttpUtils()
        {

        }


        public async Task<Response> Get(string url)
        {
            int statusCode = 0;
            String? respons = null;
            try
            {
                respons = await httpClient.GetStringAsync(url);
                statusCode = 200;
            }
            catch (HttpRequestException e)
            {
                statusCode = (int)(e.StatusCode ?? 0);
                Console.Error.WriteLine($"Error : {statusCode} ");
            }

            return new Response() { content = respons, statusCode = statusCode, url = url };

        }


    }

}