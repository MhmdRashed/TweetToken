using System;
using System.Collections;


namespace TokenTweet
{
    class Program
    {
        static void Main(string[] args)
        {
            string tweet = "Hello @ahmed, do you like #programming? # me and @saad love it. #python #hello_world ";
            TweetToken(tweet);
        }


        public static void TweetToken(string str)
        {
            int i = 0;

            ArrayList mentions = new ArrayList();
            ArrayList hashtags = new ArrayList();

            while (i < str.Length)
            {
                string currentTweet = "";
                if (str[i] == '#')
                {
                    if (str[i+1] != ' ')
                    {
                        i++;
                        int count = 0;
                        while (count < str.Length)
                        {

                            if (Char.IsLetterOrDigit(str[i]) || str[i] == '_')
                            {
                                currentTweet += str[i];
                            }
                            else if (Char.IsWhiteSpace(str[i]))
                            {
                                hashtags.Add(currentTweet);
                                break;
                            }
                            count++;
                            i++;
                        }
                    }
                }
                else if (Char.IsWhiteSpace(str[i]))
                {
                    currentTweet += ' ';
                }

                i++;

            }
            Console.WriteLine("There are {0} hashtags", hashtags.Count);

            foreach (var hash in hashtags)
            {
                Console.WriteLine("#"+ hash);
            }

            foreach (var men in mentions)
            {
                Console.WriteLine("@" + men);
            }


        }

    }
}
