
//程序获取信息的速度很慢，以后学习到优化方法再更新吧
 class Program
    {    
       
        static void Main(string[] args)
        {
         
             //WebClient 提供用于将数据发送到由 URI 标识的资源及从这样的资源接收数据的常用方法。
            WebClient wc = new WebClient();

            StringBuilder result = new StringBuilder ();
            string data = "";
            for (int i = 1; i < 200; i++)
            {
                Uri uri = new Uri("http://XXX.com/GroupClientDetails.aspx?id=" + i);
      
                //由于该URL地址有可能返回错误(id不存在时)，程序会出现异常，所以，下面捕获。
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
                
                //从data中获取到需要的信息
                string name = data.Substring(nameIndex + 9, 8);
                string card = data.Substring(cardIndex + 9, 18);
                string phone = data.Substring(phoneIndex + 7, 11);
                result.Append(name +"  " + card+"  " + phone+"    ");
                
            }
      
      
            //写入文件
            StreamWriter sw = new StreamWriter("file.txt");
            sw.WriteLine(result);

            Console.WriteLine("done!");
            Console.ReadKey();
        }
    }